using System;
using System.Collections.Generic;
using System.Linq;

namespace SGPGeneric.Extensions
{
    public static class IQueryableExtensions
    {
        public static List<T> ApplyPaging<T>(this List<T> query, IQueryObject<T> filter)
        {
            if (filter.Page <= 0)
                filter.Page = 1;

            if (filter.PageSize <= 0)
                filter.PageSize = 10;

            return query.Skip((filter.Page - 1) * filter.PageSize).Take(filter.PageSize).ToList();
        }
        public static List<T> ApplyOrdering<T>(this List<T> list, IQueryObject<T> filter)
        {
            var query = list.AsQueryable();
            if (filter.Sort != null && filter.Sort.Any())
            {
                var isSortAscending = !filter.Sort.Any(c => c.Contains("-"));
                filter.Sort = filter.Sort.Select(c => { c = c.ToLower().Replace("-", ""); return c; }).ToList();
                var map = filter.Map();

                if (filter.Sort.Any())
                {
                    return (isSortAscending) ? query.OrderBy(map[filter.Sort[0]]).ToList() : query.OrderByDescending(map[filter.Sort[0]]).ToList();
                }
            }
            return query.ToList();
        }
        public static IQueryable<T> ApplyOrdering<T>(this IQueryable<T> query, IQueryObject<T> filter)
        {
            if (filter.Sort != null && filter.Sort.Any())
            {
                var isSortAscending = !filter.Sort.Any(c => c.Contains("-"));
                filter.Sort = filter.Sort.Select(c => { c = c.ToLower().Replace("-", ""); return c; }).ToList();
                var map = filter.Map();

                if (filter.Sort.Any())
                {
                    var orderedQuery = (isSortAscending) ? query.OrderBy(map[filter.Sort[0]]) : query.OrderByDescending(map[filter.Sort[0]]);
                    foreach (var field in filter.Sort.Skip(1))
                    {
                        if (!String.IsNullOrWhiteSpace(field) && map.ContainsKey(field))
                            orderedQuery = isSortAscending ? orderedQuery.ThenBy(map[field]) : orderedQuery.ThenBy(map[field]);
                    }
                    query = orderedQuery;
                }
            }
            return query;
        }
        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, IQueryObject<T> filter)
        {
            if (filter.Page <= 0)
                filter.Page = 1;

            if (filter.PageSize <= 0)
                filter.PageSize = 20;

            return query.Skip((filter.Page - 1) * filter.PageSize).Take(filter.PageSize);
        }

        public static IQueryable<long> ApplyPaging<T>(this IQueryable<long> query, IQueryObject<T> filter)
        {
            if (filter.Page <= 0)
                filter.Page = 1;

            if (filter.PageSize <= 0)
                filter.PageSize = 20;

            return query.Skip((filter.Page - 1) * filter.PageSize).Take(filter.PageSize);
        }
    }
}