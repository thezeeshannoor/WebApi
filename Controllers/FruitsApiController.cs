using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Security.Cryptography.X509Certificates;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FruitsApiController : ControllerBase
    {
        public string[] fruits = [ "apple", "banana", "cherry","zee" ];
        

        [HttpGet]
        public string[]  Get()
        {
            return fruits;
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
           return fruits[id];
        }
    }
}
