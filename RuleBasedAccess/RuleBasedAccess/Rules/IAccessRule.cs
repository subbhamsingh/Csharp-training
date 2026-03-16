using RuleBasedAccess.Models;


namespace RuleBasedAccess.Rules
{
    public interface IAccessRule
    {

        public AccessDecision Evaluate(User user, Resource resource, string actionType);

    }
}
