namespace Solution.CrossCutting.Security
{
	public interface IHash
	{
		string Generate(string text);
	}
}
