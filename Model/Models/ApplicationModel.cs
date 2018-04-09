using System.Collections;
using Solution.CrossCutting.Extensions;
using Solution.CrossCutting.Resources;

namespace Solution.Model.Models
{
	public class ApplicationModel
	{
		public IDictionary Texts { get; set; } = typeof(Texts).ToDictionary();
	}
}
