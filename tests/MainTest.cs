namespace StudentsApp;

public class MainTest
{
    [Fact]
    public void Main_Succesfully()
    {
        //init school
        School school = new("ACME school");

        //init payment gateway
        PaymentGateway paymentGateway = new();

        //create students
        Student student1 = new("Alvaro Diaz", 21);
        Student student2 = new("Nicki Nicole", 18);
        Student student3 = new("Sergio Ramos", 20);

        //register students to school
        school.RegisterStudent(student1);
        school.RegisterStudent(student2);
        school.RegisterStudent(student3);

        //test if school contains students
        Assert.Contains(student1, school.Students);
        Assert.Contains(student2, school.Students);
        Assert.Contains(student3, school.Students);

        //create courses
        Course cookingClass =
            new(
                "How to cook chicken",
                1000,
                DateTime.Now.AddMonths(1),
                DateTime.Now.AddMonths(3),
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
                DateTime.Now.AddMonths(5),
                DateTime.Now.AddMonths(8),
                paymentGateway
            );

        //register courses to school
        school.RegisterCourse(cookingClass);
        school.RegisterCourse(programingClass);
        school.RegisterCourse(mathClass);

        //test if school contains courses
        Assert.Contains(cookingClass, school.Courses);
        Assert.Contains(programingClass, school.Courses);
        Assert.Contains(mathClass, school.Courses);

        //process payments and registrations for student1
        paymentGateway.ProcessPayment(student1, cookingClass, 1000);
        school.RegisterStudentToCourse(student1, cookingClass);

        paymentGateway.ProcessPayment(student1, programingClass, 2000);
        school.RegisterStudentToCourse(student1, programingClass);

        //process payments and registrations for student2
        paymentGateway.ProcessPayment(student2, programingClass, 2000);
        school.RegisterStudentToCourse(student2, programingClass);

        paymentGateway.ProcessPayment(student2, cookingClass, 1000);
        school.RegisterStudentToCourse(student2, cookingClass);

        school.RegisterStudentToCourse(student2, mathClass);

        //process payments and registrations for student3
        paymentGateway.ProcessPayment(student3, cookingClass, 1000);
        school.RegisterStudentToCourse(student3, cookingClass);

        //test student1 registered courses
        Assert.Contains(cookingClass, student1.Courses);
        Assert.Contains(programingClass, student1.Courses);

        //test student2 registered courses
        Assert.Contains(cookingClass, student2.Courses);
        Assert.Contains(programingClass, student2.Courses);
        Assert.Contains(mathClass, student2.Courses);

        //test student3 registered courses
        Assert.Contains(cookingClass, student3.Courses);

        //print students courses with range of dates filter
        DateTime startDate = DateTime.Now.AddMonths(1);
        DateTime endDate = DateTime.Now.AddMonths(2);

        Console.WriteLine("Students courses between " + startDate + " and " + endDate);

        //filtered student1 courses
        var filteredStudent1Courses = student1.ListStudentCoursesByDate(startDate, endDate);
        Assert.Contains(cookingClass, filteredStudent1Courses);
        Assert.Contains(programingClass, filteredStudent1Courses);
        Assert.DoesNotContain(mathClass, filteredStudent1Courses);

        //filtered student2 courses
        var filteredStudent2Courses = student2.ListStudentCoursesByDate(startDate, endDate);
        Assert.Contains(cookingClass, filteredStudent2Courses);
        Assert.Contains(programingClass, filteredStudent2Courses);
        Assert.DoesNotContain(mathClass, filteredStudent2Courses);

        //filtered student3 courses
        var filteredStudent3Courses = student3.ListStudentCoursesByDate(startDate, endDate);
        Assert.Contains(cookingClass, filteredStudent3Courses);
        Assert.DoesNotContain(programingClass, filteredStudent3Courses);
        Assert.DoesNotContain(mathClass, filteredStudent3Courses);
    }
}
