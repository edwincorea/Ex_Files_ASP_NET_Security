using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Tutorial.AspNetSecurity.WebApi.Controllers
{
    [EnableCors("RouxAcademy")]
    [Route("api/[controller]")]
    public class CoursesController : Controller
    {
        // GET api/courses
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Computer Science", "Biology", "Anthropology" };
        }
    }
}
