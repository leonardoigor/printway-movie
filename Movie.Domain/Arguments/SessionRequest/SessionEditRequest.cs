using Movie.Domain.Entities;
using Movie.Domain.Enums;

namespace Movie.Domain.Arguments.SessionRequest;

public class SessionEditRequest
{
    public string EndTime;
    public Guid MovieId;
    public string StartTime;
    public TypeAnimation TypeAnimation { get; set; }
    public DateTime Date { get; set; }
    public Entities.Movie Movie { get; set; }
    public double Price { get; set; }
    public Room Room { get; set; }
    public string EndDate { get; set; }
    public bool IsDubbed { get; set; }
    public string StartDate { get; set; }
    public Guid Id { get; set; }
}
