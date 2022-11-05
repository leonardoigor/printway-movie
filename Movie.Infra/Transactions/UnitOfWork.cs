using Movie.Infra.Persistence.Contexts;

namespace Movie.Infra.Transactions;

public class UnitOfWork
{
    private readonly PopCornContext _context;

    public UnitOfWork(PopCornContext context)
    {
        _context = context;
    }

    public void Commit()
    {
        _context.SaveChanges();
    }
}
