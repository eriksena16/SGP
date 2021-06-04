using SGP.Contract.CategoryContract;
using SGP.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGP.CategoryService
{
    public class CategorysServices : ICategoryService
    {
        public Task<Category> Create(Category obj)
        {
            throw new NotImplementedException();
        }

        public Task<Category> Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Category> Update(Category obj)
        {
            throw new NotImplementedException();
        }
    }
}
