using System;
using System.Collections.Generic;
using System.Text;

namespace RuleBasedAccess.Models
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
