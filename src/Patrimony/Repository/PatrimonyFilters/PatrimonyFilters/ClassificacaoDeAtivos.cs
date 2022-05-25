using SGP.Model.Entity;
using SGP.Patrimony.Util.PatrimonyUtil;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace LuxERP.Services.SGP.Patrimony.Repository.PatrimonyFilters
{
    public class ClassificacaoDeAtivosFilter : GenericFilter<ClassificacaoDeAtivos>, IQueryObject<ClassificacaoDeAtivos>
    {
        public string Nome { get; set; }

        public Dictionary<string, Expression<Func<ClassificacaoDeAtivos, object>>> Map()
        {
            var columnsMap = new Dictionary<string, Expression<Func<ClassificacaoDeAtivos, object>>>()
            {
                ["id"] = c => c.Id,
                ["nome"] = c => c.Nome
            };

            return columnsMap;
        }
    }
}