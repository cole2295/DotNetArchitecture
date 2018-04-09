using System.Linq;
using Solution.CrossCutting.Resources;
using Solution.CrossCutting.Values;
using Solution.Model.Models;

namespace Solution.Model.Validations
{
	public sealed class AuthenticatedValidation : Validation<AuthenticatedModel>
	{
		public override ValidationResult Validate(AuthenticatedModel obj)
		{
			var validationResult = new ValidationResult();

			if (obj == null || obj.UserId == 0 || obj.Roles == null || !obj.Roles.Any())
			{
				validationResult.Errors.Add(nameof(Texts.AuthenticationInvalid), Texts.AuthenticationInvalid);
			}

			return validationResult;
		}
	}
}
