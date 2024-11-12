using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentAndSell.Car.API.Data.Entities.Concrete;

namespace RentAndSell.Car.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarsController : ControllerBase
	{
		private static List<Araba> cars = new List<Araba>();

		[HttpGet]
		public ActionResult Get()
		{
			return Ok(cars);
		}

		[HttpGet("{id}")]
		public ActionResult Get(int id)
		{
			return Ok(cars.Where(c => c.Id == id).SingleOrDefault());
		}

		[HttpPost]
		public ActionResult Post(Araba car)
		{
			cars.Add(car);
			return Ok(cars);
		}

		[HttpPut("{id}")]
		public ActionResult Put(int id , Araba car)
		{
			Araba findOrginalCar = cars.Where(c => c.Id == id).SingleOrDefault();
			int findOrginalIndex = cars.IndexOf(findOrginalCar);

			cars[findOrginalIndex] = car;
			return Ok(car);
		}

		[HttpDelete("{id}")]
		public ActionResult Delete(int id, Araba car)
		{
			Araba removedCar = cars.Where(c => c.Id == id).SingleOrDefault();

			cars.Remove(removedCar);

			return Ok(removedCar);
		}

		[HttpGet("Year/{year:range(1980,2024)}")]
		public ActionResult Filter(int year)
		{
			return Ok($"{year} yılına ait arabalar");
		}

		[HttpGet("Year/{year:range(1980,2024)}/Marka/{brand:alpha}")]
		public ActionResult Filter(int year,string brand)
		{
			return Ok($"{year} yılına ait arabalar ve {brand} markasına ait arabalar");
		}

		[HttpGet("Year/{year:range(1980,2024)}/Marka/{brand:alpha}/Model/{model}")]
		public ActionResult Filter(int year, string brand,string model)
		{
			return Ok($"{year} {brand} {model} modeline ait arabalar");
		}
	}
}
