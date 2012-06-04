using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace SSOServerLibrary
{
    public class Sites
    {
        string cfgPath = "";
        XmlDocument doc = new XmlDocument();
        public Sites()
        {
            cfgPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sites.config");
            doc.Load(cfgPath);
        }
        private static readonly Sites instance = new Sites();
        public static Sites Instance
        {
            get
            {
                return instance;
            }
        }

        public ISSOSite GetSite(string siteId)
        {
            
            XmlElement documentElement = this.doc.DocumentElement;
            string xpath = string.Format("site[@siteid='{0}']", siteId);
            XmlNode node = documentElement.SelectSingleNode(xpath);
            if (node == null)
            {
                return null;
            }
            XmlAttribute attribute = node.Attributes["homepage"];
            ISSOSite site = new SSOSite();
            site.SiteId = siteId;
            site.HomePage = "http://localhost:34391/default.aspx";
            return site;
        }
    }
}
