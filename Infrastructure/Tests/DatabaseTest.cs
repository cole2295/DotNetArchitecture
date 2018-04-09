using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solution.CrossCutting.DependencyInjection;
using Solution.Infrastructure.Databases.Database.Context;
using Solution.Infrastructure.Databases.Database.UnitOfWork;
using Solution.Model.Enums;
using Solution.Model.Models;

namespace Solution.Infrastructure.Tests
{
	[TestClass]
	public class DatabaseTest
	{
		public DatabaseTest()
		{
			Container.RegisterServices();
			Container.AddDbContextInMemoryDatabase<DatabaseContext>();
			DatabaseUnitOfWork = Container.GetService<IDatabaseUnitOfWork>();
		}

		public IDatabaseUnitOfWork DatabaseUnitOfWork { get; }

		[TestMethod]
		public void DatabaseUnitOfWork_Repository()
		{
			// Add
			var userAdd = new UserModel
			{
				Name = "Name",
				Surname = "Surname",
				Email = "email@email.com",
				Login = "login",
				Password = "password",
				Status = Status.Active
			};

			// Add
			DatabaseUnitOfWork.User.Add(userAdd);
			DatabaseUnitOfWork.SaveChanges();

			// Select
			var userExists = DatabaseUnitOfWork.User.Find(userAdd.UserId);

			// Update
			userExists.Name = "Updated";
			DatabaseUnitOfWork.User.Update(userExists, userAdd.UserId);
			DatabaseUnitOfWork.SaveChanges();

			// Delete
			DatabaseUnitOfWork.User.Delete(userAdd.UserId);
			DatabaseUnitOfWork.SaveChanges();

			// Count
			var count = DatabaseUnitOfWork.User.Count();
			Assert.IsTrue(count > 0);
		}
	}
}
