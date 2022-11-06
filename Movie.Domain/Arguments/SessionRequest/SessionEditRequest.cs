using Movie.Domain.Entities;
using Movie.Domain.Enums;

namespace Movie.Domain.Arguments.SessionRequest;

public class SessionEditRequest
{
    public string EndTime;
    public Entities.Movie Movie;
    public Room Room;
    public string StartTime;

    public SessionEditRequest()
    {
        Movie = new Entities.Movie();
        Room = new Room();
    }

    public Guid MovieId { get; set; }
    public Guid RoomId { get; set; }
    public TypeAnimation TypeAnimation { get; set; }
    public DateTime Date { get; set; }
    public double Price { get; set; }
    public DateTime EndDate => StartDate.AddMinutes(Movie.Minutes).AddHours(Movie.Hours);
    public bool IsDubbed { get; set; }
    public DateTime StartDate { get; set; }
    public Guid Id { get; set; }
}
