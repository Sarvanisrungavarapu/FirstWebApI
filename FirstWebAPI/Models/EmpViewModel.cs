namespace FirstWebAPI.Models
{
    public class EmpViewModel
    {
        public int EmpId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Title { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? HireDate { get; set; }
        public string City { get; set; } = string.Empty;
        public int? ReportsTo { get; set; }
    }
}
