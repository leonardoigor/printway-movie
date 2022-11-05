using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Movie.Domain.Entities;

namespace Movie.Infra.Persistence.Contexts;

public class PopCornContext : DbContext
{
    public PopCornContext() : base(@"Server=.\sqlexpress; Database=PopCorn;Trusted_Connection=True;")
    {
    }

    public DbSet<Domain.Entities.Movie> Movies { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<Room> Rooms { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        //Remove the pluralization of table names
        modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        //Remove cascading delete
        modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

        //Set to use varchar or instead of nvarchar
        modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));


        //If I forget to inform the field size, it will put a varchar of 100
        modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(100));


        #region Add Entity auto-map by assembly

        modelBuilder.Configurations.AddFromAssembly(typeof(PopCornContext).Assembly);

        #endregion

        base.OnModelCreating(modelBuilder);
    }
}
