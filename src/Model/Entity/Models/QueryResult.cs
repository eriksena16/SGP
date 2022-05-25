using Newtonsoft.Json;
using SGP.Patrimony.Util.PatrimonyUtil;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SGP.Model.Entity
{
    public class QueryResult<T> : QueryResultFields<T>
    {
        public QueryResult(IQueryObject<T> filter)
        {
            if (filter.Page == 0)
                filter.Page = 1;

            if (filter.PageSize == 0)
                filter.PageSize = 20;

            Page = filter.Page;
            PageSize = filter.PageSize;
        }
        public QueryResult(int PageSize)
        {
            if (PageSize == 0)
                PageSize = 20;

            Page = 1;
            this.PageSize = PageSize;
        }
    }
    public class QueryResultFields<T>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages
        {
            get
            {
                return TotalItems > 0 ? (Items.Count() == PageSize) ? (int)Math.Ceiling((double)TotalItems / Items.Count()) : (int)Math.Ceiling((double)TotalItems / PageSize) : 1;
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
    public class Total
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Balance { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public decimal? TotalAmount { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Amount { get; set; }
    }
}