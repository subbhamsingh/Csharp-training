using AccessControlSystem.Enums;
using AccessControlSystem.Models;


namespace AccessControlSystem.Services
{
    public class UserService
    {
        private List<User> users = new List<User>();  // this is for containing all user infromation
        private int counter = 101;

        public bool HasUsers()
        {
            return users.Count > 0;
        }

        
        public User CreateUserFromInput()
        {
            Console.Write("Enter User Name:\n> ");
            string name = Console.ReadLine();
            Console.WriteLine();

            if (!ValidationService.IsValidText(name))
            {
                Console.WriteLine("Invalid Name!");
                Console.WriteLine();
                return null;
            }

            Console.WriteLine("Select Role:");
            Console.WriteLine("1. Admin");
            Console.WriteLine("2. Manager");
            Console.WriteLine("3. Viewer");
            Console.WriteLine();
            Console.Write("> ");

            string choice = Console.ReadLine();

            if (!ValidationService.IsValidChoice(choice))
            {
                Console.WriteLine("Invalid Role Selection!");
                Console.WriteLine();
                return null;
            }

            Role role;

            if (choice == "1")
                role = Role.Admin;
            else if (choice == "2")
                role = Role.Manager;
            else
                role = Role.Viewer;

            return CreateUser(name, role);
        }

        
        public User CreateUser(string name, Role role)
        {
            string id = "U" + counter++;

          
            User user = new User(id, name, role);

            users.Add(user);

            Console.WriteLine();
            Console.WriteLine("User created successfully!");
            Console.WriteLine("User ID: " + user.Id);
            Console.WriteLine("Role: " + user.Role);
            Console.WriteLine();

            return user;
        }

        public User GetUserById(string id)
        {
            return users.FirstOrDefault(u => u.Id == id);
        }

        //public User GetUserById(string id)
        //{
        //    foreach(var user in users)
        //    {
        //        if (user.Id == id)
        //            return user;
        //    }
        //    return null;
        //}
    }
}