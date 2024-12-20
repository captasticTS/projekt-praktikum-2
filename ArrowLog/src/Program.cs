using ArrowLog.Components;
using ArrowLog.Database;
using MudBlazor.Services;
using ArrowLog.Features.Login;
using Microsoft.AspNetCore.Authentication.Cookies;
using ArrowLog.Components.Pages.Services;
using Blazored.LocalStorage;
using ArrowLog.Database.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Adds Mudblazor
builder.Services.AddMudServices();

// Adds DB Context for EF Core
builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddTransient<DbPersonService>();

// Adds Login Services
builder.Services.AddScoped<AuthService>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/login";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(60); // Ensure cookies expire consistently with the session
    });
builder.Services.AddAuthorization();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(60);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddHttpContextAccessor();

// Adds Theme Service
builder.Services.AddScoped<ThemeService>();
builder.Services.AddBlazoredLocalStorage();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.UseStaticFiles();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

