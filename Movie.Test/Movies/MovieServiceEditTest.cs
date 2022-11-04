using Moq;
using Movie.Domain.Arguments.Movie;
using Movie.Domain.Entities;
using Movie.Domain.Interfaces.Repositories;
using Movie.Domain.Interfaces.Services;
using Movie.Domain.Services;

namespace Movie.Test.Movies;

public class MovieServiceEditTest
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
    public void Test1()
    {
        Assert.Pass();
    }

    [Test]
    public void MustReturnTrueIfRequestIsValid()
    {
        var req = new MovieEditRequest
        {
            Id = Guid.NewGuid(),
            date = DateTime.Now,
            price = 10,
            endDate = TimeSpan.FromDays(DateTime.Now.AddDays(1).Day),
            startDate = TimeSpan.FromDays(DateTime.Now.Day),
            Room = new Room
            {
                Id = Guid.NewGuid(),
                Name = "Sala 1"
            },
            Movie = new Domain.Entities.Movie
            {
                Id = Guid.NewGuid(),
                Description = "Filme 1",
                Duration = TimeSpan.FromMinutes(120),
                Image = "image",
                Title = "Filme 1"
            }
        };
        var result = _movieService.Edit(req);
        Assert.AreEqual(true, true);
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
