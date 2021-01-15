using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeOS.Models
{
    public class HomeIndexModel
    {
        public Pi_Hole.Models.GetAllQueriesModel AllQueries { get; set; }
        public string LastBlockedDomain { get; set; }
        public Pi_Hole.Models.TopItemsModel TopItems { get; set; }
        public bool Enabled { get; set; }
    }
}
