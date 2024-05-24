using System.Diagnostics;

public class School
{
    public string Name { get; set; }
    public List<Student> Students { get; set; }
    public List<Course> Courses { get; set; }

    public School(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty or null.");
        Name = name;
        Students = new List<Student>();
        Courses = new List<Course>();
    }

    public bool RegisterStudent(Student student)
    {
        if (student.Age < 18)
            throw new ArgumentException(
                "Person must be at least 18 years old to register as a student."
            );

        if (!Students.Contains(student))
        {
            Students.Add(student);
            Console.WriteLine($"Student {student.Name} succesfully registered in the school.");
            return true;
        }
        else
            Console.WriteLine($"Student {student.Name} is already registered in the school.");
        return false;
    }

    public bool RegisterCourse(Course course)
    {
        if (!Courses.Contains(course))
        {
            Courses.Add(course);
            Console.WriteLine($"Course {course.Name} succesfully registered in the school.");
            return true;
        }
        else
            Console.WriteLine($"Course {course.Name} is already registered in the school.");
        return false;
    }

    public bool RegisterStudentToCourse(Student student, Course course)
    {
        VerifyRecords(student, course);
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
                return false;
            }
        }
        student.Courses.Add(course);
        Console.WriteLine($"Student {student.Name} succesfully registered to {course.Name} course");
        return true;
    }

    private void VerifyRecords(Student student, Course course)
    {
        if (!Students.Contains(student))
            throw new ArgumentException($"Student {student.Name} is not registered in the school.");
        if (!Courses.Contains(course))
            throw new ArgumentException($"Course {course.Name} is not registered in the school.");
    }
}
