using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http.Dispatcher;

namespace Chargoon.Sample.UI
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



			Framework.SampleEnvironment.Start();

			var controllerFactory = new Framework.ControllerFactory();
			ControllerBuilder.Current.SetControllerFactory(controllerFactory);

			var defaultSelector = GlobalConfiguration.Configuration.Services.GetService(typeof(IHttpControllerSelector)) as IHttpControllerSelector;
			GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerSelector), new Framework.ControllerSelector(GlobalConfiguration.Configuration, defaultSelector));

		}
	}
}
