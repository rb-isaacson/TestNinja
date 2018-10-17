# TestNinja
## Unit Testing for C# Developers

### Getting Started
#### Writing Unit Tests for the Reservation Class Method CanBeCancelledBy

The name of the project is TestNinja, so create a project for the unit tests using the convention of TestNinja.UnitTests because
you want to keep the UnitTests separate from the integration tests.  The unit tests run fast and the integration tests tend to run slower.

Right click Solution 'TestNinja' in Visual Studio > Add > New Project > Test (under Visual C#) > Unit Test Project (.NET Framework)
The file created will have a using Microsoft.VisualStudio.TestTools.UnitTesting statement

You'll get a new Project with a class decorated with the [TestClass] attribute with a method decorated with the [TestMethod] attribute.  
These attributes are used by the Test Runner to know what needs to be run. 

Rename the class to be ReservationTests since Reservation is the class under test and rename the method following this naming convention:

**MethodName_Scenario_ExpectedBehavior**

so in this case name it CanBeCancelledBy_UserIsAdmin_ReturnsTrue()

When you start having lots of tests in your test suite, it will really help to follow a naming convention.  You also need to rename the file
itself to be ReservationTests.cs (I think resharper and other commercial tools might do that for you when you rename the class).

The shortcut to rename in Visual Studio is Ctrl+R, R

In the body of the method, use Arrange, Act and Assert convention to write the test (triple A).

The arrange part usually involves creating an instance of the class under test.
The act part usually involved calling the  method under test.
The assert part asserts whatever you are trying to test.

``` c#
[TestMethod]
public void CanBeCancelledBy_AdminCancelling_ReturnsTrue()
{
  // Arrange
  var reservation = new Reservation();
  
  // Act
  var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });
  
  // Assert
  Assert.IsTrue(result);
}
```

The shortcut to run the tests is Ctrl+R, A
You should have a passing test at this point.

There are three execution paths for this method, so write two more tests to hit all execution paths.
Now we have three passing tests.

#### Refactoring With Confidence

Having unit tests, allows you to refactor with confidence!

#### Using NUnit in Visual Studio

In Package Manager Console, make sure that the Default project is TestNinja.UnitTests, then type

```
PM> Install-Package NUnit -Version 3.8.1
PM> Install-Package NUnit3TestAdapter -Version 3.8.0
```
Note that if you use ReSharper you don't need to install NUnit3TestAdapter.

| MSTest | NUnit |
| ---| ---|
| [TestClass] | [TestFixture] |
| [TestMethod] | [Test] |
| | [SetUp] |
| | [TearDown] |

Remove using statement for MSTest so Assert method will resolve properly. Can use:

Assert.IsTrue(result);
or
Assert.That(result, Is.True);
or 
Assert.That(result == true);

#### Test Driven Development

Test first:
1. Write a failing test.
2. Write the simplest code to make the test pass.
3. Refactor if necessary.

#### Benefits of TDD

1. Testable Source Code
2. Full Coverage
3. Simpler Implementation

### Fundamentals of Unit Testing

#### Characteristics of Good Unit Tests

1. First class citizens
2. Single Responsibility
3. Clean, readable, maintainable
4. No logic
5. Isolated
6. Not too specific or too general

#### What to Test and What Not To Test

Test:
1. Query function--returns a value
2. Command function--making a change in the system (changing the state of an object in memory, and/or writing to 
a database, or calling a web service or sending a message to a message queue, etc)

Don't Test:
1. Language features, for example, if you have a class with lots of properties you don't need to test that the properties
are being set.
2. Don't need to test 3rd party code.

#### Naming and Organizing Tests

[MethodName]_[Scenario]_[ExpectedBehavior]

#### Parameterized Tests

With NUnit you can easily parameterize your tests.  With MSTest you have to use spreadsheets!

```
[Test]
        [TestCase(2, 1, 2)]
        [TestCase(1, 2, 2)]
        [TestCase(1, 1, 1)]
        public void Max_WhenCalled_ReturnTheGreaterArgument(int a, int b, int expectedResult)
        {
            var result = _math.Max(a, b);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
```
#### Ignoring Tests

You can use the [Ignore] attribute to temporarilty ignore a test. 
This is a better way then commenting a test out because it will still show up on the results.
That way you won't lose track of it.

### Core Unit Testing Techniques

1. Testing methods that return a value.
2. Testing void methods.
3. Testing methods that throw an exception.
4. Testing method that raise an event.
5. Testing private methods.

#### Testing Strings

#### Testing Arrays and Collections








