using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chargoon.Sample.UI.Models.User
{
    public class UserListViewModel
    {
        public int id { get; set; }
        public string full_name { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string username { get; set; }
        public string starter { get; set; }
        public string modifier { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }
        public string status { get; set; }
        public int role_id { get; set; }
        public string role { get; set; }
        public bool active { get; set; }
    }
}