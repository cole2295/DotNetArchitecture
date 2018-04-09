using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solution.CrossCutting.DependencyInjection;
using Solution.CrossCutting.Mapping;
using Solution.Model.Enums;
using Solution.Model.Models;

namespace Solution.CrossCutting.Tests
{
	[TestClass]
	public class MappingTest
	{
		public MappingTest()
		{
			Container.RegisterServices();
			Mapping = Container.GetService<IMapping>();
		}

		public IMapping Mapping { get; }

		[TestMethod]
		public void Mapping_Map()
		{
			var userModel = new UserModel { UserId = 1 };
			userModel.UsersRoles.Add(new UserRoleModel { UserId = 1, Role = Role.Admin });
			var result = Mapping.Map<AuthenticatedModel>(userModel);

			Assert.IsNotNull(result.UserId);
			Assert.IsNotNull(result.Roles);
			Assert.IsTrue(result.Roles.Any());
		}

		[TestMethod]
		public void Mapping_Merge()
		{
			var source = new UserModel
			{
				Name = "Name",
				UserId = 1
			};

			var destination = new UserModel
			{
				Email = "email@mail.com",
				Login = "login",
				Password = "password"
			};

			var result = Mapping.Map(source, destination);

			Assert.IsNotNull(result.Email);
			Assert.IsNotNull(result.Login);
			Assert.IsNotNull(result.Name);
			Assert.IsNotNull(result.Password);
			Assert.IsNotNull(result.UserId);
		}
	}
}
