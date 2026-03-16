using ClinicSystem.Interfaces;
using ClinicSystem.RelationShips;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicSystem.Entities
{
    public class Doctor:Person, IAvailable
    {
        public string Specialization{  get; set; }


        public Doctor(string name, string age, string specialization)
        {
            Name = name;
            Age = age;
            Specialization = specialization;

        }

        public override void GetDetails()
        {
            Console.WriteLine("Doctor Name: " + Name);
            Console.WriteLine("Age: " + Age);
            Console.WriteLine("Specialization: " + Specialization);
            Console.WriteLine();
        }

        public bool CheckAvailability(DateTime date, List<Appointement> appointements)
        {
            if (date.DayOfWeek == DayOfWeek.Saturday ||
       date.DayOfWeek == DayOfWeek.Sunday)
            {
                return false;
            }

            for (int i = 0; i < appointements.Count; i++)
            {
                if (appointements[i].Doctor == this &&
                    appointements[i].AppointmentDate == date &&
                    appointements[i].Status == AppointementStatus.Scheduled)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
