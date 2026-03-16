using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicSystem.Entities
{   
    public abstract class Person
    {
        public string Name { get; set; }
        public string Age {  get; set; }

        public abstract void GetDetails();  
    }
}
