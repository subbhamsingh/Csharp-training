using ClinicSystem.Interfaces;
using ClinicSystem.RelationShips;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicSystem.Entities
{
    public  class Patient : Person 
    {
       
        public string DiseaseName {  get; set; }

        public Patient(string name, string age, string disease)
        {
            Name = name;
            Age = age;
            DiseaseName= disease;
        }

        public override void GetDetails()
        {
            Console.WriteLine("Patient Name: " + Name);
            Console.WriteLine("Age: " + Age);
            Console.WriteLine("Disease: " + DiseaseName);
            Console.WriteLine();
        }

    }
}
