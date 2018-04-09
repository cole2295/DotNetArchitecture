using System.Collections.Generic;

namespace Solution.CrossCutting.Values
{
	public sealed class ValidationResult
	{
		public IDictionary<string, string> Errors { get; } = new Dictionary<string, string>();

		public bool IsValid => Errors == null || Errors.Count == 0;
	}
}
