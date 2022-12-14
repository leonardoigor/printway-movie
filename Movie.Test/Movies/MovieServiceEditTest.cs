using Moq;
using Movie.Domain.Arguments.Movie;
using Movie.Domain.Interfaces.Repositories;
using Movie.Domain.Interfaces.Services;
using Movie.Domain.Services;

namespace Movie.Test.Movies;

public class MovieServiceEditTest
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
    public void MustReturnFalseIfRequestIsInValid()
    {
        var req = new MovieEditRequest
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
                Hours = 0,
                Minutes = 0,
                Image = "",
                Title = ""
            }
        };
        var result = _movieService.Edit(req);
        Assert.AreEqual(result, false);
        Assert.AreEqual(_movieService.IsValid(), false);
    }

    [Test]
    public void MustReturnTrueIfRequestIsValid()
    {
        _movieRepositoryMock.Setup(x => x.Edit(It.IsAny<Domain.Entities.Movie>())).Returns(new Domain.Entities.Movie());
        var req = new MovieEditRequest
        {
            Id = Guid.NewGuid(),
            date = DateTime.Now,
            price = 10,
            endDate = TimeSpan.FromDays(DateTime.Now.AddDays(1).Day),
            startDate = TimeSpan.FromDays(DateTime.Now.Day),

            Movie = new Domain.Entities.Movie
            {
                Id = Guid.NewGuid(),
                Description = "Filme 1",
                Minutes = 0,
                Hours = 0, Image = "image",
                Title = "Filme 1"
            }
        };
        var result = _movieService.Edit(req);
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
