using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagement.API.Models
{
    public class Lecturer
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Title { get; set; }
        public bool IsActive { get; set; } = true;
        [ForeignKey("UserId")]
        public Account? Account { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}