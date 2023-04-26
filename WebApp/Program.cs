using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);
var SyncFusionKey = builder.Configuration.GetSection("SyncfusionKey").Value;
builder.Services.AddDistributedMemoryCache();
builder.Services.AddControllersWithViews().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddHttpClient();
var app = builder.Build();

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(SyncFusionKey);

app.UseStaticFiles();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();