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
        public class DictionarySort : System.Collections.IComparer
        {
            public int Compare(object oLeft, object oRight)
            {
                string sLeft = oLeft as string;
                string sRight = oRight as string;
                int iLeftLength = sLeft.Length;
                int iRightLength = sRight.Length;
                int index = 0;
                while (index < iLeftLength && index < iRightLength)
                {
                    if (sLeft[index] < sRight[index])
                        return -1;
                    else if (sLeft[index] > sRight[index])
                        return 1;
                    else
                        index++;
                }
                return iLeftLength - iRightLength;

            }
        }
        public bool checkSignature(string token, string timestamp, string nonce, ref string signature)
        {
            string[] a = { token, timestamp, nonce };
            ArrayList AL = new ArrayList();
            AL.Add(token);
            AL.Add(timestamp);
            AL.Add(nonce);
            AL.Sort(new DictionarySort());
            string raw = "";
            for (int i = 0; i < AL.Count; ++i)
            {
                raw += AL[i];
            }
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            byte[] buffer = Encoding.UTF8.GetBytes(raw);
            byte[] data = SHA1.Create().ComputeHash(buffer);
            string hash = BitConverter.ToString(data).Replace("-", "");
            hash = hash.ToLower();
            if (hash == signature)
            {
                signature = hash;
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}