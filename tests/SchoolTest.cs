namespace StudentsApp;

public class SchoolTest
{
    [Fact]
    public void School_Create_Succesfully()
    {
        var school = new School("School of EasyVard");
        Assert.Equal("School of EasyVard", school.Name);
    }

    [Fact]
    public void School_Create_InvalidNameException()
    {
        Assert.Throws<ArgumentException>(() => new School(""));
    }

    [Fact]
    public void School_RegisterStudent_Succesfully()
    {
        var school = new School("School of EasyVard");
        var student = new Student("John Doe", 31);
        school.RegisterStudent(student);

        Assert.Contains(student, school.Students);
    }

    [Fact]
    public void School_RegisterStudent_AlreadyContainsStudent()
    {
        var school = new School("School of EasyVard");
        var student = new Student("John Doe", 31);
        school.RegisterStudent(student);

        Assert.False(school.RegisterStudent(student));
        Assert.Contains(student, school.Students);
    }

    [Fact]
    public void School_RegisterStudent_AgeException()
    {
        var school = new School("School of EasyVard");
        var student = new Student("John Doe", 16);

        Assert.Throws<ArgumentException>(() => school.RegisterStudent(student));
        Assert.DoesNotContain(student, school.Students);
    }

    [Fact]
    public void School_RegisterCourse_Succesfully()
    {
        var school = new School("School of EasyVard");
        var course = new Course(
            "How to cook chicken",
            100,
            DateTime.Now.AddMonths(1),
            DateTime.Now.AddMonths(3),
            new PaymentGateway()
        );

        school.RegisterCourse(course);

        Assert.Contains(course, school.Courses);
    }

    [Fact]
    public void School_RegisterCourse_AlreadyContainsCourse()
    {
        var school = new School("School of EasyVard");
        var course = new Course(
            "How to cook chicken",
            100,
            DateTime.Now.AddMonths(1),
            DateTime.Now.AddMonths(3),
            new PaymentGateway()
        );
        school.RegisterCourse(course);

        Assert.False(school.RegisterCourse(course));
        Assert.Contains(course, school.Courses);
    }

    [Fact]
    public void School_RegisterStudentToCourse_Succesfully()
    {
        var school = new School("School of EasyVard");
        var student = new Student("Nicki Nicole", 18);
        var paymentGateway = new PaymentGateway();
        var course = new Course(
            "How to cook chicken",
            100,
            DateTime.Now.AddMonths(1),
            DateTime.Now.AddMonths(3),
            paymentGateway
        );

        school.RegisterStudent(student);
        school.RegisterCourse(course);

        paymentGateway.ProcessPayment(student, course, 100);
        var registrationSucess = school.RegisterStudentToCourse(student, course);

        Assert.True(registrationSucess);
        Assert.Contains(course, student.Courses);
    }

    [Fact]
    public void School_RegisterStudentToCourse_NotRegisteredStudentException()
    {
        var school = new School("School of EasyVard");
        var student = new Student("Nicki Nicole", 18);
        var paymentGateway = new PaymentGateway();
        var course = new Course(
            "How to cook chicken",
            100,
            DateTime.Now.AddMonths(1),
            DateTime.Now.AddMonths(3),
            paymentGateway
        );

        school.RegisterCourse(course);
        paymentGateway.ProcessPayment(student, course, 100);

        Assert.Throws<ArgumentException>(() => school.RegisterStudentToCourse(student, course));
        Assert.DoesNotContain(student, school.Students);
        Assert.DoesNotContain(course, student.Courses);
    }

    [Fact]
    public void School_RegisterStudentToCourse_NotRegisteredCourseException()
    {
        var school = new School("School of EasyVard");
        var student = new Student("Nicki Nicole", 18);
        var paymentGateway = new PaymentGateway();
        var course = new Course(
            "How to cook chicken",
            100,
            DateTime.Now.AddMonths(1),
            DateTime.Now.AddMonths(3),
            paymentGateway
        );

        school.RegisterStudent(student);
        paymentGateway.ProcessPayment(student, course, 100);

        Assert.Throws<ArgumentException>(() => school.RegisterStudentToCourse(student, course));
        Assert.DoesNotContain(course, school.Courses);
        Assert.DoesNotContain(course, student.Courses);
    }

    [Fact]
    public void School_RegisterStudentToCourse_InvalidPaymentAmountException()
    {
        var school = new School("School of EasyVard");
        var student = new Student("Nicki Nicole", 18);
        var paymentGateway = new PaymentGateway();
        var course = new Course(
            "How to cook chicken",
            100,
            DateTime.Now.AddMonths(1),
            DateTime.Now.AddMonths(3),
            paymentGateway
        );

        school.RegisterStudent(student);
        school.RegisterCourse(course);

        Assert.Throws<ArgumentException>(() => paymentGateway.ProcessPayment(student, course, 50));
        Assert.DoesNotContain(course, student.Courses);
    }

    [Fact]
    public void School_RegisterStudentToCourse_NoPaymentException()
    {
        var school = new School("School of EasyVard");
        var student = new Student("Nicki Nicole", 18);
        var paymentGateway = new PaymentGateway();
        var course = new Course(
            "How to cook chicken",
            100,
            DateTime.Now.AddMonths(1),
            DateTime.Now.AddMonths(3),
            paymentGateway
        );

        school.RegisterStudent(student);
        school.RegisterCourse(course);
        var registrationSucess = school.RegisterStudentToCourse(student, course);

        Assert.False(registrationSucess);
        Assert.DoesNotContain(course, student.Courses);
    }
}
