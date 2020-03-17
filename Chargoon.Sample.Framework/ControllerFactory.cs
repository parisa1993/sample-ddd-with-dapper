using System;
using System.Web.Mvc;

namespace Chargoon.Sample.Framework
{
	public class ControllerFactory : DefaultControllerFactory
	{
		public override void ReleaseController(IController controller)
		{
			SampleEnvironment.Container.ReleaseComponent(controller);
		}

		protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
		{
			if (controllerType == null)
			{
				throw new System.Web.HttpException(404, string.Format("The controller for path '{0}' could not be found.", requestContext.HttpContext.Request.Path));
			}
			return (IController)SampleEnvironment.Container.Resolve(controllerType);
		}
	}
}
