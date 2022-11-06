using Movie.Domain.Entities;
using Movie.Domain.Enums;

namespace Movie.Domain.Arguments.SessionRequest;

public class SessionRemoveRequest
{
    public string EndTime;
    public Guid MovieId;
    public string StartTime;
    public TypeAnimation TypeAnimation { get; set; }
    public DateTime Date { get; set; }
    public Entities.Movie Movie { get; set; }
    public double Price { get; set; }
    public Room Room { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsDubbed { get; set; }
    public DateTime StartDate { get; set; }
}
