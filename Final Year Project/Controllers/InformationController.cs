using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Final_Year_Project.Controllers
{
    public class InformationController : Controller
    {
        public IActionResult about_us()
        {
            return View();
        }
        public IActionResult Transport()
        {
            return View();
        }
        public IActionResult FAQS()
        {
            return View();
        }
        public IActionResult Safety()
        {
            return View();
        }
        public IActionResult ITCenter()
        {
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }
        public IActionResult LABs()
        {
            return View();

        }
        public IActionResult Hostel()
        {
            return View();
        }
    }
}