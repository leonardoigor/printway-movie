using Movie.Domain.Entities;

namespace Movie.Domain.Arguments.Movie;

public class MovieDeleteRequest
{
    public DateTime date;
    public TimeSpan endDate;
    public double price;
    public TimeSpan startDate;
    public Enum typeAnimation;


    public MovieDeleteRequest()
    {
    }

    public MovieDeleteRequest(DateTime date, TimeSpan endDate, double price, TimeSpan startDate, Enum typeAnimation,
        Guid id, Entities.Movie movie, Room room)
    {
        this.date = date;
        this.endDate = endDate;
        this.price = price;
        this.startDate = startDate;
        this.typeAnimation = typeAnimation;
        Id = id;
        Movie = movie;
        Room = room;
    }

    public Guid Id { get; set; }


    public Entities.Movie Movie { get; set; }
    public Room Room { get; set; }
}
