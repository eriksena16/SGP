using SGP.Contract.CategoryContract;
using SGP.Contract.GenericContract;
using SGP.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGP.CategoryService
{
    public class CategorysServices  : ICategoryService,  IGenericService<Category>
    {
        public Task<Category> Create()
        {
            throw new NotImplementedException();
        }

        public Task<Category> Delete()
        {
            throw new NotImplementedException();
        }

        public Task<Category> Details(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> Index()
        {
            throw new NotImplementedException();
        }

        public Task<Category> Update()
        {
            throw new NotImplementedException();
        }
    }
}
