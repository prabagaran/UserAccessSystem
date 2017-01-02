using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAccessSystem
{
    public class Role
    {
        public string RoleName;

        public string RoleId;

        public HashSet<ActionType> allowedActions;

        public Role(string roleName, string roleId)
        {
            this.RoleName = roleName;
            this.RoleId = roleId;
        }
    }
}
