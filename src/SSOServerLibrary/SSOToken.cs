using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace SSOServerLibrary
{
    public class SSOToken : ISSOToken
    {
        RSACryption rsa = new RSACryption();

        public SSOToken()
        {
        }
        public SSOToken(string token)
        {
            try
            {
                if (string.IsNullOrEmpty(token))
                {
                    return;
                }
                string v = rsa.RSADecrypt(SSOConst.PrivateKey, token);
                string[] vs = v.Split(',');
                Uid = vs[0];
                TimeSpan = new TimeSpan(Convert.ToInt64(vs[1]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string GetToken()
        {
            try
            {
                if (string.IsNullOrEmpty(Uid))
                {
                    return null;
                }
                string v = string.Format("{0},{1}", Uid, TimeSpan.Ticks);
                return rsa.RSAEncrypt(SSOConst.PublicKey, v);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string Uid { get; set; }
        public TimeSpan TimeSpan { get; set; }
    }
}
