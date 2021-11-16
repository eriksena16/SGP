﻿using SGP.Model.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGP.Contract.Service.PatrimonyContract.Repositories
{
    public interface IGenericRepository<TEntity> : IDisposable where TEntity : GenericEntity
    {
        Task Create(TEntity obj);
        Task<TEntity> Get(long id);
        Task<List<TEntity>> Get();
        Task Update( TEntity obj);
        Task Delete(long id);
        Task<bool> Exists(long id);

    }
}