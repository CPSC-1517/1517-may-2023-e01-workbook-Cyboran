using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPsReview;

namespace OOPsReview
{
    public class Person
    {
        /*
        private string _FirstName;
        private string _LastName;
        */
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

        public Person(string fName, string lName) 
        {
            FirstName = fName;
            LastName = lName;
        }
    }
}
