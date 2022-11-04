using Movie.Domain.Interfaces.Repositories.Base;

namespace Movie.Domain.Interfaces.Repositories;

public interface IMovieRepository : IRepositoryBase<Entities.Movie, Guid>
{
}
