using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Voeg MVC services toe
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// CUSTOM route: als URL alleen een nummer is, ga naar KorteBroekController.Index
app.MapControllerRoute(
    name: "short",
    pattern: "{id:int}",
    defaults: new { controller = "KorteBroek", action = "Index" }
);

// Standaard route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=KorteBroek}/{action=Index}/{id?}"
);

app.Run();