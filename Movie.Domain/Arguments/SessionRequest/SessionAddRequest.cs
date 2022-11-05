using Movie.Domain.Enums;

namespace Movie.Domain.Arguments.SessionRequest;

public class SessionAddRequest
{
    public string EndTime { get; set; }
    public string StartTime { get; set; }
    public Guid RoomId { get; set; }
    public Guid MovieId { get; set; }

    public TypeAnimation TypeAnimation { get; set; }
    public DateTime Date { get; set; }
    public double Price { get; set; }
    public string EndDate { get; set; }
    public bool IsDubbed { get; set; }
    public string StartDate { get; set; }
}
