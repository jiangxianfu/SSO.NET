using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace SSOServerLibrary
{
    public class SSOServerState : ISSOServerState
    {
        private static readonly SSOServerState instance = new SSOServerState();
        public static Hashtable table = new Hashtable();
        public static SSOServerState Instance
        {
            get
            {
                return instance;
            }
        }
        public int GetUserCount()
        {
            return table.Count;
        }

        public ICollection GetUserCollection()
        {
            return table.Keys;
        }
        public void Add(string uid, string siteid)
        {
            lock (table)
            {
                List<string> sites = new List<string>();
                if (table.Contains(uid))
                {
                    sites = table[uid] as List<string>;
                }
                if (sites.Contains(siteid))
                {
                    return;
                }
                sites.Add(siteid);
                table[uid] = sites;
            }
        }
        public List<string> GetLoginSites(string uid)
        {
            lock (table)
            {
                List<string> sites = new List<string>();
                if (table.Contains(uid))
                {
                    sites = table[uid] as List<string>;
                }
                return sites;
            }
        }
        public void RemoveUser(string uid)
        {
            lock (table)
            {
                table.Remove(uid);
            }
        }
    }
}