namespace MvcApp.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string? Name { get; set; } // имя пользователя
        public int Age { get; set; } // возраст пользователя
        public int? CompanyId { get; set; }
        public Company? Company { get; set; }
    }
}