﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chargoon.Sample.UI.Models.User
{
    public class TokenViewModel
    {
        public string access_token { get; set; }

        public string token_type { get; set; }

        public string expires_in { get; set; }



    }
}