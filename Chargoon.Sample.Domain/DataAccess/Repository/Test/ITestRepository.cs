using Chargoon.Library.Repository.Repository;
using System;
using System.Collections.Generic;

namespace Chargoon.Sample.Domain.DataAccess.Repository.Test
{
	public interface ITestRepository : IRepository<DataModel.TestModel, int>, ITestReaderRepository
	{
		bool Add(DataModel.TestModel model);
	}
}
