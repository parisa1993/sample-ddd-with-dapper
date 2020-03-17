using System;
using System.Collections.Generic;
using System.Linq;
using Chargoon.Library.Repository.Repository;
using Chargoon.Sample.Domain.DataModel;

namespace Chargoon.Sample.Domain.DataAccess.Repository.Role
{
    public interface IRoleRepository : IRepository<DataModel.RoleModel, int>, IRoleReaderRepository
    {
        bool Add(DataModel.RoleModel model);

        
    }
}
