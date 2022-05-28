using SGP.Model.Entity;
using SGP.Patrimony.Util.PatrimonyUtil;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SGP.Patrimony.Repository.PatrimonyFilters
{
    public class FabricanteFilter : GenericFilter<Fabricante>, IQueryObject<Fabricante>
    {
        public string? Nome { get; set; }

        public Dictionary<string, Expression<Func<Fabricante, object>>> Map()
        {
            var columnsMap = new Dictionary<string, Expression<Func<Fabricante, object>>>()
            {
                ["id"] = c => c.Id,
                ["nome"] = c => c.Nome
            };

            return columnsMap;
        }
    }
}