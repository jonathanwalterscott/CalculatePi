using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CalculatePi.Library;
using System.Collections.Generic;

namespace CalculatePi.Web.Pages
{
    public class CalculatePiModel : PageModel
    {
        public CalculatePiModel()
        {
            Iterations = 0;
            Result = "";
        }

        [BindProperty]
        public List<SelectListItem> Models { get; private set; }
        [BindProperty]
        public string ModelToUse { get; set; }
        [BindProperty]
        public int Iterations { get; set; }
        [BindProperty]
        public string Result { get; set; }

        public void OnGet()
        {
            Models = new List<SelectListItem> {
                new SelectListItem { Value = "Gregory-Leibniz", Text = "Gregory-Leibniz"},
                new SelectListItem { Value = "Nilikantha", Text = "Nilikantha" }
            };
        }

        public void OnPost()
        {
            Models = new List<SelectListItem> {
                new SelectListItem { Value = "Gregory-Leibniz", Text = "Gregory-Leibniz"},
                new SelectListItem { Value = "Nilikantha", Text = "Nilikantha" }
            };
            IterativeMethod pi = null;
            switch (ModelToUse)
            {
                case "Gregory-Leibniz" :
                    pi = new Gregory_Leibniz();
                    break;
                case "Nilikantha":
                    pi = new Nilikantha();
                    break;
                default:
                    throw new System.Exception($"Could not find [{ModelToUse}] model.");
            }
            pi.NumberOfIterations = Iterations;
            var result = pi.Calculate();
            Result = $"Result = {result}";
        }
    }
}