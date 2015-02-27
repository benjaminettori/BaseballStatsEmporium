using BaseballStats.CrossCutting.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaseballStatsEmporium.ModelParameters
{
    public class PlayerInformationParameters
    {
        public int? Skip { get; set; }
        public int? Take { get; set; }
        public List<FilterObject> Filter { get; set; }
    }
}