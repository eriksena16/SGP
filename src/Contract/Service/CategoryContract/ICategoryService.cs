using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SGP.Entity;

namespace SGP.CategoryContract
{
   public interface ICategoryService
    {
        Task<List<Category>> Get();
    }
}
