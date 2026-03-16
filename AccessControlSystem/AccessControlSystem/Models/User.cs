using AccessControlSystem.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccessControlSystem.Models
{
    public class User
    {
        public string Id { get; private set; } 
        public string Name { get; private set; }
        public Role Role { get; private set; }  // enums

      

        public User(string id, string name, Role role)
        {
            Id = id;
            Name = name;
            Role = role;
        }

       
    }
}
