using System;
using System.Security.Cryptography;
using System.Text;

namespace Solution.CrossCutting.Security
{
	public class Hash : IHash
	{
		public string Generate(string text)
		{
			if (string.IsNullOrWhiteSpace(text)) { return null; }

			using (var algorithm = new SHA512Managed())
			{
				var bytes = algorithm.ComputeHash(Encoding.Unicode.GetBytes(text));
				return Convert.ToBase64String(bytes, 0, bytes.Length);
			}
		}
	}
}
