using Autofac;
using Autofac.Integration.Mvc;
using BaseballStats.CrossCutting.Query;
using BaseballStats.CrossCutting.Query.Interfaces;
using BaseballStats.Data;
using BaseballStats.Data.Interfaces;
using BaseballStatsEmporium.Composers;
using BaseballStatsEmporium.Composers.Infrastructure;
using BaseballStatsEmporium.ModelParameters;
using BaseballStatsEmporium.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaseballStatsEmporium.Components
{
    public class ComponentRegistration
    {
        public static void RegisterComponents()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<BaseballStatsContext>().As<IBaseballContext>();
            builder.RegisterType<Composer>().As<IComposer>();
            builder.RegisterType<PlayerInformationComposer>().As<ICompose<List<PlayerInformation>>.Using<PlayerInformationParameters>>();
            builder.RegisterType<FilterExpressionBuilder>().As<IBuildFilterExpressions>();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}