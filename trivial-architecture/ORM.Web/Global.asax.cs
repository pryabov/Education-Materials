using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using ORM.Web.App_Start;

namespace ORM.Web
{
	public class Global : HttpApplication
	{
		protected void Application_Start(object sender, EventArgs e)
		{
			// Code that runs on application startup
			AreaRegistration.RegisterAllAreas();
			GlobalConfiguration.Configure(WebApiConfig.Register);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			GlobalConfig.CustomizeConfig(GlobalConfiguration.Configuration);
			// Configure IoC
			IoCConfig.ConfigureIoC();

			// Database Initializer could be defined there instead of web.config
			//System.Data.Entity.Database.SetInitializer(new ORMDatabaseInitializer());
		}
	}
}