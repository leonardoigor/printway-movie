using Movie.Domain.Entities.Base;

namespace Movie.Domain.Entities;

public class Session : EntityBase
{
    public Session()
    {
    }

    public Session(DateTime date, TimeSpan startDate, TimeSpan endDate, double price, Enum typeAnimation,
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
    }

    public DateTime Date { get; set; }
    public TimeSpan StartDate { get; set; }
    public TimeSpan EndDate { get; set; }
    public double Price { get; set; }
    public Enum TypeAnimation { get; set; }
    public bool IsDubbed { get; set; }
    public virtual Movie Movie { get; set; }
    public virtual Room Room { get; set; }

    protected override void NotificationsConfig()
    {
        // new AddNotifications<Movie>(this)
        //     .IfNullOrInvalidLength(x => x.Description, 1, 1000,
        //         Messages.A_DESCRIÇÃO_DEVE_CONTER_ENTRE_X0_E_X1_CARACTERES.ToFormat("1", "1000"))
        //     .IfNullOrInvalidLength(x => x.Title, 1, 1000,
        //         Messages.A_DESCRIÇÃO_DEVE_CONTER_ENTRE_X0_E_X1_CARACTERES.ToFormat("1", "1000"))
        //     .IfNullOrInvalidLength(x => x.Image, 1, 1000,
        //         Messages.A_DESCRIÇÃO_DEVE_CONTER_ENTRE_X0_E_X1_CARACTERES.ToFormat("1", "1000"));
        base.NotificationsConfig();
    }
}
