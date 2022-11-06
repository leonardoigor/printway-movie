using Movie.Domain.Arguments.Movie;
using Movie.Domain.Interfaces.Repositories;
using Movie.Domain.Interfaces.Services;
using Movie.Domain.Services.Base;
using prmToolkit.NotificationPattern;

namespace Movie.Domain.Services;

public class MovieService : Notifiable, IMovieService, IServiceBase
{
    private readonly IMovieRepository _movieRepository;


    public MovieService(
        IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }


    public bool AddMovie(MovieAddRequest movieRequest)
    {
        var movie = new Entities.Movie(movieRequest.Movie.Image, movieRequest.Movie.Title,
            movieRequest.Movie.Description, movieRequest.Movie.Minutes, movieRequest.Movie.Hours);

        AddNotifications(movie);
        if (IsInvalid())
            return false;
        var result = _movieRepository.Add(movie);
        if (result == null)
            return false;
        return true;
    }

    public bool Edit(MovieEditRequest movieRequest)
    {
        var movie = new Entities.Movie(movieRequest.Movie.Image, movieRequest.Movie.Title,
            movieRequest.Movie.Description, movieRequest.Movie.Minutes, movieRequest.Movie.Hours);
        _movieRepository.Add(movie);
        AddNotifications(movie);
        if (IsInvalid())
            return false;
        var result = _movieRepository.Edit(movie);
        if (result == null)
            return false;
        return true;
    }

    public bool Remove(DeleteMovieRequest movieRequest)
    {
        var movie = new Entities.Movie(movieRequest.Movie.Image, movieRequest.Movie.Title,
            movieRequest.Movie.Description, movieRequest.Movie.Minutes, movieRequest.Movie.Hours);
        _movieRepository.Add(movie);
        AddNotifications(movie);
        if (IsInvalid())
            return false;
        var result = _movieRepository.Remove(movie);
        if (result == null)
            return false;
        return true;
    }

    public bool Exist(Guid movieId)
    {
        var result = _movieRepository.Exist(x => x.Id == movieId);
        if (!result)
            AddNotification("Filme", "Filme não encontrado");
        return result;
    }

    public bool Exist(string movieTitle)
    {
        var result = _movieRepository.Exist(x => x.Title == movieTitle);
        if (!result)
            AddNotification("Filme", "Filme não encontrado");
        return result;
    }

    public List<Entities.Movie> GetMovies()
    {
        return _movieRepository.List().ToList();
    }

    public bool UpdateMovie(MovieEditRequest request)
    {
        var movie = _movieRepository.GetById(request.Id);
        if (movie == null)
        {
            AddNotification("Filme", "Filme não encontrado");
            return false;
        }

        movie.Description = request.Movie.Description;
        movie.Hours = request.Movie.Hours;
        movie.Minutes = request.Movie.Minutes;
        movie.Title = request.Movie.Title;
        movie.Image = request.Movie.Image;
        var result = _movieRepository.Edit(movie);
        if (result == null)
        {
            AddNotification("Filme", "Filme não encontrado");
            return false;
        }

        return true;
    }

    public bool DeleteMovie(Guid id)
    {
        var movie = _movieRepository.GetById(id);
        if (movie == null)
        {
            AddNotification("Filme", "Filme não encontrado");
            return false;
        }

        var result = _movieRepository.Remove(movie);
        if (result == null)
        {
            AddNotification("Filme", "Filme não encontrado");
            return false;
        }

        return true;
    }
}
