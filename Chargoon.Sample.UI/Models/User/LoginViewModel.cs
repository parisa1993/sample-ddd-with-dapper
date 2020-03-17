using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chargoon.Sample.UI.Models.User
{
    public class LoginViewModel
    {
        public TokenViewModel token { get; set; }
        public string full_name { get; set; }
        public string role { get; set; }
    }
}