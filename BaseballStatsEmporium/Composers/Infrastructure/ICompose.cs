using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaseballStatsEmporium.Composers.Infrastructure
{
    public abstract class ICompose<T>
    {
        public interface Using<Tparam>
        {
            T Compose(Tparam parameters);
        }

        public abstract T UsingParameters<Tparam>(Tparam parameters);
    }
}