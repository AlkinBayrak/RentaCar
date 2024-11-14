using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentAndSell.Car.API.Models;

namespace RentAndSell.Car.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		[HttpPost("Login")]
		public ActionResult Login(LoginViewModel model)
		{
			LoginResultVİewModel loginResult = new LoginResultVİewModel();
			loginResult.BasicAuth = "Basic abc123xyz";
			loginResult.IsLogin = true;
			loginResult.ErrorMessage = "";


			return Ok(loginResult);
		}
	}
}
