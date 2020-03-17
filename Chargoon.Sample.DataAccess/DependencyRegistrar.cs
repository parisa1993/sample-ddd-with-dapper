using Chargoon.Sample.Framework;

namespace Chargoon.Sample.DataAccess
{
	public class DependencyRegistrar : IDependencyRegistrar
	{
		public void Register(Container container)
		{
			container.RegisterSingletonImplementation<DataContext.IDapperSampleContext, DataContext.DapperSampleContext>();
			container.RegisterImplementation<Domain.DataAccess.Repository.Test.ITestRepository, Repository.TestRepository>();
			container.RegisterImplementation<Domain.DataAccess.Repository.User.IUserRepository, Repository.UserRepository>();
			container.RegisterImplementation<Domain.DataAccess.Repository.Role.IRoleRepository, Repository.RoleRepository>();
            container.RegisterImplementation<Utils.IStringEncryptor, Utils.TripleDESStringEncryptor>();
        }
	}
}
