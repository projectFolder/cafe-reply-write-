using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using WindowsFormsApp1;
using aiswing_product;
using aiswing_product.CustomControl;
using WindowsFormsApp1.Class;

namespace WindowsFormsApp2.Class
{
    public class HttpWebRequetClass
    {

        private MainForm main;

        #region [ Constructor ]

        public HttpWebRequetClass(MainForm main)
        {
            this.main = main;
        }

        #endregion

        #region [ get club info ]

        public Tuple<String, String, String> get_info(String url)
        {

            String html = "";

            HttpWebRequest PostReq = (HttpWebRequest)HttpWebRequest.Create(url);
            PostReq.Method = "GET";
            PostReq.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/86.0.4240.75 Safari/537.36";

            WebResponse res = PostReq.GetResponse();
            using (StreamReader sr = new StreamReader(res.GetResponseStream(), System.Text.UTF8Encoding.Default))
            {
                html = sr.ReadToEnd();
            }

            String _clubid = Regex.Split(Regex.Split(html, "var g_sClubId = \"")[1], "\"")[0];
            String _cafeName = Regex.Split(Regex.Split(html, "var cafenameTitle = \"")[1], "\"")[0];
            String _boardName = Regex.Split(Regex.Split(html, "<h3 class=\"sub-tit-color\">")[1], "<")[0];

            return Tuple.Create(_clubid, _cafeName, _boardName);

        }

        #endregion

    }
}
