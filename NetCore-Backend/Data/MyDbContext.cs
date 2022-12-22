using Microsoft.EntityFrameworkCore;
using NetCore_Backend.Data;

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
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCate> ProductCates { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductGalary> ProductGalaries { get; set; }
        public DbSet<WatchList> WatchLists { get; set; }
        public DbSet<WatchListProduct> WatchListProducts { get; set; }
       
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<NetCore_Backend.Data.Bid> Bid { get; set; }


    }
}
