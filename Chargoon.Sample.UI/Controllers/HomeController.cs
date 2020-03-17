using Chargoon.Sample.Domain.Service;
using System.Web.Mvc;

namespace Chargoon.Sample.UI.Controllers
{
	public class HomeController : Controller
	{
		private readonly IUserService userService;

		public HomeController(IUserService userService)
		{
			this.userService = userService;
		}

		public ActionResult Index()
		{
			ViewBag.Title = "Home Page";

			try
			{
                //var usermodel = new Domain.DataModel.UserModel()
                //{
                //    FirstName = "Ali",
                //    LastName = "Rezai",
                //    UserName = "rezai.ali",
                //    CreatedUser=1,
                //    RoleId = 1,
                //    Password = "123456789",
                //};
                //var inserted = userService.AddNewUserModel(usermodel);
                //var user = userService.GetUserModel(1);

                var user = userService.CheckUserNamePassword("deldar.m", "123456789");
            }
			catch(System.Exception ex)
			{

			}

			return View();
		}
	}
}
