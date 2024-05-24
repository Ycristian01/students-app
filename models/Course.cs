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
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty or null.");
        if (registrationFee < 0)
            throw new ArgumentException("Registration fee must be either 0 or a positive integer.");
        if (startDate >= endDate)
            throw new ArgumentException("Start date must be before end date.");

        Name = name;
        RegistrationFee = registrationFee;
        StartDate = startDate;
        EndDate = endDate;
        PaymentGateway = paymentGateway ?? throw new ArgumentNullException(nameof(paymentGateway));
    }
}
