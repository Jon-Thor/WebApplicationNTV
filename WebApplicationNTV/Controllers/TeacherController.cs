using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationNTV.Data;
using WebApplicationNTV.Models;
using WebApplicationNTV.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationNTV.Controllers
{
    [Route("api")]
    [ApiController]
    public class TeacherController : ControllerBase
    {

        private ISchoolRepository _repo;
        
        public TeacherController(ISchoolRepository repo) 
        {
            _repo = repo;
        }


        [HttpGet]
        [Route("Teachers")]
        public List<Teacher> GetAllTeachers() 
        {
            return _repo.GetAllTeachers();
        }

       [HttpGet]
        [Route("Teachers/{id}")]

       public ActionResult<TeacherDTO> GetTeacherById(int id)
        {

            Teacher? teacher = _repo.GetTeacherById(id);

            if (teacher == null)
            {
                return NotFound();
            }

            TeacherDTO teacherDTO = new TeacherDTO() { FirstName = teacher.FirstName, Subjects = teacher.Subjects};

            return teacherDTO;

        }


        [HttpPost]
        [Route("Teachers")]
        public ActionResult<Teacher> CreateTeacher(Teacher teacher)
        {


            try {
                _repo.CreateTeacher(teacher); 
            
                //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
                return CreatedAtAction(nameof(GetTeacherById), new { id = teacher.TeacherId }, teacher);

            }
            catch(Exception) 
            {
                return StatusCode(500);
            }
            


        }

        [HttpPut]
        [Route("Teachers/{id}")]
        public  IActionResult UpdateTeacher(int id, Teacher teacherFromBody)
        {
            if (id != teacherFromBody.TeacherId)
            {
                return BadRequest();
            }

            try
            {
              Teacher? updated = _repo.UpdateTeacher(id, teacherFromBody);   

                if(updated == null)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpDelete]
        [Route("Teachers/{id}")]
        public ActionResult<bool> DeleteTeacherById(int id)
        {

            try
            {
                Teacher? teacher = _repo.GetTeacherById(id);

                if (teacher == null)
                {
                    return NotFound();
                }

              bool success =  _repo.DeleteTeacher(teacher);
                
                if (!success) 
                {
                    return StatusCode(500);
                }

                return Ok();

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpGet]
        [Route("Students")]
        public List<Student> GetAllStudents()
        {
            return _repo.GetAllStudents();
        }



    }
}
