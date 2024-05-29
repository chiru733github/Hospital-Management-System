using Business_Layer.Interfaces;
using Business_Layer.Services;
using Repository_Layer.Interfaces;
using Repository_Layer.Services;

namespace Hospital_Management_System
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddTransient<IPatientBusiness, PatientBusiness>();
            builder.Services.AddTransient<IPatientRepo,PatientRepo>();
            builder.Services.AddTransient<IDoctorBusiness, DoctorBusiness>();
            builder.Services.AddTransient<IDoctorRepo, DoctorRepo>();
            builder.Services.AddTransient<IAppointmentBL, AppointmentBL>();
            builder.Services.AddTransient<IAppointmentRepo, AppointmentRepo>();
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
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}