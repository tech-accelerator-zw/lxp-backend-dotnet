namespace UserManagement.API.Models.Data
{
    public class CompleteSignUpRequest
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? OtpCode { get; set; }
        public string? Password { get; set; }
    }
}