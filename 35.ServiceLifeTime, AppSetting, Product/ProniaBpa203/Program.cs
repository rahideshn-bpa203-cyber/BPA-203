
using Microsoft.EntityFrameworkCore;
using ProniaBpa203.DAL;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(opt =>
   opt.UseSqlServer("server=DESKTOP-4LV7K5A\\SQLEXPRESS;" +
   "database=ProniaBPA203DB;" +
   "trusted_connection=true;" +
   "trustServerCertificate=true")

);

var app = builder.Build();

app.UseStaticFiles();

app.MapControllerRoute(

    "default",
    "{controller=home}/{action=index}/{id?}"


    );

app.Run();
