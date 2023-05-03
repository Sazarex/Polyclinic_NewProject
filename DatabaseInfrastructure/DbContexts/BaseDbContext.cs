using Interfaces.Domain;
using Microsoft.EntityFrameworkCore;
using Interfaces.Common;
using Npgsql;

namespace DatabaseInfrastructure.DbContexts
{
    public abstract class BaseDbContext: DbContext
    {
        protected BaseDbContext( DbContextOptions options)
            : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<Account> Accounts { get; set; }

        //Сопоставления енума из бд с енумом из проекта
        static BaseDbContext() => NpgsqlConnection.GlobalTypeMapper.MapEnum<Role>();

        //EF Core cоздает тип енума для бд
        protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.HasPostgresEnum<Role>();
    }
}
