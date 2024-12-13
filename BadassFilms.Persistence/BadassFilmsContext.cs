using BadassFilms.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BadassFilms.Persistence
{
    public class BadassFilmsContext : DbContext
    {
        public BadassFilmsContext(DbContextOptions<BadassFilmsContext> options)
            : base(options) { }

        public DbSet<Movies> Movies => Set<Movies>();

    }
}
