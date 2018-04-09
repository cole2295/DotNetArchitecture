using Microsoft.IdentityModel.Tokens;

namespace Solution.CrossCutting.Security
{
	public interface IJsonWebToken
	{
		T Decode<T>(string token);

		string Encode(string sub, string[] roles = null, object data = null);

		TokenValidationParameters GetTokenValidationParameters();
	}
}
