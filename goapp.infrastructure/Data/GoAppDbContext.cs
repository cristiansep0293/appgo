using goapp.application.Data;
using goapp.domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goapp.infrastructure.Data
{
    public class GoAppDbContext : DbContext, IGoAppDbContext
    {
        public GoAppDbContext(DbContextOptions<GoAppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Destination> Destinations => Set<Destination>();
        public DbSet<ShippingQuote> ShippingQuotes => Set<ShippingQuote>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de la relación User-ShippingQuote
            modelBuilder.Entity<ShippingQuote>()
                .HasOne(sq => sq.User)          // ShippingQuote tiene un User
                .WithMany(u => u.ShippingQuotes) // User tiene muchas ShippingQuotes
                .HasForeignKey(sq => sq.IdUser) // Especificamos la clave foránea
                .OnDelete(DeleteBehavior.Cascade); // Propagación de eliminaciones

            base.OnModelCreating(modelBuilder);
        }

    }
}
