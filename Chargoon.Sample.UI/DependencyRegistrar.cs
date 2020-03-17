using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Chargoon.Sample.Framework;

namespace Chargoon.Sample.UI
{
	public class DependencyRegistrar : IDependencyRegistrar
	{
		public void Register(Container container)
		{
			container.RegisterImplementation<Controllers.ValuesController>();
			container.RegisterImplementation<Controllers.HomeController>();
			container.RegisterImplementation<WebApi.UserApiController>();
			container.RegisterImplementation<WebApi.AccountApiController>();
        }
	}
}