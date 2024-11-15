using RentAndSell.Car.WebApp.Commons.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAndSell.Car.WebApp.Models
{
	public class ArabaViewModel
	{
        public int Id { get; set; }
        public string Marka { get; set; }
		public string Model { get; set; }
		public MotorTipi MotorTipi { get; set; }
		public YakitTuru YakitTuru { get; set; }
		public SanzimanTipi SanzimanTipi { get; set; }

		[Range(1940,2024)]
		public short Yili { get; set; }
	}
}
