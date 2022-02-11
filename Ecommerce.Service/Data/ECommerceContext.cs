using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ECommerce.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Ecommerce.Service.Data
{
    public class ECommerceContext : DbContext
    {
        public ECommerceContext(DbContextOptions options) : base(options){ }

        public DbSet<Address> Address { get; set;}
        public DbSet<Category> Category { get; set;}
        public DbSet<Costumer> Costumer { get; set;}
        public DbSet<Email> Email { get; set;}
        public DbSet<Image> Image { get; set;}
        public DbSet<Phone> Phone { get; set;}
        public DbSet<Product> Product { get; set;}
        public DbSet<Purchases> Purchases { get; set;}
        public DbSet<ShoppingCart> ShoppingCart { get; set;}
        public DbSet<Supplier> Supplier { get; set;}
        public DbSet<SupplierJuridical> SupplierJuridical { get; set;}
        public DbSet<SupplierPhysical> SupplierPhysical { get; set;}

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
                                                    CancellationToken cancellationToken = default)
        {
            foreach (var entity in ChangeTracker.Entries().Where(entity => entity.Entity.GetType().GetProperty("InsertDate") != null ||
                                                                entity.Entity.GetType().GetProperty("UpdateDate") != null))
            {
                if(entity.State == EntityState.Added)
                {
                    entity.Property("InsertDate").CurrentValue = DateTime.Now;
                    entity.Property("UpdateDate").IsModified = false;
                }
                else if(entity.State == EntityState.Modified)
                {
                    entity.Property("InsertDate").IsModified = false;
                    entity.Property("UpdateDate").CurrentValue = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                                                       .SelectMany(e => e.GetProperties()
                                                                        .Where(p => p.ClrType == typeof(string))))
            {
                property.SetColumnType("varchar(256)");
            }
            foreach (var relationShip in modelBuilder.Model.GetEntityTypes().SelectMany(p => p.GetForeignKeys()))
            {
                relationShip.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }
            modelBuilder.Entity<SupplierJuridical>(entity => entity.HasIndex(e => e.Cnpj).IsUnique());
            modelBuilder.Entity<SupplierPhysical>(entity => entity.HasIndex(e => e.Cpf).IsUnique());
            modelBuilder.Entity<Supplier>(entity => entity.HasIndex(e => e.FantasyName).IsUnique());
            modelBuilder.Entity<Category>(entity => entity.HasIndex(e => e.Name).IsUnique());
            modelBuilder.Entity<Email>(entity => entity.HasIndex(e => e.EmailAddress).IsUnique());
            modelBuilder.Entity<Purchases>(entity => entity.HasIndex(e => e.CodePurchase).IsUnique());
            modelBuilder.Entity<Costumer>(entity => entity.HasIndex(e => e.Cpf).IsUnique());

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ECommerceContext).Assembly);
        }
    }
}