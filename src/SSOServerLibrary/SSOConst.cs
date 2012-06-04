using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;

namespace SSOServerLibrary
{
    public class SSOConst
    {
        private static string publicKey = ReadFile("publickey.config");
        private static string privateKey = ReadFile("privatekey.config");
        private static string signOnUrl = System.Configuration.ConfigurationManager.AppSettings["SignOnUrl"];
        public static string PublicKey
        {
            get { return publicKey; }
        }
        public static string PrivateKey
        {
            get { return privateKey; }
        }
        public static string SignOnUrl
        {
            get { return signOnUrl; }
        }
        private static string ReadFile(string filename)
        {
            string fullname = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename);
            if (!File.Exists(fullname))
            {
                throw new System.Exception(string.Format("{0}_文件不存在", fullname));
            }
            return File.ReadAllText(fullname);
        }
    }
}
