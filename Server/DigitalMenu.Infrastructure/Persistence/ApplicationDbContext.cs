using DigitalMenu.Core.Entities.Category;
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

        public DbSet<ProductObj> Product { get; set; }
        public DbSet<CategoryObj> Category { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies();
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=DigitalMenu;User Id=sa;Password=admin;TrustServerCertificate=True;");
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            MapProduct(modelBuilder);
            MapCategory(modelBuilder);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CategoryObj>()
                .HasData(new List<CategoryObj>
                {
                    new CategoryObj
                    {
                        Id = new Guid("3C0CFA73-EFC1-48E2-ABC1-55E1E27E4EB5"),
                        Name = "Frutas",
                    }
                });
            modelBuilder.Entity<ProductObj>()
                .HasData(new List<ProductObj>()
                {
                    new ProductObj()
                    {
                        Id = new Guid("ed66f47f-15b3-463f-84b9-dc16976a4d2f"),
                        Name = "Banana",
                        Description = "Banana boa",
                        CategoryId = new Guid("3C0CFA73-EFC1-48E2-ABC1-55E1E27E4EB5")
                    },
                    new ProductObj()
                    {
                        Id = new Guid("83d92fe2-cb25-4603-85e7-2910da489694"),
                        Name = "Limão",
                        Description = "Limão melhor ainda",
                        CategoryId = new Guid("3C0CFA73-EFC1-48E2-ABC1-55E1E27E4EB5")
                    }
                });
        }

        #region private methods

        private void MapProduct(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductObj>(x =>
            {
                x.ToTable("Product");
                x.HasKey(p => p.Id);
                x.Property(p => p.Name).HasColumnName("Name");
                x.Property(p => p.Description).HasColumnName("Description");
            });
        }
        private void MapCategory(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryObj>(x =>
            {
                x.ToTable("Category");
                x.HasKey(p => p.Id);
                x.Property(p => p.Name).HasColumnName("Name");
                x.HasMany(p => p.Products).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId).HasPrincipalKey(x => x.Id);
            });
        }
        #endregion
    }
}
