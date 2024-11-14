using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAndSell.Car.FormApp.Models
{
	public class LoginResultViewModel
	{
        public string BasicAuth { get; set; }
        public bool IsLogin { get; set; }
        public string ErrorMessage { get; set; }
    }
}
