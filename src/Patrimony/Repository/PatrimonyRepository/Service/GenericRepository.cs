using Microsoft.EntityFrameworkCore;
using SGP.Contract.Service.PatrimonyContract.Repositories;
using SGP.Model.Entity;
using SGP.Patrimony.Util.PatrimonyUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SGP.Patrimony.Repository.PatrimonyRepository.Service
{
    public abstract class GenericRepository<TEntity, G> : IGenericRepository<TEntity, G> where TEntity : BaseEntity, new() where G : IQueryObject<TEntity>
    {
        protected readonly DbSet<TEntity> DbSet;
        protected readonly SGPContext Db;
        public GenericRepository(SGPContext context)
        {
            Db = context;
            DbSet = context.Set<TEntity>();
        }

        public virtual async Task Create(TEntity obj)
        {
            DbSet.Add(obj);
            await SaveChanges();
        }

        public virtual async Task<TEntity> Get(long id)
        {
            return await DbSet.FindAsync(id);
        }
        public virtual TEntity GetAsNoTrackingId(long id)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Id == id);
        }

        public virtual async Task Delete(long id)
        {
            DbSet.Remove(new TEntity { Id = id });

            await SaveChanges();
        }

        public virtual async Task Update(TEntity obj)
        {
            DbSet.Update(obj);
            await SaveChanges();
        }

        public virtual Task<List<TEntity>> Get()
        {
            return DbSet.ToListAsync();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate)
        {

            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();

        }
        public async Task<QueryResult<TEntity>> Get(G filter)
        {
            var query = DbSet.AsQueryable();

            return await Get(query, filter);
        }

        public async Task<QueryResult<TEntity>> Get(IQueryable<TEntity> query, G filter, IQueryable<TEntity> includeQuery = null)
        {
            if (filter.Id.Any())
                query = query.Where(c => filter.Id.Contains(c.Id));

            if (filter.ExcludeId.Any())
                query = query.Where(c => !filter.ExcludeId.Contains(c.Id));

            // Order By
            query = query.ApplyOrdering(filter);

            var result = new QueryResult<TEntity>(filter)
            {
                TotalItems = await query.CountAsync()
            };

            // Pagination
            if (filter.GetAll != true)
                query = query.ApplyPaging(filter);

            result.Items = await query.ToListAsync();

            if (filter.IncludeId.Any())
            {
                var alreadyIn = result.Items.Select(c => c.Id).ToList();
                var newQuery = includeQuery ?? DbSet;
                var included = newQuery.Where(c => filter.IncludeId.Contains(c.Id) && !alreadyIn.Contains(c.Id)).ToList();
                result.Items = result.Items.Concat(included);
            }

            return result;
        }


        public void Dispose()
        {
            Db?.Dispose();
        }

        
    }
}
