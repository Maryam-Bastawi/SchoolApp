using Microsoft.EntityFrameworkCore;
using SchoolApp.BLL.Mapping;
using SchoolApp.BLL.Data.Contexts;
using SchoolApp.BLL.Repositories;
using SchoolApp.BLL.Services.Contract;
using SchoolApp.BLL.UnitOfWork.UnitOfWork;
using SchoolApp.DAL.Interfaces;
using SchoolApp.Services.Middleware;
using SchoolApp.Services.Services;
using SchoolApp.Services.SettingsServicies;

namespace SchoolApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            // تسجيل AppDbContext الخاص بك
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                options.EnableSensitiveDataLogging(); // <-- أضف هذا
                options.EnableDetailedErrors();       // <-- أضف هذا
            });

            // تسجيل الـ Generic Repository الخاص بك
            builder.Services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));

        // تسجيل وحدة العمل
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            // تسجيل AutoMapper
            builder.Services.AddAutoMapper(typeof(StudentProfile));
            // --- هام: قم بتسجيل خدمات التطبيق الخاصة بك (طبقة منطق العمل) هنا ---
            builder.Services.AddScoped<IStudentService, StudentService>();

        builder.Services.AddScoped<IDocumentSettings, DocumentSettings>();

            var app = builder.Build();

        // أضف برمجيات معالجة الاستثناءات الوسيطة المخصصة في أعلى مسار الطلبات
        app.UseMiddleware<ExceptionMiddleware>();
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
