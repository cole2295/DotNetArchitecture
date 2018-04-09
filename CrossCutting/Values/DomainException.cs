using System;

namespace Solution.CrossCutting.Values
{
	public sealed class DomainException : Exception
	{
		public DomainException(string message) : base(message) { }
	}
}
