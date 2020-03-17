using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chargoon.Sample.Domain.DataAccess.Repository.Role
{
    public interface IRoleReaderRepository
    {
        DataModel.RoleModel GetByID(int id);
        List<DataModel.RoleModel> GetList();
    }
}
