using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeOS.Controllers
{
    public class DeviceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddScreenInterface()
        {
            List<BusinessImplementation.ScreenInterface> screenInterfaces = new List<BusinessImplementation.ScreenInterface>();

            foreach (var device in BusinessImplementation.SaveFile.SaveFileModelObject.Devices)
            {
                if (device is BusinessImplementation.ScreenInterface)
                {
                    screenInterfaces.Add((BusinessImplementation.ScreenInterface)device);
                }
            }

            Models.AddToAreaModel model = new Models.AddToAreaModel();
            model.Areas = BusinessImplementation.SaveFile.SaveFileModelObject.Areas;
            model.ClientGUID = ClientCookieHandler.GetUUID(Response, Request);
            model.ScreenInterfaces = screenInterfaces;

            return View(model);
        }

        [HttpPost]
        public IActionResult SaveScreenInterface([FromBody] Models.SaveScreenInterfaceModel model)
        {
            var check = BusinessImplementation.SaveFile.SaveFileModelObject.Areas.Where(x => x.GUID.ToUpper() == model.areaGUID.ToUpper()).FirstOrDefault();

            if (check == null)
            {
                return StatusCode(501);
            }
            else
            {
                var identifier = ClientCookieHandler.GetUUID(Response, Request);

                if (model.overwriteDevice)
                {
                    var check2 = BusinessImplementation.SaveFile.SaveFileModelObject.Devices.Where(x => x.GUID.ToUpper() == model.deviceGUID.ToUpper()).FirstOrDefault();

                    if (check2 != null)
                    {
                        if (check2 is BusinessImplementation.ScreenInterface)
                        {
                            var screen = (BusinessImplementation.ScreenInterface)check2;

                            screen.ClientGUID = identifier;

                            BusinessImplementation.SaveFile.SaveFileToSystem();
                        }
                    }
                }
                else
                {
                    var newDevice = new BusinessImplementation.ScreenInterface();
                    newDevice.ClientGUID = identifier;
                    newDevice.GUID = Guid.NewGuid().ToString(); //Get this from hidden? or drop down if overwritting existing
                    newDevice.DeviceInfo = "Web display";
                    newDevice.UIIconClass = "fas fa-desktop";
                    newDevice.Name = model.txtDeviceName; //textbox on ui
                    newDevice.AreaGUID = check.GUID;

                    BusinessImplementation.SaveFile.SaveFileModelObject.AddDevice(newDevice);

                    var getClientSetting = BusinessImplementation.SaveFile.SaveFileModelObject.ClientSettings.Where(x => x.Identifier_IP == identifier).FirstOrDefault();

                    if (getClientSetting == null)
                    {
                        getClientSetting = new BusinessImplementation.ClientSettings();
                        getClientSetting.Identifier_IP = identifier;
                        getClientSetting.Settings = getClientSetting.GetDefaultSettings();

                        BusinessImplementation.SaveFile.SaveFileModelObject.ClientSettings.Add(getClientSetting);
                    }

                    BusinessImplementation.SaveFile.SaveFileToSystem();
                }
            }

            return Json(true);
        }
    }
}
