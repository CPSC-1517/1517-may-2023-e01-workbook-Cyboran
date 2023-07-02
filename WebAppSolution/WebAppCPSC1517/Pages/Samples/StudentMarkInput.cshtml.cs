using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Reflection;
using WebApp.Models;

namespace WebApp.Pages.Samples
{
    public class StudentMarkInputModel : PageModel
    {
        public string Feedback { get; set; }
        public bool HasFeedback { get { return !string.IsNullOrWhiteSpace(Feedback); } }
        public IWebHostEnvironment _webHostEnvironment { get; set; }

        public List<Assessment> assessList { get; set; } = new List<Assessment>();

        [BindProperty]
        public StudentMarks studentRecord { get; set; }
      
        //[BindProperty]
        //public string? FirstName { get; set; }
        //[BindProperty]
        //public string? LastName { get; set; }

        //[BindProperty]
        //public int Assessment { get; set; }

        //[BindProperty]
        //public int AssessmentVersion { get; set; }

        //[BindProperty]
        //public double Mark { get; set; }

        public StudentMarkInputModel(IWebHostEnvironment env)
        {
            _webHostEnvironment = env;
        }
        public void OnGet()
        {
           PopulateAssessment();
        }
        
        public void PopulateAssessment()
        {
            assessList.Add(new Assessment() { Id = 1, Description = "Exercise" });
            assessList.Add(new Assessment() { Id = 2, Description = "Lab" });
            assessList.Add(new Assessment() { Id = 3, Description = "Assessment" });
            assessList.Add(new Assessment() { Id = 4, Description = "Project" });
            assessList.Add(new Assessment() { Id = 5, Description = "Quiz" });
            // x and y represent any two records in the collection, default sort ascending is x, y and descending is y, x
            assessList.Sort((x,y) => x.Description.CompareTo(y.Description));
        }

        public IActionResult OnPostRecord()
        {
            if (string.IsNullOrWhiteSpace(studentRecord.LastName))
            {
                ModelState.AddModelError("studentRecord.LastName", "Error. Last Name is Required. Please try again.");
            }
            if (Assessment == 0)
            {
                ModelState.AddModelError("studentRecord.Assessment", "Error. Assessment type not selected. Please try again.");
            }

            if (ModelState.IsValid)
            {
                //studentRecord = new StudentMarks()
                //{
                //    FirstName = FirstName,
                //    LastName = LastName,
                //    Assessment = Assessment,
                //    AssessmentVersion = AssessmentVersion,
                //    Mark = Mark
                //};
                string recordAndEndOfLine = studentRecord.ToString() + "\n";

                string rootPath = _webHostEnvironment.ContentRootPath;
                string filePath = Path.Combine(rootPath, @"Data\StudentMarks.txt");

                System.IO.File.AppendAllText(filePath, recordAndEndOfLine);
            }

            PopulateAssessment();

            return Page();
        }
        public IActionResult OnPostClear()
        {
            ModelState.Clear();
            studentRecord = null;
            //FirstName = null;
            //LastName = null;
            //Assessment = 0;
            //AssessmentVersion = 0;
            //Mark = 0;

            PopulateAssessment();

            return Page();
        }
        public IActionResult OnPostRedirectToReport()
        {

            return RedirectToPage("StudentMarkReport");
        }
    }
}
