using Chargoon.Sample.Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Chargoon.Sample.UI.Attributes
{
    public class RoleActionAttribute : ActionFilterAttribute
    {
        private readonly IUserService userService;

        private string role;

        public RoleActionAttribute(IUserService userService, string role)
        {
            this.userService = userService;
            this.role = role;
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var id = actionContext.ActionArguments["id"];
        }
    }
}