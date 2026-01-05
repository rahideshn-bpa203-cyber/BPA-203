using _35_ServiceLifeTimeAppSettingProductn.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(opp =>
    opp.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
);

var app = builder.Build();




app.UseStaticFiles();

app.MapControllerRoute(
    "admin",
    "{Area:exists}/{controller=dashboard}/{action=index}/{id?}"
    );


app.MapControllerRoute(
    "default",
    "{controller=home}/{action=index}/{id?}"
    );
app.Run();