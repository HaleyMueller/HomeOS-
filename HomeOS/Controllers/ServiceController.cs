using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeOS.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            var model = new Models.ServicesModel()
            {
                Services = BusinessImplementation.SaveFile.SaveFileModelObject.Services
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Save([FromBody]List<Service> services)
        {
            foreach (var service in services) {
                var check = BusinessImplementation.SaveFile.SaveFileModelObject.Services.Where(x => x.Name == service.name).FirstOrDefault();

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
                                if (property.propertyValue == "on")
                                {
                                    setValue = true;
                                }
                                else if (property.propertyValue == "off")
                                {
                                    setValue = false;
                                }
                                else
                                {
                                    if (checkIfHasProperty.PropertyType == typeof(bool?))
                                    {
                                        setValue = null;
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

        public class Service
        {
            public string name { get; set; }

            public List<KeyValue> properties { get; set; } = new List<KeyValue>();

            public class KeyValue
            {
                public string propertyName { get; set; }
                public string propertyValue { get; set; }
            }
        }
    }
}
