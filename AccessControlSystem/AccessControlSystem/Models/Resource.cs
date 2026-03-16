
using AccessControlSystem.Enums;

namespace AccessControlSystem.Models
{
    public class Resource
    {
        public string Name { get; private set; }
        public ResourceType ResourceType { get; private set; }  // for enum


        public Resource(string name, ResourceType resourceType)
        {
            Name = name;
            ResourceType = resourceType;
        }

        
    }
}
