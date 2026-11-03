using Microsoft.AspNetCore.Mvc;

namespace WikiSumBackend.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetHealth()
        {
            return Ok(new
            {
                status = "Healthy",
                message = "WikiSum API is running.",
                timestamp = DateTime.UtcNow
            });
        }
    }
}
