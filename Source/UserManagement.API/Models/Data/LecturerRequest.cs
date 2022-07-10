namespace UserManagement.API.Models.Data
{
    public class LecturerRequest
    {
        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Title { get; set; }
        public string? Otp { get; set; }
    }
}