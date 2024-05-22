namespace StudentsApp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            //register students
            Student student1 = new Student("Alvarito Diaz", 21);
            Student student2 = new Student("Nicki Nicole", 18);
            Student student3 = new Student("Bad bo", 20);

            //register courses
            Course chemistryClass = new Course(
                "How to cook crystal",
                1000,
                DateTime.Now,
                DateTime.Now.AddMonths(6)
            );
            Course programingClass = new Course(
                "Programming with nodejs",
                2000,
                DateTime.Now,
                DateTime.Now.AddMonths(5)
            );
            Course mathClass = new Course(
                "Finances for dummies",
                0,
                DateTime.Now,
                DateTime.Now.AddMonths(2)
            );

            //register students to courses
            student1.RegisterToCourse(chemistryClass);
            student1.RegisterToCourse(programingClass);

            student2.RegisterToCourse(programingClass);
            student2.RegisterToCourse(mathClass);
            student2.RegisterToCourse(chemistryClass);

            student3.RegisterToCourse(mathClass);

            Console.WriteLine("student 2 courses:");
            foreach (var course in student2.GetCourses())
            {
                //todo: implement filter byv range of dates
                Console.WriteLine(course.Name);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
