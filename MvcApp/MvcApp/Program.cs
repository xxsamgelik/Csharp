using Microsoft.EntityFrameworkCore;
using MvcApp.Models;    // ������������ ���� ������ ApplicationContext


var builder = WebApplication.CreateBuilder(args);

string connection = "Server = (localdb)\\mssqllocaldb;Database = userstoredb;Trusted_Connection=true";
builder.Services.AddDbContext<UsersContext>(options => options.UseSqlServer(connection));

//������ ����������� ApplicationContext
//// �������� ������ ����������� �� ����� ������������
//string connection = builder.Configuration.GetConnectionString("DefaultConnection");

//// ��������� �������� ApplicationContext � �������� ������� � ����������
//builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.MapDefaultControllerRoute();

app.Run();





//��� ��
//var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddControllersWithViews(); // ��������� ������� MVC

//var app = builder.Build();

//// ������������� ������������� ��������� � �������������
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.Run();