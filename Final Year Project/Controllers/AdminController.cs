using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using FinalYearProject.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Final_Year_Project.Controllers
{
    public class AdminController : Controller

    {
        private USKTContext ORM = null;
        private IHostingEnvironment ENV = null;

        public AdminController(USKTContext ORM , IHostingEnvironment ENV)
        {
            this.ORM = ORM;
            this.ENV = ENV;
        }
        public IActionResult AdminPage()
        {
            return View();
        }

        //Login Page
        [HttpGet]
        public IActionResult LoginPage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LoginPage(Registeration R)
        {
            Registeration LU = ORM.Registeration.Where(m => m.Email == R.Email && m.Password == R.Password).FirstOrDefault<Registeration>();
            if (LU == null)
            {
                ViewBag.Message = "Invalid UserName Or Password";
                 return View();
            }
            HttpContext.Session.SetString("LIUID", LU.Id.ToString());
            Response.Cookies.Append("LIUID", DateTime.Now.ToString());

            return RedirectToAction("First", "FirstPage");
        }

        //Registration Page
        [HttpGet]
        public IActionResult RegisterPage()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RegisterPage(Registeration R)
        {
         var UserWithSameEmail = ORM.Registeration.Where(m => m.Email == R.Email).FirstOrDefault();
            if (ModelState.IsValid)
            {
                if (UserWithSameEmail == null)
                {

                    ORM.Registeration.Add(R);
                    ORM.SaveChanges();

                    MailMessage Obj = new MailMessage();
                    Obj.From = new MailAddress("meharsalman073@gmail.com");
                    Obj.To.Add(new MailAddress(R.Email));
                    Obj.Subject = "Welcome to theta Solution:";
                    Obj.Body = "Dear" + "" + "Mr " + " " + R.FirstName + "<br ><br >" +
                    "Well Come to Online Product Price Comparison " + "<br><br>" +
                    "Reguards OPPC Team...";
                    Obj.IsBodyHtml = true;


                    //


                    //

                    SmtpClient SMTP = new SmtpClient();
                    SMTP.Host = "smtp.gmail.com";
                    SMTP.Port = 587;
                    SMTP.EnableSsl = true;
                    SMTP.Credentials = new System.Net.NetworkCredential("meharsalman073@gmail.com", "salman123");

                    try
                    {
                        SMTP.Send(Obj);
                    }
                    catch (Exception)
                    {
                        ViewBag.Message = "Mail has sent successfully";
                    }


                    ViewBag.Message = "You are signed in now";
                    return View();
                }
                ViewBag.Message = "Registration Done";
                return RedirectToAction("FirstPage");



            }
            else
            {
                ViewBag.Message = "User with this Email Already Exist";
                return View("SignUp");
            }
        }
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
        [HttpGet]
        public IActionResult AddFaculty()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddFaculty(FacultyProfile F,IFormFile Picture)
        {

            string FilePath = ENV.WebRootPath + "/WebData/FacultyPic/";
            string FileName = Guid.NewGuid().ToString();
            string FileExtension=Path.GetExtension(Picture.FileName);
            FileStream FS = new FileStream(FileName + FileExtension + FilePath, FileMode.Create);
            Picture.CopyTo(FS);
            FS.Close();
            F.ProfilePicture = FilePath;
            ORM.FacultyProfile.Add(F);
            ORM.SaveChanges();
            ViewBag.Message = "Faculty Member Added Successfuly";
            return View();
        }
        [HttpGet]
        public IActionResult AllFaculty()
        {
            IList<FacultyProfile>FacultyProfile = ORM.FacultyProfile.ToList<FacultyProfile>();
            return View(FacultyProfile);
        }
        [HttpPost]
        public IActionResult AllFaculty(String SearchByName, String SearchByDept)
        {
            IList<FacultyProfile> FacultyProfile = ORM.FacultyProfile.Where(m => m.FirstName.Contains(SearchByName) || m.Department.Contains(SearchByDept)).ToList<FacultyProfile>();
            return View(FacultyProfile);
        }
        
        public IActionResult FacultyDetail(int Id)
        {
            FacultyProfile F = ORM.FacultyProfile.Where(m => m.Id == Id).FirstOrDefault<FacultyProfile>();
            return View(F);
        }
         public IActionResult DeleteStudent(FacultyProfile F)
        {
            ORM.FacultyProfile.Remove(F);
            ORM.SaveChanges();
            return RedirectToAction("AllFaculty");
        }

    }
}