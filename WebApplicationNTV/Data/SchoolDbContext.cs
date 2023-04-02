using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using WebApplicationNTV.Models;

namespace WebApplicationNTV.Data
{
    public class SchoolDbContext : DbContext
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Marks> Marks { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=SchoolDB;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Group g1 = new Group { GroupId = 1, Name = "H22-FK1" };
            Group g2 = new Group { GroupId = 2, Name = "H22-FK2" };
            Group g3 = new Group { GroupId = 3, Name = "H22-FK3" };

            modelBuilder.Entity<Group>().HasData(g1);
            modelBuilder.Entity<Group>().HasData(g2);
            modelBuilder.Entity<Group>().HasData(g3);

            Subject s1 = new Subject { SubjectId = 1, Title = "Programming"};
            Subject s2 = new Subject { SubjectId = 2, Title = "Programming2" };
            Subject s3 = new Subject { SubjectId = 3, Title = "Programming3" };

            modelBuilder.Entity<Subject>().HasData(s1);
            modelBuilder.Entity<Subject>().HasData(s2);
            modelBuilder.Entity<Subject>().HasData(s3);

            Student st1 = new Student { StudentId = 1,  FirstName = "F1rstName", LastName = "LastName", GroupId = 1 };
            Student st2 = new Student { StudentId = 2,  FirstName = "FirstN2me", LastName = "L2stN2me", GroupId = 2 };
            Student st3 = new Student { StudentId = 3,  FirstName = "FirstNam3", LastName = "LastNam3", GroupId = 3 };

            modelBuilder.Entity<Student>().HasData(st1);
            modelBuilder.Entity<Student>().HasData(st2);    
            modelBuilder.Entity<Student>().HasData(st3);

            Teacher t1 = new Teacher { TeacherId = 1, FirstName = "Hjörtur", LastName = "Pálmi" };
            

            Teacher t2 = new Teacher { TeacherId = 2, FirstName = "Hjörtur2", LastName = "Pálmi" };
            modelBuilder.Entity<Teacher>().HasData(t2);
            modelBuilder.Entity<Teacher>().HasData(t1);

        }


    }
}
