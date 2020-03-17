using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Chargoon.Sample.UI.WebApi
{
    public class BaseApiController : ApiController
    {
        public string GetToken()
        {
            var headers = HttpContext.Current.Request.Headers.GetValues("Authorization").SingleOrDefault();
            if (!string.IsNullOrEmpty(headers))
            {
                var token = headers.Replace("Bearer ", "");
                return token;
            }
            return null;
        }
    }
}
