using BaseballStats.Data.Entity;
using BaseballStats.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseballStats.Data
{
    public class BaseballStatsContext : DbContext, IBaseballContext
    {
        public BaseballStatsContext() : base("DefaultConnection")
        {            
        }



        public DbSet<Player> Players { get; set; }        
        public DbSet<Pitching> PitchingStats { get; set; }
        public DbSet<PitchingPostSeason> PitchingPostSeasonStats { get; set; }

        public IQueryable<T> Query<T>() where T : class
        {
            return this.Set<T>();
        }        
    }
}
