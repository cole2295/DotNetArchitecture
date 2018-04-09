using Solution.Infrastructure.Databases.Database.Repositories;

namespace Solution.Infrastructure.Databases.Database.UnitOfWork
{
	public interface IDatabaseUnitOfWork
	{
		IUserRepository User { get; }

		IUserLogRepository UserLog { get; }

		IUserRoleRepository UserRole { get; }

		void DiscardChanges();

		void SaveChanges();
	}
}
