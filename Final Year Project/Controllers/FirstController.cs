using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Final_Year_Project.Controllers
{
    public class FirstController : Controller
    {
        public IActionResult FirstPage()
        {
            return View();
        }
        public IActionResult AddFaculty()
        {
            return View();
        }
    }
}