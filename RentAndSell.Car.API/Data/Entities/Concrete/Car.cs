using RentAndSell.Car.API.Data.Entities.Abstract;

namespace RentAndSell.Car.API.Data.Entities.Concrete
{
	public class Araba : BaseEntity
	{
        public string Marka { get; set; }
        public string Model { get; set; }
        public MotorTipi MotorTipi { get; set; }
        public YakitTuru YakitTuru { get; set; }
        public SanzimanTipi SanzimanTipi { get; set; }

        public short Yili {  get; set; }
    }
}
