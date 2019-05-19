using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CalculatePi.Library;

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
        public int Iterations { get; set; }
        [BindProperty]
        public string Result { get; set; }

        public void OnPost()
        {
            var pi = new CalculatePi.Library.Gregory_Leibniz();
            pi.NumberOfIterations = Iterations;
            var result = pi.Calculate();
            Result = $"Result = {result}";
        }
    }
}