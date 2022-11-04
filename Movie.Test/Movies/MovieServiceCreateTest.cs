using Moq;
using Movie.Domain.Arguments.Movie;
using Movie.Domain.Entities;
using Movie.Domain.Interfaces.Repositories;
using Movie.Domain.Interfaces.Services;
using Movie.Domain.Services;

namespace Movie.Test.Movies;

public class MovieServiceCreateTest
{
    private Mock<IMovieRepository> _movieRepositoryMock;
    private IMovieService _movieService;

    [SetUp]
    public void Setup()
    {
        _movieRepositoryMock = new Mock<IMovieRepository>();
        _movieService = new MovieService();
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }

    [Test]
    public void MustFaildIfRequestHasError()
    {
        var req = new MovieAddRequest
        {
            Movie = new Domain.Entities.Movie("", "", "", TimeSpan.MinValue),
            Room = new Room("teste", 50)
        };
        var result = _movieService.AddMovie(req);
        Assert.AreEqual(result, false);
    }


    [TearDown]
    public void TearDown()
    {
        _movieRepositoryMock = null;
        _movieService = null;
    }
}
