public class Student : Person
{
    public List<Course> Courses { get; set; }

    public Student(string name, int age)
        : base(name, age)
    {
        if (age < 18)
            throw new ArgumentException(
                "Person must be at least 18 years old to register as a student."
            );
        Courses = new List<Course>();
    }

    public void RegisterToCourse(Course course)
    {
        if (!Courses.Contains(course))
            Courses.Add(course);
    }

    public List<Course> GetCourses()
    {
        return Courses;
    }

    public static void ListStudentCoursesByDate(
        List<Student> students,
        DateTime startDate,
        DateTime endDate
    )
    {
        foreach (var student in students)
        {
            List<Course> filteredCourses = student
                .GetCourses()
                .Where(c => c.StartDate <= startDate && c.EndDate >= endDate)
                .ToList();
            foreach (var course in filteredCourses)
            {
                Console.WriteLine("Student " + student.Name + " is in " + course.Name + " course");
            }
        }
    }
}
