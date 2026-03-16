using RuleBasedAccess.Services;

namespace RuleBasedAccess
{
    public class Program
    {

        private  static UserService userService = new UserService();
        private static CheckAccessService checkService = new CheckAccessService();

        static void ShowHeader()
        {
            Console.WriteLine("=========================================");
            Console.WriteLine("   RULE-BASED ACCESS CONTROL SYSTEM");
            Console.WriteLine("=========================================\n");
        }

        static void ShowMenu()
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("1. Create User");
            Console.WriteLine("2. Check Access");
            Console.WriteLine("3. Exit");
            Console.WriteLine("------------------------------------------");
            Console.Write("Select an option: ");
        }

        public static void Main()
        {
            while (true)
            {
                Console.Clear();
                ShowHeader();
                ShowMenu();

                string choice = Console.ReadLine();
                Console.WriteLine();

                try
                {

                    switch (choice)
                    {
                        case "1":
                            userService.CreateUserFromInput();
                            break;

                        case "2":
                            if (!userService.NoOfUsersInList())
                            {
                                Console.WriteLine("No users available. Please create user first!");
                                break;
                            }

                            checkService.CheckAccessFromInput(userService);
                            break;

                        case "3":
                            return;

                        default:
                            Console.WriteLine("\nInvalid option!");
                            break;
                    }

                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadLine();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                   
                
                }
            }
        }
    }
}