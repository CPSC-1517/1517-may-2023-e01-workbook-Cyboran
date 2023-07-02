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
        public string? MassText { get; set; }
        [BindProperty]
        public int FaveCourse { get; set; }
        [BindProperty]
        public string FaveCourseNoValue { get; set; }
        [BindProperty]
        public string? FeedBack { get; set; }

        // an example of managing the collection of errors on web page using a List<>
        public List<string> ErrorList { get; set; } = new List<string>();
        public void OnGet()
        {
        }

        //using void - 
        //public void OnPostControlProcessing()
        //{// anything with the void datatype does not require a return and stays on the same page
        //    //FeedBack = $"You have pressed the button. " 
        //    //    + $"The values entered/chosen are as follows: "
        //    //    + $"    Number: {Num}"
        //    //    + $"    Textbox: {MassText}"
        //    //    + $"    Course 1: {FaveCourse}"
        //    //    + $"    Course 2: {FaveCourseNoValue}";

        //    // Num vaildation
        //    if (Num < 0)
        //    {
        //        // using ModelState
        //        ModelState.AddModelError("Num", $"The value of the number: {Num} cannot be negative. Please try again.");
        //        // adding to ErrorList
        //        ErrorList.Add($"The value of the number: {Num} cannot be negative. Please try again.");
        //    }
        //    // MassText validation
        //    if (string.IsNullOrWhiteSpace(MassText))
        //    {
        //        // using ModelState we can associate the AddModelError with asp-validation-for on span control so that it appears beside the input. This function is used with 2 arguements to associate the error message with the span tag
        //        ModelState.AddModelError(nameof(MassText), "The Text box for Textarea is empty. Please try again.");
        //        // adding to ErrorList
        //        ErrorList.Add("The Text box for Textarea is empty. Please try again.");
        //    }
        //    // FaveCourse validation
        //    if (FaveCourse == 0)
        //    {
        //        // using ModelState
        //        ModelState.AddModelError(nameof(FaveCourse), "No selection was made (Selection #1). Please try again.");
        //        // adding to ErrorList
        //        ErrorList.Add("No selection was made (Selection #1). Please try again.");
        //    }

        //    // FaveCourseNoValue validation
        //    if (FaveCourseNoValue == "Select course...")
        //    {
        //        // using ModelState
        //        ModelState.AddModelError(nameof(FaveCourseNoValue), "No selection was made (Selection #2). Please try again.");
        //        // adding to ErrorList
        //        ErrorList.Add("No selection was made (Selection #2). Please try again.");
        //    }

        //    // testing code
        //    //if (ErrorList.Count() == 0)
        //    if (ModelState.IsValid)
        //    {
        //        FeedBack = "Your data was valid and submitted. Thank you.";
        //    }
        //}


        // using IActionResult - 
        public IActionResult OnPostControlProcessing()
        {// anything with the void datatype does not require a return and stays on the same page
            //FeedBack = $"You have pressed the button. " 
            //    + $"The values entered/chosen are as follows: "
            //    + $"    Number: {Num}"
            //    + $"    Textbox: {MassText}"
            //    + $"    Course 1: {FaveCourse}"
            //    + $"    Course 2: {FaveCourseNoValue}";

            // Num vaildation
            if (Num < 0)
            {
                // using ModelState
                ModelState.AddModelError("Num", $"The value of the number: {Num} cannot be negative. Please try again.");
                // adding to ErrorList
                ErrorList.Add($"The value of the number: {Num} cannot be negative. Please try again.");
            }
            // MassText validation
            if (string.IsNullOrWhiteSpace(MassText))
            {
                // using ModelState we can associate the AddModelError with asp-validation-for on span control so that it appears beside the input. This function is used with 2 arguements to associate the error message with the span tag
                ModelState.AddModelError(nameof(MassText), "The Text box for Textarea is empty. Please try again.");
                // adding to ErrorList
                ErrorList.Add("The Text box for Textarea is empty. Please try again.");
            }
            // FaveCourse validation
            if (FaveCourse == 0)
            {
                // using ModelState
                ModelState.AddModelError(nameof(FaveCourse), "No selection was made (Selection #1). Please try again.");
                // adding to ErrorList
                ErrorList.Add("No selection was made (Selection #1). Please try again.");
            }

            // FaveCourseNoValue validation
            if (FaveCourseNoValue == "Select course...")
            {
                // using ModelState
                ModelState.AddModelError(nameof(FaveCourseNoValue), "No selection was made (Selection #2). Please try again.");
                // adding to ErrorList
                ErrorList.Add("No selection was made (Selection #2). Please try again.");
            }

            // testing code
            //if (ErrorList.Count() == 0)
            if (ModelState.IsValid)
            {
                FeedBack = "Your data was valid and submitted. Thank you.";
            }

            return Page(); //using IActionResult requires a return and this line makes it so you stay on the same page
        }
        public IActionResult OnPostRedirectPage()
        {// IActionResult requires a return statement that has an action, as shown below. If it were used in the above statement, then the following statement would be required: return Page();
            return RedirectToPage("BasicEvents");
        }
    }
}
