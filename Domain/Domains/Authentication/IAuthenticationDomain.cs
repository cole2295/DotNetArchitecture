using Solution.Model.Models;

namespace Solution.Domain.Domains
{
	public interface IAuthenticationDomain : IBaseDomain
	{
		AuthenticatedModel Authenticate(AuthenticationModel authentication);

		string GenerateJwtToken(AuthenticatedModel authenticated);

		void Logout(long userId);
	}
}
