using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SGPGeneric.Extensions
{
    public interface IQueryObject<T>
    {
        long ConnectedAccountId { get; set; }
        bool IsAdmin { get; set; }
        bool? GetAll { get; set; }
        List<string> Sort { get; set; }
        int Page { get; set; }
        int PageSize { get; set; }
        public List<long> IncludeId { get; set; }
        public List<long> ExcludeId { get; set; }
        public List<long> Id { get; set; }
        Dictionary<string, Expression<Func<T, object>>> Map();
    }
}