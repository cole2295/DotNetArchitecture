using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solution.CrossCutting.DependencyInjection;
using Solution.CrossCutting.Values;
using Solution.Domain.Domains;
using Solution.Infrastructure.Databases.Database.Context;
using Solution.Model.Models;

namespace Solution.Domain.Tests
{
	[TestClass]
	public class DomainTest
	{
		public DomainTest()
		{
			Container.RegisterServices();
			Container.AddDbContextInMemoryDatabase<DatabaseContext>();
			AuthenticationDomain = Container.GetService<IAuthenticationDomain>();
			UserDomain = Container.GetService<IUserDomain>();
		}

		public IAuthenticationDomain AuthenticationDomain { get; }
		public IUserDomain UserDomain { get; }

		[TestMethod]
		public void AuthenticationDomain_Authenticate_Exists()
		{
			var authenticationModel = new AuthenticationModel { Login = "admin", Password = "admin" };
			var result = AuthenticationDomain.Authenticate(authenticationModel);
			Assert.IsNotNull(result);
		}

		[TestMethod]
		[ExpectedException(typeof(DomainException))]
		public void AuthenticationDomain_Authenticate_Inexists()
		{
			var result = AuthenticationDomain.Authenticate(new AuthenticationModel());
			Assert.IsNull(result);
		}

		[TestMethod]
		public void UserDomain_Select()
		{
			var result = UserDomain.Select(1);
			Assert.IsNotNull(result);
		}
	}
}
