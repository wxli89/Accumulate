using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comm
{
    public interface IPaging
    {
        PageModel<T> Paging<T>(string TableName, int PageSize = 20, int PageIndex = 1, string OrderBy = "ID", string Where = "");
    }
}
