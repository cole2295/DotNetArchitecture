namespace Solution.CrossCutting.Security
{
	public interface ICriptography
	{
		string Decrypt(string text);

		string Encrypt(string text);
	}
}
