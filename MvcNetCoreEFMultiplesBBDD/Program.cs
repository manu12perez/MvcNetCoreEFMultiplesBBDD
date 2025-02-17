using Microsoft.EntityFrameworkCore;
using MvcNetCoreEFMultiplesBBDD.Data;
using MvcNetCoreEFMultiplesBBDD.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

/*****************************************************************************************************************************************/

//SQL
//string connectionString = builder.Configuration.GetConnectionString("SqlHospital");
//builder.Services.AddDbContext<HospitalContext>(x => x.UseSqlServer(connectionString));
//builder.Services.AddTransient<IRepositoryEmpleados, RepositoryEmpleados>();

//ORACLE
//string connectionString = builder.Configuration.GetConnectionString("OracleHospital");
//builder.Services.AddDbContext<HospitalContext>(x => x.UseOracle(connectionString));
//builder.Services.AddTransient<IRepositoryEmpleados, RepositoryEmpleadosOracle>();

//MYSQL
string connectionString = builder.Configuration.GetConnectionString("MySqlHospital");
builder.Services.AddDbContext<HospitalContext>(x => x.UseMySQL(connectionString));
builder.Services.AddTransient<IRepositoryEmpleados, RepositoryEmpleadosMySql>();

/*****************************************************************************************************************************************/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
