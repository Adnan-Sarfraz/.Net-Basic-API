using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private static List<Student> students = new List<Student>();
        private static int nextId = 1;

        // GET: api/student
        [HttpGet]
        public ActionResult<IEnumerable<StudentResponse>> GetAll()
        {
            var response = students.Select(s => new StudentResponse
            {
                Id = s.Id,
                Name = s.Name,
                Email = s.Email
            });

            return Ok(response);
        }

        // POST: api/student
        [HttpPost]
        public IActionResult Create([FromBody] CreateStudentRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var student = new Student
            {
                Id = nextId++,
                Name = request.Name,
                Email = request.Email,
                Age = request.Age
            };

            students.Add(student);

            var response = new StudentResponse
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email
            };

            return CreatedAtAction(nameof(GetAll), new { id = student.Id }, response);
        }
    }
}
