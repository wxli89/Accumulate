using AdminModel;
using IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comm;
using Dapper;

namespace DAL
{
    public class JokeDAL : IJokeDAL
    {
        public List<Joke> GetJokes()
        {
            string sql = @"SELECT ID,MenuName,ParentID,Link,CreateTime,UpdateTime,Sort,MenuStatus,
                        Remark FROM [dbo].[Joke] ORDER BY Sort ";
            return SqlHelper.ExecuteRead((con) => con.Query<Joke>(sql).ToList());
        }
        public int AddJoke(Joke joke)
        {
            return SqlHelper.ExecuteWrite((con) => con.Insert(joke));
        }
        public int DelJoke(IList<int> ids)
        {
            string sql = "DELETE Menu WHERE ID IN @ids";
            return SqlHelper.ExecuteWrite((con) => con.Execute(sql, new { ids = ids }));
        }
        public int UpdateJoke(Joke joke)
        {
            return 1;
        }
        public PageModel<T> Paging<T>(string TableName, int PageSize = 20, int PageIndex = 1, string OrderBy = "ID", string Where = "")
        {
            return SqlHelper.ExecuteRead((con) => con.Paging<T>(TableName, PageSize, PageIndex, OrderBy, Where));
        }


        public int Zan(int id)
        {
            string sql = "UPDATE joke SET Zan = Zan + 1 WHERE ID = @id";
            return SqlHelper.ExecuteWrite((con) => con.Execute(sql, new { id = id }));
        }

        public int Cai(int id)
        {
            string sql = "UPDATE joke SET Cai = Cai + 1 WHERE ID = @id";
            return SqlHelper.ExecuteWrite((con) => con.Execute(sql, new { id = id }));
        }
    }
}
