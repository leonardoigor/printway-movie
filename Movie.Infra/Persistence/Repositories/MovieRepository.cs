using Movie.Domain.Arguments.Movie;
using Movie.Domain.Interfaces.Repositories;
using Movie.Infra.Persistence.Contexts;
using Movie.Infra.Persistence.Repositories.Base;

namespace Movie.Infra.Persistence.Repositories;

public class MovieRepository : RepositoryBase<Domain.Entities.Movie, Guid>, IMovieRepository
{
    protected readonly PopCornContext _context;

    public MovieRepository(PopCornContext context) : base(context)
    {
        _context = context;
    }

    public bool AddMovie(MovieAddRequest movie)
    {
        throw new NotImplementedException();
    }

    public bool AddMovie(Domain.Entities.Movie movie)
    {
        throw new NotImplementedException();
    }
}
