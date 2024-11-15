using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RentAndSell.Car.API.Data.Entities.Concrete;
using RentAndSell.Car.API.Models;
using RentAndSell.Car.API.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace RentAndSell.Car.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly UserManager<Kullanici> _userManager;
		private readonly SignInManager<Kullanici> _signInManager;

		public AuthController(UserManager<Kullanici> userManager, SignInManager<Kullanici> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		[HttpPost("Login")]
		public ActionResult Login(LoginViewModel model)
		{
			LoginResultVİewModel loginResult = new LoginResultVİewModel();

			Kullanici? kullanici = _userManager.FindByNameAsync(model.UserName).Result;

			if (kullanici is null)
			{
				loginResult.IsLogin = false;
				loginResult.ErrorMessage = "Kullanıcı veya şifreniz yanlıştır";

				return Unauthorized(loginResult);
			}

			bool passwordChecked = _userManager.CheckPasswordAsync(kullanici, model.Password).Result;

			if (!passwordChecked)
			{
				loginResult.IsLogin = false;
				loginResult.ErrorMessage = "Kullanıcı veya şifreniz yanlıştır";

				return Unauthorized(loginResult);
			}

			#region Basic Auth Kodları
			//var usernamePassword = $"{model.UserName}:{model.Password}";
			//var base64EncodeUserNamePassword = Convert.ToBase64String(Encoding.UTF8.GetBytes(usernamePassword));
			//var basicAuth = $"Basic {base64EncodeUserNamePassword}";

			//loginResult.IsLogin = true;
			//loginResult.BasicAuth = basicAuth;
			#endregion

			#region Custom Auth Token Kodları

			var basic64EncodeUserNameWithToken = CustomToken.GenerateToken(model.UserName);

			var basicAuth = $"CustomToken {basic64EncodeUserNameWithToken}";

			loginResult.IsLogin = true;
			loginResult.BasicAuth = basicAuth;

			#endregion





			return Ok(loginResult);
		}



		[HttpPost("LoginWithJwt")]
		public async Task<ActionResult> LoginWithJwt([FromBody] LoginViewModel model)
		{
			Kullanici? kullanici = await _userManager.FindByNameAsync(model.UserName);

            if (kullanici != null && await _userManager.CheckPasswordAsync(kullanici, model.Password))
            {
				var token = GenerateToken(kullanici);

				return Ok(new { token });
            }

			return Unauthorized();
          
		}

		private string GenerateToken(Kullanici kullanici)
		{
			var claims = new[]
			{
				new Claim(JwtRegisteredClaimNames.Sub,kullanici.UserName),
				new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
				new Claim(ClaimTypes.NameIdentifier,kullanici.Id),
				//new Claim(JwtRegisteredClaimNames.Iat,DateTime.Now.ToString("ddMMyyyyHHmmss")), //15112024123641
				new Claim(JwtRegisteredClaimNames.Iat,DateTime.Now.Ticks.ToString()), // 1.1.1970 den beri tick tak sayısı
			};

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("gizlikelime-şayet-bu-çok-gizlibirkelime"));

			//buraya geleceğiz

			//var signinCred = new SigningCredentials(key,"HS256");
			var signinCred = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(
				issuer: "CarApi",
				audience: "CarWeb",
				claims: claims,
				expires: DateTime.Now.AddMinutes(5),
				signingCredentials: signinCred
				);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}
