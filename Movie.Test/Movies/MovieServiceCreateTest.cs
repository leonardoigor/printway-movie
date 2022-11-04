using Moq;
using Movie.Domain.Arguments.Movie;
using Movie.Domain.Entities;
using Movie.Domain.Interfaces.Repositories;
using Movie.Domain.Interfaces.Services;
using Movie.Domain.Services;

namespace Movie.Test.Movies;

public class MovieServiceCreateTest
{
    private IMovieService _movieService;
    private Mock<ISessionRepository> _sessionRepositoryMock;

    [SetUp]
    public void Setup()
    {
        _sessionRepositoryMock = new Mock<ISessionRepository>();
        _movieService = new MovieService(_sessionRepositoryMock.Object);
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }

    [Test]
    public void MustReturnFalseIfRequestHasError()
    {
        var req = new MovieAddRequest
        {
            Movie = new Domain.Entities.Movie("", "", "", TimeSpan.MinValue),
            Room = new Room("teste", 50)
        };
        var result = _movieService.AddMovie(req);
        Assert.AreEqual(result, false);
    }

    [Test]
    public void MustReturnTrueIfRequestIsValid()
    {
        _sessionRepositoryMock.Setup(x => x.Add(It.IsAny<Session>())).Returns(new Session());
        var req = new MovieAddRequest
        {
            Movie = new Domain.Entities.Movie("0000", "0000", "000", TimeSpan.MinValue),
            Room = new Room("teste", 50)
        };
        var result = _movieService.AddMovie(req);
        Assert.AreEqual(result, true);
    }


    [TearDown]
    public void TearDown()
    {
        _sessionRepositoryMock = null;
        _movieService = null;
    }
}
