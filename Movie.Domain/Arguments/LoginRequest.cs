namespace Movie.Domain.Arguments;

public class LoginRequest
{
    public LoginRequest()
    {

    }
    public LoginRequest(string email, string password)
    {
        this.email = email;
        this.password = password;
    }

    public string email { get; set; }
    public string password { get; set; }
}
