namespace MvcApp.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<Person> Users { get; set; } = new();
    }
}