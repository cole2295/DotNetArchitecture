using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Solution.CrossCutting.Security
{
	public class Criptography : ICriptography
	{
		public string Key { get; set; }

		public string Salt { get; set; }

		private SymmetricAlgorithm Algorithm
		{
			get
			{
				if (string.IsNullOrWhiteSpace(Salt)) { Salt = Key; }

				var key = new Rfc2898DeriveBytes(Key, Encoding.ASCII.GetBytes(Salt));

				var algorithm = new RijndaelManaged { BlockSize = 256 };

				algorithm.Key = key.GetBytes(algorithm.KeySize / 8);

				algorithm.IV = key.GetBytes(algorithm.BlockSize / 8);

				return algorithm;
			}
		}

		public string Decrypt(string text)
		{
			var result = Transform(Convert.FromBase64String(text), Algorithm.CreateDecryptor());
			return Encoding.Unicode.GetString(result);
		}

		public string Encrypt(string text)
		{
			var result = Transform(Encoding.Unicode.GetBytes(text), Algorithm.CreateEncryptor());
			return Convert.ToBase64String(result);
		}

		private static byte[] Transform(byte[] bytes, ICryptoTransform transform)
		{
			using (var memoryStream = new MemoryStream())
			{
				var cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
				cryptoStream.Write(bytes, 0, bytes.Length);
				cryptoStream.Close();
				return memoryStream.ToArray();
			}
		}
	}
}
