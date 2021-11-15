using Microsoft.EntityFrameworkCore;
using SGP.Contract.Service.PatrimonyContract;
using SGP.Model.Entity;
using SGPGeneric.Entities;
using SGPGeneric.Extensions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SGP.Patrimony.Repository.PatrimonyRepository.Service
{
    public abstract class GenericRepository<T, G> : IGenericRepository<T, G> where T : GenericEntity, new() where G : IQueryObject<T>
    {
        private readonly DbSet<T> entities;

        public GenericRepository(DbContext context)
        {
            entities = context.Set<T>();
        }

        public void Create(T obj)
        {
            entities.Add(obj);
        }

        public async Task<T> Get(long id, G filter)
        {
            return await entities.FirstOrDefaultAsync(s => s.Id == id);
        }

        public void Delete(T obj)
        {
            entities.Remove(obj);
        }

        public async Task<QueryResult<T>> Get(G filter)
        {
            var query = entities.AsQueryable();

            return await Get(query, filter);
        }
        public async Task<QueryResult<T>> Get(IQueryable<T> query, G filter, IQueryable<T> includeQuery = null)
        {
            if (filter.Id.Any())
                query = query.Where(c => filter.Id.Contains(c.Id));

            if (filter.ExcludeId.Any())
                query = query.Where(c => !filter.ExcludeId.Contains(c.Id));

            // Order By
            query = query.ApplyOrdering(filter);

            var result = new QueryResult<T>(filter)
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
                var newQuery = includeQuery ?? entities;
                var included = newQuery.Where(c => filter.IncludeId.Contains(c.Id) && !alreadyIn.Contains(c.Id)).ToList();
                result.Items = result.Items.Concat(included);
            }

            return result;
        }

        public Task<T> Get(long id)
        {
            throw new NotImplementedException();
        }

        public void Update(T obj)
        {
            entities.Update(obj);
        }
    }
}
