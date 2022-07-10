using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagement.API.Models
{
    public class Institute
    {
        public int Id { get; set; }
        public string? RegisteredName { get; set; }
        public string? LogoUrl { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        [ForeignKey("UserId")]
        public Account? Account { get; set; }
    }
}