using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Weixin
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string echoString = Request["echoStr"].ToString();
            //string token = "weixin";
            //string timestamp = Request["timestamp"].ToString();
            //string nonce = Request["nonce"].ToString();
            //string signature = Request["signature"].ToString();
            OperatWeixin ow = new OperatWeixin();
            //string a = ow.HttpGET("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=wx5d560f982a31abb7&secret=5c5eb9c763b30bab2c1d938d7ef078d8");
            //if (ow.checkSignature(token, timestamp, nonce, signature))
            //{
            //    Response.Write(echoString);
            //    Response.End();  
            //}
            //else
            //{
            //    Response.Write("微信接入失败");
            //}
            FileStream fs1 = new FileStream(Server.MapPath(".") + "\\menu.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs1, Encoding.GetEncoding("GBK"));
            string menu = sr.ReadToEnd();
            sr.Close();
            fs1.Close();
            ow.HttpPOST("https://api.weixin.qq.com/cgi-bin/menu/create?SkmbjJtJz7ZkmM3Nek5N4l8CwmLLq7SRTD022jtOe8a2AYMm-JqA9aNr4R9GZ8UbFF0-UOvaA_3xjAmqIxhr9hXzhUFw2SUASUzocPdgY7NKCB5HtYiF-H1kqjGLxUpmDAYfAIAQNL", menu);  
        }
    }
}