namespace Redkik.Classes
{
    public class LoginRequest
    {
        public string? email { get; set; }
        public string? password { get; set; }

        public LoginRequest(string email, string password)
        {
            this.email = email;
            this.password = password;
        }
    }
}
