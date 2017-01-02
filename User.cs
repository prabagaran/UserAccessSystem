using System;
using System.Collections.Generic;

namespace UserAccessSystem
{
    public class User
    {
        public string UserName { get; set; }

        public string UserId { get; set; }

        public Dictionary<string, Role> Roles;

        public HashSet<Resource> Resources;

        public User(string userName, string userId)
        {
            this.UserId = userId;
            this.UserName = userName;
            Roles = new Dictionary<string, Role>();
            Resources = new HashSet<Resource>();
            Console.WriteLine("Creating user " + userName + " with no roles");
        }
    }
}
