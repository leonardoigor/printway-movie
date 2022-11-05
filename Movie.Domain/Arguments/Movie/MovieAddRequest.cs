namespace Movie.Domain.Arguments.Movie;

public class MovieAddRequest
{
    public MovieAddRequest()
    {
    }

    public MovieAddRequest(Entities.Movie movie)
    {
        Movie = movie;
    }


    public Entities.Movie Movie { get; set; }
}
