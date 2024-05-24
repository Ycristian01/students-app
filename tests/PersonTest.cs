namespace StudentsApp;

public class PersonTest
{
    [Fact]
    public void Person_CreateSuccesfully()
    {
        var person = new Person("John Doe", 31);

        Assert.Equal("John Doe", person.Name);
        Assert.Equal(31, person.Age);
    }

    [Fact]
    public void Person_InvalidNameException()
    {
        Assert.Throws<ArgumentException>(() => new Person("", 20));
    }

    [Fact]
    public void Person_InvalidAgeException()
    {
        Assert.Throws<ArgumentException>(() => new Person("John", -20));
    }
}
