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
	public class YetkiKontrolYaklayicisi : AuthenticationHandler<AuthenticationSchemeOptions>
	{
		private readonly UserManager<Kullanici> _userManager;
		private readonly SignInManager<Kullanici> _signInManager;

		public YetkiKontrolYaklayicisi(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, UserManager<Kullanici> userManager, SignInManager<Kullanici> signInManager) : base(options, logger, encoder)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
		{
			if (Request.Headers.ContainsKey("Authorization"))
			{
				string authorization = Request.Headers["Authorization"];

				if (authorization.StartsWith("Basic"))
				{
					string base64Encode = authorization.Split("Basic ")[1];
					string authDecode = Encoding.UTF8.GetString(Convert.FromBase64String(base64Encode));
					string[] credentials = authDecode.Split(':');
					string username = credentials[0];
					string password = credentials[1];

					SignInResult signInResult = _signInManager.PasswordSignInAsync(username, password, false, false).Result;

					if (signInResult.IsLockedOut)
						return AuthenticateResult.Fail("Hesabınız kilitlenmiştir. Lütfen yetkili birim ile görüşünüz");

					if (signInResult.IsNotAllowed)
						return AuthenticateResult.Fail("Hesabınız henüz doğrulanmamıştır. Lütfen mail adresine gelen linke tıklayınız");

					if (signInResult.RequiresTwoFactor)
						return AuthenticateResult.Fail("İkili doğrulama işlemi gerçekleştirmeniz gerekiyor.");

					if (signInResult.Succeeded)
					{
						List<Claim> claims = Context.User.Claims.ToList();

						ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, Scheme.Name);
						ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

						AuthenticationTicket gecisBileti = new AuthenticationTicket(claimsPrincipal, Scheme.Name);

						return AuthenticateResult.Success(gecisBileti);
					}

					return AuthenticateResult.Fail("Yetksizi giriş denemesi");
				}
				else if (authorization.StartsWith("CustomToken")) 
				{
					string base64Encode = authorization.Split("CustomToken ")[1];
					string authDecode = Encoding.UTF8.GetString(Convert.FromBase64String(base64Encode));
					string[] credentials = authDecode.Split(':');
					string username = credentials[0];
					string token = credentials[1];

					if (CustomToken.TokenIsValid(token, username))
					{
						List<Claim> claims = new List<Claim>()
						{
							new Claim(ClaimTypes.Name, username)
						};

						ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, Scheme.Name);
						ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

						AuthenticationTicket gecisBileti = new AuthenticationTicket(claimsPrincipal, Scheme.Name);

						return AuthenticateResult.Success(gecisBileti);
					}

					return AuthenticateResult.Fail("Kullanıcı adı veya şifreniz yanlıştır.");
				}

			}

			return AuthenticateResult.Fail("Kullanıcı adı veya şifreniz yanlıştır.");

		}
	}
}
