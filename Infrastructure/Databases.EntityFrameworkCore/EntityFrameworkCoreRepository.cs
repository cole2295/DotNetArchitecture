using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Solution.CrossCutting.Values;

namespace Solution.Infrastructure.Databases.EntityFrameworkCore
{
	public class EntityFrameworkCoreRepository<TEntity> : IRepository<TEntity> where TEntity : class
	{
		private readonly DbContext _context;

		protected EntityFrameworkCoreRepository(DbContext context)
		{
			_context = context;
		}

		public void Add(TEntity entity)
		{
			Set().Add(entity);
		}

		public void AddAsync(TEntity entity)
		{
			Set().AddAsync(entity);
		}

		public void AddOrUpdate(TEntity entity)
		{
			Set().Update(entity);
		}

		public void AddRange(params TEntity[] entities)
		{
			Set().AddRange(entities);
		}

		public void AddRangeAsync(params TEntity[] entities)
		{
			Set().AddRangeAsync(entities);
		}

		public bool Any(Expression<Func<TEntity, bool>> where = null)
		{
			return Queryable(where).Any();
		}

		public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> where = null)
		{
			return Queryable(where).AnyAsync();
		}

		public long Count(Expression<Func<TEntity, bool>> where = null)
		{
			return Queryable(where).LongCount();
		}

		public Task<long> CountAsync(Expression<Func<TEntity, bool>> where = null)
		{
			return Queryable(where).LongCountAsync();
		}

		public void Delete(object key)
		{
			var entityContext = Find(key);

			if (entityContext != null)
			{
				Set().Remove(entityContext);
			}
		}

		public TEntity Find(object key)
		{
			return Set().Find(key);
		}

		public Task<TEntity> FindAsync(object key)
		{
			return Set().FindAsync(key);
		}

		public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> where = null, params Expression<Func<TEntity, object>>[] properties)
		{
			return Queryable(where, properties).FirstOrDefault();
		}

		public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> where = null, params Expression<Func<TEntity, object>>[] properties)
		{
			return await Queryable(where, properties).FirstOrDefaultAsync();
		}

		public TEntity LastOrDefault(Expression<Func<TEntity, bool>> where = null, params Expression<Func<TEntity, object>>[] properties)
		{
			return Queryable(where, properties).LastOrDefault();
		}

		public Task<TEntity> LastOrDefaultAsync(Expression<Func<TEntity, bool>> where = null, params Expression<Func<TEntity, object>>[] properties)
		{
			return Queryable(where, properties).LastOrDefaultAsync();
		}

		public IEnumerable<TEntity> List(Expression<Func<TEntity, bool>> where = null, params Expression<Func<TEntity, object>>[] properties)
		{
			return Queryable(where, properties).ToList();
		}

		public PagedList<TEntity> List(PagedListParameters parameters, Expression<Func<TEntity, bool>> where = null, params Expression<Func<TEntity, object>>[] properties)
		{
			return new PagedList<TEntity>(Queryable(where, properties), parameters);
		}

		public async Task<IEnumerable<TEntity>> ListAsync(Expression<Func<TEntity, bool>> where = null, params Expression<Func<TEntity, object>>[] properties)
		{
			return await Queryable(where, properties).ToListAsync();
		}

		public IQueryable<TEntity> Queryable(Expression<Func<TEntity, bool>> where = null, params Expression<Func<TEntity, object>>[] properties)
		{
			var queryable = Set().AsQueryable();
			if (where != null) { queryable = queryable.Where(where); }
			properties?.ToList().ForEach(property => queryable = queryable.Include(property));
			return queryable;
		}

		public IQueryable<TEntityResult> QueryableMapResult<TEntityResult>(Expression<Func<TEntity, TEntityResult>> result, Expression<Func<TEntity, bool>> where = null)
		{
			return Queryable(where).Select(result);
		}

		public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> where = null, params Expression<Func<TEntity, object>>[] properties)
		{
			return Queryable(where, properties).SingleOrDefault();
		}

		public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> where = null, params Expression<Func<TEntity, object>>[] properties)
		{
			return await Queryable(where, properties).SingleOrDefaultAsync();
		}

		public void Update(TEntity entity, object key)
		{
			var entityContext = Find(key);

			if (entityContext != null)
			{
				_context.Entry(entityContext).CurrentValues.SetValues(entity);
			}
		}

		private DbSet<TEntity> Set()
		{
			return _context.Set<TEntity>();
		}
	}
}
