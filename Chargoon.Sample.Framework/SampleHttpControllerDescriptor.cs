using System;
using System.Net.Http;
using System.Web.Http.Controllers;

namespace Chargoon.Sample.Framework
{
	public class SampleHttpControllerDescriptor : HttpControllerDescriptor
	{
		public SampleHttpControllerDescriptor(System.Web.Http.HttpConfiguration configuration, string controllerName, Type controllerType)
			: base(configuration, controllerName, controllerType)
		{ }

		public override IHttpController CreateController(HttpRequestMessage request)
		{
			return (IHttpController)SampleEnvironment.Container.Resolve(ControllerType);
		}
	}
}
