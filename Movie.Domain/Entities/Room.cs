using Movie.Domain.Entities.Base;

namespace Movie.Domain.Entities;

public class Room : EntityBase
{
    public Room(string name, int quantity)
    {
        Name = name;
        Quantity = quantity;
    }

    public string Name { get; set; }
    public int Quantity { get; set; }

    public List<Chair> Chairs => GenerateChairs();

    private List<Chair> GenerateChairs()
    {
        var _tmp = new List<Chair>();
        for (var i = 0; i < Quantity; i++) _tmp.Add(new Chair(i));
        return _tmp;
    }

    protected override void NotificationsConfig()
    {
        // new AddNotifications<Room>(this)
        //     .IfNullOrInvalidLength(x => x.Description, 1, 1000,
        //         Messages.A_DESCRIÇÃO_DEVE_CONTER_ENTRE_X0_E_X1_CARACTERES.ToFormat("1", "1000"))
        //     .IfNullOrInvalidLength(x => x.Title, 1, 1000,
        //         Messages.A_DESCRIÇÃO_DEVE_CONTER_ENTRE_X0_E_X1_CARACTERES.ToFormat("1", "1000"))
        //     .IfNullOrInvalidLength(x => x.Image, 1, 1000,
        //         Messages.A_DESCRIÇÃO_DEVE_CONTER_ENTRE_X0_E_X1_CARACTERES.ToFormat("1", "1000"));
        base.NotificationsConfig();
    }
}
