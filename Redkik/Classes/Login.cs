namespace Redkik.Classes
{
    public class Login
    {
        public string? email { get; set; }
        public string? password { get; set; }

        public Login(string email, string password)
        {
            this.email = email;
            this.password = password;
        }
    }
}
