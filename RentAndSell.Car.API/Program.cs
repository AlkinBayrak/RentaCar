using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RentAndSell.Car.API;
using RentAndSell.Car.API.Data;
using RentAndSell.Car.API.Data.Entities.Concrete;
using RentAndSell.Car.API.Services;
using System.Text;
using HttpMethod = Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpMethod;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthentication("YetkiKontrol").AddScheme<AuthenticationSchemeOptions,YetkiKontrolYakalayicisi>("YetkiKontrol",null);

builder.Services.AddDbContext<CarRentDbContext>(opt =>
{
	opt.UseSqlServer(builder.Configuration.GetConnectionString("CarRentDbCon"));
});

builder.Services.AddIdentity<Kullanici,IdentityRole>()
				 .AddEntityFrameworkStores<CarRentDbContext>();

builder.Services.AddControllers();

builder.Services.ConfigureApplicationCookie(opt =>
{
	opt.Events.OnRedirectToLogin = (context) =>
	{
		context.Response.StatusCode = StatusCodes.Status401Unauthorized;

		return Task.CompletedTask;
	};

	opt.Events.OnRedirectToAccessDenied = (context) =>
	{
		context.Response.StatusCode = StatusCodes.Status403Forbidden;

		return Task.CompletedTask;
	};
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapControllers();

// GET | POST | PUT | PATCH | DELETE | OPTIONS

#region Senkron Main method
//app.Map("/", async (context) => {
//   return "Hello World All Methods GET | POST | PUT | PATCH | DELETE | OPTIONS";
//}); 
#endregion

#region Asenkron With Context Method

//app.Map("/", async (context) =>
//{
//    await context.Response.WriteAsync("Hello World All Methods GET | POST | PUT | PATCH | DELETE | OPTIONS\n");

//    if (context.Request.Method == HttpMethod.Get.ToString().ToUpper())
//        await context.Response.WriteAsync("Hello World Only GET ");

//    if (context.Request.Method == HttpMethod.Post.ToString().ToUpper())
//        await context.Response.WriteAsync("Hello World Only POST");

//    if (context.Request.Method == HttpMethod.Put.ToString().ToUpper())
//        await context.Response.WriteAsync("Hello World Only PUT");

//    if (context.Request.Method == HttpMethod.Patch.ToString().ToUpper())
//        await context.Response.WriteAsync("Hello World Only PATCH");

//    if (context.Request.Method == HttpMethod.Delete.ToString().ToUpper())
//        await context.Response.WriteAsync("Hello World Only DELETE");

//    if (context.Request.Method == HttpMethod.Options.ToString().ToUpper(new System.Globalization.CultureInfo("en-Us")))
//        await context.Response.WriteAsync("Hello World Only OPTIONS");

//});

#endregion

#region Http All Verbs Endpoint Map GET | POST | PUT | PATCH | DELETE 
//// GET
//app.MapGet("/", () =>
//{
//    return "Hello World Only GET";
//});

//// POST
//app.MapPost("/", () =>
//{
//    return "Hello World Only POST";
//});

//// PUT
//app.MapPut("/", () =>
//{
//    return "Hello World Only PUT";
//});

//// PATCH
//app.MapPatch("/", () =>
//{
//    return "Hello World Only PATCH";
//});

//// DELETE
//app.MapDelete("/", () =>
//{
//    return "Hello World Only DELETE";
//}); 
#endregion

#region Content-Type özelinde örnekler text/plain, text/css, text/html
//app.Map("/", async (context) =>
//{

//if (context.Request.Method == "OPTIONS")
//{
//context.Response.Headers.Accept = "Accept Info : All Browsers";
//context.Response.Headers.AcceptCharset = "UTF-8";
//context.Response.Headers.AcceptLanguage = "tr-TR";
//context.Response.Headers.AccessControlAllowOrigin = "*";
//context.Response.Headers.AccessControlAllowMethods = "GET,POST,PUT";

//}

//    //return "<b>Text Plain</b>";

//    //context.Response.StatusCode = 503;
//});

//app.MapGet("/", async (context) =>
//{
//    if (context.Request.Headers.UserAgent.ToString().Contains("Postman"))
//        context.Response.StatusCode = 404;
//    else
//    {
//        string responeContent = "Herhangi bir þey <b>bu yazý bold</b>";

//        context.Response.StatusCode = 200;
//        context.Response.ContentLength = Encoding.UTF8.GetByteCount(responeContent);
//        context.Response.ContentType = "text/plain; charset=utf-8";


//        await context.Response.WriteAsync(responeContent);
//    }


//    //return "<b>Text Plain</b>";

//    //context.Response.StatusCode = 503;
//});

//app.MapGet("/{cssFileName}", async (HttpContext context, string cssFileName) =>
//{
//    string cssContent = "";

//    switch (cssFileName)
//    {
//        case "user.css":
//            cssContent = @"p { color: red; font-size: 8px }";
//            break;
//        case "main.css":
//            cssContent = @"p { color: blue; font-size: 24px }";
//            break;
//        case "index.css":
//            cssContent = @"p { color: yellow; font-size: 48px }";
//            break;
//    }

//    context.Response.StatusCode = 200;
//    context.Response.ContentLength = Encoding.UTF8.GetByteCount(cssContent);
//    context.Response.ContentType = "text/css; charset=utf-8";

//    await context.Response.WriteAsync(cssContent);

//});

#endregion

#region Car CRUD Operations

//List<Car> cars = new List<Car>();


////GET       https://localhost:7247/Cars               => AllCars

//app.MapGet("/Cars", () =>
//{
//    return cars;
//});

////GET       https://localhost:7247/Cars/{id}          => Car With ID

//app.MapGet("/Cars/{id}", (int id) =>
//{
//    return cars.Where(c => c.Id == id).SingleOrDefault();
//});


////POST      https://localhost:7247/Cars               => jsonData Model ile New Car 

//app.MapPost("/Cars", (Car car) =>
//{
//    //int lastId = cars.MaxBy(c => c.Id).Id;

//    //car.Id = lastId + 1;

//    cars.Add(car);
//    return car;
//});


////PUT       https://localhost:7247/Cars/{id}          => jsonData Model ve ID ile Edit Car

//app.MapPut("/Cars/{id}", (int id, Car car) =>
//{
//    Car findOrginalCar = cars.Where(c => c.Id == id).SingleOrDefault();
//    int findOrginalIndex = cars.IndexOf(findOrginalCar);

//    cars[findOrginalIndex] = car;

//    return car;
//});

////DELETE    https://localhost:7247/Cars/{id}          => Car ID ile Delete Car 

//app.MapDelete("/Cars/{id}", (int id) =>
//{
//    Car removedCar = cars.Where(c => c.Id == id).SingleOrDefault();

//    cars.Remove(removedCar);

//    return removedCar;
//});

#endregion


app.Run();
