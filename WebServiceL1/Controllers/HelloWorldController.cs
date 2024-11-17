using Microsoft.AspNetCore.Mvc;

namespace WebServiceL1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloWorldController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> GetHelloWorld(string name)
        {
            return Ok($"Hello, {name}");
        }
    }
}
