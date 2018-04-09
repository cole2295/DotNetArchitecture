using Microsoft.EntityFrameworkCore;
using Solution.CrossCutting.Security;
using Solution.Infrastructure.Databases.EntityFrameworkCore;
using Solution.Model.Enums;
using Solution.Model.Models;

namespace Solution.Infrastructure.Databases.Database.Context
{
	public sealed class DatabaseContext : EntityFrameworkCoreContext
	{
		public DatabaseContext(DbContextOptions options) : base(options) { }

		protected override void OnModelCreatingCustom(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationFromAssembly();
		}

		protected override void Seed()
		{
			SaveUserAdministrador();
			SaveChanges();
		}

		private void SaveUserAdministrador()
		{
			if (Set<UserModel>().Find(1L) != null) { return; }

			var _hash = new Hash();

			var userModel = new UserModel
			{
				Name = "Administrator",
				Surname = "Administrator",
				Email = "administrator@administrator.com",
				Login = _hash.Generate("admin"),
				Password = _hash.Generate("admin"),
				Status = Status.Active
			};

			var userRoleModel = new UserRoleModel { UserId = 1, Role = Role.Admin };

			Set<UserModel>().Add(userModel);

			Set<UserRoleModel>().Add(userRoleModel);
		}
	}
}
