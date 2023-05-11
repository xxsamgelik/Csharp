using Microsoft.EntityFrameworkCore;
using MvcApp.Models;    // пространство имен класса ApplicationContext


var builder = WebApplication.CreateBuilder(args);

string connection = "Server = (localdb)\\mssqllocaldb;Database = userstoredb;Trusted_Connection=true";
builder.Services.AddDbContext<UsersContext>(options => options.UseSqlServer(connection));

//старое подключение ApplicationContext
//// получаем строку подключения из файла конфигурации
//string connection = builder.Configuration.GetConnectionString("DefaultConnection");

//// добавляем контекст ApplicationContext в качестве сервиса в приложение
//builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.MapDefaultControllerRoute();

app.Run();





//Без БД
//var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddControllersWithViews(); // добавляем сервисы MVC

//var app = builder.Build();

//// устанавливаем сопоставление маршрутов с контроллерами
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.Run();