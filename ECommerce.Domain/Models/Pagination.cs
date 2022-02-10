using System.Collections.Generic;
using ECommerce.Domain.Interface;

namespace ECommerce.Domain.Models
{
    public class Pagination<T> where T : IAggregateRoot
    {
        public IEnumerable<T> List { get; set; } = new List<T>();
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Query { get; set; }
        public int TotalResult { get; set; }
    }
}