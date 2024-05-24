public class PaymentGateway
{
    private readonly Dictionary<Student, Course> _paymentRecords = new();

    public bool ProcessPayment(Student student, Course course, int amount)
    {
        ArgumentNullException.ThrowIfNull(student);
        ArgumentNullException.ThrowIfNull(course);
        if (course.RegistrationFee != amount)
            throw new ArgumentException("Invalid payment amount");

        _paymentRecords[student] = course;
        Console.WriteLine($"Payment of {amount:C} succesfully processed for {student.Name}.");
        return true;
    }

    public bool HasPaid(Student student, Course course)
    {
        ArgumentNullException.ThrowIfNull(student);
        return _paymentRecords.TryGetValue(student, out var registeredCourse)
            && registeredCourse == course;
    }
}
