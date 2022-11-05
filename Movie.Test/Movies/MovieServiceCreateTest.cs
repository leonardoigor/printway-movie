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
        _movieService = new MovieService(
            _movieRepositoryMock.Object);
    }


    [Test]
    public void MustReturnFalseIfRequestHasError()
    {
        _movieRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(new Domain.Entities.Movie());
        var req = new MovieAddRequest
        {
            Movie = new Domain.Entities.Movie("", "", "", DateTime.Now),
            Room = new Room("teste", 50)
        };
        var result = _movieService.AddMovie(req);
        Assert.AreEqual(result, false);
        Assert.AreEqual(_movieService.IsValid(), false);
    }

    [Test]
    public void MustReturnTrueIfRequestIsValid()
    {
        _movieRepositoryMock.Setup(x => x.Add(It.IsAny<Domain.Entities.Movie>())).Returns(new Domain.Entities.Movie());
        var req = new MovieAddRequest
        {
            Movie = new Domain.Entities.Movie("0000", "0000", "000", DateTime.Now),
            Room = new Room("teste", 50)
        };
        var result = _movieService.AddMovie(req);
        Assert.AreEqual(result, true);
        Assert.AreEqual(_movieService.IsValid(), true);
    }


    [TearDown]
    public void TearDown()
    {
        _movieRepositoryMock = null;
        _movieService = null;
    }
}