namespace StudentsApp;

class Program
{
    static void Main(string[] args)
    {
        //init school
        School school = new("School of EasyVard");

        //init payment gateway
        PaymentGateway paymentGateway = new();
        try
        {
            //create students
            Student student1 = new("Alvarito Diaz", 21);
            Student student2 = new("Nicki Nicole", 18);
            Student student3 = new("Bad bo", 20);

            //register students to school
            school.RegisterStudent(student1);
            school.RegisterStudent(student2);
            school.RegisterStudent(student3);

            //create courses
            Course chemistryClass =
                new(
                    "How to cook crystal",
                    1000,
                    DateTime.Now,
                    DateTime.Now.AddMonths(6),
                    paymentGateway
                );
            Course programingClass =
                new(
                    "Programming with nodejs",
                    2000,
                    DateTime.Now,
                    DateTime.Now.AddMonths(6),
                    paymentGateway
                );
            Course mathClass =
                new(
                    "Finances for dummies",
                    0,
                    DateTime.Now,
                    DateTime.Now.AddMonths(6),
                    paymentGateway
                );

            //register courses to school
            school.RegisterCourse(chemistryClass);
            school.RegisterCourse(programingClass);
            school.RegisterCourse(mathClass);

            //process payments and registrations for student1
            paymentGateway.ProcessPayment(student1, chemistryClass, 1000);
            school.RegisterStudentToCourse(student1, chemistryClass);

            paymentGateway.ProcessPayment(student1, programingClass, 2000);
            school.RegisterStudentToCourse(student1, programingClass);

            //process payments and registrations for student2
            paymentGateway.ProcessPayment(student2, programingClass, 2000);
            school.RegisterStudentToCourse(student2, programingClass);

            paymentGateway.ProcessPayment(student2, chemistryClass, 1000);
            school.RegisterStudentToCourse(student2, chemistryClass);

            school.RegisterStudentToCourse(student2, mathClass);

            //process payments and registrations for student3
            paymentGateway.ProcessPayment(student3, chemistryClass, 1000);
            school.RegisterStudentToCourse(student3, chemistryClass);

            //print students courses with range of dates filter
            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now.AddMonths(1);

            foreach (var student in school.Students)
            {
                student.ListStudentCoursesByDate(startDate, endDate);
                Console.WriteLine(
                    "----------------------------------------------------------------------"
                );
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
