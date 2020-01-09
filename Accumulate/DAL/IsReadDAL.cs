using AdminModel;
using IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class IsReadDAL:IIsReadDAL
    {
        public int AddIsRead(List<IsRead> reads)
        {
            return SqlHelper.ExecuteWrite((con) => con.InsertList(reads, reads[0]));
        }
    }
}
