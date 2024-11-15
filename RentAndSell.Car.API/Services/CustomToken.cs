using System.Security.Cryptography;
using System.Text;

namespace RentAndSell.Car.API.Services
{
	public class CustomToken
	{
		private static readonly string _prifexSecretKey = "cokgizlibirkelime";

		public static string GenerateToken(string username)
		{
			var base64Mixed = Base64Mixed(username);

			var usernameWithToken = $"{username}:{base64Mixed}"; // "goksel:karışıkaset"

			//Merhaba Git Hub :D

			var base64EncodeUserNameWithToken = Convert.ToBase64String(Encoding.UTF8.GetBytes(usernameWithToken)); ;

			return base64EncodeUserNameWithToken;
		}

		public static bool TokenIsValid(string token, string username)
		{
			var usernameWithToken = Encoding.UTF8.GetString(Convert.FromBase64String(token)); // admin:sifrelikısım

			var credentional = usernameWithToken.Split(":");

			if (credentional.Length != 2)
				return false;

			var sendUsername = credentional[0];

			var sendBase64Mixed = credentional[1];

			#region Oluşturulan Base64 Mixed ı tekrar oluşturup bize yollanan ile kontrol edeceğiz.

			var base64Mixed = Base64Mixed(username);
			#endregion


			return sendBase64Mixed == base64Mixed;
		}

		private static string Base64Mixed(string username)
		{
			var stringDate = DateTime.Now.ToString("ddMMyyyy"); //15112024
			var base64EncodeDate = Convert.ToBase64String(Encoding.UTF8.GetBytes(stringDate));

			var secretKey = "";

			using (SHA256 sha256 = SHA256.Create())
			{
				byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes($"{_prifexSecretKey}-{username}"));
				secretKey = BitConverter.ToString(hashBytes).Replace("-", "").ToUpperInvariant();
			}

			return base64EncodeDate.Substring(base64EncodeDate.Length / 2) + secretKey + base64EncodeDate.Substring(0, base64EncodeDate.Length / 2);

		}
	}
}