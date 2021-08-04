using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz_App.Areas.Main.Controllers
{
  [Area("Main")]
    public class welcomeController : Controller
    {
        public IActionResult welcome()
        {
            return View();
        }
    }
}
