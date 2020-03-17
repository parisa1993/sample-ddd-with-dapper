using Chargoon.Sample.Domain.DataAccess.Repository.Test;
using Chargoon.Sample.Domain.DataModel;
using Chargoon.Sample.Domain.Service;

namespace Chargoon.Sample.Service
{
	public class TestService : ITestService
	{
		private readonly ITestRepository testRepository;

		public TestService(ITestRepository testRepository)
		{
			this.testRepository = testRepository;
		}

		public bool AddNewTestModel(TestModel testModel)
		{
			return testRepository.Add(testModel);
		}

		public TestModel GetTestModel(int id)
		{
			return testRepository.Get(id);
		}
	}
}
