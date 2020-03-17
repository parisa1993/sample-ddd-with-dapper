using Chargoon.Library.Repository.Dapper.Repository;
using Chargoon.Sample.DataAccess.DataContext;
using Chargoon.Sample.Domain.DataAccess.Repository.Role;
using Chargoon.Sample.Domain.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chargoon.Sample.DataAccess.Repository
{
    public class RoleRepository : Repository<RoleModel, int>, IRoleRepository
    {
        public RoleRepository(IDapperSampleContext dapperSampleContext, System.Data.IDbTransaction transaction = null)
			: base(dapperSampleContext, transaction)
		{

        }
        public bool Add(RoleModel model)
        {
            throw new NotImplementedException();
        }

        public RoleModel GetByID(int id)
        {
            return Get(id);
        }

        public List<RoleModel> GetList()
        {
            return Find(null).ToList();
        }
    }
}
