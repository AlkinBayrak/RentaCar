using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentAndSell.Car.API.Commons.Enums;
using RentAndSell.Car.API.Data;
using RentAndSell.Car.API.Data.Entities.Concrete;
using System.Globalization;

namespace RentAndSell.Car.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarHistoryController : ControllerBase
	{
		private CarRentDbContext _dbContext;
		private IQueryable<ArabaTarihce> _activeAndNotDeletedCarHistory;

		public CarHistoryController(CarRentDbContext dbContext)
		{
			_dbContext = dbContext;
			_activeAndNotDeletedCarHistory = _dbContext.ArabaTarihcesi.Where(a => a.IsActive == true);
		}

		[HttpGet]
		public ActionResult Get()
		{
			return Ok(_activeAndNotDeletedCarHistory.ToList());
		}

		[HttpGet("{id}")] //??? arabaId yazmalı mıydık?
		public ActionResult Get(int id)
		{
			return Ok(_activeAndNotDeletedCarHistory.Where(a => a.ArabaId == id).ToList());
		}
		//Post metodu olmamalı bizce.
		//Put da olmamalı??

		[HttpGet("IslemTipi/{islemTipi}/")]
		public ActionResult Filter(IslemTipi islemTipi)
		{
			return Ok(_activeAndNotDeletedCarHistory.AsNoTracking().Where(a => a.IslemTipi == islemTipi).ToList());
		}

		[HttpGet("IslemTarihi/{islemZamani}")]
		public ActionResult Filter(string islemZamani)
		{
			DateTime islemTarihi;

			// Tarih formatını belirliyoruz (örneğin, "yyyy-MM-dd")
			string format = "yyyy-MM-dd";

			// DateTime.ParseExact kullanarak dönüşüm yapıyoruz
			if (!DateTime.TryParseExact(islemZamani, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out islemTarihi))
			{
				// Hatalı format durumunda bir hata yanıtı döndürülüyor
				return BadRequest("Tarih formatı geçersiz. Lütfen yyyy-MM-dd formatında bir tarih girin.");
			}

			// Dönüşüm başarılıysa, sorgu yapılır
			var result = _activeAndNotDeletedCarHistory
				.AsNoTracking()
				.Where(a => a.IslemZamani.Date == islemTarihi.Date) // Tarihi karşılaştırırken saatleri göz ardı etmek için sadece Date kısmını alıyoruz
				.ToList();

			return Ok(result);

			//return Ok(_activeAndNotDeletedCarHistory.AsNoTracking().Where(a => a.IslemZamani.Month == islemZamani.Month).ToList());
		}

		[HttpGet("IslemTipi/{islemTipi}/IslemTarihi/{islemZamani}")]
		public ActionResult Filter(IslemTipi islemTipi, string islemZamani)
		{
			DateTime islemTarihi;
			string format = "yyyy-MM-dd";

			if (!DateTime.TryParseExact(islemZamani, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out islemTarihi))
			{
				return BadRequest("Tarih formatı geçersiz. Lütfen yyyy-MM-dd formatında bir tarih girin.");
			}

			return Ok(_activeAndNotDeletedCarHistory.AsNoTracking().Where(a => a.IslemZamani.Date == islemTarihi.Date && a.IslemTipi == islemTipi).ToList());
		}

		[HttpGet("ArabaId/{arabaId}/IslemTarihi/{islemZamani}")]
		public ActionResult Filter(int arabaId, string islemZamani)
		{
			DateTime islemTarihi;
			string format = "yyyy-MM-dd";

			if (!DateTime.TryParseExact(islemZamani, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out islemTarihi))
			{
				return BadRequest("Tarih formatı geçersiz. Lütfen yyyy-MM-dd formatında bir tarih girin.");
			}
			return Ok(_activeAndNotDeletedCarHistory.AsNoTracking().Where(a => a.IslemZamani.Date == islemTarihi.Date && a.ArabaId == arabaId).ToList());
		}
	}
}