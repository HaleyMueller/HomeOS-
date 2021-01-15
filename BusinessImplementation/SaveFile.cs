using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BusinessImplementation
{
    public static class SaveFile
    {
        public static SaveFileModel SaveFileModelObject = new SaveFileModel();

        private static Newtonsoft.Json.JsonSerializerSettings JsonSettings = new Newtonsoft.Json.JsonSerializerSettings()
        {
            TypeNameHandling = Newtonsoft.Json.TypeNameHandling.All
        };

        public static void LoadFileFromSystem()
        {
            var applicationDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            //This is where you add new services
            SaveFileModelObject.AddService(new Service.PiHole());

            SaveFileModelObject.ClientSettings.Add(new ClientSettings());
            SaveFileModelObject.ClientSettings.ForEach(x => x.GetDefaultSettings().ForEach(y => x.AddClientSetting(y)));

            SaveFileModelObject.AddAreas(new List<Area>() { 
                new Area() { GUID = Guid.NewGuid().ToString(), Name = "Living Room" },
                new Area() { GUID = Guid.NewGuid().ToString(), Name = "Kitchen" },
                new Area() { GUID = Guid.NewGuid().ToString(), Name = "Hallway" },
                new Area() { GUID = Guid.NewGuid().ToString(), Name = "Office" },
                new Area() { GUID = Guid.NewGuid().ToString(), Name = "Guest Bedroom" },
                new Area() { GUID = Guid.NewGuid().ToString(), Name = "Master Bedroom" }
            });

            var filePath = System.IO.Path.Combine(applicationDirectory, "settings.json");

            if (!File.Exists(filePath))
            {
                SaveFileToSystem();
            }

            var content = "";

            using (StreamReader sr = new StreamReader(filePath))
            {
                content = sr.ReadToEnd();
            }

            if (string.IsNullOrEmpty(content) == false)
            {
                var tempSaveFileModelObject = Newtonsoft.Json.JsonConvert.DeserializeObject<SaveFileModel>(content, JsonSettings);

                foreach (var service in SaveFileModelObject.Services) //This adds the new services to the exisiting file data
                {
                    tempSaveFileModelObject.AddService(service);
                }

                foreach (var client in SaveFileModelObject.ClientSettings)
                {
                    foreach (var clientSetting in client.Settings)
                    {
                        tempSaveFileModelObject.ClientSettings.ForEach(x => x.AddClientSetting(clientSetting));
                    }
                }

                SaveFileModelObject = tempSaveFileModelObject;

                foreach (var service in SaveFileModelObject.Services)
                {
                    service.LoadConfig();
                }
            }

            SaveFileToSystem();
        }

        public static void SaveFileToSystem()
        {
            var applicationDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            var filePath = System.IO.Path.Combine(applicationDirectory, "settings.json");

            var ceral = Newtonsoft.Json.JsonConvert.SerializeObject(SaveFileModelObject, Newtonsoft.Json.Formatting.Indented, JsonSettings);

            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(filePath))
            {
                sw.Write(ceral);
            }
        }

        public class SaveFileModel
        {
            public List<Service> Services { get; set; } = new List<Service>();
            public List<ClientSettings> ClientSettings { get; set; } = new List<ClientSettings>();
            public List<Area> Areas { get; set; } = new List<Area>();
            public List<Device> Devices { get; set; } = new List<Device>();

            public void AddService(Service service)
            {
                if (Services.Any(x => x.GetType() == service.GetType()) == false)
                {
                    Services.Add(service);
                }
            }

            public void AddDevice(Device device)
            {
                if (Devices.Any(x => x.GUID == device.GUID) == false)
                {
                    Devices.Add(device);
                }
            }

            public ScreenInterface GetScreenInterfaceByClientGUID(string clientGUID)
            {
                List<BusinessImplementation.ScreenInterface> screenInterfaces = new List<BusinessImplementation.ScreenInterface>();

                foreach (var device in BusinessImplementation.SaveFile.SaveFileModelObject.Devices)
                {
                    if (device is BusinessImplementation.ScreenInterface)
                    {
                        screenInterfaces.Add((BusinessImplementation.ScreenInterface)device);
                    }
                }

                return screenInterfaces.Where(x => x.ClientGUID == clientGUID).FirstOrDefault();
            }

            public Service GetService(Service.ServiceTypes serviceType)
            {
                Service ret = null;

                ret = Services.Where(x => x.ServiceType == serviceType).FirstOrDefault();

                return ret;
            }

            public void AddAreas(List<Area> areas)
            {
                foreach (var area in areas)
                {
                    AddArea(area);
                }
            }

            public void AddArea(Area area)
            {
                var check = Areas.Any(x => x.Name.ToUpper() == area.Name.ToUpper());

                if (check == false)
                {
                    Areas.Add(area);
                }
            }
        }
    }
}
