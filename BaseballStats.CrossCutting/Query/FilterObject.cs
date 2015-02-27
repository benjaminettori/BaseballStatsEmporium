using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseballStats.CrossCutting.Query
{
    public class FilterObject
    {
        public string FilterColumn { get; set; }
        public string FilterValue { get; set; }
        public FilterOperator FilterOperator { get; set; }
        public LogicalOperator LogicalOperator { get; set; }
    }
}
