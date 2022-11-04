using Moq;
using Movie.Domain.Arguments.RoomRequest;
using Movie.Domain.Entities;
using Movie.Domain.Interfaces.Repositories;
using Movie.Domain.Services;

namespace Movie.Test.Rooms;

public class RoomServiceEditTest
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
        var req = new EditRoomRequest
        {
            Room = new Room
            {
                Name = "Sa",
                Quantity = 0
            }
        };

        var result = _roomService.Edit(req);

        Assert.AreEqual(false, _roomService.IsValid());
        Assert.AreEqual(false, result);
    }

    [Test]
    public void MustReturnTrueIfReqIsInvalidAndMustReturnResultTrue()
    {
        _roomRepositoryMock.Setup(x => x.Edit(It.IsAny<Room>())).Returns(new Room());
        var req = new EditRoomRequest
        {
            Room = new Room
            {
                Name = "Sala 1",
                Quantity = 0
            }
        };

        var result = _roomService.Edit(req);

        Assert.AreEqual(true, _roomService.IsValid());
        Assert.AreEqual(true, result);
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }

    [TearDown]
    public void TearDown()
    {
        _roomRepositoryMock = null;
        _roomService = null;
    }
}
