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
    public void MustReturnFalseIfRequestHasError()
    {
        _sessionRepositoryMock.Setup(x => x.Add(It.IsAny<Session>())).Returns(new Session());
        _roomRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(new Room());
        _movieRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(new Domain.Entities.Movie());
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
        _movieRepositoryMock.Setup(x => x.Add(It.IsAny<Domain.Entities.Movie>())).Returns(new Domain.Entities.Movie());
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
        _movieRepositoryMock = null;
        _roomRepositoryMock = null;
        _movieService = null;
    }
}
