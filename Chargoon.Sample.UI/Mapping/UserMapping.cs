using Chargoon.Sample.Domain.DataModel;
using Chargoon.Sample.Domain.Dto.User;
using Chargoon.Sample.UI.Models.User;
using Chargoon.Sample.UI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chargoon.Sample.UI.Mapping
{
    public static class UserMapping
    {
        public static UserListViewModel GetUserDetail(UserModel user)
        {
            return new UserListViewModel()
            {
                id = user.Id,
                username = user.UserName,
                full_name = user.FirstName + " " + user.LastName,
                first_name = user.FirstName,
                last_name = user.LastName,
                starter = user.CreatedUserModel.UserName,
                role = user.RoleModel.Title,
                modifier = user.ModifiedUserModel != null ? user.ModifiedUserModel.UserName : null,
                status = user.EndDate <= DateTime.Now ? "پایان یافته" : "در جریان",
                start_date = DateTimeHelper.ToJalaliDateTime(user.SubmitDate),
                end_date = user.EndDate != null ? DateTimeHelper.ToJalaliDateTime(user.EndDate.Value) : null,
                role_id = user.RoleId,
                active = user.IsActive
            };
        }
        public static List<UserListViewModel> GetUserList(List<UserModel> users)
        {
            var result = new List<UserListViewModel>();
            foreach (var user in users)
            {
                result.Add(GetUserDetail(user));
            }
            return result;
            //return users.Select(user => new UserListViewModel()
            //{
            //    id = user.Id,
            //    username = user.UserName,
            //    full_name = user.FirstName + " " + user.LastName,
            //    starter = user.CreatedUserModel.UserName,
            //    role = user.RoleModel.Title,
            //    modifier = user.ModifiedUserModel != null ? user.ModifiedUserModel.UserName : null,
            //    status = user.EndDate <= DateTime.Now ? "پایان یافته" : "در جریان",
            //    start_date = DateTimeHelper.ToJalaliDateTime(user.SubmitDate),
            //    end_date = user.EndDate != null ? DateTimeHelper.ToJalaliDateTime(user.EndDate.Value) : null,

            //}).ToList();
        }

        public static UserModel GetUserAddModel(UserAddModel model, int userId)
        {
            Nullable<DateTime> endDate = null;
            return new UserModel()
            {
                FirstName = model.first_name,
                LastName = model.last_name,
                SubmitDate = DateTime.Now,
                Password = model.password,
                RoleId = model.role,
                UserName = model.username,
                CreatedUser = userId,
                EndDate = model.end_date!= null? Utils.DateTimeHelper.JalaliStringToGregorian(model.end_date) : endDate,
            };
        }

        public static ListSearchModel GetUserListFilter(UserFilterModel model)
        {
            if(model == null)
            {
                return new ListSearchModel();
            }

            return new ListSearchModel()
            {
                username = model.username == null || model.username == "" ? null : model.username,
                start_date_gte = model.start_date== null || model.start_date.gte==null ? null 
                        : Utils.DateTimeHelper.JalaliStringToGregorian(model.start_date.gte).ToString("yyyy/MM/dd h:mm"),
                start_date_lte = model.start_date == null || model.start_date.lte == null ? null 
                        : Utils.DateTimeHelper.JalaliStringToGregorian(model.start_date.lte).ToString("yyyy/MM/dd h:mm"),
            };
        }
    }
}