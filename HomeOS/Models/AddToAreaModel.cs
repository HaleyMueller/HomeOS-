using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeOS.Models
{
    public class AddToAreaModel
    {
        public List<BusinessImplementation.Area> Areas { get; set; } = new List<BusinessImplementation.Area>();
        public List<BusinessImplementation.ScreenInterface> ScreenInterfaces { get; set; } = new List<BusinessImplementation.ScreenInterface>();
        public string ClientGUID { get; set; }
    }
}
