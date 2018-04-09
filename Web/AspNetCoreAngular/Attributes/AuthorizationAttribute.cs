using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Solution.Model.Enums;

namespace Solution.Web.AspNetCoreAngular.Attributes
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
	public class AuthorizationAttribute : AuthorizeAttribute
	{
		public AuthorizationAttribute(params Role[] roles)
		{
			Roles = string.Join(", ", roles.Select(role => Enum.GetName(role.GetType(), role)));
		}
	}
}
