using Movie.Domain.Enums;

namespace Movie.Domain.Arguments.SessionRequest;

public class SessionAddRequest
{
    public Entities.Movie Movie;
    public Guid RoomId { get; set; }
    public Guid MovieId { get; set; }

    public TypeAnimation TypeAnimation { get; set; }
    public DateTime Date { get; set; }
    public double Price { get; set; }
    public bool IsDubbed { get; set; }
    public DateTime EndDate => StartDate.AddMinutes(Movie.Minutes).AddHours(Movie.Hours);

    public DateTime StartDate { get; set; }
}
