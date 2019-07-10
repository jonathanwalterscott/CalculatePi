using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Extensions.Configuration;

namespace CalculatePi.Web.Pages
{
    public class CalculatePiModel : PageModel
    {
        private readonly IConfiguration _config;
        private readonly IHttpClientFactory _clientFactory;

        public CalculatePiModel(IConfiguration config, IHttpClientFactory clientFactory)
        {
            Iterations = 0;
            Result = "";
            _config = config;
            _clientFactory = clientFactory;
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
            var httpClient = _clientFactory.CreateClient("CalculatePiAPI");
            IConfigurationSection webAPISection = _config.GetSection("WebAPI");
            string baseAddress = webAPISection.GetValue<string>("BaseAddress");
            httpClient.BaseAddress = new System.Uri(baseAddress);
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