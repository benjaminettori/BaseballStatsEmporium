using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaseballStatsEmporium.Composers.Infrastructure
{
    public interface IComposer
    {
        ICompose<T> Compose<T>();
    }
}