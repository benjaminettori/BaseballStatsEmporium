using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseballStats.CrossCutting.Query
{
    public enum FilterOperator
    {
        eq = 0,
        gt = 1,
        lt = 2,
        ctns = 3
    }

    public enum LogicalOperator
    {
        And = 0,
        Or = 1
    }
}
