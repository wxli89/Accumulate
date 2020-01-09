using Comm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminModel
{
    public class Account
    {
         [Identity]
        public int ID { get; set; }
        public string AccountName { get; set; }
        public int Tel { get; set; }
        public string Pwd { get; set; }
        public string Salt { get; set; }
        public string GUID { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime LastTime { get; set; }
    }
}
