using DAL;
using HtmlAgilityPack;
using Network;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace cj
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 3665; i++)
            {
                List<Joke> list = new List<Joke>();
                string url = "https://www.zbjuran.com/wenzixiaohua/list_1_{0}.html";
                url = string.Format(url, i);
                HttpWebResponse response = HttpWebResponseUtility.CreateGetHttpResponse(url);
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("gb2312"));
                string result = sr.ReadToEnd();
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(result);
                HtmlNode main = doc.DocumentNode.SelectSingleNode("//div[@class='main']");
                HtmlNodeCollection item = main.SelectNodes("./div[@class='item']");
                foreach (var one in item)
                {
                    HtmlNode title = one.SelectSingleNode("./h3");
                    HtmlNode time = one.SelectSingleNode("./span");
                    HtmlNode content = one.SelectSingleNode("./div");
                    if (title == null || time == null || content == null) continue;
                    list.Add(new Joke()
                    {
                        content = content.InnerText,
                        title = title.InnerText,
                        createtime = time.InnerText
                    });
                }
                DataTable dt = list.ListToDT<Joke>();
                SqlHelper.SqlBulkCopyInsert("joke", dt);
            }
        }
    }
    class Joke
    {
        public int id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public string createtime { get; set; }        
    }
}
