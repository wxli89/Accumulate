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
    public class JokeBLL : IJokeBLL
    {
        public IJokeDAL JokeDAL;
        public JokeBLL(IJokeDAL jokedal)
        {
            JokeDAL = jokedal;
        }
        public List<Joke> GetJokes()
        {
            return JokeDAL.GetJokes();
        }

        public int AddJoke(Joke joke)
        {
            return JokeDAL.AddJoke(joke);
        }

        public int DelJoke(IList<int> ids)
        {
            return JokeDAL.DelJoke(ids);
        }

        public int UpdateJoke(Joke joke)
        {
            return JokeDAL.UpdateJoke(joke);
        }

        public Comm.PageModel<T> Paging<T>(string TableName, int PageSize = 20, int PageIndex = 1, string OrderBy = "ID", string Where = "")
        {
            return JokeDAL.Paging<T>(TableName, PageSize, PageIndex, OrderBy, Where);
        }


        public int Zan(int id)
        {
            return JokeDAL.Zan(id);
        }

        public int Cai(int id)
        {
            return JokeDAL.Cai(id);
        }
    }
}
