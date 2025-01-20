using goapp.domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goapp.application.Data
{
    public interface IGoAppDbContext
    {
        DbSet<User> Users { get; }
        DbSet<Destination> Destinations { get; }
        DbSet<ShippingQuote> ShippingQuotes { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
