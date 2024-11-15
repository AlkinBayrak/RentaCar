using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using RentAndSell.Car.WebApp.Models;
using System.Security.Claims;

namespace RentAndSell.Car.WebApp.Controllers
{
	public class AccountController : Controller
	{
		private readonly HttpClient _httpClient;
		private const string _endPoint = "Auth";

		public AccountController(HttpClient httpClient)
		{
			_httpClient = httpClient;
			_httpClient.BaseAddress = new Uri("https://localhost:7247/api/");
		}

		[HttpGet]
		public IActionResult Login()
		{
			LoginViewModel model = new LoginViewModel();

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel model)
		{
			if (!ModelState.IsValid)
				return View(model);

			//Burada api ye Auth/LoginWithJwt ye istek atacağız token değerimizi alacağız
			HttpResponseMessage responseMessage = _httpClient.PostAsJsonAsync<LoginViewModel>(_endPoint + "/LoginWithJwt", model).Result;

			if (responseMessage.IsSuccessStatusCode)
			{
				TokenResultViewModel result = responseMessage.Content.ReadFromJsonAsync<TokenResultViewModel>().Result;

				if (!string.IsNullOrEmpty(result.Token))
				{
					List<Claim> claims = new List<Claim>
					{
					new Claim(ClaimTypes.Name,model.UserName),
					new Claim(ClaimTypes.NameIdentifier,"1")
					};

					ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

					ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

					await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,claimsPrincipal);

					HttpContext.Session.SetString("Token",result.Token);

					return RedirectToAction("Index","Home");
				}

				
			}

			return View(model);
		}

		[HttpGet]
		public IActionResult Logout()
		{
			HttpContext.Session.Clear();
			HttpContext.SignOutAsync();

			return RedirectToAction("Index","Home");
		}
	}
}
