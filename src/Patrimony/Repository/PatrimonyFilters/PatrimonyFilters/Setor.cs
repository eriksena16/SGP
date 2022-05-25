using SGP.Model.Entity;
using SGP.Patrimony.Util.PatrimonyUtil;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace LuxERP.Services.SGP.Patrimony.Repository.PatrimonyFilters
{
    public class SetorFilter : GenericFilter<Setor>, IQueryObject<Setor>
    {
        public string Nome { get; set; }

        public Dictionary<string, Expression<Func<Setor, object>>> Map()
        {
            var columnsMap = new Dictionary<string, Expression<Func<Setor, object>>>()
            {
                ["id"] = c => c.Id,
                ["nome"] = c => c.Nome
            };

            return columnsMap;
        }
    }
}