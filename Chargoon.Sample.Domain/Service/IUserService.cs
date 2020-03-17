using Chargoon.Sample.Domain.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chargoon.Sample.Domain.Service
{
    public interface IUserService
    {
        bool AddNewUserModel(DataModel.UserModel userModel);
        bool UpdateUserModel(DataModel.UserModel userModel);
        bool DeleteUserModel(DataModel.UserModel userModel);
        bool DeleteUserModel(int id);
        DataModel.UserModel GetUserModel(int id);
        List<DataModel.UserModel> GetUserListModel(ListSearchModel model);
        DataModel.UserModel CheckUserNamePassword(string username, string password);
        bool UserNameExist(string username);
        string GetUserRoleName(int id);
        bool ChangeUserModelActive(int id);
    }
}
