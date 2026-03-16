


namespace OOps
{
   public class Student
    {
        public string? Name;
        public int Age;
        public string? Email;
        //private readonly int Id;
        public int Id { get; private set; }  //-> property 


        // static class 

        public static int Count;
        static Student()
        {
            Count = 0;
            Console.WriteLine("Static Constructor Called");
        }
        public Student(string name, int age, int id, string email)
        {
            Name = name;
            Age = age;
            Id = id;
            Email = email;
            Count++;
        }
      // copy constructor 
      public Student(Student other)
        {
            Name = other.Name;
            Age = other.Age;
            Id = other.Id;
            Email = other.Email;
            Count++;
        }
        //public int IdAccess()
        //{

        //    return Id;
        //}




    }
   public class Program
    {
        public static void Main()
        {
            Student student = new Student("Rajveer", 23, 1, "raj@gmail.com");
            Student student1 = new Student("Subham", 23, 2, "subham@gmail.com");
            // use of copy constructor 
            Student student2 = new Student(student);  // independent object is created by copying the values
            student2.Name = "Veer";

            Student student3 = student;  // only refernce is created , we can change values of student
                                         // by the help of   student3
            //student3.Name = "Veer";




            //Console.WriteLine(student.Name + student.Age + student.IdAccess() + student.Email);
            Console.WriteLine(student.Name + student.Age + student.Id + student.Email);
            Console.WriteLine(student1.Name + student1.Age + student1.Id + student1.Email);
            Console.WriteLine(student2.Name + student2.Age + student2.Id + student2.Email);




            //Console.WriteLine(student.Count);// this is wrong  we cannot access static with making object
            Console.WriteLine(Student.Count);

            //Student student = new Student();
            //student.Name = "rajveer";
            //student.Age = 23;
            ////student.Id = 1;
            //student.Email = "raj@gmai;.com";


        }
    }



}

