using System.Linq;
using Solution.CrossCutting.Security;
using Solution.Infrastructure.Databases.Database.UnitOfWork;
using Solution.Model.Enums;
using Solution.Model.Models;
using Solution.Model.Validations;

namespace Solution.Domain.Domains
{
	public sealed class AuthenticationDomain : BaseDomain, IAuthenticationDomain
	{
		public AuthenticationDomain(
			IDatabaseUnitOfWork database,
			IHash hash,
			IJsonWebToken jsonWebToken,
			IUserLogDomain userLog) : base(database)
		{
			Hash = hash;
			JsonWebToken = jsonWebToken;
			UserLog = userLog;
		}

		private IHash Hash { get; }
		private IJsonWebToken JsonWebToken { get; }
		private IUserLogDomain UserLog { get; }

		public AuthenticatedModel Authenticate(AuthenticationModel authentication)
		{
			new AuthenticationValidation().ValidateThrowException(authentication);

			authentication.Login = Hash.Generate(authentication.Login);
			authentication.Password = Hash.Generate(authentication.Password);

			var authenticated = Database.User.Authenticate(authentication);

			new AuthenticatedValidation().ValidateThrowException(authenticated);

			var userLog = UserLog.Create(authenticated.UserId, LogType.Login);
			UserLog.Add(userLog);

			return authenticated;
		}

		public string GenerateJwtToken(AuthenticatedModel authenticated)
		{
			var roles = authenticated.Roles.Select(role => role.ToString()).ToArray();
			return JsonWebToken.Encode(authenticated.UserId.ToString(), roles);
		}

		public void Logout(long userId)
		{
			var userLog = UserLog.Create(userId, LogType.Logout);
			UserLog.Add(userLog);
		}
	}
}
