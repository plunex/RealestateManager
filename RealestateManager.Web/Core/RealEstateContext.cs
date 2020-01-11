using Microsoft.EntityFrameworkCore;
using RealestateManager.Web.Core.Entities;

namespace RealestateManager.Web.Core
{
    public class RealEstateContext: DbContext
    {
        public RealEstateContext(DbContextOptions<RealEstateContext> options) 
            : base(options)
        {
            
        }

        public DbSet<Property> Properties { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}
