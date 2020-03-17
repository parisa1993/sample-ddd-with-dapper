using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chargoon.Sample.Domain.Dto.User
{
    public class ListSearchModel
    {
        public string start_date_gte { get; set; }
        public string start_date_lte { get; set; }
        public string username { get; set; }
    }
}
