using Microsoft.Extensions.DependencyInjection;
using Movie.Domain.Interfaces.Repositories.Base;
using Movie.Domain.Interfaces.Services;
using Movie.Domain.Services;
using Movie.Infra.Persistence.Contexts;
using Movie.Infra.Persistence.Repositories.Base;
using Movie.Infra.Transactions;
using Movie.Infra.Transactions.Base;

namespace Movie.IOC;

public static class DependenciesSolve
{
    public static IServiceCollection SolveDepencies(this IServiceCollection ser)
    {
        ser.AddScoped<PopCornContext>();
        ser.AddTransient<IUnitOfWork, UnitOfWork>();

        // add repositories
        ser.AddTransient(typeof(IRepositoryBase<,>), typeof(RepositoryBase<,>));

        // ser.AddTransient<IPostRepository, PostRepository>();

        //add services
        ser.AddTransient<IMovieService, MovieService>();
        ser.AddTransient<ISessionService, SessionService>();
        ser.AddTransient<IMovieService, MovieService>();

        return ser;
    }
}
