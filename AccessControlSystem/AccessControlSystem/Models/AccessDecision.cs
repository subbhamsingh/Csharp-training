
namespace AccessControlSystem.Models
{
    public class AccessDecision
    {
        public bool IsAllowed { get; private set; }
        public string Message { get; private set; }

         // constructor 
        public AccessDecision(bool isAllowed, string message)
        {
            IsAllowed = isAllowed;
            Message = message;
        }
    }
}
