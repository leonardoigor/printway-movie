using Microsoft.Extensions.DependencyInjection;
using Movie.Domain.Interfaces.Repositories;
using Movie.Domain.Interfaces.Repositories.Base;
using Movie.Domain.Interfaces.Services;
using Movie.Domain.Services;
using Movie.Infra.Persistence.Contexts;
using Movie.Infra.Persistence.Repositories;
using Movie.Infra.Persistence.Repositories.Base;
using Movie.Infra.Transactions;
using Movie.Infra.Transactions.Base;

namespace Movie.IOC;

public static class SolveDependencies
{
    public static IServiceCollection SolveDependenciesInstance(this IServiceCollection ser)
    {
        ser.AddScoped<PopCornContext>();
        ser.AddTransient<IUnitOfWork, UnitOfWork>();

        // add repositories
        ser.AddTransient(typeof(IRepositoryBase<,>), typeof(RepositoryBase<,>));

        ser.AddTransient<IRoomRepository, RoomRepository>();
        ser.AddTransient<IMovieRepository, MovieRepository>();
        ser.AddTransient<ISessionRepository, SessionRepository>();

        //add services
        ser.AddTransient<IMovieService, MovieService>();
        ser.AddTransient<ISessionService, SessionService>();
        ser.AddTransient<IRoomService, RoomService>();

        return ser;
    }
}
