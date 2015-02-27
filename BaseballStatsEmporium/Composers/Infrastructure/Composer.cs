using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaseballStatsEmporium.Composers.Infrastructure
{
    public class Composer : IComposer
    {
        public ICompose<T> Compose<T>()
        {
            return new ComposerFor<T>();
        }

        private class ComposerFor<T> : ICompose<T>
        {
            public override T UsingParameters<Tparam>(Tparam parameters)
            {
                var composer = DependencyResolver.Current.GetService<Using<Tparam>>();
                return composer.Compose(parameters);
            }
        }
    }
}