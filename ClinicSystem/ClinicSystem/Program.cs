using ClinicSystem.Exceptions;
using ClinicSystem.Services;
using System.Runtime.CompilerServices;


namespace ClinicSystem
{
   public class Program
    {
        public static void Main()
        {
              ClinicService service = new ClinicService();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=========================================");
                Console.WriteLine("=========   CLINIC SYSTEM MENU  =========");
                Console.WriteLine("=========================================");
                Console.WriteLine("1. Register Patient");
                Console.WriteLine("2. Register Doctor");
                Console.WriteLine("3. Find Doctor By Specialization");
                Console.WriteLine("4. Book Appointment");
                Console.WriteLine("5. Complete Appointment");
                Console.WriteLine("6. View Upcoming Appointments");
                Console.WriteLine("7. Exit");
                Console.WriteLine("-------------------------------");
                Console.WriteLine();

                Console.Write("Enter Choice: ");
                string choice = Console.ReadLine();
                if (!ValidationService.IsValidChoice(choice))
                {
                    Console.WriteLine("Warning !!! You should choose from option given only");
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    continue;
                }

                try
                {
                    switch (choice)
                    {
                        case "1":
                            service.RegisterPatient();
                            break;

                        case "2":
                            service.RegisterDoctor();
                            break;

                        case "3":
                            service.FindDoctorBySpecialization();
                            break;

                        case "4":
                            service.BookAppointement();
                            break;

                        case "5":
                            service.CompleteAppointment();
                            break;


                        case "6":
                            service.GetUpcomingAppointments();
                            break;
                        case "7":
                            return;

                        default:
                            Console.WriteLine("Invalid Choice");
                            break;
                          
                    }
                    
                }
                catch (AppointmentConflictException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }

                catch (PatientNotFoundException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadLine();
                Console.Clear();

            }
        }
    }
}