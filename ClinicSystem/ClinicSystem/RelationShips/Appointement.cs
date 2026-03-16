using ClinicSystem.Entities;
using ClinicSystem.Interfaces;

namespace ClinicSystem.RelationShips
{
    public  class Appointement: IBillable
    {
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public AppointementStatus Status { get; set; }

        public DateTime AppointmentDate { get; set; }

        public Prescription Prescription { get; set; }
        
        public AppointementType Type { get; set; }

        public double BillAmount { get; set; } 
      
        public double CalculateBill()
        {
            if (Type == AppointementType.Specialist)
                return 100;
            else
                return 50;
        }
    }
}
