namespace Chargoon.Sample.Domain.Service
{
	public interface ITestService
	{
		bool AddNewTestModel(DataModel.TestModel testModel);
		DataModel.TestModel GetTestModel(int id);
	}
}
