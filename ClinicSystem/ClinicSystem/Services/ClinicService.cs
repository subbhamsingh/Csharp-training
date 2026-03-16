using ClinicSystem.Entities;
using ClinicSystem.Exceptions;
using ClinicSystem.RelationShips;

namespace ClinicSystem.Services
{
    public class ClinicService
    {
        // list of patient, doctors, appointements
        private List<Patient> patients = new List<Patient>();
        private List<Doctor> doctors = new List<Doctor>();
        private List<Appointement> appointements = new List<Appointement>();

        public void RegisterPatient()
        {

            Console.WriteLine("Registering patient Details");
            Console.WriteLine();

            Console.WriteLine("Enter patient name");
            string PatientName = Console.ReadLine();
            if (!ValidationService.IsValidText(PatientName))
            {
                Console.WriteLine("Warning !!!  Name should contains only letters");
                Console.WriteLine();
                return;
            }
            Console.WriteLine();
            Console.WriteLine("Enter patient Age");

            string PatientAge = Console.ReadLine();
            if (!ValidationService.IsValidAge(PatientAge))
            {
                Console.WriteLine("Warning !!!   Age should contains only digits");
                Console.WriteLine();
                return;
            }

            Console.WriteLine();

            Console.WriteLine("Enter Patient Health issue (disease) ");
            string PatientDisease = Console.ReadLine();
            if (!ValidationService.IsValidText(PatientDisease))
            {
                Console.WriteLine("Warning !!! Disease Name  should contains only letters");
                Console.WriteLine();
                return;
            }
            Console.WriteLine();

            Patient p = new Patient(PatientName, PatientAge, PatientDisease);
            patients.Add(p);
            Console.WriteLine("Patient registerred successfully");
            Console.WriteLine();

        }

        public void RegisterDoctor()
        {
            Console.WriteLine("Registering Doctor Details");
            Console.WriteLine();

            Console.WriteLine("Enter Doctor name");
            string DoctorName = Console.ReadLine();
            if (!ValidationService.IsValidText(DoctorName))
            {
                Console.WriteLine("Warning !!! Name should contains only letters");
                Console.WriteLine();
                return;
            }
            Console.WriteLine();

            Console.WriteLine("Enter Doctor Age");
            string DoctorAge = Console.ReadLine();
            if (!ValidationService.IsValidAge(DoctorAge))
            {
                Console.WriteLine("Warning !!! Age should contains only digits");
                Console.WriteLine();
                return;
            }
            Console.WriteLine();

            Console.WriteLine("Enter Doctor Specialization ");
            string DoctorSpecialization = Console.ReadLine();
            if (!ValidationService.IsValidText(DoctorSpecialization))
            {
                Console.WriteLine("Warning !!! Name should contains only letters");
                Console.WriteLine();
                return;
            }
            Console.WriteLine();


            Doctor d = new Doctor(DoctorName, DoctorAge, DoctorSpecialization);
            doctors.Add(d);
            Console.WriteLine("Doctor registerred successfully");
            Console.WriteLine();

        }



