using Movie.Domain.Entities;

namespace Movie.Domain.Arguments.Movie;

public class MovieAddRequest
{
    public DateTime date;
    public TimeSpan endDate;
    public double price;
    public TimeSpan startDate;
    public Enum typeAnimation;

    public MovieAddRequest()
    {
    }

    public MovieAddRequest(Entities.Movie movie, Room room)
    {
        Movie = movie;
        Room = room;
    }

    public Entities.Movie Movie { get; set; }
    public Room Room { get; set; }
}
