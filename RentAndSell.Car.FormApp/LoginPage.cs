using RentAndSell.Car.FormApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentAndSell.Car.FormApp
{
	public partial class LoginPage : Form
	{
		private HttpClient _httpClient;
		private const string _endPoint = "Auth";
		public LoginPage()
		{
			InitializeComponent();

			_httpClient = new HttpClient();
			_httpClient.BaseAddress = new Uri("https://localhost:7247/api/");
			
		}

		private void btnLogin_Click(object sender, EventArgs e)
		{
			LoginViewModel loginModel = new LoginViewModel();
			loginModel.UserName = txtUserName.Text;
			loginModel.Password = txtPassword.Text;

			HttpResponseMessage responseMessage = _httpClient.PostAsJsonAsync(_endPoint + "/Login" , loginModel).Result;

			LoginResultViewModel result = responseMessage.Content.ReadFromJsonAsync<LoginResultViewModel>().Result;

			if (responseMessage.IsSuccessStatusCode)
			{
				Program.BasicAuth = result.BasicAuth;

				Form car = new CarPage();
				car.Show();
				this.Hide();
			}

			MessageBox.Show(result.ErrorMessage);
		}
	}
}
