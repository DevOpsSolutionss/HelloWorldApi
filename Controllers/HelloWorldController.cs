using Microsoft.AspNetCore.Mvc;

namespace HelloWorldApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloWorldController : ControllerBase
    {
        [HttpGet("{number}")]
        public IActionResult Get(int number)
        {
            if (number > 100)
            {
                return new JsonResult("high");
            }
            else
            {
                return new JsonResult("low");
            }
        }
    }
}