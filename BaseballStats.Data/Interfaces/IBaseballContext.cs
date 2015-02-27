using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseballStats.Data.Interfaces
{
    public interface IBaseballContext
    {
        IQueryable<T> Query<T>() where T : class;
        int SaveChanges();
    }
}
