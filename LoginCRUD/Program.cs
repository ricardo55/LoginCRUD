using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using LoginCRUD.Data;
using LoginCRUD.Areas.Identity.Data;
using Microsoft.Extensions.DependencyInjection;
using LoginCRUD.Models;




var builder = WebApplication.CreateBuilder(args);

// Funciona para crear la base de datos con postgresql en Azure
//var connectionString = builder.Configuration.GetConnectionString("AZURE_POSTGRESQL_CONNECTIONSTRING") ?? throw new InvalidOperationException("Connection string 'LoginDBContextConnection' not found.");
//builder.Services.AddDbContext<LoginDBContext>(options => options.UseNpgsql(connectionString));


//var connectionString = builder.Configuration.GetConnectionString("LoginDBContextConnection") ?? throw new InvalidOperationException("Connection string 'LoginDBContextConnection' not found.");
// Funciona para crear la base de datos con sqlite
//builder.Services.AddDbContext<LoginDBContext>(options => options.UseSqlite(connectionString));

// Funciona para crear la base de datos con sqlserver
var connectionString = builder.Configuration.GetConnectionString("ConnectionStringSQLServer") ?? throw new InvalidOperationException("Connection string 'MyDbConnection' not found.");
builder.Services.AddDbContext<LoginDBContext>(options => options.UseSqlServer(connectionString));

// Funciona para crear la base de datos con postgresql
//var connectionString = builder.Configuration.GetConnectionString("ConnectionStringPSQL") ?? throw new InvalidOperationException("Connection string 'LoginDBContextConnection' not found.");
//builder.Services.AddDbContext<LoginDBContext>(options => options.UseNpgsql(connectionString));

// Funciona para crear la BD Redis en Azure
// builder.Services.AddStackExchangeRedisCache(options =>{
// options.Configuration = builder.Configuration["AZURE_REDIS_CONNECTIONSTRING"];
// options.InstanceName = "SampleInstance";
// });

// Es para autenticar con el login de Identity
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<LoginDBContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add App Service logging
builder.Logging.AddAzureWebAppDiagnostics();

builder.Services.AddRazorPages();
// builder.Services.AddDbContext<LoginDBContext2>(options =>
//     options.UseSqlite(builder.Configuration.GetConnectionString("LoginDBContext2") ?? throw new InvalidOperationException("Connection string 'LoginDBContext2' not found.")));

// Inicializar la base de datos con registros
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

// Para saber si estamos en desarrollo o produccion
// if (builder.Environment.IsDevelopment())
// {
//     builder.Services.AddDbContext<LoginDBContext>(options =>
//         options.UseSqlite(builder.Configuration.GetConnectionString("LoginDBContextConnection")));
// }
// else
// {
//     builder.Services.AddDbContext<LoginDBContext>(options =>
//         options.UseSqlServer(builder.Configuration.GetConnectionString("ProductionLoginDBContextConnection")));
// }


//Para desabilitar la validacion de contraseña en mayusculas
// builder.Services.Configure<IdentityOptions>(options =>
// {
//     options.Password.RequireUppercase = false;
// }

//var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseDeveloperExceptionPage();
app.UseDatabaseErrorPage();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
