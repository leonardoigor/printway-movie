using Movie.Domain.Entities.Base;
using Movie.Domain.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;

namespace Movie.Domain.Entities;

public class Movie : EntityBase
{
    public Movie()
    {
    }

    public Movie(string image, string title, string description, int minutes, int hours)
    {
        Image = image;
        Title = title;
        Description = description;
        Hours = hours;
        Minutes = minutes;
        NotificationsConfig();
    }

    public string Image { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Minutes { get; set; }
    public int Hours { get; set; }

    protected override void NotificationsConfig()
    {
        new AddNotifications<Movie>(this)
            .IfNullOrInvalidLength(x => x.Description, 1, 1000,
                Messages.A_DESCRIÇÃO_DEVE_CONTER_ENTRE_X0_E_X1_CARACTERES.ToFormat("1", "1000"))
            .IfNullOrInvalidLength(x => x.Title, 1, 1000,
                Messages.A_DESCRIÇÃO_DEVE_CONTER_ENTRE_X0_E_X1_CARACTERES.ToFormat("1", "1000"))
            .IfNullOrInvalidLength(x => x.Image, 1, 1000,
                Messages.A_DESCRIÇÃO_DEVE_CONTER_ENTRE_X0_E_X1_CARACTERES.ToFormat("1", "1000"));
        base.NotificationsConfig();
    }
}
