using Movie.Domain.Entities.Base;
using Movie.Domain.Enums;
using Movie.Domain.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;

namespace Movie.Domain.Entities;

public class Session : EntityBase
{
    public Session()
    {
        NotificationsConfig();
    }

    public Session(DateTime date, string startDate, string endDate, double price, TypeAnimation typeAnimation,
        bool isDubbed, Movie movie, Room room)
    {
        Date = date;
        StartDate = startDate;
        EndDate = endDate;
        Price = price;
        TypeAnimation = typeAnimation;
        IsDubbed = isDubbed;
        Movie = movie;
        Room = room;
        NotificationsConfig();
    }

    public DateTime Date { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public double Price { get; set; }
    public TypeAnimation TypeAnimation { get; set; }
    public bool IsDubbed { get; set; }
    public virtual Movie Movie { get; set; }
    public virtual Room Room { get; set; }
    public Guid RoomId { get; set; }
    public Guid MovieId { get; set; }

    protected override void NotificationsConfig()
    {
        new AddNotifications<Session>(this)
            .IfGreaterThan(x => x.Price, 1, Messages.X0_INVALIDO.ToFormat("Preço"));

        base.NotificationsConfig();
    }
}