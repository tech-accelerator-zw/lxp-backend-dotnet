using UserManagement.API.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagement.API.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }
        public int RoleId { get; set; }
        public AccountStatus Status { get; set; }
        [ForeignKey("RoleId")]
        public Role? Role { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        [NotMapped]
        public string? Token { get; set; }
    }
}