using RuleBasedAccess.Constants;
using RuleBasedAccess.Models;

namespace RuleBasedAccess.Rules
{
    public class RolePermissionRule : IAccessRule
    {

        public AccessDecision Evaluate(User user, Resource resource, string action)
        {
            if (user.Role == Role.Admin)
            {
                return new AccessDecision(true, "Role Rule: Passed");
            }
            else if (user.Role == Role.Manager)
            {
                if (action == ActionType.Read || action == ActionType.Write)
                {
                    return new AccessDecision(true, "Role Rule: Passed");
                }
                else
                {
                    return new AccessDecision(false, "Managers cannot perform Delete operation");
                }
            }
            else if (user.Role == Role.Viewer)
            {
                if (action == ActionType.Read)
                {
                    return new AccessDecision(true, "Role Rule: Passed");
                }
                else
                {
                    return new AccessDecision(false, "Viewers can only perform Read operation");
                }
            }

            return new AccessDecision(false, "Invalid role.");
        }
    }
}
