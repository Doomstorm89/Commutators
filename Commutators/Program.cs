using Microsoft.EntityFrameworkCore;
using Commutators.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CommutatorsContext>(options =>
{
    // (!!!) TODO: Заменить строку подключения на свою (!!!)
    options.UseSqlServer(builder.Configuration.GetConnectionString("CommutatorsContext") ?? throw new InvalidOperationException("Connection string 'CommutatorsContext' not found."));
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope();
var context = serviceScope.ServiceProvider.GetRequiredService<CommutatorsContext>();

if (context.Database.EnsureCreated()) { context.Database.MigrateAsync(); }
else { context.Database.EnsureCreatedAsync(); }

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Commutator}/{action=Index}");

app.Run();
