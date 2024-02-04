namespace MVCEFcore.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Duration { get; set; }
        public string Topic { get; set; }
        public DateTime StartDate { get; set; }
    }
}