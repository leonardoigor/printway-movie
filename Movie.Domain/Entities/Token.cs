using Microsoft.IdentityModel.Tokens;

namespace Movie.Domain.Entities;

public class Token
{
    public DateTime Expires { get; set; }
    public object tokenType { get; set; }
    public string TokenString { get; set; }
    public string email { get; set; }
}
