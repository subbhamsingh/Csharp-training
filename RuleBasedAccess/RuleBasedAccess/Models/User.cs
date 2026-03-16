using System;
using System.Collections.Generic;
using System.Text;

namespace RuleBasedAccess.Models
{
    public class User
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
       

        public string Role { get; private set; }

       

        public User(string id, string name, string role)
        {
            Id = id;
            Name = name;
            Role = role;
        }
    }
}
