using Chargoon.Library.Repository.Configuation;
using Chargoon.Library.Repository.Dapper.Configuration;
using Chargoon.Sample.DataAccess.DataContext;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chargoon.Sample.DataAccess.Configuration
{
	public class TestConfig : IEntityConfig
	{
		private readonly IDapperSampleContext testAppDataContext;

		public TestConfig(IDapperSampleContext testAppDataContext)
		{
			this.testAppDataContext = testAppDataContext;
		}

		public void SetConfig()
		{
			EntityConfiguration.GetDefaultEntityMapping<Domain.DataModel.TestModel>()
													.SetTableName(testAppDataContext.DbPrefix + "Tests")
													.SetProperty(test => test.ID, prop => prop.SetPrimaryKey().SetDatabaseGenerated(DatabaseGeneratedOption.Identity)) // Call SetProperty once per each property!
													.SetProperty(test => test.Title);

		}
	}
}
