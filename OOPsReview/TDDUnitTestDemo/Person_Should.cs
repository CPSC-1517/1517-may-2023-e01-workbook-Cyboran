using FluentAssertions;
using OOPsReview;
using System.Xml.Linq;
using Xunit.Sdk;

namespace TDDUnitTestDemo
{
    public class Person_Should
    {
        public Person Make_Test_Instance()
        {
            string fName = "Rion";
            string lName = "Murphy";
            Residence address = new Residence(20, "Catalina Court", "Fort Sasketchewan", "AB", "T8L0E9");
            Person me = new Person(fName, lName, address, null);

            return me;
        }
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
            person.FirstName.Should().Be(expectedFirstName);
            person.LastName.Should().Be(expectedLastName);
            person.Address.Should().BeNull();
            person.EmploymentPositions.Count().Should().Be(0);
        }

        [Fact]
        public void Create_FirstName_To_New_Name()
        {
            // arrange (setup)
            Person me = Make_Test_Instance();
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
            Person me = Make_Test_Instance();
            string expectedlName = "Cloudwalker";
            // act (execution)
            me.LastName = expectedlName;
            // assert (testing of action)
            me.LastName.Should().Be(expectedlName);
        }

        [Fact]
        public void Create_FullName_To_New_Name()
        {
            // arrange (setup)
            Person me = Make_Test_Instance();
            string expectedfName = "Tiyna";
            string expectedlName = "Cloudwalker";
            // act (execution)
            me.ChangeName(expectedfName, expectedlName);
            // assert (testing of action)
            me.FirstName.Should().Be(expectedfName);
            me.LastName.Should().Be(expectedlName);
        }

        [Fact]
        public void Return_FullName()
        {
            // arrange (setup)
            Person me = Make_Test_Instance();
            // act (execution)
            string fullName = me.LastName + "," + me.FirstName;
            // assert (testing of action)
            me.FullName.Should().Be(fullName);
        }

        [Fact]
        public void Return_Number_Of_Employment_Instances()
        {
            // arrange (setup)
            Person me = Make_Test_Instance();
            // act (execution)
            int count = me.NumberOfEmployments;
            // assert (testing of action)
            count.Should().Be(0);
        }

        [Fact]
        public void Add_First_Employment_Instance()
        {
            // arrange (setup)
            Person me = Make_Test_Instance();
            int expectedResult = 1;
            Employment employment = new Employment("TDD Lead", SupervisoryLevel.TeamMember, new DateTime(2018,03,10));
            // act (execution)
            me.AddEmployment(employment);
            // assert (testing of action)
            me.NumberOfEmployments.Should().Be(expectedResult);
            me.EmploymentPositions[0].ToString().Should().Be(employment.ToString());
        }

        [Fact]
        public void Add_Multiple_Employment_Instances()
        {
            // arrange (setup)
            int expectedResult = 4;
            List<Employment> employments = new List<Employment>();
            Employment emp1 = new Employment("TDD Member", SupervisoryLevel.TeamMember, new DateTime(2018, 03, 10));
            Employment emp2 = new Employment("TDD Lead", SupervisoryLevel.TeamLeader, new DateTime(2016, 03, 10));
            Employment emp3 = new Employment("TDD Department Head", SupervisoryLevel.DepartmentHead, new DateTime(2020, 03, 10));
            employments.Add(emp1);
            employments.Add(emp2);
            employments.Add(emp3);
            string fName = "Rion";
            string lName = "Murphy";
            Residence address = new Residence(20, "Catalina Court", "Fort Sasketchewan", "AB", "T8L0E9");
            Person me = new Person(fName, lName, address, employments);
            Employment employment = new Employment("TDD Owner", SupervisoryLevel.Owner, new DateTime(2015, 03, 10));
            List<Employment> expectedEmp = new List<Employment>()
            {
                emp1,
                emp2,
                emp3,
                employment
            };
            // act (execution)
            me.AddEmployment(employment);
            // assert (testing of action)
            me.NumberOfEmployments.Should().Be(expectedResult);
            me.EmploymentPositions.Should().ContainInConsecutiveOrder(expectedEmp);
        }

        #endregion

        #region Invalid Data

        [Theory]
        [InlineData(null, "Murphy")]
        [InlineData("", "Murphy")]
        [InlineData("    ", "Murphy")]
        [InlineData("Rion", null)]
        [InlineData("Rion", "")]
        [InlineData("Rion", "    ")]
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
        public void Throw_Exception_When_Setting_FirstName_To_Missing_Data(string changeName)
        {
            // arrange (setup)
            Person me = Make_Test_Instance();
            // act (execution)
            Action action = () => me.FirstName = changeName;
            // assert (testing of action)
            action.Should().Throw<ArgumentNullException>();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public void Throw_Exception_When_Setting_LastName_To_Missing_Data(string changeName)
        {
            // arrange (setup)
            Person me = Make_Test_Instance();
            // act (execution)
            Action action = () => me.LastName = changeName;
            // assert (testing of action)
            action.Should().Throw<ArgumentNullException>();
        }

        [Theory]
        [InlineData(null, "Murphy")]
        [InlineData("", "Murphy")]
        [InlineData("    ", "Murphy")]
        [InlineData("Rion", null)]
        [InlineData("Rion", "")]
        [InlineData("Rion", "    ")]
        public void Throw_Exception_Change_FullName_With_Missing_Data(string changeFirstName, string changeLastName)
        {
            // arrange (setup)
            Person me = Make_Test_Instance();
            // act (execution)
            Action action = () => me.ChangeName(changeFirstName, changeLastName);
            // assert (testing of action)
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Throw_Exception_Add_First_Employment_Instance()
        {
            // arrange (setup)
            Person me = Make_Test_Instance();
            // act (execution)
            Action action = () => me.AddEmployment(null);
            // assert (testing of action)
            action.Should().Throw<ArgumentNullException>();
        }

        #endregion
    }
}