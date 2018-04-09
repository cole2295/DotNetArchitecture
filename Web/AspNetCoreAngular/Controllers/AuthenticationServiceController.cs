using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Solution.Application.Applications;
using Solution.CrossCutting.Extensions;
using Solution.Model.Enums;
using Solution.Model.Models;
using Solution.Web.AspNetCoreAngular.Attributes;

namespace Solution.Web.AspNetCoreAngular.Controllers
{
	public class AuthenticationServiceController : BaseController
	{
		public AuthenticationServiceController(IAuthenticationApplication authentication)
		{
			Authentication = authentication;
		}

		private IAuthenticationApplication Authentication { get; }

		[AllowAnonymous]
		[HttpPost]
		public IActionResult Authenticate([FromBody]AuthenticationModel authentication)
		{
			var authenticated = Authentication.Authenticate(authentication);
			var token = Authentication.GenerateJwtToken(authenticated);
			return Json(token);
		}

		[Authorization(Role.Admin)]
		[HttpGet]
		public IActionResult GetAuthenticatedUserId()
		{
			return Json(User.GetAuthenticatedUserId());
		}

		[HttpPost]
		public void Logout()
		{
			Authentication.Logout(User.GetAuthenticatedUserId());
		}
	}
}
