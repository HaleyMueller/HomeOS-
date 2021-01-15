using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessImplementation
{
    public class Card
    {
        public class Percentage : Card
        {
            public string UIFAIcon { get; set; }
            public string Value { get; set; }
            public string MaxValue { get; set; }
        }
    }
}
