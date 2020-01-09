using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comm
{
    public class PageModel<T>
    {
        public List<T> Data { get; set; }
        public PageInfo PageInfo { get; set; }

    }
    public class PageInfo
    {
        public int Total { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
    }
}
