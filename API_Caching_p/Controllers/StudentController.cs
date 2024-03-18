using API_Caching_p.DataBaseAction;
using API_Caching_p.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Caching_p.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        // GET: api/<StudentController>
        public readonly BaseDbContext _baseDbContext;
        public readonly IMemoryCache _MemoryCache;

        public StudentController(BaseDbContext baseDbContext, IMemoryCache memoryCache) 
        {
            _baseDbContext = baseDbContext;
            _MemoryCache = memoryCache;
        }



        [HttpGet]
        [Route("GetAllStudents")]
        public async Task<IActionResult> GetStudents()
        {
            try
            {
                string cacheKey = $"GetAllStudentsAll";
                if (!_MemoryCache.TryGetValue(cacheKey, out List<StudentMaster> StudentcachedResult))
                {
                    StudentcachedResult = await _baseDbContext.StudentMaster.ToListAsync();
                    _MemoryCache.Set(cacheKey, StudentcachedResult, TimeSpan.FromHours(1));
                }
                return Ok(StudentcachedResult);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StudentController>
        [HttpPost]
        [Route("PostStudents")]
        public async Task<IActionResult> PostStudents([FromBody] StudentMaster value)
        {
            try
            {
                if(value == null)
                {
                    return BadRequest("Student data is null");
                }
                else
                {
                    _baseDbContext.StudentMaster.Add(value);
                    await _baseDbContext.SaveChangesAsync();
                    return CreatedAtAction(nameof(GetStudents), new { id = value.Id }, value);
                }
               
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
