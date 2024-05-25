# Students App

This is my attempt at the AnalyticAlways code challenge.

# Discussion

- This solution uses .NET 8.0.
- The approach I used was a rich domain model based, with class objects with its own behavior and validations. There is a School class which is the main class and is in charge of perform all the necessary school operations, such as register a new student, a new course and a student in a course. The student class inherits from a Person class that has the name and the age, and the course class that saves most relevant information about the course object and implements a payment gateway for each student registration process.

# How to run

- Install [.NET 8 SDK](https://dotnet.microsoft.com/es-es/download/dotnet/8.0) (8.0 version)
- Run `dotnet test` to execute all the unitary tests of the project.
- If it's required, you can run a specific test of any test class, running `dotnet test --filter "FullyQualifiedName=StudentsApp.TestClass.Test"`, where `TestClass` is the desired test class and `Test` the desired test function of that class. e.g: `dotnet test --filter "FullyQualifiedName=StudentsApp.MainTest.Main_Succesfully"`.
- The `MainTest.cs` has the principal test which succesfully executes a complete flow of the application (also shows a list of the students with their courses between a range of dates), but if it's necessary you can check any of the `./tests` classes that have all the individual steps of the application with succesfull and invalid cases.

### Troubleshooting

- If you have an issue running the `dotnet test` command with a message about `verifying workloads`, first run `dotnet workload update` (with `sudo` if necessary).

# Non possible but desired features

- Implement a DB
- Dockerize the project to ease the execution
- Implement a more complex payment gateway using [braintreepayments](https://www.braintreepayments.com/sandbox).

# Time invested

The time invested for this project was about 3 days (4 or 5 hours per day)
