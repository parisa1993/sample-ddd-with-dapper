using Chargoon.Library.Repository.Dapper.Repository;
using Chargoon.Sample.DataAccess.DataContext;
using Chargoon.Sample.Domain.DataAccess.Repository.Test;
using Chargoon.Sample.Domain.DataModel;

namespace Chargoon.Sample.DataAccess.Repository
{
	public class TestRepository : Repository<TestModel, int>, ITestRepository
	{
		public TestRepository(IDapperSampleContext dapperSampleContext, System.Data.IDbTransaction transaction = null)
			: base(dapperSampleContext, transaction)
		{

		}

		public bool Add(TestModel model)
		{
			Insert(model);
			return true;
		}

		public TestModel GetByID(int id)
		{
			return Get(id);
		}
	}
}
