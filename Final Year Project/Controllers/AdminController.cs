using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Final_Year_Project.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult AdminPage()
        {
            return View();
        }

        //Login Page
        public IActionResult LoginPage()
        {
            return View();
        }

        //Registration Page
        public IActionResult RegisterPage()
        {
            return View();
        }
    }
}