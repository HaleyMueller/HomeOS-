using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessImplementation
{
    public static class ServiceHandler
    {
        public static List<Device> GetDevices()
        {
            var ret = new List<Device>();

            foreach (var service in SaveFile.SaveFileModelObject.Services)
            {
                ret.AddRange(service.GetDevices());
            }

            return ret;
        }
    }

    public class Service
    {
        [JsonIgnore]
        public string Name { get; set; }
        public bool? Enabled { get; set; }
        public virtual ServiceTypes ServiceType { get; set; }

        public enum ServiceTypes
        {
            PiHole
        }

        public virtual void LoadConfig() { }

        public virtual List<Device> GetDevices() { return new List<Device>(); }

        public class PiHole : Service
        {
            public new ServiceTypes ServiceType = ServiceTypes.PiHole;
            
            [Display("End Point URL")]
            [DisplayType(DisplayTypeAttribute.DisplayTypes.text)]
            public string EndPointURL { get; set; } = "http://192.168.1.5/admin/api.php";

            [Display("API Token")]
            [DisplayType(DisplayTypeAttribute.DisplayTypes.password)]
            public string APIToken { get; set; }

            public override void LoadConfig()
            {
                this.Name = "Pi-Hole";
                Pi_Hole.API.URL = EndPointURL;
                Pi_Hole.API.TOKEN = APIToken;
            }

            public override List<Device> GetDevices()
            {
                var device = new Device(); //Some how get device info saving and loading from config
                //device.

                return base.GetDevices();
            }
        }
    }

    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class DisplayAttribute : System.Attribute
    {
        public string Name { get; set; }

        public DisplayAttribute(string name)
        {
            this.Name = name;
        }
    }

    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class DisplayOrderAttribute : System.Attribute
    {
        public int Order { get; set; }

        public DisplayOrderAttribute(int order)
        {
            this.Order = order;
        }
    }

    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class DisplayTypeAttribute : System.Attribute
    {
        public DisplayTypes DisplayType;

        public DisplayTypeAttribute(DisplayTypes displayType)
        {
            this.DisplayType = displayType;
        }

        public enum DisplayTypes
        {
            text,
            password,
            checkbox,
            integer
        }
    }
}
