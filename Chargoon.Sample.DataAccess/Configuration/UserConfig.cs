using Chargoon.Library.Repository.Configuation;
using Chargoon.Library.Repository.Dapper.Configuration;
using Chargoon.Sample.DataAccess.DataContext;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Chargoon.Sample.DataAccess.Configuration
{
    public class UserConfig : IEntityConfig
    {
        private readonly IDapperSampleContext userAppDataContext;

        public UserConfig(IDapperSampleContext userAppDataContext)
        {
            this.userAppDataContext = userAppDataContext;
        }

        public void SetConfig()
        {
            EntityConfiguration.GetDefaultEntityMapping<Domain.DataModel.UserModel>()
                                                    .SetTableName(userAppDataContext.DbPrefix + "Users")
                                                    .SetProperty(user => user.Id, prop => prop.SetPrimaryKey().SetDatabaseGenerated(DatabaseGeneratedOption.Identity))
                                                    .SetProperty(user => user.UserName)
                                                    .SetProperty(user => user.Password)
                                                    .SetProperty(user => user.FirstName)
                                                    .SetProperty(user => user.LastName)
                                                    .SetProperty(user => user.SubmitDate)
                                                    .SetProperty(user => user.EndDate)
                                                    .SetProperty(user => user.ModifiedUser)
                                                    //.SetProperty(user => user.CreatedUser, user=> user.ChildParentRelationship= new Dapper.FastCrud.Mappings.PropertyMappingRelationship(typeof(Domain.DataModel.UserModel), "Id"))
                                                    .SetProperty(user => user.CreatedUser, prop=> prop.SetChildParentRelationship<Domain.DataModel.UserModel>("Id"))
                                                    //.SetProperty(user => user.RoleId);
                                                    //.SetProperty(user => user.CreatedUser, prop=> prop.SetChildParentRelationship<use)
                                                    //.SetProperty(user => user.CreatedUser, prop => prop.SetChildParentRelationship<Domain.DataModel.UserModel>("Id"))
                                                    //.SetProperty(user => user.RoleId, prop => prop.SetChildParentRelationship<Domain.DataModel.RoleModel>("RoleModel").);
                                                    .SetProperty(user => user.RoleId);
        }
    }
}
