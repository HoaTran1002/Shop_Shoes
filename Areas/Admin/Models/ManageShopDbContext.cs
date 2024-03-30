using Microsoft.EntityFrameworkCore;




namespace Shoes.Areas.Admin.Models
{
    public class ManageShopDbContext : DbContext
    {
        public ManageShopDbContext(DbContextOptions<ManageShopDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Login>().ToTable("Login");

            base.OnModelCreating(modelBuilder);

        }
        public DbSet<Product> Product { get; set; }
        public DbSet<Login> Logins { get; set; }



    }
}
