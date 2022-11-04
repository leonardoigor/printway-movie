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
    private Mock<IRoomRepository> _roomRepositoryMock;
    private Mock<ISessionRepository> _sessionRepositoryMock;

    [SetUp]
    public void Setup()
    {
        _sessionRepositoryMock = new Mock<ISessionRepository>();
        _movieRepositoryMock = new Mock<IMovieRepository>();
        _roomRepositoryMock = new Mock<IRoomRepository>();
        _movieService = new MovieService(_sessionRepositoryMock.Object, _roomRepositoryMock.Object,
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
                Duration = TimeSpan.FromMinutes(120),
                Image = "",
                Title = ""
            }
        };
        var result = _movieService.Remove(req);
        Assert.AreEqual(result, false);
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
                Duration = TimeSpan.FromMinutes(120),
                Image = "000",
                Title = "00"
            }
        };
        _movieService.Remove(req);
        Assert.AreEqual(_movieService.IsValid(), true);
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }

    [TearDown]
    public void TearDown()
    {
        _sessionRepositoryMock = null;
        _movieRepositoryMock = null;
        _roomRepositoryMock = null;
        _movieService = null;
    }
}
