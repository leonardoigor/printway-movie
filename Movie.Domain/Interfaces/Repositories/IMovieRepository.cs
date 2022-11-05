using Movie.Domain.Arguments.Movie;
using Movie.Domain.Interfaces.Repositories.Base;

namespace Movie.Domain.Interfaces.Repositories;

public interface IMovieRepository : IRepositoryBase<Entities.Movie, Guid>
{
    public bool AddMovie(MovieAddRequest movie);
    public bool AddMovie(Entities.Movie movie);
}
