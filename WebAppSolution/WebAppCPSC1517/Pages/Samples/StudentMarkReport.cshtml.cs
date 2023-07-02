using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Models;
using System.IO;

namespace WebAppCPSC1517.Pages.Samples
{
    public class StudentMarkReportModel : PageModel
    {
        public string FeedBack { get; set; }
        public bool HasFeedBack
        {
            get
            {
                return !string.IsNullOrWhiteSpace(FeedBack);
            }
        }
        public List<StudentMarks> studentMarks { get; set; } = new List<StudentMarks>();

        //dependency injector (constructor)
        // by creating a constructor for the model class, the services to be injected will be parameters, saving the incoming parameters in a public property.
        public IWebHostEnvironment _Env { get; set; }
        public StudentMarkReportModel(IWebHostEnvironment env)
        {
            _Env = env;
        }
        public void OnGet()
        {
            // parsing the student marks into the List
            string rootPath = _Env.ContentRootPath;
            string filePath = Path.Combine(rootPath, @"Data\StudentMarks.txt");

            Array data = null;
            StudentMarks record = null;

            try
            {
                data = System.IO.File.ReadAllLines(filePath);
                foreach (string line in data)
                {
                    try
                    {
                        record = StudentMarks.Parse(line);
                        if (record != null)
                        {
                            studentMarks.Add(record);
                        }
                    }
                    catch (FormatException ex)
                    {
                        ModelState.AddModelError("Record Format", $"{GetInnerException(ex)}: record {line}");
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("System Error", $"{GetInnerException(ex)}: record {line}");
                    }
                }
            }
            catch (Exception ex)
            {
                //ModelState.AddModelError("", $"{ex.Message}");
                ModelState.AddModelError("File Data Error", $"{GetInnerException(ex)}");
            }
            //studentMarks.Add(StudentMarks.Parse(filePath));

        }

        public Exception GetInnerException(Exception ex)
        {
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            return ex;
        }
    }
}
