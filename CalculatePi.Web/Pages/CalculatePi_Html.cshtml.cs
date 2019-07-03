using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CalculatePi.Library;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Required (ErrorMessage = "Model is required")]
        public string ModelToUse { get; set; }

        [BindProperty]
        [Required]
        [Range(0,100000000)]
        public int Iterations { get; set; }

        [BindProperty]
        public string Result { get; set; }

        public IActionResult OnGet()
        {
            Models = new List<SelectListItem> {
                new SelectListItem { Value = "Gregory-Leibniz", Text = "Gregory-Leibniz"},
                new SelectListItem { Value = "Nilikantha", Text = "Nilikantha" }
            };
            return Page();
        }

        public IActionResult OnPost()
        {
            Models = new List<SelectListItem> {
                new SelectListItem { Value = "Gregory-Leibniz", Text = "Gregory-Leibniz"},
                new SelectListItem { Value = "Nilikantha", Text = "Nilikantha" }
            };
            if (!ModelState.IsValid)
            {
                Result = "";
                return Page();
            }
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
            return Page();
        }
    }
}