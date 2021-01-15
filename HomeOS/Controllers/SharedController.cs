using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeOS.Controllers
{
    public class SharedController : Controller
    {
        public IActionResult CheckForCookie() //This checks if there is no cookie. It takes them to screen where they can add device or override existing one with the GUID
        {
            var GUID = ClientCookieHandler.GetUUID(Response, Request);

            var clientCookie = new ClientCookie();
            clientCookie.GUID = GUID;
            clientCookie.IsNewClient = ClientCookieHandler.IsNewClient(GUID);

            var clientScreenInterface = BusinessImplementation.SaveFile.SaveFileModelObject.GetScreenInterfaceByClientGUID(GUID);

            clientCookie.HasScreenInterfaceDevice = (clientScreenInterface != null);

            return Json(clientCookie);
        }

        public class ClientCookie
        {
            public string GUID { get; set; }
            public bool IsNewClient { get; set; }
            public bool HasScreenInterfaceDevice { get; set; }
        }

        public IActionResult GetAllAreas()
        {
            return Json(BusinessImplementation.SaveFile.SaveFileModelObject.Areas);
        }
    }
}
