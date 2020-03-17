using System;
using System.Collections.Generic;
using System.Data;
using Chargoon.Library.Repository.Dapper.Repository;
using Chargoon.Library.Repository.DataContext;
using Chargoon.Library.Repository.Repository;
using Chargoon.Sample.DataAccess.DataContext;
using Chargoon.Sample.Domain.DataAccess.Repository.User;
using Chargoon.Sample.Domain.DataModel;
using Chargoon.Sample.DataAccess.Utils;
using System.Linq;
using Chargoon.Sample.Domain.Dto.User;

namespace Chargoon.Sample.DataAccess.Repository
{
    public class UserRepository : Repository<UserModel, int>, IUserRepository
    {
        private IStringEncryptor encryptor;
        public UserRepository(IStringEncryptor encryptor,IDapperSampleContext dapperSampleContext, System.Data.IDbTransaction transaction = null)
			: base(dapperSampleContext, transaction)
		{
            this.encryptor = encryptor;
        }

        public bool Add(UserModel model)
        {
            //encrypt the password
            model.Password = encryptor.EncryptString(model.Password);
            Insert(model);
            return true;
        }

        public UserModel CheckUserPass(string username, string password)
        {
            var user = Find(action => action.Where($"UserName = '{username}' and Password= '{encryptor.EncryptString(password)}' and IsActive=1"));
            return user.SingleOrDefault();
        }

        public bool Delete(UserModel model)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(int id)
        {
            PhysicalDelete(id);
            return true;
        }

        public UserModel GetByID(int id)
        {
            return Get(id);
        }

        public List<UserModel> GetList(ListSearchModel model)
        {
            List<string> where = new List<string>();
            if (!string.IsNullOrEmpty(model.username))
                where.Add($"UserName like '%{model.username}%'");
            if (!string.IsNullOrEmpty(model.start_date_gte))
                where.Add($"SubmitDate >= '{model.start_date_gte}'");
            if (!string.IsNullOrEmpty(model.start_date_lte))
                where.Add($"SubmitDate <= '{model.start_date_lte}'");
            if(where.Count == 0)
                return Find(null).ToList();
            FormattableString query = $"{CreateQueryString(where, "and")}";
            return Find(action => action.Where(query)).ToList();
        }

        public bool UserNameExist(string username)
        {
            var user = Find(action => action.Where($"UserName = '{username}'"));
            return user.Count() > 0 ? true : false;
        }

        bool IUserRepository.Update(UserModel model)
        {
            throw new NotImplementedException();
        }

        private string CreateQueryString(List<string> where, string operation)
        {
            if (where.Count == 0)
                return "";
            var queryString = where.Count == 0 ? "" : where.FirstOrDefault();
            for(int i=1; i<where.Count;i++)
                queryString += " " + operation + " " + where[i];
            return queryString;
        }

        public bool ChangeActive(int id)
        {
            var user = GetByID(id);
            user.IsActive = !user.IsActive;
            Update(user);
            return true;
        }
    }
}
