namespace Movie.Domain.Arguments.Movie;

public class MovieEditRequest
{
    public MovieEditRequest()
    {
    }

    public MovieEditRequest(
        Guid id, Entities.Movie movie)
    {
        Id = id;
        Movie = movie;
    }


    public Guid Id { get; set; }


    public Entities.Movie Movie { get; set; }
}
