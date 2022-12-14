using Moq;
using Movie.Domain.Arguments.SessionRequest;
using Movie.Domain.Interfaces.Repositories;
using Movie.Domain.Services;

namespace Movie.Test.Session;

public class SessionServiceAddTest
{
    private Mock<ISessionRepository> _sessionRepositoryMock;
    private SessionService sessionService;

    [SetUp]
    public void Setup()
    {
        _sessionRepositoryMock = new Mock<ISessionRepository>();
        sessionService = new SessionService(_sessionRepositoryMock.Object);
    }

    [Test]
    public void MustReturnTrueIfRequestIsOkAndCanAdd()
    {
        _sessionRepositoryMock.Setup(x => x.Add(It.IsAny<Domain.Entities.Session>()))
            .Returns(new Domain.Entities.Session());
        var req = new SessionAddRequest
        {
            Date = DateTime.Now,
            MovieId = Guid.NewGuid(),
            Price = 10d,
            RoomId = Guid.NewGuid(),
            EndDate = DateTime.Now.AddHours(2).ToLongDateString(),
            EndTime = DateTime.Now.AddHours(2).ToLongTimeString(),
            IsDubbed = true,
            StartDate = DateTime.Now.ToShortDateString(),
            StartTime = DateTime.Now.ToShortDateString()
        };

        var result = sessionService.Add(req);
        Assert.IsTrue(result);
        Assert.IsTrue(sessionService.IsValid());
    }

    [Test]
    public void MustReturnFaĆ§sefRequestIsOkAndCantAdd()
    {
        var req = new SessionAddRequest();

        var result = sessionService.Add(req);
        Assert.IsFalse(result);
        Assert.IsFalse(sessionService.IsInvalid());
    }


    [TearDown]
    public void TearDown()
    {
        _sessionRepositoryMock = null;
        sessionService = null;
    }
}
