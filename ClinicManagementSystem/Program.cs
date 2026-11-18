using ClinicManagementSystem.Repositories;
using ClinicManagementSystem.Repositories.IRepositories;

namespace ClinicManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            builder.Services.AddDbContext<ClinicManagementSystem.Data.ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IRepository<User>, Repository<User>>();
            builder.Services.AddScoped<IRepository<Specialty>, Repository<Specialty>>();
            builder.Services.AddScoped<IRepository<Doctor>, Repository<Doctor>>();
            builder.Services.AddScoped<IRepository<Patient>, Repository<Patient>>();
            builder.Services.AddScoped<IRepository<Appointment>, Repository<Appointment>>();
            builder.Services.AddScoped<IRepository<MedicalRecord>, Repository<MedicalRecord>>();


            //builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

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
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
