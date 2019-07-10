using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Net.Http;

namespace CalculatePi.Web.Pages
{
    public class CalculatePiModel : PageModel
    {
        private readonly IHttpClientFactory ClientFactory;

        public CalculatePiModel(IHttpClientFactory clientFactory)
        {
            Iterations = 0;
            Result = "";
            ClientFactory = clientFactory;
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

        public async Task<IActionResult> OnPost()
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
            var httpClient = ClientFactory.CreateClient("CalculatePiAPI");
            httpClient.BaseAddress = new System.Uri("http://localhost:5001/api/CalculatePi/");
            var result = await httpClient.GetAsync(Iterations + "/" + ModelToUse);
            if (result.IsSuccessStatusCode)
            {
                Result = $"Result = {await result.Content.ReadAsStringAsync()}";
            }
            else
            {
                Result = $"Error {result.ReasonPhrase}";
                return Page();
            }
            return Page();
        }
    }
}