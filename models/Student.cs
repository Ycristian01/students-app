public class Student : Person
{
    public List<Course> Courses { get; set; }

    public Student(string name, int age)
        : base(name, age)
    {
        Courses = new List<Course>();
    }

    public List<Course> ListStudentCoursesByDate(DateTime startDate, DateTime endDate)
    {
        List<Course> filteredCourses = Courses
            .Where(c => c.StartDate <= startDate && c.EndDate >= endDate)
            .ToList();
        foreach (var course in filteredCourses)
        {
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("Student " + this.Name + " is in " + course.Name + " course");
            Console.WriteLine("---------------------------------------------------");
        }
        return filteredCourses;
    }
}
