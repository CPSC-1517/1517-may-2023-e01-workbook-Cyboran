namespace ClassLibraryMay15
{
    public class Employment
    {
        private SupervisoryLevel _Level;
        private string _Title;
        private string _Years;

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
    }
}