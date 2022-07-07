using UserManagement.API.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace UserManagement.API.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; } 
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }
        public int RoleId { get; set; }
        public AccountStatus Status { get; set; }
        [ForeignKey("RoleId")]
        public Role? Role { get; set; }
        public DateTime DateCreated { get; set; }
        [NotMapped]
        public string? Token { get; set; }

    }
}