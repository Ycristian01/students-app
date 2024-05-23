namespace StudentsApp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            //register students
            Student student1 = new("Alvarito Diaz", 21);
            Student student2 = new("Nicki Nicole", 18);
            Student student3 = new("Bad bo", 20);

            //register courses
            Course chemistryClass =
                new(
                    "How to cook crystal",
                    1000,
                    DateTime.Now.AddMonths(1),
                    DateTime.Now.AddMonths(6)
                );
            Course programingClass =
                new("Programming with nodejs", 2000, DateTime.Now, DateTime.Now.AddMonths(4));
            Course mathClass =
                new("Finances for dummies", 0, DateTime.Now, DateTime.Now.AddMonths(2));

            //register students to courses
            student1.RegisterToCourse(chemistryClass);
            student1.RegisterToCourse(programingClass);

            student2.RegisterToCourse(programingClass);
            student2.RegisterToCourse(mathClass);
            student2.RegisterToCourse(chemistryClass);

            student3.RegisterToCourse(mathClass);

            //print students courses with range of dates filter
            Console.WriteLine("students courses by range of dates:");
            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now.AddMonths(3);

            Student.ListStudentCoursesByDate([student1, student2, student3], startDate, endDate);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
