using System;
using System.Collections.Generic;
using System.Text;

namespace RuleBasedAccess.Models
{
    public class Resource
    {
        public string Name { get; private set; }
    

        public string ResourceType { get; private set; }


        public Resource(string name, string resourceType)
        {
            Name = name;
            ResourceType = resourceType;
        }
    }
}
