using System;

namespace UserAccessSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            RoleManager rm = RoleManager.GetRoleManager();
            User u1 = new User("Praba", "E1");
            Resource r1 = new Resource("Resource1");
            r1.AddNewUser(u1);

            Console.WriteLine(rm.HasAccess(u1, ActionType.READ, r1));
            Console.WriteLine(rm.HasAccess(u1, ActionType.WRITE, r1));
            Console.WriteLine(rm.HasAccess(u1, ActionType.DELETE, r1));

            rm.AssignRoleToUser(u1, "Guest");
            Console.WriteLine(rm.HasAccess(u1, ActionType.READ, r1));
            Console.WriteLine(rm.HasAccess(u1, ActionType.WRITE, r1));
            Console.WriteLine(rm.HasAccess(u1, ActionType.DELETE, r1));

            rm.AssignRoleToUser(u1, "User");
            Console.WriteLine(rm.HasAccess(u1, ActionType.READ, r1));
            Console.WriteLine(rm.HasAccess(u1, ActionType.WRITE, r1));
            Console.WriteLine(rm.HasAccess(u1, ActionType.DELETE, r1));

            rm.AssignRoleToUser(u1, "Admin");
            Console.WriteLine(rm.HasAccess(u1, ActionType.READ, r1));
            Console.WriteLine(rm.HasAccess(u1, ActionType.WRITE, r1));
            Console.WriteLine(rm.HasAccess(u1, ActionType.DELETE, r1));

            rm.AssignRoleToUser(u1, "SuperAdmin");
            Console.WriteLine(rm.HasAccess(u1, ActionType.READ, r1));
            Console.WriteLine(rm.HasAccess(u1, ActionType.WRITE, r1));
            Console.WriteLine(rm.HasAccess(u1, ActionType.DELETE, r1));

            rm.RevokeRoleToUser(u1, "SuperAdmin");
            Console.WriteLine(rm.HasAccess(u1, ActionType.READ, r1));
            Console.WriteLine(rm.HasAccess(u1, ActionType.WRITE, r1));
            Console.WriteLine(rm.HasAccess(u1, ActionType.DELETE, r1));

            rm.RevokeRoleToUser(u1, "Admin");
            Console.WriteLine(rm.HasAccess(u1, ActionType.READ, r1));
            Console.WriteLine(rm.HasAccess(u1, ActionType.WRITE, r1));
            Console.WriteLine(rm.HasAccess(u1, ActionType.DELETE, r1));

            Console.ReadLine();
        }
    }
}
