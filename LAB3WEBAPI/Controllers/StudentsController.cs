using Microsoft.AspNetCore.Mvc;
using LAB3WEBAPI.Models;


namespace LAB3WEBAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private static List<Student> students = new List<Student>
        {
            new Student
            {
                Id = 22490470,
                Name = "Ayanda",
                Course = "ICT",
                Age = 21
            },
            new Student
            {
                Id = 22455155,
                Name = "Nosipho",
                Course = "Computer Science",
                Age = 22
            }
        };
        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(students);
        }
        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            students.Add(student);
            return CreatedAtAction(nameof(GetStudent),
                new { id = student.Id },
                student
                );
        }
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, Student updateStudent)
        {
            var student = students.FirstOrDefault(s=> s.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            student.Name = updateStudent.Name;
            student.Course = updateStudent.Course;
            student.Age = updateStudent.Age;

            return Ok(student);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            students.Remove(student);
            return NoContent();
        }
    }
}
