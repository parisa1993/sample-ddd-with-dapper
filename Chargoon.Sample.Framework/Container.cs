using Castle.Windsor;
using System;

namespace Chargoon.Sample.Framework
{
	public class Container
	{
		private readonly WindsorContainer windsorContainer;

		public Container()
		{
			var windsorContainer = new WindsorContainer();
			windsorContainer.Kernel.Resolver.AddSubResolver(new Castle.MicroKernel.Resolvers.SpecializedResolvers.CollectionResolver(windsorContainer.Kernel, true));
			windsorContainer.Kernel.AddFacility<Castle.Facilities.TypedFactory.TypedFactoryFacility>();

			this.windsorContainer = windsorContainer;
		}

		public void RegisterImplementation<TImplementation>()
			where TImplementation : class
		{
			RegisterImplementation<TImplementation, TImplementation>();
		}

		public void RegisterImplementation<TContract, TImplementation>()
			where TContract : class
			where TImplementation : TContract
		{
			var component = Castle.MicroKernel.Registration.Component.For<TContract>().ImplementedBy<TImplementation>();
			var registration = component.LifeStyle;
			windsorContainer.Register(registration.Is(Castle.Core.LifestyleType.PerWebRequest));
		}

		public void RegisterSingletonImplementation<TContract, TImplementation>()
			where TContract : class
			where TImplementation : TContract
		{
			var component = Castle.MicroKernel.Registration.Component.For<TContract>().ImplementedBy<TImplementation>();
			var registration = component.LifeStyle;
			windsorContainer.Register(registration.Is(Castle.Core.LifestyleType.Singleton));
		}


		public void ReleaseComponent(object instance)
		{
			windsorContainer.Kernel.ReleaseComponent(instance);
		}

		public object Resolve(Type contract)
		{
			return windsorContainer.Resolve(contract);
		}

		public T[] ResolveAll<T>() where T : class
		{
			try
			{
				return windsorContainer.ResolveAll<T>();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
