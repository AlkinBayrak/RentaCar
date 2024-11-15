using System.ComponentModel.DataAnnotations;

namespace RentAndSell.Car.WebApp.Models
{
	public class LoginViewModel
	{
		[Display(Name = "Kullanıcı Adı")]
		public string UserName { get; set; }

        [Display(Name ="Şifre")]
		[DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
