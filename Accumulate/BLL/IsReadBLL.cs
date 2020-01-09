using AdminModel;
using IBLL;
using IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class IsReadBLL : IIsReadBLL
    {
        private IIsReadDAL IsReadDAL;
        public IsReadBLL(IIsReadDAL isReadDAL)
        {
            IsReadDAL = isReadDAL;
        }
        public int AddIsRead(List<IsRead> reads)
        {
            return IsReadDAL.AddIsRead(reads);
        }
    }
}
