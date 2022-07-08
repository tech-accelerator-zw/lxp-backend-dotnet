namespace UserManagement.API.Models.Data
{
    public class StudentRequest
    {
        public int UserId { get; set; }
        public string? FirstNames { get; set; }
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Otp { get; set; }
    }
}