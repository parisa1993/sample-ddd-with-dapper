using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chargoon.Sample.Domain.DataModel
{
    public class UserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime SubmitDate { get; set; } = DateTime.Now;
        public Nullable<DateTime>  EndDate { get; set; }
        public int CreatedUser { get; set; }
        public UserModel CreatedUserModel { get; set; }
        public int? ModifiedUser { get; set; }
        public UserModel ModifiedUserModel { get; set; }
        public int RoleId { get; set; }
        public RoleModel RoleModel { get; set; }
        public bool IsActive { get; set; }
    }
}
