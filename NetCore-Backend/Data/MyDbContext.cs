using Microsoft.EntityFrameworkCore;

namespace NetCore_Backend.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options): base(options) {}

        public DbSet<Country> Countries { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Galary> Galarys { get; set; }
        public DbSet<Dossier> Dossiers { get; set; }
    }
}
