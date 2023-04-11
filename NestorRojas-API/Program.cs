using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Entity.DataModel.DataModelContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataAccessConnection")));
builder.Services.AddScoped<MyRepository.DataModel.IRepository, MyRepository.DataModel.Repository>();
builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
var app = builder.Build();
app.UseAuthentication();
app.UseStaticFiles();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();