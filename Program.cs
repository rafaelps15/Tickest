using Microsoft.EntityFrameworkCore;
using Tickest.Data;
using Tickest.Data.Seed;

namespace Tickest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddHttpContextAccessor();

            var authentication = builder.Services.AddAuthentication(opt =>
            {
                opt.DefaultChallengeScheme = "Authentication";
                opt.DefaultScheme = "Authentication";
            });

            authentication.AddCookie("Authentication", opt =>
            {
                opt.Cookie.HttpOnly = true;
                opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                opt.LoginPath = new PathString("/Autenticacao/Login");
                opt.AccessDeniedPath = new PathString("/acesso-negado");
                opt.ExpireTimeSpan = TimeSpan.FromDays(10);
            });

            builder.Services.AddDbContext<Contexto>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            SeedData.Initialize(builder.Services.BuildServiceProvider());
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Ticket}/{action=Listagem}/{id?}");

            app.Run();

        }
    }

   


}