using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ROSys.WebClient
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            InitializeSystem();
        }

        private void InitializeSystem()
        {
            Globals.Tables = new List<Models.Table>();

            Globals.Tables.Add(new Models.Table()
            {
                Id = Guid.NewGuid(),
                Number = "1",
                NumberOfPerson = 4
            }); 

            Globals.Tables.Add(new Models.Table()
            {
                Id = Guid.NewGuid(),
                Number = "2",
                NumberOfPerson = 4
            });

            Globals.Tables.Add(new Models.Table()
            {
                Id = Guid.NewGuid(),
                Number = "3",
                NumberOfPerson = 2
            });
        }
    }
}
