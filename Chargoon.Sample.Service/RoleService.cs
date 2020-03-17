using Chargoon.Sample.Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chargoon.Sample.Domain.DataModel;
using Chargoon.Sample.Domain.DataAccess.Repository.Role;

namespace Chargoon.Sample.Service
{
    class RoleService : IRoleService
    {
        private readonly IRoleRepository roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        public bool AddNewRoleModel(RoleModel roleModel)
        {
            throw new NotImplementedException();
        }

        public List<RoleModel> GetRoleList()
        {
            return roleRepository.GetList();
        }

        public RoleModel GetRoleModel(int id)
        {
            return roleRepository.GetByID(id);
        }
    }
}
