namespace UserManagement.API.Models.Data
{
    public class InstituteRequest
    {
        public int UserId { get; set; }
        public string? RegisteredName { get; set; }
        public string? LogoUrl { get; set; }
        public string? Otp { get; set; }
    }
}