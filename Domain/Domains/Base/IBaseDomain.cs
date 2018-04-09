using Solution.Infrastructure.Databases.Database.UnitOfWork;

namespace Solution.Domain.Domains
{
	public interface IBaseDomain
	{
		IDatabaseUnitOfWork Database { get; }
	}
}
