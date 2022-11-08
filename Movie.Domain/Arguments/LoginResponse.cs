using Movie.Domain.Entities;

namespace Movie.Domain.Arguments;

public class LoginResponse
{
    public Token Token { get; set; }
    public DateTime Expires { get; set; }
    public string TokenType { get; set; }
    public string Email { get; set; }
}
