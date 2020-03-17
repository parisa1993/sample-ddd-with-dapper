using Chargoon.Sample.Framework;

namespace Chargoon.Sample.Service
{
	public class DependencyRegistrar : IDependencyRegistrar
	{
		public void Register(Container container)
		{
			container.RegisterImplementation<Domain.Service.ITestService, TestService>();
			container.RegisterImplementation<Domain.Service.IUserService, UserService>();
			container.RegisterImplementation<Domain.Service.ITokenService, TokenService>();
			container.RegisterImplementation<Domain.Service.IRoleService, RoleService>();
        }
	}
}
