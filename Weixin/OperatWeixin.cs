using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Weixin
{
    public class OperatWeixin
    {
        public bool checkSignature(string token, string timestamp, string nonce, string signature)
        {
            string[] a = { token, timestamp, nonce };
            List<string> list = new List<string>();
            list.Add(token);
            list.Add(timestamp);
            list.Add(nonce);
            list.Sort();
            string s = string.Join(",",list.ToArray());
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            var buffer = Encoding.UTF8.GetBytes(s);
            var data = SHA1.Create().ComputeHash(buffer);
            StringBuilder sb = new StringBuilder();
            foreach (var r in data)
            {
                sb.Append(r.ToString("X2"));
            }
            if (sb.ToString() == signature)
            {
                return true;
            }
            else
            {
                return false;
            }

            
        }
    }
}