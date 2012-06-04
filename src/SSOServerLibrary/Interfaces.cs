using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace SSOServerLibrary
{
    public interface ISSOSite
    {
        string SiteId { get; set; }
        string HomePage { get; set; }
    }
    public interface ISSOServer
    {
        string SiteId { get; set; }
        SSOToken Token { get; set; }
        string ReturnUrl { get; set; }
    }
    public interface ISSOToken
    {
        string GetToken();
        string Uid { get; set; }
        //string SiteId { get; set; }
        TimeSpan TimeSpan { get; set; }
    }
    public interface ISSOController
    {
        ISSOServer GetRequestSSOServer();
        string GetResponseToken();
        int CheckUser(string uid, string password, string siteid);
        bool CheckUser();
        void Redirect(string returnUrl);
        void SignOut();
        void SignOn(string uid, string siteid, string returnUrl);
    }
    public interface ISSOServerState
    {
        void Add(string uid, string siteid);
        List<string> GetLoginSites(string uid);
        ICollection GetUserCollection();
        int GetUserCount();
        void RemoveUser(string uid);
    }
    public interface ISSOUser
    {
        string Uid { get; set; }
        string Password { get; set; }
    }
}
