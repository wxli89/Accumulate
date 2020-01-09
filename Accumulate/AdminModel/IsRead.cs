using Comm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminModel
{
    public class IsRead
    {
        [IdentityAttribute]
        public int ID { get; set; }
        public int JokeID { get; set; }
        public string GUID { get; set; }
    }
}
