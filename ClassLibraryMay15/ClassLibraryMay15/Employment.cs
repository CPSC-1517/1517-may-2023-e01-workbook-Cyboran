namespace ClassLibraryMay15
{
    public class Employment
    {
        private SupervisoryLevel _Level;
        private string _Title;
        private int _Years;

        // summary
        // Properties are associated with a single piece of data
        // can be implmented by fully implementing or auto implementing them

        // fully implemented has additional logic to execute for the control of the data, usually validation
        // fully implemented will also have declared data members to store data
        // auto implemented will not have additional logic
        // auto implemented will not have a declared data member to store the data, instead the OS will create based on the property only accessible by the property

        public string Title
        {
            // accessor
            get { return _Title; }
            // mutator
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Title is required.");
                }
                _Title = value;
            }
        }

        public SupervisoryLevel Level
        {
            get { return _Level; }
            private set 
            { // private set means that the property can only be set by code within the class. This helps to increase security as it won't allow a standard user to change the information.
                // to validate and test enums you make use of the following, where xx is the datatype:  Enum.IsDefined(typeof(xx), value)
                if (!Enum.IsDefined(typeof(SupervisoryLevel), value))
                {
                    throw new ArgumentException($"Supervisory Level is invalid: {value}.");
                }
                _Level = value;
            }
        }

        public int Years
        {
            get { return _Years; }
            set
            {
                // validate for a positive value
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                // second way to validate
                /*
                if (!Utilities.IsZeroOrPositive(value))
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                */
                _Years = value;
            }
        }

        // auto-implemented property
        public DateTime StartDate { get; private set; }

        // default constructor
        public Employment()
        {
            // default values
            Title = "Unknown";
            Level = SupervisoryLevel.TeamMember;
            StartDate = DateTime.Today;
        }

        // greedy constructor
        public Employment(string title, int years, SupervisoryLevel level, DateTime start)
        {
            Title = title;
            Level = level;
            StartDate = start;
            Years = years;

            if (start >= DateTime.Today.AddDays(1))
            {
                throw new ArgumentException($"The start date {start} is invalid, as it is in the future.");
            }
        }
    }
}