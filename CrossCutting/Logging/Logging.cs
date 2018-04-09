using System;
using Solution.CrossCutting.Extensions;

namespace Solution.CrossCutting.Logging
{
	public class Logging : ILogging
	{
		public void Error(Exception exception)
		{
			if (exception == null) { return; }
			var message = exception.GetDetail();
		}

		public void Information(string message)
		{
			if (string.IsNullOrWhiteSpace(message)) { return; }
		}
	}
}
