using BloodBank.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Data
{
    public class BloodBankDbContext : DbContext
    {
        public BloodBankDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Donor> Donors { get; set; }
    }
}
