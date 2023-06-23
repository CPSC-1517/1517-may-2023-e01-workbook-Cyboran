using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAppCPSC1517.Pages.Samples
{
    public class BasicEventsModel : PageModel
    {
        //page properties
        public string Feedback { get; set; }
        private Random random = new Random();
        /*
         * OnGet is a method called whenever the page is created. This page is called first when the page is retrieved
         * 
         * OnPost is a method that is called whenever a submit button is clicked and there is no specific event name for the button
         * 
         * The internet is a stateless environment. This means any webpage requested exists in memory for as long as it's executing code. After the page is sent to the browser, the system doesn't know about the page
         */
        public void OnGet()
        {
            Feedback = "in OnGet Method";
        }
        //public void OnPost()
        public void OnPostFirstButton()
        {
            int oddeven = random.Next(1, 101);
            if (oddeven % 2 == 0)
            {
                Feedback = $"Your value is {oddeven} and it is even. In OnPost Method.";
            }
            else
            {
                Feedback = $"Your value is {oddeven} and it is odd. In OnPost Method.";
            }
        }
        public void OnPostSecondButton()
        {
            Feedback = "You have clicked the second button.";
        }
    }
}
