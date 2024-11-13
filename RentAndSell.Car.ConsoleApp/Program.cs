// Http isteği atmak istiyorum kime?
// https://localhost:7247/api/Cars adresine istek atacağız
// Nasıl?

using RentAndSell.Car.ConsoleApp.Models;
using System.Net.Http.Json;

HttpClient httpClient = new HttpClient();
httpClient.BaseAddress = new Uri("https://localhost:7247/api/");

#region HttpClient İstekle tipleri

#region ResponseMessage İşlemleri ile yapılan istek
//HttpResponseMessage httpResponseMessage = httpClient.GetAsync("Cars").Result;
//HttpContent content = httpResponseMessage.Content;
//var responseContentJson = content.ReadFromJsonAsync(typeof(List<ArabaViewModel>)).Result;

//string responseContent = content.ReadAsStringAsync().Result;
//var responseContentJson = content.ReadFromJsonAsync(typeof(List<ArabaViewModel>)).Result;
//List<ArabaViewModel> arabaViewModelList = content.ReadFromJsonAsync<List<ArabaViewModel>>().Result; 
#endregion

#region FromJsonAsync return Object isteği
//List<ArabaViewModel> arabaViewModels = (List<ArabaViewModel>) httpClient.GetFromJsonAsync("Cars",typeof(List<ArabaViewModel>)).Result; 
#endregion

#endregion

List<ArabaViewModel> arabaViewModels = httpClient.GetFromJsonAsync<List<ArabaViewModel>>("Cars").Result;

Console.WriteLine("-----Araba Listesi-------");

foreach (ArabaViewModel araba in arabaViewModels)
{
    Console.WriteLine($"{araba.Marka} {araba.Model} {araba.Yili}");
}

Console.WriteLine("---------------");

Console.WriteLine("-------Yeni Kayıt-------");

Console.WriteLine("Marka :");
string marka = Console.ReadLine();
Console.WriteLine("Model :");
string model = Console.ReadLine();
Console.WriteLine("Yılı :");
string yili = Console.ReadLine();
Console.WriteLine("Yakıt Türü :");
string yakitTürü = Console.ReadLine();
Console.WriteLine("Motor Tipi :");
string motorTipi = Console.ReadLine();
Console.WriteLine("Şanzıman Tipi :");
string sanzimanTipi = Console.ReadLine();

ArabaViewModel yeniAraba = new ArabaViewModel();

yeniAraba.Marka = marka;
yeniAraba.Model = model;
yeniAraba.Yili = short.Parse(yili);
yeniAraba.YakitTuru = int.Parse(yakitTürü);
yeniAraba.MotorTipi = int.Parse(motorTipi);
yeniAraba.SanzimanTipi = int.Parse(sanzimanTipi);

HttpResponseMessage responsePostMessage = httpClient.PostAsJsonAsync("Cars",yeniAraba).Result;

if (responsePostMessage.IsSuccessStatusCode)
{
    Console.WriteLine("Yeni araba kayıt edildi");
    var responseData = await responsePostMessage.Content.ReadAsStringAsync();

    Console.WriteLine("Yanıt : " + responseData);
}

arabaViewModels = httpClient.GetFromJsonAsync<List<ArabaViewModel>>("Cars").Result;

Console.WriteLine("----- Güncel Araba Listesi-------");

foreach (ArabaViewModel araba in arabaViewModels)
{
	Console.WriteLine($"{araba.Marka} {araba.Model} {araba.Yili}");
}


Console.ReadLine();