﻿using SGP.Contract.Service.PatrimonyContract;
using SGP.Contract.Service.PatrimonyContract.Repositories;
using SGP.Model.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGP.Patrimony.Service.PatrimonyService
{
    public class CategoriaDoItemService : ICategoriaDoItemService
    {

        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaDoItemService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<CategoriaDoItem> Create(CategoriaDoItem obj)
        {
            try
            {
                await _categoriaRepository.Create(obj);
            }
            catch (Exception ex)
            {

                throw new Exception(ex + "Aconteceu um erro");
            }


            return obj;
        }

        public async Task Delete(CategoriaDoItem obj)
        {
            await _categoriaRepository.Delete(obj);
        }

        public virtual async Task<CategoriaDoItem> Get(long id)
        {
            CategoriaDoItem categoria = await _categoriaRepository.Get(id);

            return categoria;

        }

        public async Task<List<CategoriaDoItem>> Get()
        {
            var categorias = await _categoriaRepository.Get();

            return categorias;
        }

        public async Task<CategoriaDoItem> Update(CategoriaDoItem obj)
        {
            if (!await _categoriaRepository.Exists(obj.Id)) return new CategoriaDoItem();

            var categoria = await _categoriaRepository.Get(obj.Id);

            if (categoria != null)
            {
                try
                {
                    await _categoriaRepository.Update(categoria);
                }
                catch (Exception ex)
                {

                    throw new Exception(ex + "Aconteceu um erro!");
                }
            }

            return obj;
        }

        public void Dispose()
        {
            _categoriaRepository?.Dispose();
        }
    }
}
