using Moq;
using Movie.Domain.Arguments.RoomRequest;
using Movie.Domain.Entities;
using Movie.Domain.Interfaces.Repositories;
using Movie.Domain.Services;

namespace Movie.Test.Rooms;

public class RoomServiceCreateTest
{
    private Mock<IRoomRepository> _roomRepositoryMock;
    private RoomService _roomService;

    [SetUp]
    public void Setup()
    {
        _roomRepositoryMock = new Mock<IRoomRepository>();
        _roomService = new RoomService(_roomRepositoryMock.Object);
    }

    [Test]
    public void MustReturnFalseIfReqIsInvalid()
    {
        var req = new RoomAddRequest
        {
            Room = new Room
            {
                Name = "sa",
                Quantity = 50
            }
        };
        var result = _roomService.Add(req);
        Assert.AreEqual(false, _roomService.IsValid());
        Assert.AreEqual(false, result);
    }

    [Test]
    public void MustReturnTrueIfReqIsvalid()
    {
        _roomRepositoryMock.Setup(x => x.Add(It.IsAny<Room>())).Returns(new Room());
        var req = new RoomAddRequest
        {
            Room = new Room
            {
                Name = "sala 1",
                Quantity = 50
            }
        };
        var result = _roomService.Add(req);
        Assert.AreEqual(true, _roomService.IsValid());
        Assert.AreEqual(true, result);
    }


    [TearDown]
    public void TearDown()
    {
        _roomRepositoryMock = null;
        _roomService = null;
    }
}
