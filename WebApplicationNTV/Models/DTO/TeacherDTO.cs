﻿namespace WebApplicationNTV.Models
{
    public class TeacherDTO
    {
        public TeacherDTO() 
        {
        
        } 


        public string FirstName { get; set; }


        public List<Subject> Subjects { get; set; }
    }
}
