using AccessControlSystem.Enums;
using AccessControlSystem.Models;
using AccessControlSystem.Rules;

namespace AccessControlSystem.Services
{
    public class CheckAccessService
    {
        private List<Resource> resources;

        public CheckAccessService()
        {
            resources = new List<Resource>();

            resources.Add(new Resource("Customer Profile", ResourceType.General));
            resources.Add(new Resource("Invoice Record", ResourceType.Financial));
            resources.Add(new Resource("Salary Sheet", ResourceType.Financial));
            resources.Add(new Resource("Public Announcement", ResourceType.General));
        }

        public List<Resource> GetResources()
        {
            return resources;
        }

        public void CheckAccessFromInput(UserService userService)
        {
            Console.Write("Enter User ID:\n> ");
            string userId = Console.ReadLine();
            Console.WriteLine();

            var user = userService.GetUserById(userId);

            if (user == null)
            {
                Console.WriteLine("User not found!");
                Console.WriteLine();
                return;
            }

            Console.WriteLine("Available Resources:");
            Console.WriteLine();

         

            for (int i = 0; i < resources.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + resources[i].Name +
                " (" + resources[i].ResourceType + ")");
            }


            Console.WriteLine();
            Console.Write("Select Resource:\n> ");
         

            string resourceInput = Console.ReadLine();

            if (!ValidationService.IsValidChoice(resourceInput))
            {
                Console.WriteLine("Invalid Resource Selection!");
                Console.WriteLine();
                return;
            }

            int index = int.Parse(resourceInput) - 1;
            Console.WriteLine();
            Console.WriteLine("Enter Action:");
            Console.WriteLine("1. Read");
            Console.WriteLine("2. Write");
            Console.WriteLine("3. Delete");
            Console.WriteLine();
            Console.Write("> ");

            string actionChoice = Console.ReadLine();
            Console.WriteLine();

            if (!ValidationService.IsValidChoice(actionChoice))
            {
                Console.WriteLine("Invalid Action Selection!");
                Console.WriteLine();
                return;
            }

            ActionType action;

            if (actionChoice == "1")
                action = ActionType.Read;
            else if (actionChoice == "2")
                action = ActionType.Write;
            else
                action = ActionType.Delete;

            IAccessRule rule = new RolePermissionRule();

            var decision = rule.Evaluate(user, resources[index], action);

            Console.WriteLine();

            Console.WriteLine("Evaluating access...");
            Console.WriteLine();

            if (decision.IsAllowed)
            {
                Console.WriteLine(" Role Rule: Passed");
                Console.WriteLine();
                Console.WriteLine("FINAL DECISION: ACCESS GRANTED");
                Console.WriteLine();

                if (action == ActionType.Read)
                {
                    Console.WriteLine("Sample Resource Data:");
                    Console.WriteLine("This is demo resource content.");
                }
                else if (action == ActionType.Write)
                {
                    Console.Write("> Enter data to update:\n");
                    Console.ReadLine();
                    Console.WriteLine();
                    Console.WriteLine("Data updated successfully (simulation).");
                }
                else if (action == ActionType.Delete)
                {
                    Console.WriteLine("Delete confirmation simulated.");
                    Console.WriteLine("Resource deletion completed (simulation).");
                }
            }
            else
            {
                Console.WriteLine(" Role Rule: " + decision.Message);
                Console.WriteLine();
                Console.WriteLine("FINAL DECISION: ACCESS DENIED");
                if (!string.IsNullOrEmpty(decision.Message))
                {
                    Console.WriteLine("Reason: " + decision.Message);
                }
            }
        }
    }
}