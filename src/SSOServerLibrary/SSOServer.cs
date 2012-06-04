using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace SSOServerLibrary
{
    public class SSOServer : ISSOServer
    {
        public string SiteId { get; set; }
        public SSOToken Token { get; set; }
        public string ReturnUrl { get; set; }
    }
}
