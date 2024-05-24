namespace StudentsApp;

public class StudentTest
{
    [Fact]
    public void Student_ListCoursesByDate_Succesfully()
    {
        var student = new Student("John Doe", 31);
        var course1 = new Course(
            "How to cook chicken",
            100,
            DateTime.Now.AddMonths(1),
            DateTime.Now.AddMonths(3),
            new PaymentGateway()
        );
        var course2 = new Course(
            "How to cook beef",
            200,
            DateTime.Now.AddMonths(4),
            DateTime.Now.AddMonths(7),
            new PaymentGateway()
        );
        var course3 = new Course(
            "How to cook pork",
            0,
            DateTime.Now.AddMonths(4),
            DateTime.Now.AddMonths(8),
            new PaymentGateway()
        );
        student.Courses.Add(course1);
        student.Courses.Add(course2);
        student.Courses.Add(course3);

        List<Course> filteredCourses = [course2, course3];

        List<Course> filteredCoursesTest = student.ListStudentCoursesByDate(
            DateTime.Now.AddMonths(4),
            DateTime.Now.AddMonths(6)
        );
        Assert.Equal(filteredCourses, filteredCoursesTest);
    }
}
