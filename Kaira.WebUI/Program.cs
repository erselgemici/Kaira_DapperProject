using Kaira.WebUI.Context;
using Kaira.WebUI.Repositories.AiInteractionRepositories;
using Kaira.WebUI.Repositories.CategoryRepositories;
using Kaira.WebUI.Repositories.FeatureRepositories;
using Kaira.WebUI.Repositories.IMainSliderRepositories;
using Kaira.WebUI.Repositories.PartnerRepositories;
using Kaira.WebUI.Repositories.ProductRepositories;
using Kaira.WebUI.Repositories.TestimonialRepositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ITestimonialRepository, TestimonialRepository>();
builder.Services.AddScoped<IMainSliderRepository, MainSliderRepository>();
builder.Services.AddScoped<IFeatureRepository, FeatureRepository>();
builder.Services.AddScoped<IPartnerRepository, PartnerRepository>();
builder.Services.AddScoped<IAiInteractionRepository, AiInteractionRepository>();
builder.Services.AddScoped<AppDbContext>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
  name: "areas",
  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");


app.MapControllerRoute(
name: "default",
pattern: "{controller=Home}/{action=Index}/{id?}")
.WithStaticAssets();


app.Run();
