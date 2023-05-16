using Microsoft.EntityFrameworkCore;
using MvcApp.Models;    // пространство имен класса ApplicationContext


var builder = WebApplication.CreateBuilder(args);

string connection = "Server = (localdb)\\mssqllocaldb;Database = People;Trusted_Connection=false";
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.MapDefaultControllerRoute();

app.Run();