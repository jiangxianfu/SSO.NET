using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace SSOServerLibrary
{
    public class Users
    {
        private static readonly Users instance = new Users();
        public static Users Instance
        {
            get
            {
                return instance;
            }
        }
        string cfgPath = "";
        XmlDocument doc = new XmlDocument();
        public Users()
        {
            cfgPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "users.config");
            doc.Load(cfgPath);
        }
        public int Validate(string username, string password)
        {
            XmlElement documentElement = this.doc.DocumentElement;
            string xpath = string.Format("user[@uid='{0}']", username);
            XmlNode node = documentElement.SelectSingleNode(xpath);
            if (node == null)
            {
                return -1;
            }
            XmlAttribute attribute = node.Attributes["pwd"];
            if (attribute.Value == password)
            {
                return 1;
            }
            return 0;
        }
        public ISSOUser GetUser(string uid)
        {
            XmlElement documentElement = this.doc.DocumentElement;
            string xpath = string.Format("user[@uid='{0}']", uid);
            XmlNode node = documentElement.SelectSingleNode(xpath);
            if (node == null)
            {
                return null;
            }
            XmlAttribute attribute = node.Attributes["pwd"];
            var user = new SSOUser();
            user.Uid = uid;
            user.Password = attribute.Value;
            return user;
        }
    }
}