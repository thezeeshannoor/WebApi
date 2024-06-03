using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentApiController : ControllerBase
    {
        private readonly DbfirstContext _dbfirstContext;
        public StudentApiController(DbfirstContext context) {
            this._dbfirstContext = context;
           }
        [HttpGet]
        public async Task<ActionResult<List<Student>>> Get()
        {
            var data = await _dbfirstContext.Students.ToListAsync();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetById(int id)
        {
            var data = await _dbfirstContext.Students.FindAsync(id);
            if(data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult<Student>> AddStudent(Student std)
        {
            await _dbfirstContext.Students.AddAsync(std);
            await _dbfirstContext.SaveChangesAsync();
            return Ok(std);


        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateStd(int id,Student std)
        {
           
            var data = await _dbfirstContext.Students.FindAsync(id);
            
            data.Fname = std.Fname;
            data.Lname = std.Lname;
            data.Class = std.Class;
            data.Number = std.Number;
           
            await _dbfirstContext.SaveChangesAsync();

            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> DeleteStd(int id)
        {
            var std = await _dbfirstContext.Students.FindAsync(id);
            if (std == null)
            {
                return NotFound();
            }
             _dbfirstContext.Students.Remove(std);
            await _dbfirstContext.SaveChangesAsync();
            return Ok($"Student Deleted of ID {id}");
        }

    }
}
