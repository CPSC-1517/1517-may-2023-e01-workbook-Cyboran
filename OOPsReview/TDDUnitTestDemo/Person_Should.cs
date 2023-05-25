using FluentAssertions;
using OOPsReview;

namespace TDDUnitTestDemo
{
    public class Person_Should
    {
        // attribute titles - Fact is a title that does only one test and is usually setup and coded within the test. Theory is a title that allows for multiple tests using multiple data streams applied to the same test by making use of InlineData.
        [Fact]
        public void Create_Instance_With_First_And_Last_Name()
        {
            // arrange (setup)
            string fName = "Rion";
            string lName = "Murphy";
            // act (execution)
            Person person = new Person(fName, lName);
            // assert (testing of action)
            person.FirstName.Should().Be(fName);
            person.LastName.Should().Be(lName);
        }
    }
}