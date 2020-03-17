using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chargoon.Sample.UI.Models.Base
{
    public class BaseResult<T>
    {
        public bool success { get; set; }
        public T data { get; set; }
        public string message { get; set; }
    }
}