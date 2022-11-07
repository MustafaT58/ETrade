using Microsoft.EntityFrameworkCore;
using ETrade.Dal;
using ETrade.Repos.Abstract;
using ETrade.Entity.Concretes;
using ETrade.Repos.Concretes;
using ETrade.UI.Models;
using ETrade.Uw;
using ETrade.DTO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<TradeContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("Baglanti")));
builder.Services.AddScoped<IBasketDetailRep, BasketDetailRep<BasketDetail>>();
builder.Services.AddScoped<IBasketMasterRep, BasketMasterRep<BasketMaster>>();
builder.Services.AddScoped<ICategoriesRep, CategoriesRep<Categories>>();
builder.Services.AddScoped<ICitiesRep, CitiesRep<Cities>>();
builder.Services.AddScoped<ICountiesRep, CountiesRep<Counties>>();
builder.Services.AddScoped<IProductsRep, ProductsRep<Products>>();
builder.Services.AddScoped<ISuppliersRep, SuppliersRep<Suppliers>>();
builder.Services.AddScoped<IUsersRep, UsersRep<Users>>();
builder.Services.AddScoped<IUnitRep, UnitRep<Unit>>();
builder.Services.AddScoped<IVatRep, VatRep<Vat>>();
builder.Services.AddScoped<IUnit,UnitOw>();
builder.Services.AddScoped<CityModel>();
builder.Services.AddScoped<CategoriesModel>();
builder.Services.AddScoped<UnitModel>();
builder.Services.AddScoped<UsersModel>();
builder.Services.AddScoped<BasketMaster>();
builder.Services.AddScoped<BasketDetail>();
builder.Services.AddScoped<BasketDetailModel>();
builder.Services.AddSession(x => x.IdleTimeout = TimeSpan.FromSeconds(15));




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
