using RentAndSell.Car.API.Commons.Enums;
using RentAndSell.Car.API.Data.Entities.Abstract;

namespace RentAndSell.Car.API.Data.Entities.Concrete
{
	public class ArabaTarihce : BaseEntity
	{
        public int ArabaId { get; set; }
        public string Marka { get; set; }
		public string Model { get; set; }
		public MotorTipi MotorTipi { get; set; }
		public YakitTuru YakitTuru { get; set; }
		public SanzimanTipi SanzimanTipi { get; set; }

		public short Yili { get; set; }

		public IslemTipi IslemTipi { get; set; }
		public DateTime IslemZamani { get; set; }
	}
}
