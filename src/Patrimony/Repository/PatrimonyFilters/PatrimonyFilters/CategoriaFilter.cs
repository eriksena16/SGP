using SGP.Model.Entity;
using SGP.Model.Entity;
using SGP.Patrimony.Util.PatrimonyUtil;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SGP.Patrimony.Repository.PatrimonyFilters
{
    public class CategoriaFilter : GenericFilter<CategoriaDoItem>, IQueryObject<CategoriaDoItem>
    {
        public Dictionary<string, Expression<Func<CategoriaDoItem, object>>> Map()
        {
            var columnsMap = new Dictionary<string, Expression<Func<CategoriaDoItem, object>>>()
            {
                ["id"] = c => c.Id,
            };

            return columnsMap;
        }
    }
}