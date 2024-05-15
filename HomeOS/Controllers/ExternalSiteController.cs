using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeOS.Controllers
{
    public class ExternalSiteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
