using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeOS.Controllers
{
    public class ClientController : Controller
    {
        [HttpGet]
        public IActionResult GetInfo() //Eventually make a javascript wrapper that can recieve client info and parse out the data entity instead of just custom fields
        {
            var model = new ClientInfo();

            var identifier = ClientCookieHandler.GetUUID(Response, Request);

            var getClientSetting = BusinessImplementation.SaveFile.SaveFileModelObject.ClientSettings.Where(x => x.Identifier_IP == identifier).FirstOrDefault();

            var timeOutInMins = 1;

            if (getClientSetting != null)
            {
                var awaySetting = getClientSetting.GetClientSetting(BusinessImplementation.ClientSetting.ClientSettingTypes.Away);
                if (awaySetting != null)
                {
                    var obj = (BusinessImplementation.ClientSetting.AwaySetting)awaySetting;

                    timeOutInMins = obj.AFKTime;
                    model.ShowDate = obj.DisplayDate;
                    model.ShowTime = obj.DisplayTime;
                }
            }

            model.Identifier = identifier;
            model.TimeOutInMins = timeOutInMins;

            var clientScreenInterface = BusinessImplementation.SaveFile.SaveFileModelObject.GetScreenInterfaceByClientGUID(identifier);

            if (clientScreenInterface != null)
                model.DeviceName = clientScreenInterface.Name;

            return Json(model);
        }

        public class ClientInfo //TODO show just raw file client settings and let javascript figure it out
        {
            public string Identifier { get; set; }
            public int TimeOutInMins { get; set; }
            public bool ShowTime { get; set; }
            public bool ShowDate { get; set; }
            public string DeviceName { get; set; }
        }

        public IActionResult Index()
        {
            var identifier = ClientCookieHandler.GetUUID(Response, Request);

            var getClientSetting = BusinessImplementation.SaveFile.SaveFileModelObject.ClientSettings.Where(x => x.Identifier_IP == identifier).FirstOrDefault();

            if (getClientSetting == null)
            {
                getClientSetting = new BusinessImplementation.ClientSettings();
                getClientSetting.Identifier_IP = identifier;
                getClientSetting.Settings = getClientSetting.GetDefaultSettings();
            }

            return View(getClientSetting);
        }



        [HttpPost]
        public IActionResult Save([FromBody] List<Models.SaveServiceModel> services)
        {
            var identifier = ClientCookieHandler.GetUUID(Response, Request);

            var getClientSetting = BusinessImplementation.SaveFile.SaveFileModelObject.ClientSettings.Where(x => x.Identifier_IP == identifier).FirstOrDefault();

            if (getClientSetting == null)
            {
                getClientSetting = new BusinessImplementation.ClientSettings();
                getClientSetting.Identifier_IP = identifier;
                getClientSetting.Settings = getClientSetting.GetDefaultSettings();

                BusinessImplementation.SaveFile.SaveFileModelObject.ClientSettings.Add(getClientSetting);
            }

            foreach (var service in services)
            {
                var check = getClientSetting.Settings.Where(x => x.Name == service.name).FirstOrDefault();

                if (check != null)
                {
                    var properties = check.GetType().GetProperties();

                    foreach (var property in service.properties) //Loop through all client side properties to update server ram
                    {
                        var checkIfHasProperty = properties.Where(x => x.Name == property.propertyName).FirstOrDefault();

                        if (checkIfHasProperty != null)
                        {
                            dynamic setValue = property.propertyValue;

                            //Parsing for non string values
                            #region bool?

                            if (checkIfHasProperty.PropertyType == typeof(bool) || checkIfHasProperty.PropertyType == typeof(bool?))
                            {
                                if (property.propertyValue == "on" || property.propertyValue == "true")
                                {
                                    setValue = true;
                                }
                                else if (property.propertyValue == "off" || property.propertyValue == "false")
                                {
                                    setValue = false;
                                }
                                else
                                {
                                    if (checkIfHasProperty.PropertyType == typeof(bool?))
                                    {
                                        setValue = null;
                                    }
                                    else
                                    {
                                        setValue = false;
                                    }
                                }
                            }

                            #endregion

                            #region int?

                            if (checkIfHasProperty.PropertyType == typeof(int) || checkIfHasProperty.PropertyType == typeof(int?))
                            {
                                int val = 0;

                                if (int.TryParse(setValue, out val))
                                {
                                    setValue = val;
                                }
                                else
                                {
                                    if (checkIfHasProperty.PropertyType == typeof(int?))
                                    {
                                        setValue = null;
                                    }
                                    else
                                    {
                                        throw new Exception("Value isn't an integer");
                                    }
                                }
                            }

                            #endregion

                            try
                            {
                                checkIfHasProperty.SetValue(check, setValue);
                            }
                            catch (Exception e)
                            {
                                var s = 1;
                            }
                        }
                    }
                }
            }

            BusinessImplementation.SaveFile.SaveFileToSystem();

            var model = new Models.ServicesModel()
            {
                Services = BusinessImplementation.SaveFile.SaveFileModelObject.Services
            };

            return Json(model);
        }
    }
}
