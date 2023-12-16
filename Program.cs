using CleanGrassAppWeb.Data;

using CleanGrassAppWeb.Services.Data;
using CleanGrassAppWeb.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<CleanGrassDbContext>();



builder.Services.Configure<IdentityOptions>(options => {
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 3;
// Lockout settings
    options.Lockout.MaxFailedAccessAttempts = 30;
    options.Lockout.AllowedForNewUsers = true;
// User settings
    options.User.RequireUniqueEmail = true;
});

// Add services to the container.''
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Marcas");
    options.Conventions.AuthorizeFolder("/Categorias");
});

builder.Services.AddTransient<IGrassService, GrassService>();
builder.Services.AddDbContext<CleanGrassDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

var context = new CleanGrassDbContext();
context.Database.Migrate();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();