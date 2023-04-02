using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationNTV.Data.Interfaces;
using WebApplicationNTV.Models;

namespace WebApplicationNTV.Data
{
    public class MockRepository : ISchoolRepository
    {
        List<Teacher> Teachers = new List<Teacher>()
        {
            new Teacher { TeacherId = 1, FirstName = "Mock-Hjörtur", LastName = "Pálmi"},
            new Teacher { TeacherId = 2, FirstName = "Mock2-Hjörtur", LastName = "Pálmi"},
            new Teacher { TeacherId = 3, FirstName = "Mock3-Hjörtur", LastName = "Pálmi"},
            new Teacher { TeacherId = 4, FirstName = "Mock4-Hjörtur", LastName = "Pálmi"},
        };

        List<Student> Students = new List<Student>() { new Student { StudentId = 1, FirstName = " Mock_Student", LastName = "Mock-LastName" } };

        public List<Teacher> GetAllTeachers()
        {
            return Teachers;
        }

        public Teacher? GetTeacherById(int id)
        {
            return Teachers.Where(t => t.TeacherId == id).FirstOrDefault();
        }

        public List<Student> GetAllStudents()
        {
            return Students;
        }

        public void CreateTeacher(Teacher teacher)
        {
            throw new NotImplementedException();
        }

        public Teacher? UpdateTeacher(int id, Teacher teacherFromBody)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTeacher(Teacher teacher)
        {
            throw new NotImplementedException();
        }
    }//Don't go past this
}


