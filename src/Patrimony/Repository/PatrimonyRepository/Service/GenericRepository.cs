﻿using Microsoft.EntityFrameworkCore;
using SGP.Contract.Service.PatrimonyContract.Repositories;
using SGP.Model.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGP.Patrimony.Repository.PatrimonyRepository.Service
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : GenericEntity, new()
    {
        protected readonly DbSet<TEntity> entities;
        protected readonly DbContext Context;
        public GenericRepository(DbContext context)
        {
            Context = context;
            entities = context.Set<TEntity>();
        }

        public virtual async Task Create(TEntity obj)
        {
            entities.Add(obj);
            await SaveChanges();
        }

        public virtual async Task<TEntity> Get(long id)
        {
            return await entities.FirstOrDefaultAsync(s => s.Id == id);
        }

        public virtual async Task Delete(long id)
        {
            entities.Remove(new TEntity { Id = id });
            await SaveChanges();

        }

        //public async Task<QueryResult<T>> Get(G filter)
        //{
        //    var query = entities.AsQueryable();

        //    return await Get(query, filter);
        //}
        //public async Task<QueryResult<T>> Get(IQueryable<T> query, G filter, IQueryable<T> includeQuery = null)
        //{
        //    if (filter.Id.Any())
        //        query = query.Where(c => filter.Id.Contains(c.Id));

        //    if (filter.ExcludeId.Any())
        //        query = query.Where(c => !filter.ExcludeId.Contains(c.Id));

        //    // Order By
        //    query = query.ApplyOrdering(filter);

        //    var result = new QueryResult<T>(filter)
        //    {
        //        TotalItems = await query.CountAsync()
        //    };

        //    // Pagination
        //    if (filter.GetAll != true)
        //        query = query.ApplyPaging(filter);

        //    result.Items = await query.ToListAsync();

        //    if (filter.IncludeId.Any())
        //    {
        //        var alreadyIn = result.Items.Select(c => c.Id).ToList();
        //        var newQuery = includeQuery ?? entities;
        //        var included = newQuery.Where(c => filter.IncludeId.Contains(c.Id) && !alreadyIn.Contains(c.Id)).ToList();
        //        result.Items = result.Items.Concat(included);
        //    }

        //    return result;
        //}

        public virtual async Task Update(TEntity obj)
        {
            entities.Update(obj);
            await SaveChanges();
        }

        public virtual Task<List<TEntity>> Get()
        {
            return entities.ToListAsync();
        }

        public virtual async Task<int> SaveChanges()
        {
            return await Context.SaveChangesAsync();
        }

        public virtual Task<bool> Exists(long id)
        {
            return entities.AnyAsync(c=> c.Equals(id));
        }
        public void Dispose()
        {
            Context?.Dispose();
        }

        
    }
}
