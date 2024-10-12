using GestordePacientes.Core.Application.Interfaces;
using GestordePacientes.Core.Application.Services;
using GestordePacientes.Infrastructure.Persistence.Contexts;
using GestordePacientes.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication("Cookies")
    .AddCookie("Cookies", options =>
    {
        options.LoginPath = "/Access/Login"; // Ruta para el login
        options.AccessDeniedPath = "/Home/AccessDenied"; // Ruta para acceso denegado
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("EsAsistente", policy => policy.RequireRole("Asistente"));
    options.AddPolicy("EsAdministrador", policy => policy.RequireRole("Administrador"));
});

builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

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
    pattern: "{controller=Home}/{action=MenuAdmin}/{id?}");

app.Run();
