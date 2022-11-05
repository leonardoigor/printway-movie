using Moq;
using Movie.Domain.Arguments.Movie;
using Movie.Domain.Interfaces.Repositories;
using Movie.Domain.Interfaces.Services;
using Movie.Domain.Services;

namespace Movie.Test.Movies;

public class MovieServiceDeleteTest
{
    private Mock<IMovieRepository> _movieRepositoryMock;
    private IMovieService _movieService;

    [SetUp]
    public void Setup()
    {
        _movieRepositoryMock = new Mock<IMovieRepository>();
        _movieService = new MovieService(
            _movieRepositoryMock.Object);
    }

    [Test]
    public void MustReturnFalseIfRequestIsInvalid()
    {
        var req = new DeleteMovieRequest
        {
            Id = Guid.NewGuid(),
            date = DateTime.Now,
            price = 10,
            endDate = TimeSpan.FromDays(DateTime.Now.AddDays(1).Day),
            startDate = TimeSpan.FromDays(DateTime.Now.Day),

            Movie = new Domain.Entities.Movie
            {
                Id = Guid.NewGuid(),
                Description = "",
                Duration = DateTime.Now,
                Image = "",
                Title = ""
            }
        };
        var result = _movieService.Remove(req);
        Assert.AreEqual(result, false);
        Assert.AreEqual(_movieService.IsValid(), false);
    }

    [Test]
    public void MustReturnTrueIfRequestIsvalid()
    {
        var req = new DeleteMovieRequest
        {
            Id = Guid.NewGuid(),
            date = DateTime.Now,
            price = 10,
            endDate = TimeSpan.FromDays(DateTime.Now.AddDays(1).Day),
            startDate = TimeSpan.FromDays(DateTime.Now.Day),

            Movie = new Domain.Entities.Movie
            {
                Id = Guid.NewGuid(),
                Description = "0000",
                Duration = DateTime.Now,
                Image = "000",
                Title = "00"
            }
        };
        var result = _movieService.Remove(req);
        Assert.AreEqual(_movieService.IsValid(), true);
        Assert.AreEqual(result, true);
    }


    [TearDown]
    public void TearDown()
    {
        _movieRepositoryMock = null;
        _movieService = null;
    }
}