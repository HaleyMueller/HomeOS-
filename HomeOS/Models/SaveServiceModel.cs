using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeOS.Models
{
    public class SaveServiceModel
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
