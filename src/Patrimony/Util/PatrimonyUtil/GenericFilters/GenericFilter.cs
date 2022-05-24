
using System.Collections.Generic;

namespace SGP.Patrimony.Util.PatrimonyUtil
{
    public abstract class GenericFilter<T>
    {
        public GenericFilter()
        {
            Sort = new List<string>();
            Id = new List<long>();
            IncludeId = new List<long>();
            ExcludeId = new List<long>();
            Totals = new List<string>();
        }
        public long ConnectedUserId { get; set; }
        public long ConnectedAccountId { get; set; }
        public bool IsAdmin { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public bool? GetAll { get; set; }
        public bool Minimal { get; set; }
        public List<long> Id { get; set; }
        public List<long> IncludeId { get; set; }
        public List<long> ExcludeId { get; set; }
        public List<string> Sort { get; set; }
        public List<string> Totals { get; set; }
    }
}
