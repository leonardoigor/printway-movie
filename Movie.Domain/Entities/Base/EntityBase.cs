using prmToolkit.NotificationPattern;

namespace Movie.Domain.Entities.Base;

public class EntityBase : Notifiable
{
    protected EntityBase()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; set; }

    protected virtual void NotificationsConfig()
    {
    }
}
