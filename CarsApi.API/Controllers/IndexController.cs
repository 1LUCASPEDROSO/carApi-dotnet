using Microsoft.AspNetCore.Mvc;

namespace CarsApi.API.Controllers
{
    [ApiController]
    [Route("/")]
    public class IndexController : ControllerBase
    {
       [HttpGet]
        public IActionResult RedirectToSwagger()
        {
            return Redirect("/swagger");
        }
    }
}