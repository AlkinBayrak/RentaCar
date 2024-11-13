using RentAndSell.Car.FormApp.Commons.Enums;
using RentAndSell.Car.FormApp.Models;
using System.Net.Http.Json;

namespace RentAndSell.Car.FormApp
{
	public partial class Form1 : Form
	{
		private HttpClient _httpClient;
		private const string _endPoint = "Cars";

		public Form1()
		{
			InitializeComponent();
			_httpClient = new HttpClient();
			_httpClient.BaseAddress = new Uri("https://localhost:7247/api/");
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			cBoxYakitTuru.DataSource = Enum.GetValues(typeof(YakitTuru));
			cBoxMotorTipi.DataSource = Enum.GetValues(typeof(MotorTipi));
			cBoxSanzimanTipi.DataSource = Enum.GetValues(typeof(SanzimanTipi));

			nbrUpDownYil.Maximum = DateTime.Now.Year;
			//nbrUpDownYil.Minimum = DateTime.Now.Year - 50; // son 50 yýllýk iþ 

			//MessageBox.Show(cBoxYakitTuru.SelectedValue.ToString());
			//MessageBox.Show(cBoxMotorTipi.SelectedValue.ToString());
			//MessageBox.Show(cBoxSanzimanTipi.SelectedValue.ToString());

			//MessageBox.Show("" + (int)cBoxYakitTuru.SelectedValue);
			//MessageBox.Show("" + (int)cBoxMotorTipi.SelectedValue);
			//MessageBox.Show("" + (int)cBoxSanzimanTipi.SelectedValue);

			for (short i = 1940; i <= DateTime.Now.Year; i++)
				cBoxYil.Items.Add(i);

			cBoxYil.SelectedIndex = 0;


			ReloadedDataGridView();

		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			ArabaViewModel model = new ArabaViewModel();
			model.Marka = txtMarka.Text;
			model.Model = txtModel.Text;
			model.Yili = (short)cBoxYil.SelectedItem;
			model.YakitTuru = (YakitTuru)cBoxYakitTuru.SelectedItem;
			model.MotorTipi = (MotorTipi)cBoxMotorTipi.SelectedItem;
			model.SanzimanTipi = (SanzimanTipi)cBoxSanzimanTipi.SelectedItem;

			HttpResponseMessage responseMessage = _httpClient.PostAsJsonAsync(_endPoint, model).Result;

			if (responseMessage.IsSuccessStatusCode)
			{
				MessageBox.Show("Kayýt baþarýlýdýr. Yanýt: " + responseMessage.Content.ReadAsStringAsync().Result);

				ReloadedDataGridView();
			}

			else
				MessageBox.Show("Kayýt yapýlamadý");

		}

		private void ReloadedDataGridView()
		{
			List<ArabaViewModel> arabaViewModels = _httpClient.GetFromJsonAsync<List<ArabaViewModel>>(_endPoint).Result;

			dgvArabaList.DataSource = arabaViewModels;
		}

		private void dgvArabaList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			//List<ArabaViewModel> arabaViewModels = _httpClient.GetFromJsonAsync<List<ArabaViewModel>>(_endPoint).Result;

			ArabaViewModel selectedAraba = (ArabaViewModel)dgvArabaList.SelectedRows[0].DataBoundItem;

			txtId.Text = selectedAraba.Id.ToString();
			txtMarka.Text = selectedAraba.Marka;
			txtModel.Text = selectedAraba.Model;

			cBoxYil.SelectedItem = selectedAraba.Yili;
			cBoxYakitTuru.SelectedItem = selectedAraba.YakitTuru;
			cBoxMotorTipi.SelectedItem = selectedAraba.MotorTipi;
			cBoxSanzimanTipi.SelectedItem = selectedAraba.SanzimanTipi;

			
		}
	}
}
