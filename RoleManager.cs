using System;
using System.Collections.Generic;

namespace UserAccessSystem
{
    public class RoleManager
    {
        private Dictionary<string, Role> Roles;

        private static RoleManager roleManager;

        private static object lockrolemgr = new object();

        private static object lockroles = new object();

        private RoleManager()
        {
            Roles = new Dictionary<string, Role>();
            InitializeRoles();
        }

        private void InitializeRoles()
        {
            lock (lockroles)
            {
                Role r = new Role("Guest", "R1");
                r.allowedActions = new HashSet<ActionType> { };
                Roles[r.RoleName] = r;

                r = new Role("User", "R2");
                r.allowedActions = new HashSet<ActionType> { ActionType.READ };
                Roles[r.RoleName] = r;

                r = new Role("Admin", "R3");
                r.allowedActions = new HashSet<ActionType> { ActionType.READ, ActionType.WRITE };
                Roles[r.RoleName] = r;

                r = new Role("SuperAdmin", "R4");
                r.allowedActions = new HashSet<ActionType> { ActionType.READ, ActionType.WRITE, ActionType.DELETE };
                Roles[r.RoleName] = r;
            }
        }

        public static RoleManager GetRoleManager()
        {
            lock(lockrolemgr)
            {
                if(roleManager == null)
                {
                    roleManager = new RoleManager();
                }
            }
            return roleManager;
        }

        public void AssignRoleToUser(User user, string roleName)
        {
            lock (lockroles)
            {
                user.Roles[roleName] = Roles[roleName];
            }
            Console.WriteLine("Assinging new Role to user " + roleName + " " + user.UserName);
        }

        public void RevokeRoleToUser(User user, string roleName)
        {
            lock (lockroles)
            {
                if (user.Roles.ContainsKey(roleName))
                {
                    user.Roles.Remove(roleName);
                }
            }
            Console.WriteLine("Removing Role user " + roleName + " " + user.UserName);
        }

        public bool HasAccess(User user, ActionType actionType, Resource resource)
        {
            if (resource.GetAllowedUsers().Contains(user))
            {
                var roles = user.Roles;
                lock (lockroles)
                {
                    foreach (KeyValuePair<string, Role> role in roles)
                    {
                        if (role.Value.allowedActions.Contains(actionType))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
