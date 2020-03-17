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
    [ApiAuthorize]
    public class UserApiController : BaseApiController
    {
        private readonly IUserService userService;
        private readonly ITokenService tokenService;

        public UserApiController(IUserService userService, ITokenService tokenService)
        {
            this.userService = userService;
            this.tokenService = tokenService;
        }

        [HttpPost]
        [Route("list")]
        public IHttpActionResult userList(UserFilterModel filter)
        {
            var filtermodel = Mapping.UserMapping.GetUserListFilter(filter);
            var users = Mapping.UserMapping.GetUserList(userService.GetUserListModel(filtermodel));

            return Content(HttpStatusCode.OK, new BaseResult<List<UserListViewModel>>()
            {
                success = true,
                data = users
            });
        }

        [HttpGet]
        [Route("info")]
        [Route("info/{id}")]
        public IHttpActionResult userDetail(int? id = null)
        {
            if(id == null) //detail of current user if id is null
            {
                string userId;
                var validate = tokenService.ValidateToken(GetToken(), out userId);
                id = Convert.ToInt32(userId);
            }
            var user = Mapping.UserMapping.GetUserDetail(userService.GetUserModel(id.Value));

            return Content(HttpStatusCode.OK, new BaseResult<UserListViewModel>()
            {
                success = false,
                data = user
            });
        }

        [HttpPost]
        [Route("add")]
        public IHttpActionResult AddUser(UserAddModel model)
        {
            string userId;
            var validate = tokenService.ValidateToken(GetToken(), out userId);
            var userRole = userService.GetUserRoleName(Convert.ToInt32(userId));
            
            if(userRole != "Admin") //access denied
                return Content(HttpStatusCode.Forbidden, new BaseResult<dynamic>()
                {
                    success = false
                });
            if (ModelState.IsValid)
            {
                
                if(userService.UserNameExist(model.username)) //check username existance 
                    return Content(HttpStatusCode.Conflict, new BaseResult<int>()
                    {
                        success = false,
                    });

                //add user
                var result = userService.AddNewUserModel(Mapping.UserMapping.GetUserAddModel(model, Convert.ToInt32(userId)));
                return Content(HttpStatusCode.OK, new BaseResult<int>()
                {
                    success = true,
                });
            }
            //model error
            return Content(HttpStatusCode.BadRequest, new BaseResult<dynamic>()
            {
                success = false,
                data = null,
                message = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage))
            });
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IHttpActionResult DeleteUser(int id)
        {
            string userId;
            var validate = tokenService.ValidateToken(GetToken(), out userId);
            var userRole = userService.GetUserRoleName(Convert.ToInt32(userId));
            
            if (userRole != "Admin") //access denied
                return Content(HttpStatusCode.Forbidden, new BaseResult<dynamic>()
                {
                    success = false
                });

            if(Convert.ToInt32(userId) == id) // user tries to delete his own account
            {
                return Content(HttpStatusCode.BadRequest, new BaseResult<int>()
                {
                    success = true,
                });
            }
            //add user
            var result = userService.DeleteUserModel(id);
            return Content(HttpStatusCode.OK, new BaseResult<int>()
            {
                success = true,
            });
        }

        [HttpPost]
        [Route("active/{id}")]
        public IHttpActionResult ChangeUserActive(int id)
        {
            string userId;
            var validate = tokenService.ValidateToken(GetToken(), out userId);
            var userRole = userService.GetUserRoleName(Convert.ToInt32(userId));

            if (userRole != "Admin") //access denied
                return Content(HttpStatusCode.Forbidden, new BaseResult<dynamic>()
                {
                    success = false
                });

            if (userService.ChangeUserModelActive(id)) 
                return Content(HttpStatusCode.OK, new BaseResult<int>()
                {
                    success = true,
                });
            return Content(HttpStatusCode.InternalServerError, new BaseResult<int>()
            {
                success = false,
            });
        }

    }
}
