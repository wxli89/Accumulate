using Network;
using System;
using System.Collections.Generic;
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
            string url = "https://www.zbjuran.com/wenzixiaohua/list_1_1.html";
            HttpWebResponse response = HttpWebResponseUtility.CreateGetHttpResponse(url);
            StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string result = sr.ReadToEnd();

        }
    }
}
