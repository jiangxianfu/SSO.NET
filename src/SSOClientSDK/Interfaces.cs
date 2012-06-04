using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSOClientSDK
{
    public interface ISSOClient
    {
        string SiteId { get; }
        string Uid { get; set; }
        string HomePage { get; }
        string LoginPage { get; }
        string GetUid(string token);
        bool SignOn(out string exInfo);
        void SignOut();
    }
}
