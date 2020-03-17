using Chargoon.Library.Repository.Configuation;
using Chargoon.Library.Repository.Dapper.Configuration;
using Chargoon.Sample.DataAccess.DataContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chargoon.Sample.DataAccess.Configuration
{
    class RoleConfig : IEntityConfig
    {
        private readonly IDapperSampleContext roleAppDataContext;

        public RoleConfig(IDapperSampleContext roleAppDataContext)
        {
            this.roleAppDataContext = roleAppDataContext;
        }

        public void SetConfig()
        {
            EntityConfiguration.GetDefaultEntityMapping<Domain.DataModel.RoleModel>()
                                                    .SetTableName(roleAppDataContext.DbPrefix + "Roles")
                                                    .SetProperty(role => role.Id, prop => prop.SetPrimaryKey().SetDatabaseGenerated(DatabaseGeneratedOption.Identity))
                                                    .SetProperty(role => role.Title)
                                                    .SetProperty(role => role.IsActive);

        }
    }
}
