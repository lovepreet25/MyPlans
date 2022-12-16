using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlansLibrary.Models
{
    public class Pagination<T>
    {
        public int TotalPages { get; set; }

        public int Page { get; set; }
        public int PageSize { get; set; }
        public int ItemCount { get; set; }
        public IEnumerable<T> Records { get; set; }
    }
}