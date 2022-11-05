using Movie.Infra.Persistence.Contexts;
using Movie.Infra.Transactions.Base;

namespace Movie.Infra.Transactions;

public class UnitOfWork : IUnitOfWork

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
