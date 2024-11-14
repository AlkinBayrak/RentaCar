using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using RentAndSell.Car.API.Data.Entities.Concrete;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace RentAndSell.Car.API.Services
{
	public class YetkiKontrolYakalayicisi : AuthenticationHandler<AuthenticationSchemeOptions>
	{
		private readonly UserManager<Kullanici> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly SignInManager<Kullanici> _signInManager;

		public YetkiKontrolYakalayicisi(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, RoleManager<IdentityRole> roleManager = null, UserManager<Kullanici> userManager = null, SignInManager<Kullanici> signInManager = null) : base(options, logger, encoder)
		{
			_roleManager = roleManager;
			_userManager = userManager;
			_signInManager = signInManager;

		}


		//api de login etme authorization ekleme 
		protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
		{
			if (Request.Headers.ContainsKey("Authorization"))
			{
				string authorization = Request.Headers["Authorization"];

				string base64Encode = authorization.Split("Basic")[1];

				string autDeCode = Encoding.UTF8.GetString(Convert.FromBase64String(base64Encode));

				string[] credentials = autDeCode.Split(":");
				string username = credentials[0];
				string password = credentials[1];


				Kullanici? kullanici = _userManager.FindByNameAsync(username).Result;

				if (kullanici is null)
				{
					return AuthenticateResult.Fail("Kullanıcı adı veya şifre hatalı");
				}

				bool passwordChecked = _userManager.CheckPasswordAsync(kullanici, password).Result;

				if (!passwordChecked)
				{
					return AuthenticateResult.Fail("Kullanıcı adı veya şifre hatalı");
				}

				_signInManager.AuthenticationScheme = Scheme.Name;

				SignInResult signInResult = _signInManager.CheckPasswordSignInAsync(kullanici, password, false).Result;

				if (signInResult.IsLockedOut)
					return AuthenticateResult.Fail("Hesabınız kilitlenmiştir Lütfen yetkili birim ile görüşünüz");

				if (signInResult.IsNotAllowed)
					return AuthenticateResult.Fail("Hesabınız henüz doğrulanmamıştır Lütfen mail adresine gelen linke tıklayınız");

				if (signInResult.RequiresTwoFactor)
					return AuthenticateResult.Fail("İkili doğrulama işlemi gerçekleştirmeniz gerekiyor");

				if (signInResult.Succeeded)
				{
					//List<Claim> claims = _userManager.GetClaimsAsync(kullanici).Result.ToList();


					List<Claim> claims = new List<Claim>()
						{
							new Claim(ClaimTypes.NameIdentifier, kullanici.Id),
							new Claim(ClaimTypes.Name, kullanici.UserName),
							new Claim(ClaimTypes.Email, kullanici.Email)
						};

					ClaimsIdentity identity = new ClaimsIdentity(claims, Scheme.Name);
					ClaimsPrincipal principal = new ClaimsPrincipal(identity);

					AuthenticationTicket gecisBileti = new AuthenticationTicket(principal, Scheme.Name);

					return AuthenticateResult.Success(gecisBileti);
				}

				return AuthenticateResult.Fail("Yetkisiz giriş denemesi");

			}

			return AuthenticateResult.Fail("Yetkisiz giriş denemesi");

		}
	}
}
