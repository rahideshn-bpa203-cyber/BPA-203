using ProniaBpa203.Models;
using Microsoft.EntityFrameworkCore;



namespace ProniaBpa203.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        
        public DbSet<ProductImage> ProductImages { get; set; }
    }
}