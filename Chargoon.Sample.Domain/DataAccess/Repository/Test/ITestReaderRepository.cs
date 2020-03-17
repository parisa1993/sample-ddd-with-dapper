namespace Chargoon.Sample.Domain.DataAccess.Repository.Test
{
	public interface ITestReaderRepository
	{
		DataModel.TestModel GetByID(int id);
	}
}
