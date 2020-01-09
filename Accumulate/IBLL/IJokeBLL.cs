using AdminModel;
using Comm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public interface IJokeBLL : IPaging
    {
        List<Joke> GetJokes();
        int AddJoke(Joke joke);
        int DelJoke(IList<int> ids);
        int UpdateJoke(Joke joke);
        int Zan(int id);
        int Cai(int id);
    }
}
