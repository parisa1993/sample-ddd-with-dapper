using Chargoon.Sample.Domain.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chargoon.Sample.Domain.DataAccess.Repository.User
{
    public interface IUserReaderRepository
    {
        DataModel.UserModel GetByID(int id);
        bool UserNameExist(string username);
        DataModel.UserModel CheckUserPass(string username, string password);
        List<DataModel.UserModel> GetList(ListSearchModel model);
    }
}
