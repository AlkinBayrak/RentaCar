using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentAndSell.Car.API.Data;
using RentAndSell.Car.API.Data.Entities.Concrete;

namespace RentAndSell.Car.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarsController : ControllerBase
	{
		private static List<Araba> cars = new List<Araba>();
		private CarRentDbContext _dbContext;
		public CarsController(CarRentDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		[HttpGet]
		public ActionResult Get()
		{
			return Ok(_dbContext.Arabalar.Where(a => a.IsActive == true && a.IsDeleted == false).ToList());
		}

		[HttpGet("{id}")]
		public ActionResult Get(int id)
		{
			return Ok(_dbContext.Arabalar.Where(a => a.Id == id && a.IsActive == true && a.IsDeleted == false).SingleOrDefault());
		}

		[HttpPost]
		public ActionResult Post(Araba car)
		{
			_dbContext.Arabalar.Add(car);
			_dbContext.SaveChanges();

			return Created();
		}

		[HttpPut("{id}")]
		public ActionResult Put(int id, Araba car)
		{
			Araba? readAraba = _dbContext.Arabalar.AsNoTracking()
												 .Where(a => a.Id == id && a.IsActive == true && a.IsDeleted == false)
												 .SingleOrDefault();


			if (readAraba != null)
			{
				readAraba = car;

				_dbContext.Arabalar.Update(readAraba);
				_dbContext.SaveChanges();
				return NoContent();
			}

			return StatusCode(503, "Güncelleme İşlemi yapılamadı");

		}

		[HttpDelete("{id}")]
		public ActionResult Delete(int id)
		{
			Araba? readAraba = _dbContext.Arabalar.AsNoTracking()
												 .Where(a => a.Id == id && a.IsActive == true && a.IsDeleted == false)
												 .SingleOrDefault();

			if (readAraba != null)
			{
				_dbContext.Arabalar.Remove(readAraba);
				_dbContext.SaveChanges();
				return NoContent();
			}

			return StatusCode(503, "Silme İşlemi yapılamadı");
		}


		[HttpGet("Year/{year:range(1980,2024)}")]
		public ActionResult Filter(int year)
		{
			return Ok($"{year} model ait arabalar");
		}

		[HttpGet("Year/{year:range(1980,2024)}/Marka/{brand:alpha}")]
		public ActionResult Filter(int year, string brand)
		{
			return Ok($"{year} {brand} markasına ait arabalar");
		}

		[HttpGet("Year/{year:range(1980,2024)}/Marka/{brand:alpha}/Model/{model}")]
		public ActionResult Filter(int year, string brand, string model)
		{
			return Ok($"{year} {brand} {model} modeline ait arabalar");
		}
	}
}
