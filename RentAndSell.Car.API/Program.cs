using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using RentAndSell.Car.API;
using RentAndSell.Car.API.Data;
using System.Text;
using HttpMethod = Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<CarRentDbContext>(opt=>opt.UseSqlServer(builder.Configuration.GetConnectionString("CarRentConn")));

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapControllers();

//GET | POST | PUT | PATCH | DELETE | OPTIONS

#region Senkron Main Method
//app.Map("/", async (context) =>
//{
//	return "Hello World All Methods GET | POST | PUT | PATCH | DELETE | OPTIONS";


//}); 
#endregion

#region Asenkron With Context Method
//app.Map("/", async (context) =>
//{
//	await context.Response.WriteAsync("Hello World All Methods GET | POST | PUT | PATCH | DELETE | OPTIONS\n");

//	if (context.Request.Method == HttpMethod.Get.ToString().ToUpper())
//		await context.Response.WriteAsync("Hello World Only GET");
//	if (context.Request.Method == HttpMethod.Post.ToString().ToUpper())
//		await context.Response.WriteAsync("Hello World Only POST");
//	if (context.Request.Method == HttpMethod.Put.ToString().ToUpper())
//		await context.Response.WriteAsync("Hello World All Only PUT");
//	if (context.Request.Method == HttpMethod.Patch.ToString().ToUpper())
//		await context.Response.WriteAsync("Hello World All Only PATCH");
//	if (context.Request.Method == HttpMethod.Delete.ToString().ToUpper())
//		await context.Response.WriteAsync("Hello World All Only DELETE");
//	if (context.Request.Method == HttpMethod.Options.ToString().ToUpper())
//		await context.Response.WriteAsync("Hello World All Only OPTIONS");

//});


#endregion

#region Http All Verbs Endpoint Map GET | POST | PUT | PATCH | DELETE
//GET
//app.MapGet("/", () =>
//{
//	return "Hello World Only Get";
//});

//POST
//app.MapPost("/", () =>
//{
//	return "Hello World Only Post";
//});

//PUT
//app.MapPut("/", () =>
//{
//	return "Hello World Only Put";
//});

//PATCH
//app.MapPatch("/", () =>
//{
//	return "Hello World Only Patch";
//});

//DELETE
//app.MapDelete("/", () =>
//{
//	return "Hello World Only Delete";
//}); 
#endregion


#region Content-Type �zelinde �rnekler text/plain,text/css,text/html
//app.Map("/", async (context) =>
//{
//	if(context.Request.Method == "OPTIONS")
//	{
//		context.Response.Headers.Accept = "Accept Info : All Browsers";
//		context.Response.Headers.AcceptCharset = "UTF-8";
//		context.Response.Headers.AcceptLanguage = "tr-TR";
//		context.Response.Headers.AccessControlAllowOrigin = "*";
//		context.Response.Headers.AccessControlAllowMethods = "GET,POST,PUT";
		
//	}


//	//return "Text Plain";

//	//context.Response.StatusCode = 404;

//});

//app.MapGet("/", async (context) =>
//{
//	if (context.Request.Headers.UserAgent.ToString().Contains("Postman"))
//		context.Response.StatusCode = 404;
//	else
//	{
//		string responseContent = "Herhangi bir <b>�ey</b>";

//		context.Response.StatusCode = 200;
//		context.Response.ContentLength = Encoding.UTF8.GetByteCount(responseContent);
//		context.Response.ContentType = "text/plain; charset=utf-8";

//		await context.Response.WriteAsync(responseContent);
//	}
		


//	//return "Text Plain";

//	//context.Response.StatusCode = 404;

//});

//app.MapGet("/{cssFileName}", async (HttpContext context, string cssFileName) =>
//{
//	string cssContent = "";

//	switch (cssFileName)
//	{
//		case "user.css":
//			cssContent = @"p { color: red; font-size: 8px }";
//			break;
//		case "main.css":
//			cssContent = @"p { color: blue; font-size: 24px }";
//			break;
//		case "index.css":
//			cssContent = @"p { color: yellow; font-size: 48px }";
//			break;
//	}

//	context.Response.StatusCode = 200;
//	context.Response.ContentLength = Encoding.UTF8.GetByteCount(cssContent);
//	context.Response.ContentType = "text/css; charset=utf-8";

//	await context.Response.WriteAsync(cssContent);

//}); /**/
	#endregion

#region Car CRUD Opertaions

//List<Car> cars = new List<Car>();

////GET	  https://localhost:7247/Cars        => AllCars

//app.MapGet("/Cars", () =>
//{
//	return cars;
//});

////GET	  https://localhost:7247/Cars/{id}   => Car With ID

//app.MapGet("/Cars/{id}", (int id) =>
//{
//	return cars.Where(c=>c.Id == id).SingleOrDefault();
//});

////POST	  https://localhost:7247/Cars		 => jsonData Model ile New Car

//app.MapPost("/Cars", (Car car) =>
//{
//	//int lastId = cars.MaxBy(c=>c.Id).Id;

//	//car.Id = lastId + 1;

//	cars.Add(car);
//	return car;
//});

////PUT     https://localhost:7247/Cars/{id}   => jsonData Model ve ID ile New Car

//app.MapPut("/Cars/{id}", (int id ,Car car) =>
//{
//	Car findOrginalCar = cars.Where(c => c.Id == id).SingleOrDefault();
//	int findOrginalIndex = cars.IndexOf(findOrginalCar);

//	cars[findOrginalIndex] = car;

//	return car;
//});

////DELETE  https://localhost:7247/Cars/{id}   => Car ID ile Delete Car 

//app.MapDelete("/Cars/{id}", (int id) =>
//{
//	Car removedCar = cars.Where(c => c.Id == id).SingleOrDefault();

//	cars.Remove(removedCar);

//	return removedCar;
//});

#endregion


app.Run();


