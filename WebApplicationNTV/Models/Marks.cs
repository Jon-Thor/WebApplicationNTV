namespace WebApplicationNTV.Models
{
    public class Marks
    {
        public Marks() 
        {
            Date = DateTime.Now;
        }  
        public int MarksId { get; set; }

        public int StudentId { get; set; }  // Foreignkey

        public Student Student { get; set; } // Navigation property

        public int SubjectId { get; set; } // Foreignkey

        public Subject Subject { get; set; } // Navigation property

        public DateTime Date { get; set; }

        public int Mark { get; set; }
    }
}
