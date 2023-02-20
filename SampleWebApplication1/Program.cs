using Microsoft.EntityFrameworkCore;
using SampleWebApplication1.Models;

var builder = WebApplication.CreateBuilder(args);

//adatbaziskapcsolat config
//----------------------------------------------------------
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlite("Data source=SampleMvcWebApp.db"));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();   //servicecollection buildelese itt megtortent (serviceprovider)

// Configure the HTTP request pipeline.
//-------------------------------------------------------------------
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//Database
//--------------------------------------------------------------

using (IServiceScope serviceScope = app.Services.CreateScope())
{
    using AppDbContext appDbContext = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
    {
        appDbContext.Database.EnsureDeleted();
        appDbContext.Database.EnsureCreated();
    }
}

//Run
//---------------------------------------------------------------
app.Run();
