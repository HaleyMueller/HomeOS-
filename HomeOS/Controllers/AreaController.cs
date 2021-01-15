using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeOS.Controllers
{
    public class AreaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Save([FromBody]AreaSaveModel model)
        {
            var check = BusinessImplementation.SaveFile.SaveFileModelObject.Areas.Where(x => x.GUID.ToUpper() == model.guid.ToUpper()).FirstOrDefault();

            if (check == null)
            {
                var area = new BusinessImplementation.Area();
                area.Name = model.name;
                area.GUID = Guid.NewGuid().ToString();

                BusinessImplementation.SaveFile.SaveFileModelObject.AddArea(area);
                BusinessImplementation.SaveFile.SaveFileToSystem();

                return Json(true);
            }
            else
            {
                //Already has name todo

                return Json(false);
            }
        }

        public class AreaSaveModel
        {
            public string guid { get; set; }
            public string name { get; set; }
        }

        public IActionResult Edit(string name)
        {
            if (string.IsNullOrEmpty(name))
                name = "";

            var model = new EditModel();

            var check = BusinessImplementation.SaveFile.SaveFileModelObject.Areas.Where(x => x.Name.ToUpper() == name.ToUpper()).FirstOrDefault();

            if (check == null)
            {
                check = new BusinessImplementation.Area();
            }

            model.Area = check;

            return PartialView("_Edit", model);
        }

        public class EditModel
        {
            public BusinessImplementation.Area Area { get; set; }
        }
    }
}
