using Microsoft.AspNetCore.Identity;

namespace RentAndSell.Car.API.Data.Entities.Concrete
{
	public class Kullanici : IdentityUser
	{
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
