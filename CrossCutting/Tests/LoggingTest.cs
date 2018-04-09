using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solution.CrossCutting.DependencyInjection;
using Solution.CrossCutting.Logging;

namespace Solution.CrossCutting.Tests
{
	[TestClass]
	public class LoggingTest
	{
		public LoggingTest()
		{
			Container.RegisterServices();
			Logging = Container.GetService<ILogging>();
		}

		public ILogging Logging { get; }

		[TestMethod]
		public void Logging_Information_Error()
		{
			Logging.Information("Information A");
			Logging.Error(new Exception("Exception 1"));
			Logging.Error(new Exception("Exception 2"));
			Logging.Information("Information B");
			Logging.Information("Information C");

			try
			{
				var a = 10;
				var b = 0;
				var c = a / b;
			}
			catch (Exception e)
			{
				Logging.Error(e);
			}
		}
	}
}
