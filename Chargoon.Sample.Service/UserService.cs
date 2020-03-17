using System;
using System.Collections.Generic;
using Chargoon.Sample.Domain.DataAccess.Repository.User;
using Chargoon.Sample.Domain.DataModel;
using Chargoon.Sample.Domain.Service;
using Chargoon.Sample.Domain.DataAccess.Repository.Role;
using Chargoon.Sample.Domain.Dto.User;

namespace Chargoon.Sample.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IRoleRepository roleRepository;

        public UserService(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
        }

        public bool AddNewUserModel(UserModel userModel)
        {
            return userRepository.Add(userModel);
        }

        public bool ChangeUserModelActive(int id)
        {
            return userRepository.ChangeActive(id);
        }

        public UserModel CheckUserNamePassword(string username, string password)
        {
            var user = userRepository.CheckUserPass(username, password);
            //todo : need to fix
            if(user != null)
                user.RoleModel = roleRepository.GetByID(user.RoleId);
            return user;
        }

        public bool DeleteUserModel(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUserModel(int id)
        {
            return userRepository.DeleteById(id);
        }

        public List<UserModel> GetUserListModel(ListSearchModel model)
        {
            var users = userRepository.GetList(model);
            //todo : need to fix
            var roles = roleRepository.GetList();
            foreach (var user in users)
            {
                user.CreatedUserModel = GetUserModel(user.CreatedUser);
                user.ModifiedUserModel = user.ModifiedUser == null ? null : GetUserModel(user.ModifiedUser.Value);
                user.RoleModel = roles.Find(x => x.Id == user.RoleId);
            }
            return users;
        }

        public UserModel GetUserModel(int id)
        {
            var user = userRepository.GetByID(id);
            user.CreatedUserModel = userRepository.GetByID(user.CreatedUser);
            user.ModifiedUserModel = user.ModifiedUser == null ? null : userRepository.GetByID(user.ModifiedUser.Value);
            user.RoleModel = roleRepository.GetByID(user.RoleId);
            return user;
        }

        public string GetUserRoleName(int id)
        {
            var user = userRepository.GetByID(id);
            var role = roleRepository.GetByID(user.RoleId);
            return role.Title;
        }

        public bool UpdateUserModel(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public bool UserNameExist(string username)
        {
            return userRepository.UserNameExist(username);
        }
    }
}
