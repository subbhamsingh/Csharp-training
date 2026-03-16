using SolidPrinciple.DIP;
using SolidPrinciple.ISP;
using SolidPrinciple.LSP;
using SolidPrinciple.OCP;
using SolidPrinciple.SRP;
namespace SolidPrinciple
{
    public class Program 
    { 
        public static void Main()
        {
            // srp principle
            Console.WriteLine("Single responsibility principle Bad practise");
            var user=new User();
            user.CreateUser("raj");
            Console.WriteLine();
            Console.WriteLine("Single responsibility  Good practise");
            var userService = new UserService();
            var logger = new Logger();
            var email = new EmailServiceSrp();
            
            userService.CreateUser("Rajveer");
            logger.Log("User created");
            email.SendEmail("Rajveer");
            Console.WriteLine();



            // OCP principle
            Console.WriteLine("Open Closed Principle - Bad Practice");
            // Bad design
            DiscountCalculator calculator = new DiscountCalculator();
            Console.WriteLine(calculator.Calculate("Regular", 1000));
            Console.WriteLine(calculator.Calculate("Premium", 1000));
            Console.WriteLine();

            Console.WriteLine("Open Closed Principle - Good Practice");
            // Good design
            IDiscount discount1 = new RegularDiscount();
            Console.WriteLine(discount1.Calculate(1000));

            IDiscount discount2 = new PremiumDiscount();
            Console.WriteLine(discount2.Calculate(1000));

            // Adding new type without modifying old code
            IDiscount discount3 = new VipDiscount();
            Console.WriteLine(discount3.Calculate(1000));
            Console.WriteLine();



            // LSP principle
            Console.WriteLine("Liskov Substitution Principle BAD DESIGN");
            try
            {
                Bird bird1 = new Sparrow();
                bird1.Fly();

                Bird bird2 = new Penguin();
                bird2.Fly();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();

            Console.WriteLine("Liskov Substitution Principle GOOD DESIGN");

            FlyingBird1 sparrow = new Sparrow1();
            sparrow.Fly();

            Bird1 penguin = new Penguin1();
            Console.WriteLine("Penguin created");
            Console.WriteLine();



            // ISP principl
            Console.WriteLine("Interface Segregation Principle - BAD DESIGN");
            try
            {
                IWorker worker = new Robot();

                worker.Work();

                // Robot cannot eat, but interface forces it
                worker.Eat();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();
            Console.WriteLine("Interface Segregation Principle - GOOD DESIGN");

            IWork humanWork = new Human();
            IEat humanEat = new Human();

            humanWork.Work();
            humanEat.Eat();

            IWork robot = new Robot1();
            robot.Work();
            Console.WriteLine();



            // DIP principle
            // Bad design
            Console.WriteLine("Dependency Inversion Principle - BAD DESIGN");
            OrderService order = new OrderService();
            order.PlaceOrder();
            Console.WriteLine();

            // Good design
            Console.WriteLine("Dependency Inversion Principle - GOOD DESIGN");

            // Using Email
            IMessage message = new EmailService();
            OrderServiceRefactored order1 = new OrderServiceRefactored(message);
            order1.PlaceOrder();
            Console.WriteLine();

            // Switching to SMS without modifying OrderServiceRefactored
            IMessage sms = new SmsService();
            OrderServiceRefactored order2 = new OrderServiceRefactored(sms);
            order2.PlaceOrder();
            Console.WriteLine();
        }
    }  

}