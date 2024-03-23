using Microsoft.EntityFrameworkCore;
using PMS;
using PMS.DataBase;
using PMS.RepositoryServces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(x=>x.UseSqlServer(builder.Configuration.GetConnectionString("conn")));


builder.Services.AddAutoMapper(x =>
{
    x.AddMaps(typeof(ICore).Assembly);
});

builder.Services.AddTransient<IAdminRepositoryServices, AdminRepositoryServices>();
builder.Services.AddTransient<IContactRepositoryServices, ContactRepositoryServices>();
builder.Services.AddTransient<IPaymentRepositryServices,PaymentRepositoryServices>();
builder.Services.AddTransient<IPopulerRepositoryServices,PopulaerRepostitoryServices>();
builder.Services.AddTransient<ISealesOwnerRepositoryServices,SealesOwnersRepositoryServices>();
builder.Services.AddTransient<IUserRepositoryServices,UserRepositorySevices>();



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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
