//using ASP.NETCoreWebMainAPI.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace ASP.NETCoreWebMainAPI.Controllers
//{
//    [Route("api/[controller]")]

//        private readonly myDbContext context;

//        public StudentAPIController(myDbContext context)
//        {
//            this.context = context;
//        }

//        [HttpGet]
//        public async Task<ActionResult<List<Student>>> GetStudents()
//        {
//            var data = await context.Students.ToListAsync();
//            return Ok(data);
//        }
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Student>> GetStudentById(int id)
//        {
//            var student = await context.Students.FindAsync(id);
//            if (student == null)
//            {
//                return NotFound();
//            }
//            return student;
//        }



//        [HttpPost]
//        public async Task<ActionResult<Student>> CreateStudent(Student std)
//        {
//            await context.Students.AddAsync(std);
//            await context.SaveChangesAsync();
//            return Ok(std);
//        }


//        [HttpPut("{id}")]
//        public async Task<ActionResult<Student>> UpdateStudent(int id, Student std)
//        {
//            if (id != std.Id)
//            {
//                return BadRequest();
//            }

//            context.Entry(std).State = EntityState.Modified;
//            await context.SaveChangesAsync();
//            return Ok(std);

//        }



//        [HttpDelete("{id}")]
//        public async Task<ActionResult<Student>> DeleteStudent(int id)
//        {
//            var std = await context.Students.FindAsync(id);
//            if (std == null)
//            {
//                return NotFound();
//            }
//            context.Students.Remove(std);
//            await context.SaveChangesAsync();
//            return Ok();
//        }




//    }
//}


//using System.Collections.Generic;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using ASP.NETCoreWebMainAPI.Models;

//namespace ASP.NETCoreWebMainAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class StudentAPIController : ControllerBase
//    {
//        private readonly myDbContext context;

//        public StudentAPIController(myDbContext context)
//        {
//            this.context = context;
//        }

//        [HttpGet]
//        public async Task<ActionResult<List<Student>>> GetStudents()
//        {
//            var data = await context.Students.ToListAsync();
//            await context.Database.ExecuteSqlRawAsync("EXEC LogOperation 'GetStudents', 'Students', NULL");
//            return Ok(data);
//        }

//        [HttpPost]
//        public async Task<ActionResult<Student>> CreateStudent(Student std)
//        {
//            await context.Students.AddAsync(std);
//            await context.SaveChangesAsync();
//            await context.Database.ExecuteSqlRawAsync("EXEC LogOperation 'CreateStudent', 'Students', {0}", std.Id);
//            return Ok(std);
//        }

//        [HttpPut("{id}")]
//        public async Task<ActionResult<Student>> UpdateStudent(int id, Student std)
//        {
//            if (id != std.Id)
//            {
//                return BadRequest();
//            }

//            context.Entry(std).State = EntityState.Modified;
//            await context.SaveChangesAsync();
//            await context.Database.ExecuteSqlRawAsync("EXEC LogOperation 'UpdateStudent', 'Students', {0}", std.Id);
//            return Ok(std);
//        }

//        [HttpDelete("{id}")]
//        public async Task<ActionResult<Student>> DeleteStudent(int id)
//        {
//            var std = await context.Students.FindAsync(id);
//            if (std == null)
//            {
//                return NotFound();
//            }
//            context.Students.Remove(std);
//            await context.SaveChangesAsync();
//            await context.Database.ExecuteSqlRawAsync("EXEC LogOperation 'DeleteStudent', 'Students', {0}", id);
//            return Ok();
//        }
//    }
//}using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASP.NETCoreWebMainAPI.Models;

namespace ASP.NETCoreWebMainAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAPIController : ControllerBase
    {
        private readonly myDbContext context;

        public StudentAPIController(myDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudents()
        {
            var data = await context.Students.ToListAsync();
            await LogOperationAsync("GetStudents", "Students", null);
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            var student = await context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            await LogOperationAsync("GetStudentById", "Students", id);
            return student;
        }

        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent(Student std)
        {
            await context.Students.AddAsync(std);
            await context.SaveChangesAsync();
            await LogOperationAsync("CreateStudent", "Students", std.Id);
            return Ok(std);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> UpdateStudent(int id, Student std)
        {
            if (id != std.Id)
            {
                return BadRequest();
            }

            context.Entry(std).State = EntityState.Modified;
            await context.SaveChangesAsync();
            await LogOperationAsync("UpdateStudent", "Students", std.Id);
            return Ok(std);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {
            var std = await context.Students.FindAsync(id);
            if (std == null)
            {
                return NotFound();
            }
            context.Students.Remove(std);
            await context.SaveChangesAsync();
            await LogOperationAsync("DeleteStudent", "Students", id);
            return Ok();
        }

        private async Task LogOperationAsync(string operation, string tableName, int? recordId)
        {
            await context.Database.ExecuteSqlRawAsync("EXEC LogOperation {0}, {1}, {2}", operation, tableName, recordId);
        }
    }
}