public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty or null.");
        if (age <= 0)
            throw new ArgumentException("Age must be a positive integer.");

        Name = name;
        Age = age;
    }
}
