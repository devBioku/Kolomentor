using kolomentor.Data;
using kolomentor.Data.Services;
using kolomentor.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IMentorService, MentorService>();
builder.Services.AddScoped<ICareerService, CareerService>();    
builder.Services.AddScoped<IGuestService, GuestService>();
builder.Services.AddScoped<IMenteeService, MenteeService>();
builder.Services.AddScoped<ISkillService, SkillService>();
builder.Services.AddScoped<IMentorshipService, MentorshipService>();
builder.Services.AddScoped<ISkillTypeService, SkillTypeService>();
builder.Services.AddScoped<ISkillTypeTopicService, SkillTypeTopicService>();


builder.Services.AddHttpContextAccessor();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); 
});

//builder.Services.AddScoped<IMaterialService, MaterialService>();

//DbContextFile Configuration 
var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionStrings");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();
app.UseSession();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//Seeding the Data
AppDbInitializer.Seed(app);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting(); 

app.UseAuthorization();
app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
