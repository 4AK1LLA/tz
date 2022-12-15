using Microsoft.EntityFrameworkCore;
using tz;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<FoldersContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), 
        conf => { conf.UseHierarchyId(); }));

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
