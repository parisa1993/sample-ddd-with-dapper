using Chargoon.Library.Repository.Dapper.Configuration;
using Chargoon.Library.Repository.Dapper.DataContext;
using System.Reflection;

namespace Chargoon.Sample.DataAccess.DataContext
{
	public class DapperSampleContext : DapperDataContextBase, IDapperSampleContext
	{
		private static bool entitiesConfigurationWereApplied;

		public DapperSampleContext()
		{
			if (!entitiesConfigurationWereApplied)
			{
				SetEntitiesConfigurations();
			}
		}

		public override void SetEntitiesConfigurations()
		{
			entitiesConfigurationWereApplied = true;
			EntityConfiguration.SetEntitiesConfigurations(Assembly.GetExecutingAssembly(), this);
		}

		public override string ReadOnlyConnectionString
		{
			get { return ConnectionString; }
		}

		public override string ConnectionString
		{
			get { return ""; }
		}

		public override string DbPrefix
		{
			get
			{
				return "tst_";
			}
		}

		public override int CommandTimeout
		{
			get
			{
				return 20;
			}
		}
	}
}
