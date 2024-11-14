using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentAndSell.Car.API.Data.Entities.Concrete;

namespace RentAndSell.Car.API.Data
{
	public class CarRentDbContext : IdentityDbContext
	{
        public CarRentDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Araba> Arabalar {  get; set; }
		public DbSet<ArabaTarihce> ArabaTarihcesi { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Araba>()
								.ToTable(tb=>tb.HasTrigger("ArabalarEklemeSonrasi"));
			modelBuilder.Entity<Araba>()
								.ToTable(tb => tb.HasTrigger("ArabalarGuncellemeSonrasi"));
			modelBuilder.Entity<Araba>()
								.ToTable(tb => tb.HasTrigger("ArabalarSilmeSonrasi"));
		}
	}
}
