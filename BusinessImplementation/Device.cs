using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessImplementation
{
    public class Device
    {
        public string GUID { get; set; }
        public List<Entity> Entities { get; set; } = new List<Entity>();
        public string Name { get; set; }
        public string AreaGUID { get; set; }
        public Service FromService { get; set; }
        public string UIIconClass { get; set; }
        public string DeviceInfo { get; set; }
    }
}
