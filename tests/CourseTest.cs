namespace StudentsApp;

public class CourseTest
{
    [Fact]
    public void Course_CreateSuccesfully()
    {
        var paymentGateway = new PaymentGateway();
        DateTime startDate = DateTime.Now;
        DateTime endDate = DateTime.Now.AddMonths(5);

        var course = new Course("How to cook chicken", 0, startDate, endDate, paymentGateway);

        Assert.Equal("How to cook chicken", course.Name);
        Assert.Equal(0, course.RegistrationFee);
        Assert.Equal(startDate, course.StartDate);
        Assert.Equal(endDate, course.EndDate);
        Assert.Equal(paymentGateway, course.PaymentGateway);
    }

    [Fact]
    public void Course_InvalidNameException()
    {
        Assert.Throws<ArgumentException>(
            () =>
                new Course("", 1000, DateTime.Now, DateTime.Now.AddMonths(6), new PaymentGateway())
        );
    }

    [Fact]
    public void Course_InvalidRegistrationFeeException()
    {
        Assert.Throws<ArgumentException>(
            () =>
                new Course(
                    "How to cook chicken",
                    -1000,
                    DateTime.Now,
                    DateTime.Now.AddMonths(6),
                    new PaymentGateway()
                )
        );
    }

    [Fact]
    public void Course_InvalidDatesException()
    {
        Assert.Throws<ArgumentException>(
            () =>
                new Course(
                    "How to cook chicken",
                    1000,
                    DateTime.Now.AddMonths(6),
                    DateTime.Now,
                    new PaymentGateway()
                )
        );
    }
}
