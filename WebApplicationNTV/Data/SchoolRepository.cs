using Microsoft.EntityFrameworkCore;
using WebApplicationNTV.Data.Interfaces;
using WebApplicationNTV.Models;

namespace WebApplicationNTV.Data
{
    public class SchoolRepository : ISchoolRepository
    {
        private SchoolDbContext _dbContext;
        public SchoolRepository() 
        {
            _dbContext= new SchoolDbContext();
        }
        public List<Teacher> GetAllTeachers()
        {
           return _dbContext.Teachers.ToList();
        }

        public Teacher? GetTeacherById(int id)
        {
            return _dbContext.Teachers.Where(t => t.TeacherId == id).FirstOrDefault();
        }

        public List<Student> GetAllStudents()
        {
            return _dbContext.Students.ToList();
        }

        public void CreateTeacher(Teacher teacher)
        {
            _dbContext.Teachers.Add(teacher);
            _dbContext.SaveChanges();   
        }

        public Teacher? UpdateTeacher(int id, Teacher teacherFromBody)
        {

                Teacher? teacherFromDB = GetTeacherById(id);

                if (teacherFromDB == null)
                {
                    return null;
                }

                teacherFromDB.FirstName = teacherFromBody.FirstName;
                teacherFromDB.LastName = teacherFromBody.LastName;
                teacherFromDB.Subjects = teacherFromBody.Subjects;

            _dbContext.SaveChanges();

            return teacherFromDB;
        }

        public bool DeleteTeacher(Teacher teacher)
        {

            try { 

            _dbContext.Teachers.Remove(teacher);
            _dbContext.SaveChanges();  

            return true;
            
            }
            catch (Exception) {
            return false;  
            }
        }
    }//Don't go past this
}

