using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_DBM.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School_DBM.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly SchoolContext _context;

        public SchoolController(SchoolContext context)
        {
            _context = context;

            if (_context.PersonItems.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                SchoolItem.Person new_student = new SchoolItem.Person { FirstName = "Student1" };
                _context.PersonItems.Add(new_student);
                _context.SaveChanges();
            }
        }
        // GET: api/School
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SchoolItem.Person>>> GetSchoolItems()
        {
            return await _context.PersonItems.ToListAsync();
        }

        // GET: api/Student/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SchoolItem.Person>> GetTSchoolItem(int id)
        {
            var schoolItem = await _context.PersonItems.FindAsync(id);

            if (schoolItem == null)
            {
                return NotFound();
            }

            return schoolItem;
        }

        // POST: api/School
        [HttpPost]
        public async Task<ActionResult<SchoolItem.Person>> PostTodoItem(SchoolItem.Person item)
        {
            _context.PersonItems.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTSchoolItem), new { id = item.id }, item);
        }

        // PUT: api/School/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(long id, SchoolItem.Person item)
        {
            if (id != item.id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Todo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            var todoItem = await _context.PersonItems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            _context.PersonItems.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}






//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;

//namespace School_DBM.Controllers
//{
//    [Route("api/[controller]")]
//    public class SchoolController : Controller
//    {
//        // GET: api/<controller>
//        [HttpGet]
//        public IEnumerable<string> Get()
//        {
//            return new string[] { "value1", "value2" };
//        }

//        // GET api/<controller>/5
//        [HttpGet("{id}")]
//        public string Get(int id)
//        {
//            return "value";
//        }

//        // POST api/<controller>
//        [HttpPost]
//        public void Post([FromBody]string value)
//        {
//        }

//        // PUT api/<controller>/5
//        [HttpPut("{id}")]
//        public void Put(int id, [FromBody]string value)
//        {
//        }

//        // DELETE api/<controller>/5
//        [HttpDelete("{id}")]
//        public void Delete(int id)
//        {
//        }
//    }
//}
