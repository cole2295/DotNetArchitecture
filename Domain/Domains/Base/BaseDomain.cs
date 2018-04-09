using Solution.Infrastructure.Databases.Database.UnitOfWork;

namespace Solution.Domain.Domains
{
	public abstract class BaseDomain : IBaseDomain
	{
		protected BaseDomain(IDatabaseUnitOfWork database)
		{
			Database = database;
		}

		public IDatabaseUnitOfWork Database { get; }
	}
}
