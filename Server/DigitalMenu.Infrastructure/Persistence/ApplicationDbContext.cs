using DigitalMenu.Core.Entities.Product;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalMenu.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=DigitalMenu;User Id=sa;Password=admin;TrustServerCertificate=True;");
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            MapProduct(modelBuilder);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasData(new List<Product>()
                {
                    new Product()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Banana",
                        Description = "Banana boa",
                    },
                    new Product()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Limão",
                        Description = "Limão melhor ainda",
                    }
                });
        }

        #region private methods

        private void MapProduct(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(x =>
            {
                x.ToTable("Product");
                x.HasKey(p => p.Id).HasName("Id");
                x.Property(p => p.Name).HasColumnName("Name");
                x.Property(p => p.Description).HasColumnName("Description");
            });
        }

        #endregion
    }
}