        public void FindDoctorBySpecialization()
        {
            Console.WriteLine("Enter specialization:");
            string specialization = Console.ReadLine();
            if (!ValidationService.IsValidText(specialization))
            {
                Console.WriteLine("Warning !!! Specialization should contains only letters");
                Console.WriteLine();
                return;
            }
            Console.WriteLine();

            bool found = false;
            for (int i = 0; i < doctors.Count; i++)
            {
                if (doctors[i].Specialization == specialization)
                {
                    Console.WriteLine("----------------------");

                    doctors[i].GetDetails();  /////////////////////////added

                    Console.WriteLine("----------------------");
                    Console.WriteLine();

                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("No doctors found with this specialization.");
                Console.WriteLine();

            }
        }

        public void BookAppointement()
        {
            Console.WriteLine("Enter Doctor Name:");
            string doctorName = Console.ReadLine();
            if (!ValidationService.IsValidText(doctorName))
            {
                Console.WriteLine("Warning !!! Name should contains only letters");
                Console.WriteLine();
                return;
            }
            Console.WriteLine();


            Console.WriteLine("Enter Patient Name:");
            string patientName = Console.ReadLine();
            if (!ValidationService.IsValidText(patientName))
            {
                Console.WriteLine("Warning !!! Name should contains only letters");
                Console.WriteLine();
                return;
            }
            Console.WriteLine();


            Console.WriteLine("Enter Patient Age:");
            string age = Console.ReadLine();
            if (!ValidationService.IsValidAge(age))
            {
                Console.WriteLine("Warning !!! Age should contains only digits");
                Console.WriteLine();
                return;
            }
            Console.WriteLine();


            Console.WriteLine("Enter Disease:");
            string disease = Console.ReadLine();
            if (!ValidationService.IsValidText(disease))
            {
                Console.WriteLine("Warning !!! Name should contains only letters");
                Console.WriteLine();
                return;
            }
            Console.WriteLine();



            Console.WriteLine("Enter Appointment Date (YYYY-MM-DD):");

            string input = Console.ReadLine();

            if (!DateTime.TryParse(input, out DateTime date))
            {
                Console.WriteLine("Invalid Date");
                return;
            }
            if (date < DateTime.Today)
            {
                Console.WriteLine("You cannot book appointment for past dates.");
                return;
            }


            Console.WriteLine();


            Doctor doctor = null;

            // Find doctor
            for (int i = 0; i < doctors.Count; i++)
            {
                if (doctors[i].Name.ToLower() == doctorName.ToLower())
                {
                    doctor = doctors[i];
                    break;
                }
            }

            if (doctor == null)
            {
                Console.WriteLine("Doctor not found");
                Console.WriteLine();
                return;
            }

            // Check availability

            if (!doctor.CheckAvailability(date, appointements))
            {
                throw new AppointmentConflictException();
            }

            Patient patient = null;

            // Search patient in list
            for (int i = 0; i < patients.Count; i++)
            {
                if (patients[i].Name.ToLower() == patientName.ToLower())
                {
                    patient = patients[i];
                    break;
                }
            }

            // If patient not found , we will create new patient
            if (patient == null)
            {
                patient = new Patient(patientName, age, disease);
                patients.Add(patient);
            }

            // Create appointment
            Appointement appointment = new Appointement();

            appointment.Doctor = doctor;
            appointment.Patient = patient;
            appointment.Status = AppointementStatus.Scheduled;
            appointment.AppointmentDate = date;

            if (doctor.Specialization.ToLower() == "specialist")
            {
                appointment.Type = AppointementType.Specialist;
                appointment.BillAmount = 100;
            }
            else
            {
                appointment.Type = AppointementType.Generalist;
                appointment.BillAmount = 50;
            }

            appointements.Add(appointment);

            Console.WriteLine("Appointment booked successfully");
            Console.WriteLine();

        }

        public void CompleteAppointment()
        {
            // now we have to complete the appintement which are scheduled for the patient
            Console.WriteLine("Enter Patient Name:");
            string patientName = Console.ReadLine();
            if (!ValidationService.IsValidText(patientName))
            {
                Console.WriteLine("Warning !!! Name should contains only letters");
                Console.WriteLine();
                return;
            }
            Console.WriteLine();


            Appointement appointment = null;

            // now we have to find scheduled appointment from the appointemnet list
            for (int i = 0; i < appointements.Count; i++)
            {
                if (appointements[i].Patient.Name == patientName &&
                    appointements[i].Status == AppointementStatus.Scheduled)
                {
                    appointment = appointements[i];
                    break;
                }
            }

            if (appointment == null)
            {

                throw new PatientNotFoundException();
            }

            // Mark appointment completed
            appointment.Status = AppointementStatus.Completed;

            // now we have to create prescription for the disease all details 
            Console.WriteLine("Enter Medicine Name:");
            string medicine = Console.ReadLine();
            if (!ValidationService.IsValidText(medicine))
            {
                Console.WriteLine("Warning !!! Medicine should contains only letters");
                Console.WriteLine();
                return;
            }
            Console.WriteLine();


            Console.WriteLine("Enter Frequency:");
            string frequency = Console.ReadLine();
            if (!ValidationService.IsValidAge(frequency))
            {
                Console.WriteLine("Warning !!! Frequency should contains only digits");
                Console.WriteLine();
                return;
            }
            Console.WriteLine();


            Console.WriteLine("Enter Number of Days:");
            string days = Console.ReadLine();
            if (!ValidationService.IsValidAge(days))
            {
                Console.WriteLine("Warning !!! Days should contains only digits");
                Console.WriteLine();
                return;
            }
            Console.WriteLine();


            // Create prescription
            Prescription prescription = new Prescription();
            prescription.Medicine = medicine;
            prescription.Frequency = frequency;
            prescription.NoOfdays = days;

            appointment.Prescription = prescription;

            // bill logic
            appointment.BillAmount = appointment.CalculateBill();

            Console.WriteLine();
            Console.WriteLine("----------------------");
            Console.WriteLine("Appointment Completed");
            Console.WriteLine("Bill Amount: " + appointment.BillAmount);
            Console.WriteLine("----------------------");
            Console.WriteLine("Prescription Details:");

            Console.WriteLine("Medicine: " + appointment.Prescription.Medicine);
            Console.WriteLine("Frequency: " + appointment.Prescription.Frequency);
            Console.WriteLine("Days: " + appointment.Prescription.NoOfdays);


        }



        //////////////////new service
        public void GetUpcomingAppointments()
        {
            if (appointements.Count == 0)
            {
                Console.WriteLine("No appointments available.");
                Console.WriteLine();
                return;
            }

            bool found = false;

            for (int i = 0; i < appointements.Count; i++)
            {
                if (appointements[i].AppointmentDate >= DateTime.Today)
                {
                    Console.WriteLine("----------------------");
                    appointements[i].Patient.GetDetails();
                    appointements[i].Doctor.GetDetails();///////////////////added

                    Console.WriteLine("Date: " + appointements[i].AppointmentDate);
                    Console.WriteLine("----------------------");
                    Console.WriteLine();

                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("No upcoming appointments found.");
                Console.WriteLine();
            }
        }



    }




}
