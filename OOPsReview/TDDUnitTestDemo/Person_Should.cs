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
            Residence address = new Residence(20, "Catalina Court", "Fort Sasketchewan", "AB", "T8L0E9");
            string expectedAdd = "20,Catalina Court,Fort Sasketchewan,AB,T8L0E9";
            // act (execution)
            Person person = new Person(fName, lName, address, null);
            // assert (testing of action)
            person.FirstName.Should().Be(fName);
            person.LastName.Should().Be(lName);
            person.Address.ToString().Should().Be(expectedAdd);
            person.EmploymentPositions.Count().Should().Be(0);
        }

        [Fact]
        public void Create_Instance_With_Default_Constructor()
        {
            // arrange (setup)

            // act (execution)
            Person person = new Person();
            // assert (testing of action)
            person.FirstName.Should().BeNull();
            person.LastName.Should().BeNull();
            person.Address.Should().BeNull();
            person.EmploymentPositions.Count().Should().Be(0);
        }
    }
}