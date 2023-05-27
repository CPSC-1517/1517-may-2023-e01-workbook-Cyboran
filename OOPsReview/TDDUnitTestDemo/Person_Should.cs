using FluentAssertions;
using OOPsReview;
using System.Xml.Linq;

namespace TDDUnitTestDemo
{
    public class Person_Should
    {
        // attribute titles - Fact is a title that does only one test and is usually setup and coded within the test. Theory is a title that allows for multiple tests using multiple data streams applied to the same test by making use of InlineData.
        #region Valid Data
        [Fact]
        public void Create_Instance_With_First_And_Last_Name_with_no_List()
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
            string expectedFirstName = "unknown";
            string expectedLastName = "unknown";
            // act (execution)
            Person person = new Person();
            // assert (testing of action)
            person.FirstName.Should().BeNull(expectedFirstName);
            person.LastName.Should().BeNull(expectedLastName);
            person.Address.Should().BeNull();
            person.EmploymentPositions.Count().Should().Be(0);
        }

        [Fact]
        public void Create_FirstName_To_New_Name()
        {
            // arrange (setup)
            string fName = "Rion";
            string lName = "Murphy";
            Residence address = new Residence(20, "Catalina Court", "Fort Sasketchewan", "AB", "T8L0E9");
            string expectedAdd = "20,Catalina Court,Fort Sasketchewan,AB,T8L0E9";
            Person me = new Person(fName, lName, address, null);
            string expectedfName = "Tiyna";
            // act (execution)
            me.FirstName = expectedfName;
            // assert (testing of action)
            me.FirstName.Should().Be(expectedfName);
        }

        [Fact]
        public void Create_LastName_To_New_Name()
        {
            // arrange (setup)
            string fName = "Rion";
            string lName = "Murphy";
            Residence address = new Residence(20, "Catalina Court", "Fort Sasketchewan", "AB", "T8L0E9");
            string expectedAdd = "20,Catalina Court,Fort Sasketchewan,AB,T8L0E9";
            Person me = new Person(fName, lName, address, null);
            string expectedlName = "Cloudwalker";
            // act (execution)
            me.LastName = expectedlName;
            // assert (testing of action)
            me.LastName.Should().Be(expectedlName);
        }

        #endregion

        #region Invalid Data

        [Theory]
        [InlineData(null,"Murphy")]
        [InlineData("Rion", null)]
        [InlineData(null, "")]
        [InlineData("", null)]
        [InlineData(null, "    ")]
        [InlineData("    ", null)]
        public void Create_Greedy_Instance_With_no_Name_Throw_Exception(string fName, string lName)
        {
            // arrange (setup)
            Residence address = new Residence(20, "Catalina Court", "Fort Sasketchewan", "AB", "T8L0E9");
            string expectedAdd = "20,Catalina Court,Fort Sasketchewan,AB,T8L0E9";
            // act (execution)
            Action action = () => new Person(fName, lName, address, null);
            // assert (testing of action)
            action.Should().Throw<ArgumentNullException>();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        /*
        public void Throw_Exception_When_Setting_FirstName_To_Missing_Data(string fName)
        {
            // arrange (setup)
            string lName = "Murphy";
            Residence address = new Residence(20, "Catalina Court", "Fort Sasketchewan", "AB", "T8L0E9");
            string expectedAdd = "20,Catalina Court,Fort Sasketchewan,AB,T8L0E9";
            Person me = new Person("unknown", lName, address, null);
            string expectedfName = "unknown";
            // act (execution)
            Action action = () => new Person(fName, lName, address, null);
            // assert (testing of action)
            action.Should().Throw<ArgumentNullException>();
        }
        */

        #endregion
    }
}