using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace Chargoon.Sample.Framework
{
	public class ControllerSelector : IHttpControllerSelector
	{
		private readonly HttpConfiguration httpConfiguration;
		private readonly IHttpControllerSelector defaultControllerSelector;

		public ControllerSelector(HttpConfiguration httpConfiguration, IHttpControllerSelector defaultControllerSelector)
		{
			this.httpConfiguration = httpConfiguration;
			this.defaultControllerSelector = defaultControllerSelector;
		}

		public IDictionary<string, HttpControllerDescriptor> GetControllerMapping()
		{
			var result = new Dictionary<string, HttpControllerDescriptor>();
			foreach (var item in SampleEnvironment.Container.ResolveAll<IHttpController>())
			{
				result.Add(GetKey(item.GetType()), new HttpControllerDescriptor(httpConfiguration, item.GetType().Name, item.GetType()));
			}

			return result;
		}

		public HttpControllerDescriptor SelectController(HttpRequestMessage request)
		{
			var descriptor = defaultControllerSelector.SelectController(request);

			var controller = SampleEnvironment.Container.Resolve(descriptor.ControllerType);

			return new SampleHttpControllerDescriptor(httpConfiguration, controller.GetType().Name, controller.GetType());
		}

		private string GetKey(System.Type type)
		{
			return type.FullName.ToLower();
		}
	}
}
