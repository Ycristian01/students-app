public class School
{
    public string Name { get; set; }
    public List<Student> Students { get; set; }
    public List<Course> Courses { get; set; }

    public School(string name)
    {
        Name = name;
        Students = new List<Student>();
        Courses = new List<Course>();
    }

    public void RegisterStudent(Student student)
    {
        if (!Students.Contains(student))
            Students.Add(student);
    }

    public void RegisterCourse(Course course)
    {
        if (!Courses.Contains(course))
            Courses.Add(course);
    }

    public bool RegisterStudentToCourse(Student student, Course course)
    {
        if (student.Courses.Contains(course))
        {
            Console.WriteLine(
                $"Student {student.Name} is already registered to {course.Name} course"
            );
            return false;
        }
        if (course.RegistrationFee > 0)
        {
            if (!course.PaymentGateway.HasPaid(student, course))
            {
                Console.WriteLine(
                    $"Student {student.Name} must pay the registration fee of {course.RegistrationFee:C} to register to {course.Name} course"
                );
                Console.WriteLine(
                    "**************************************************************************"
                );
                return false;
            }
        }
        student.Courses.Add(course);
        Console.WriteLine($"Student {student.Name} succesfully registered to {course.Name} course");
        Console.WriteLine(
            "**************************************************************************"
        );
        return true;
    }
}
