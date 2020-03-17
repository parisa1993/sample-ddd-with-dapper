using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chargoon.Sample.Domain.Service
{
    public interface IRoleService
    {
        bool AddNewRoleModel(DataModel.RoleModel roleModel);
        DataModel.RoleModel GetRoleModel(int id);
        List<DataModel.RoleModel> GetRoleList();
    }
}
