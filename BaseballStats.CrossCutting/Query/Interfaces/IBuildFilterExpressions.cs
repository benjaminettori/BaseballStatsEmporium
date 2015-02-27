using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BaseballStats.CrossCutting.Query.Interfaces
{
    public interface IBuildFilterExpressions
    {
        Expression<Func<T, bool>> BuildLambda<T>(List<FilterObject> filter);
    }
}
