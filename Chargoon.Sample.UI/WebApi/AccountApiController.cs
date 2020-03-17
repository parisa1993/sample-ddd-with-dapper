using Chargoon.Sample.Domain.Service;
using Chargoon.Sample.UI.Attributes;
using Chargoon.Sample.UI.Models.Base;
using Chargoon.Sample.UI.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace Chargoon.Sample.UI.WebApi
{
    [RoutePrefix("api/user")]
    [AllowAnonymous]
    public class AccountApiController : BaseApiController
    {
        private readonly IUserService userService;
        private readonly ITokenService tokenService;

        public AccountApiController(IUserService userService, ITokenService tokenService)
        {
            this.userService = userService;
            this.tokenService = tokenService;
        }

        [HttpPost]
        [Route("login")]
        public IHttpActionResult UserLogin(LoginModel model)
        {
            var user = userService.CheckUserNamePassword(model.username, model.password);
            if (user != null)
            {
                var token = tokenService.GenerateToken(user.Id.ToString());
                var tokenModel = new TokenViewModel()
                {
                    access_token = token,
                    expires_in = tokenService.ExpireMilliSeconds.ToString(),
                    token_type = tokenService.TokenType,
                };
                return Content(HttpStatusCode.OK, new BaseResult<LoginViewModel>()
                {
                    success = true,
                    data = new LoginViewModel()
                    {
                        token = tokenModel,
                        full_name = user.FirstName + ' ' + user.LastName,
                        role = user.RoleModel.Title.ToString()
                    },
                });
            }

            return Content(HttpStatusCode.Unauthorized, new BaseResult<LoginViewModel>()
            {
                success = false,
                data = null,
                message = "Invalid Username or password"
            });
        }
    }
}
