using SGPGeneric.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SGPGeneric.Entities
{
    public class QueryResult<T>
    {
        public QueryResult(IQueryObject<T> filter)
        {
            if (filter.PageSize == 0)
                filter.PageSize = 20;

            PageSize = filter.PageSize;
        }
        public QueryResult(int PageSize)
        {
            if (PageSize == 0)
                PageSize = 20;

            this.PageSize = PageSize;
        }
        [JsonIgnore]
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages
        {
            get
            {
                return TotalItems > 0 ? (Items.Count() == PageSize) ? (int)Math.Ceiling((double)TotalItems / Items.Count()) : (int)Math.Ceiling((double)TotalItems / PageSize) : 0;
            }
        }
        public IEnumerable<T> Items { get; set; }
    }
    public class QueryResponse<T>
    {
        public int TotalItems { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
    public class QueryResultGroup<T>
    {
        public string GroupedBy { get; set; }
        public int TotalItems { get; set; }
        public IEnumerable<ResultQueryResultGroup<T>> Items { get; set; }
    }

    public class ResultQueryResultGroup<T>
    {
        public IEnumerable<T> Items { get; set; }
        public string Name { get; set; }
    }
}