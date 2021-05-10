using Microsoft.EntityFrameworkCore;
using OrderManager.Domain;

namespace OrderManager.Repository
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<CategoryProduct> CategoryProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<PromotionProduct> PromotionsProducts { get; set; }
        public DbSet<Combo> Combos { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
        public ApplicationDbContext()
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
        }
    }
}
