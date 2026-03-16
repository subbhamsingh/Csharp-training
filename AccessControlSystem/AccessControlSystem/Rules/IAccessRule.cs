using AccessControlSystem.Enums;
using AccessControlSystem.Models;


namespace AccessControlSystem.Rules
{
    public  interface IAccessRule
    {
        public AccessDecision Evaluate(User user, Resource resource, ActionType actionType);

       
       
    }
}
