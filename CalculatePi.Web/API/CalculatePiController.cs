using Microsoft.AspNetCore.Mvc;
using CalculatePi.Library;

namespace CalculatePi.Web.API
{
    [Route("api/[controller]")]
    public class CalculatePiController : Controller
    {
        // GET api/CalculatePi/5/Nilikantha
        [HttpGet("{iterations}/{modelToUse}")]
        public double Get(int iterations, string modelToUse)
        {
            IterativeMethod pi = null;
            switch (modelToUse)
            {
                case "Gregory-Leibniz":
                    pi = new Gregory_Leibniz();
                    break;
                case "Nilikantha":
                    pi = new Nilikantha();
                    break;
                default:
                    throw new System.Exception($"Could not find [{modelToUse}] model.");
            }
            pi.NumberOfIterations = iterations;
            return pi.Calculate();
        }
    }
}
