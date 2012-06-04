using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSOServerLibrary
{
    public class SSOSite:ISSOSite
    {
        public SSOSite()
        {

        }
        private string siteId;
        public string SiteId
        {
            get
            {
                return siteId;
            }
            set
            {
                siteId = value;
            }
        }
        private string homepage;
        public string HomePage
        {
            get
            {
                return homepage;
            }
            set
            {
                homepage = value;
            }
        }
    }
}
