using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using SaleWebMvc.Data;
using SaleWebMvc.Services;
using System.Globalization;

namespace SaleWebMvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var enUs = new CultureInfo("en-Us");
            var localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(enUs),
                SupportedCultures = new List<CultureInfo> { enUs },
                SupportedUICultures = new List<CultureInfo> { enUs }
            };

            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddDbContext<SaleWebMvcContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("SaleWebMvcContext") ?? throw new InvalidOperationException("Connection string 'SaleWebMvcContext' not found.")));
            
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddScoped<SeedingService>();
            builder.Services.AddScoped<SellerService>();
            builder.Services.AddScoped<DepartmentService>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            else
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }

            app.UseRequestLocalization(localizationOptions);

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<SaleWebMvcContext>(); ;
                context.Database.EnsureCreated();

                var seedingService = scope.ServiceProvider.GetRequiredService<SeedingService>();
                seedingService.seed();
            }

            app.Run();
        }
    }
}
