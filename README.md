# TestNinja
## Unit Testing for C# Developers

### Writing Unit Tests for the Reservation Class Method CanBeCancelledBy

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

### Refactoring With Confidence

Having unit tests, allows you to refactor with confidence!





