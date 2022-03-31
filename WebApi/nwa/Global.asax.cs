using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Person.Model;
using Person.Model.Common;
using Person.Repository;
using Person.Service;
using Person.Service.Common;
using Person.Repository.Common;
using Autofac.Integration.WebApi;

namespace nwa
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }

        public static IContainer Container { get; set; }

        public void RegisterServices()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<PersonService>().As<IPersonServiceCommon>();
            builder.RegisterType<PersonRepository>().As<IPersonRepository>();
            builder.RegisterType<PersonModel>().As<IPersonModelCommon>();

            var container = builder.Build();

            var webApiResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = webApiResolver;

        }

    }

}
