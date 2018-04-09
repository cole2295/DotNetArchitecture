using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Solution.CrossCutting.Values;

namespace Solution.Infrastructure.Databases
{
	public interface IRepository<TEntity> where TEntity : class
	{
		void Add(TEntity entity);

		void AddAsync(TEntity entity);

		void AddOrUpdate(TEntity entity);

		void AddRange(params TEntity[] entities);

		void AddRangeAsync(params TEntity[] entities);

		bool Any(Expression<Func<TEntity, bool>> where = null);

		Task<bool> AnyAsync(Expression<Func<TEntity, bool>> where = null);

		long Count(Expression<Func<TEntity, bool>> where = null);

		Task<long> CountAsync(Expression<Func<TEntity, bool>> where = null);

		void Delete(object key);

		TEntity Find(object key);

		Task<TEntity> FindAsync(object key);

		TEntity FirstOrDefault(Expression<Func<TEntity, bool>> where = null, params Expression<Func<TEntity, object>>[] properties);

		Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> where = null, params Expression<Func<TEntity, object>>[] properties);

		TEntity LastOrDefault(Expression<Func<TEntity, bool>> where = null, params Expression<Func<TEntity, object>>[] properties);

		Task<TEntity> LastOrDefaultAsync(Expression<Func<TEntity, bool>> where = null, params Expression<Func<TEntity, object>>[] properties);

		IEnumerable<TEntity> List(Expression<Func<TEntity, bool>> where = null, params Expression<Func<TEntity, object>>[] properties);

		PagedList<TEntity> List(PagedListParameters parameters, Expression<Func<TEntity, bool>> where = null, params Expression<Func<TEntity, object>>[] properties);

		Task<IEnumerable<TEntity>> ListAsync(Expression<Func<TEntity, bool>> where = null, params Expression<Func<TEntity, object>>[] properties);

		IQueryable<TEntity> Queryable(Expression<Func<TEntity, bool>> where = null, params Expression<Func<TEntity, object>>[] properties);

		IQueryable<TEntityResult> QueryableMapResult<TEntityResult>(Expression<Func<TEntity, TEntityResult>> result, Expression<Func<TEntity, bool>> where = null);

		TEntity SingleOrDefault(Expression<Func<TEntity, bool>> where = null, params Expression<Func<TEntity, object>>[] properties);

		Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> where = null, params Expression<Func<TEntity, object>>[] properties);

		void Update(TEntity entity, object key);
	}
}
