public class Course
{
    public string Name { get; set; }
    public int RegistrationFee { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public readonly PaymentGateway PaymentGateway = new();

    public Course(
        string name,
        int registrationFee,
        DateTime startDate,
        DateTime endDate,
        PaymentGateway paymentGateway
    )
    {
        Name = name;
        RegistrationFee = registrationFee;
        StartDate = startDate;
        EndDate = endDate;
        PaymentGateway = paymentGateway;
    }
}
