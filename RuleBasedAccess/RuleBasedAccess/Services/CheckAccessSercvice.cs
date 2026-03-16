
using RuleBasedAccess.Constants;
using RuleBasedAccess.Models;
using RuleBasedAccess.Rules;

namespace RuleBasedAccess.Services
{
    public class CheckAccessService
    {
        // we have to create list to store all the reources and add predifined resources
      
        private List<Resource> resources;
        public CheckAccessService()
        {
            resources = new List<Resource>();

            resources.Add(new Resource("Customer Profile", ResourceType.General));
            resources.Add(new Resource("Invoice Record", ResourceType.Financial));
            resources.Add(new Resource("Salary Sheet", ResourceType.Financial));
            resources.Add(new Resource("Public Announcement", ResourceType.General));
        }


        // now we will check input access for it
        public void CheckAccessFromInput(UserService userService)  
        {
            // we ask for id 
            Console.Write("Enter User ID:\n> ");
            string userId = Console.ReadLine();
            Console.WriteLine();

            // now we will check whether that id is present or not
            var user = userService.GetUserById(userId);
            if (user == null)
            {
                Console.WriteLine("User not found!");
                Console.WriteLine();
                return;
            }

            // now we will show available resources 
            for (int i = 0; i < resources.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + resources[i].Name +
                " (" + resources[i].ResourceType + ")");
            }
            Console.WriteLine();

            // now we will ask to select from the option
            string choice = Console.ReadLine();

            // now validate that choice
            if (!ValidationService.IsValidChoiceResource(choice))
            {
                Console.WriteLine("Invalid Resource Selection!");
                Console.WriteLine();
                return;
            }

            // now we will display action which can be performed 
            Console.WriteLine();
            Console.WriteLine("Enter Action:");
            Console.WriteLine("1. Read");
            Console.WriteLine("2. Write");
            Console.WriteLine("3. Delete");
            Console.WriteLine();
            Console.Write("> ");

            // ask user to select from the option 
            string ActionChoice = Console.ReadLine();
            Console.WriteLine();

            // now we will validate the choice 
            if (!ValidationService.IsValidChoice(ActionChoice))
            {
                Console.WriteLine("Invalid Action Selection!");
                Console.WriteLine();
                return;
            }

            // now we have to deciede which action can be perform based on choice selected
            string action = null;
            if (ActionChoice == "1")
            {
                action = ActionType.Read;
            }
            else if (ActionChoice == "2")
            {
                action = ActionType.Write;
            }
            else if (ActionChoice == "3")
            {
                action = ActionType.Delete;
            }

            // now we have to evaluate the permission fro each role 
            IAccessRule CheckRule = new RolePermissionRule();
        

            AccessDecision decision = null;
            // 
            foreach (var resource in resources)
            {
                 decision = CheckRule.Evaluate(user, resource, action);

                if (decision != null && decision.IsAllowed)
                    break;
            }
                // we will display that we accessing the rule based on choice 
                Console.WriteLine();

                Console.WriteLine("Evaluating access...");
                Console.WriteLine();

                // now we will give if it is not allowedor not and if not, why it is not allowed 

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
