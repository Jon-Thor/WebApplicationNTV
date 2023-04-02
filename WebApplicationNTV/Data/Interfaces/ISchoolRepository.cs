using Microsoft.AspNetCore.Mvc;
using WebApplicationNTV.Models;

namespace WebApplicationNTV.Data.Interfaces
{
    public interface ISchoolRepository
    {
        List<Teacher> GetAllTeachers();

        List<Student> GetAllStudents();

        Teacher? GetTeacherById(int id);

        void CreateTeacher(Teacher teacher);

        Teacher? UpdateTeacher(int id, Teacher teacherFromBody);

        bool DeleteTeacher(Teacher teacher);

    }
}
