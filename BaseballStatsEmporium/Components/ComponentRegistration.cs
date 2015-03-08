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
using System.Reflection;
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
            //Register all composer types as their implemented interface
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).Where(t => t.Name.Contains("Composer")).AsImplementedInterfaces();
            builder.RegisterType<FilterExpressionBuilder>().As<IBuildFilterExpressions>();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}