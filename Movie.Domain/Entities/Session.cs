using Movie.Domain.Entities.Base;

namespace Movie.Domain.Entities;

public class Session : EntityBase
{
    public Session(string date, string startDate, string endDate, TimeSpan value, TimeSpan typeAnimation,
        TimeSpan isDubbed)
    {
        Date = date;
        StartDate = startDate;
        EndDate = endDate;
        Value = value;
        TypeAnimation = typeAnimation;
        IsDubbed = isDubbed;
    }

    public string Date { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public TimeSpan Value { get; set; }
    public TimeSpan TypeAnimation { get; set; }
    public TimeSpan IsDubbed { get; set; }
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
