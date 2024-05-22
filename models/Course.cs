public class Course
{
    public string Name { get; set; }
    public int RegistrationFee { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public List<Student> Students { get; set; }

    public Course(string name, int registrationFee, DateTime startDate, DateTime endDate)
    {
        Name = name;
        RegistrationFee = registrationFee;
        StartDate = startDate;
        EndDate = endDate;
        Students = new List<Student>();
    }

    public void RegisterStudent(Student student)
    {
        if (!Students.Contains(student))
            //todo: implement payment gateway
            Students.Add(student);
    }

    public List<Student> GetStudents()
    {
        return Students;
    }
}
