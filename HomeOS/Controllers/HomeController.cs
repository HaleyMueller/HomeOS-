using HomeOS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HomeOS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index() //Eventualy do dynamic cards and stuff on this page so make a new object for each type of cards such as graphs, pi chart, status cards, percentage bars
        {
            var piHoleQueries = Pi_Hole.API.GetAllQueries();
            var piHoleLastBlockedDomain = Pi_Hole.API.GetLastBlockedDomain();
            var piHoleTopItems = Pi_Hole.API.GetTopItems();
            var piStatus = Pi_Hole.API.GetSummaryRaw();

            var model = new Models.HomeIndexModel();
            model.AllQueries = piHoleQueries;
            model.LastBlockedDomain = piHoleLastBlockedDomain;
            model.TopItems = piHoleTopItems;
            model.Enabled = piStatus.status == "enabled" ? true : false; //Todo use websocket to do site wide updates without ajax requests

            return View(model);
        }

        public IActionResult Away()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ErrorRedirect(int? errorCode)
        {
            return View(new ErrorRedirectModel { ErrorNumber = errorCode });
        }

        [HttpPost]
        public IActionResult ChangePiHoleStatus([FromBody]Models.ChangePiHoleStatusModel model)
        {
            string response;

            if (model.enable)
            {
                response = Pi_Hole.API.Enable().status;
            }
            else
            {
                response = Pi_Hole.API.Disable().status;
            }

            return Json(response);
        }
    }
}
