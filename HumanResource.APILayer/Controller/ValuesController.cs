using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HumanResource.APILayer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            //return NotFound();
            
            return Ok("This is working successfully");
        }

        [HttpGet]
        [Route("{name}")]
        public IActionResult Get(string name)
        {
            //return Ok("Welcome " + name);

            //Json Object
            return Ok(new { Id = 1, Name = name, Age = 30, City = "SpringField" });
        }
    }
}
