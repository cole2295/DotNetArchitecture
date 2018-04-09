using System;

namespace Solution.CrossCutting.Security
{
	public static class JsonWebTokenSettings
	{
		public static string Audience { get; set; } = nameof(Audience);

		public static int ExpirationTime { get; set; } = 1;

		public static string Issuer { get; set; } = nameof(Issuer);

		public static string SecurityKey { get; } = Guid.NewGuid() + DateTime.UtcNow.ToString();
	}
}
