﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Weixin
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string echoString = Request["echoStr"].ToString();
            string token = "weixin";
            string timestamp = Request["timestamp"].ToString();
            string nonce = Request["nonce"].ToString();
            string signature = Request["signature"].ToString();
            OperatWeixin ow = new OperatWeixin();

            if (ow.checkSignature(token, timestamp, nonce, signature))
            {
                Response.Write(echoString);
                Response.End();  
            }
            else
            {
                Response.Write("微信接入失败");
            }
        }
    }
}