namespace Movie.Infra.Transactions.Base;

public interface IUnitOfWork
{
    void Commit();
}
