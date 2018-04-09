using System.Collections.Generic;
using System.Linq;

namespace Solution.CrossCutting.Extensions
{
	public static class EnumerableExtensions
	{
		public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> enumerable)
		{
			return enumerable ?? Enumerable.Empty<T>();
		}
	}
}
