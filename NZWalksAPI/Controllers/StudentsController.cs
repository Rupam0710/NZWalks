using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NZWalksAPI.Controllers
{   
    //https:localhost:portnumber/api/controller
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        //GET : https://localhost:portnumber/api/Students
        [HttpGet]
        public IActionResult GetAllStudent()
        {
            string[] studentname = new string[] { "Rohit", "Rupam", "Raj" };
            return Ok(studentname);
        }
    }
}
