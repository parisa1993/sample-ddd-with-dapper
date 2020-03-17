using Chargoon.Library.Repository.Repository;
using System;
using System.Collections.Generic;

namespace Chargoon.Sample.Domain.DataAccess.Repository.User
{
    public interface IUserRepository : IRepository<DataModel.UserModel, int>, IUserReaderRepository
    {
        bool Add(DataModel.UserModel model);
        bool Update(DataModel.UserModel model);
        bool DeleteById(int id);
        bool Delete(DataModel.UserModel model);

        bool ChangeActive(int id);
    }
}
