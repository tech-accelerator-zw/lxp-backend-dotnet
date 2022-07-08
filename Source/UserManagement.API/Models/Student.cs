using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagement.API.Models
{
    public class Student
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? FirstNames { get; set; }
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        [ForeignKey("UserId")]
        public Account? Account { get; set; }
    }
}