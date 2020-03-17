using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.IdentityModel.Tokens.Jwt;
using Chargoon.Sample.Domain.Service;

namespace Chargoon.Sample.UI.Attributes
{
    public class ApiAuthorizeAttribute : AuthorizeAttribute
    {
        public ApiAuthorizeAttribute()
        {
        }

        public override void OnAuthorization(HttpActionContext filterContext)
        {
            if (Authorize(filterContext))
            {
                return;
            }
            HandleUnauthorizedRequest(filterContext);
        }

        private bool Authorize(HttpActionContext actionContext)
        {
            try
            {
                var auth = actionContext.Request.Headers.Authorization;
                if (auth == null)
                    return false;
                var authenticationString = auth.Parameter;
                var handler = new JwtSecurityTokenHandler();
                var tokenRead = handler.ReadToken(authenticationString) as JwtSecurityToken;
                return tokenRead.ValidTo > DateTime.Now;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        //{
        //    if (actionContext == null)
        //    {
        //        throw new ArgumentNullException("actionContext", "Null actionContext");
        //    }

        //    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
        //    actionContext.Response.Headers.Add("AuthenticationStatus", "NotAuthorized");
        //    actionContext.Response.ReasonPhrase = "Authentication failed";

        //    actionContext.Response.Content = new ObjectContent(
        //            typeof(BaseResult<dynamic>),
        //            new BaseResult<dynamic>(ResultStatusCodes.Unauthorized, "Unauthorized"),
        //            new System.Net.Http.Formatting.JsonMediaTypeFormatter());

        //}


    }
}