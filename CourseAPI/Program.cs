using Courses.Domain.Interfaces;
using Courses.Repositories.Data;
using Courses.Repository.Implementations;
using Courses.Services.Contracts;
using Courses.Services.Contracts.Course;
using Courses.Services.Implementations;
using Courses.Services.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Diagnostics;

namespace Courses
{
    public class Program
    {
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
        .Build();

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configures Serilog to write logs to SQL Server
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration)
                .CreateLogger();

            // Enables Serilog debugging to surface errors if logging fails
            Serilog.Debugging.SelfLog.Enable(msg =>
            {
                Debug.Print(msg);
                Debugger.Break();
            });

            // Add services to the container.
            builder.Services.AddDbContext<CoursesDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]);
            });

            builder.Services.AddScoped<ICoursesRepository, CoursesRepository>();
            builder.Services.AddScoped<ICourseService, CourseService>();
            builder.Services.AddScoped<IValidator<CourseCreateReq>, CourseCreateReqValidator>();
            builder.Services.AddScoped<IValidator<CourseUpdateReq>, CourseUpdateReqValidator>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}