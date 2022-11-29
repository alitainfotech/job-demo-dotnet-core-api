namespace JobApplicationApi.Models
{
    public class Candidate
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime Date { get; set; }
        public string? POB { get; set; }
        public string? FilePath { get; set; }
        public string? Department { get; set; }
    }
}
