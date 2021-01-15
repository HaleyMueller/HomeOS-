using HomeOS.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeOS.Controllers
{
    public class BarcodeController : Controller
    {
        public IActionResult Capture()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ScanBarcode([FromBody]ImageModel imageModel)
        {
            var ret = "";

            var base64 = imageModel.Base64.Split(',')[1];

            BusinessImplementation.BarCode barCodeBLL = new BusinessImplementation.BarCode();
            ret = barCodeBLL.GetDataFromBase64(base64);

            return Json(ret);
        }
    }
}
