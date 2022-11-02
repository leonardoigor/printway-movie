namespace Movie.Domain.Entities.Base;
using prmToolkit.NotificationPattern;

public class EntityBase:Notifiable
{
    protected EntityBase()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
}
