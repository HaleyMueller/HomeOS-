using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeOS.Models
{
    public class SaveScreenInterfaceModel
    {
        public string areaGUID { get; set; }
        public bool overwriteDevice { get; set; }
        public string deviceGUID { get; set; }
        public string txtDeviceName { get; set; }
    }
}
