namespace FirstWebAPI.Model
{
    public class EmpViewModel
    {
        public int EmpId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public String City { get; set; } = String.Empty;
        public int ReportsTo { get; set; }



    }
}
