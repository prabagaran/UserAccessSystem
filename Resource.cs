using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAccessSystem
{
    public class Resource
    {
        public string ResourceName { get; set; }

        private HashSet<User> Users;

        public Resource(string resourceName)
        {
            this.ResourceName = resourceName;
            Users = new HashSet<User>();
            Console.WriteLine("Created Resource : " + resourceName);
        }

        public void AddNewUser(User user)
        {
            this.Users.Add(user);
            Console.WriteLine("Adding new user to the access list of the resource " + user.UserName + "   " + ResourceName);
        }

        public HashSet<User> GetAllowedUsers()
        {
            return this.Users;
        }
    }
}
