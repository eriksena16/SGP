using Microsoft.EntityFrameworkCore;
using SGP.Contract.Service.PatrimonyContract.Repositories;
using SGP.Model.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGP.Patrimony.Repository.PatrimonyRepository.Service
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity, new()
    {
        protected readonly DbSet<TEntity> DbSet;
        protected readonly DbContext Db;
        public GenericRepository(DbContext context)
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

        public virtual async Task Delete(TEntity obj)
        {
            DbSet.Remove(obj);

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

        public virtual Task<bool> Exists(long id)
        {
            return DbSet.AnyAsync(c => c.Id.Equals(id));
        }
        public void Dispose()
        {
            Db?.Dispose();
        }


    }
}
