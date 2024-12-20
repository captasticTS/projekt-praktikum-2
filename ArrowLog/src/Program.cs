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

// Adds CRUD services
builder.Services.AddTransient<DbParcoursService>();
builder.Services.AddTransient<DbPersonService>();
builder.Services.AddTransient<DbGameService>();
builder.Services.AddTransient<DbRulsetService>();
builder.Services.AddTransient<DbScoreService>();

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

//begin SetString() hack
app.Use(async delegate (HttpContext Context, Func<Task> Next)
{
    //this throwaway session variable will "prime" the SetString() method
    //to allow it to be called after the response has started
    var TempKey = Guid.NewGuid().ToString(); //create a random key
    Context.Session.Set(TempKey, Array.Empty<byte>()); //set the throwaway session variable
    Context.Session.Remove(TempKey); //remove the throwaway session variable
    await Next(); //continue on with the request
});
//end SetString() hack

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

