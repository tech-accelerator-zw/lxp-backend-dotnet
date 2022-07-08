namespace UserManagement.API.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? FirstNames { get; set; }
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsActive { get; set; } = false;
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}