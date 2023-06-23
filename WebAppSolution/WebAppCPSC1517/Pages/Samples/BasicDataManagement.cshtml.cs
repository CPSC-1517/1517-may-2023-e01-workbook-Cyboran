using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAppCPSC1517.Pages.Samples
{
    public class BasicDataManagementModel : PageModel
    {
        // form control properties
        // a property needs a [BindProperty] attribute to update when the form is submitted, this atrribute is not required but if you want to recieve data from your form into your property then you MUST have the attribute.
        [BindProperty]
        public double Num { get; set; }
        [BindProperty]
        public string MassText { get; set; }
        [BindProperty]
        public int FaveCourse { get; set; }
        [BindProperty]
        public string FaveCourseNoValue { get; set; }
        [BindProperty]
        public string FeedBack { get; set; }

        // an example of managing the collection of errors on web page using a List<>
        public List<string> ErrorList { get; set; } = new List<string>();
        public void OnGet()
        {
        }
        public void OnPostControlProcessing()
        {
            //FeedBack = $"You have pressed the button. " 
            //    + $"The values entered/chosen are as follows: "
            //    + $"    Number: {Num}"
            //    + $"    Textbox: {MassText}"
            //    + $"    Course 1: {FaveCourse}"
            //    + $"    Course 2: {FaveCourseNoValue}";

        }
    }
}
