using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPsReview;

namespace OOPsReview
{
    /*
     * Fields
     *      private string FirstName
     *      private string LastName
     * Properties
     *      public ResidentAddress Address {get; set;}
     *      public List<Employment> EmploymentPositions {get; set;}
     *      public string FirstName {get; set;}
     *      public string FullName {get;}
     *      public string LastName {get; set;}
     *      public int NumberOfEmployments {get;}
     * Methods
     *      public void AddEmployment(Employment employment)
     *      public void ChangeName(string firstName, string lastName)
     *      public Person()
     *      public Person(string firstName, string lastName, ResidentAddress address, List<Employment> employmentPositions)
     */
    public class Person
    {
        private string _FirstName;
        private string _LastName;
        
        public string FirstName 
        { get; set;
            /*
            get
            {
                return _FirstName;
            } 
            set
            {
                _FirstName = value;
            } 
            */
        }
        public string LastName
        { get; set;
            /*
            get
            {
                return _LastName;
            }
            set
            {
                _LastName = value;
            }
            */
        }
        public Residence Address { get; set; }
        public List<Employment> EmploymentPositions { get; set; } = new List<Employment>(); // creates a new instance so that there is no invalid null entries
        public Person(string fName, string lName, Residence address, List<Employment> employmentPositions) 
        { // greedy constructor
            FirstName = fName;
            LastName = lName;
            Address = address;
            if (employmentPositions != null)
            {
                EmploymentPositions = employmentPositions;
            }
        }
        public Person()
        { // default constructor
        }
    }
}
