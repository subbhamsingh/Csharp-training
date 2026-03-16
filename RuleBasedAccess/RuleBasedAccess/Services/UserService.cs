
using RuleBasedAccess.Constants;
using RuleBasedAccess.Models;

namespace RuleBasedAccess.Services
{
    public class UserService
    {
        private List<User> users = new List<User>(); // list to store user information

        // function used for validation before checking access for user , user should be there 
        public bool NoOfUsersInList()
        {
            var count = users.Count;
            if (count > 0)
                return true;

            return false;
        }

        public User CreateUserFromInput()
        {
            // asking the username 
            Console.WriteLine("Enter User name");
            string name = Console.ReadLine();
            Console.WriteLine();
            // now validate it before asking the next inputs

            if (!ValidationService.IsValidText(name))
            {
                Console.WriteLine("Invalid Name , It should only be string ! Nothing Other , Example:Rajveer");
                Console.WriteLine();
                return null;
            }

            // now we will display role option  to choose 
            Console.WriteLine("Select Role:");
            Console.WriteLine("1. Admin");
            Console.WriteLine("2. Manager");
            Console.WriteLine("3. Viewer");
            Console.WriteLine();
            Console.Write("> ");

            // now ask for to choose from option 
            string choice = Console.ReadLine();

           
            if (!ValidationService.IsValidChoice(choice))
            {
                Console.WriteLine("Invalid Role Selection!");
                Console.WriteLine();
                return null;
               

            }

            // now we have to deciede what access the user have based on its role
            string role = null;
            if (choice == "1")
                role = Role.Admin;
            else if (choice == "2")
                role = Role.Manager;
            else if (choice == "3")
                role = Role.Viewer;

            // we will call the function which will display user created 
            return CreateUser(name, role);


        }

        private int counter = 101;
        public User CreateUser(string name, string role)
        {
            string id = "U" + counter++;

            // now we are calling the constructor for User to create an object for User class
            User user = new User(id, name, role);

            // user is xccreated and we are adding in the list .
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
            foreach (var user in users)
            {
                if (user.Id == id)
                    return user;
            }
            return null;
        }



    }
}
