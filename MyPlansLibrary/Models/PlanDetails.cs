using Microsoft.AspNetCore.Http;

namespace MyPlansLibrary.Models
{
    public class PlanDetails : Plan
    {
        public IFormFile CoverFile { get; set; }

    }
}