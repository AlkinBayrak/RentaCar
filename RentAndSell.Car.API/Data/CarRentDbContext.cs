using Microsoft.EntityFrameworkCore;
using RentAndSell.Car.API.Data.Entities.Concrete;

namespace RentAndSell.Car.API.Data
{
	public class CarRentDbContext : DbContext
	{
        public CarRentDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Araba> Arabalar {  get; set; }
		public DbSet<ArabaTarihce> ArabaTarihcesi { get; set; }
	}
}
