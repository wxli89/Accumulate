using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminModel
{
    public class Menu
    {
        public int ID{ get;set;}
        public string MenuName{ get;set;}
        public int? ParentID{ get;set;}
        public string Link{ get;set;}
        public DateTime? CreateTime{ get;set;}
        public DateTime? UpdateTime{ get;set;}
        public int? Sort{ get;set;}
        public int? MenuStatus{ get;set;}
        public string Remark{ get;set;}
    }
}