using Courses.Repository;
using Courses.Repositories.Data;
using Courses.Services;
using Courses.Services.Contracts.Course;
using Microsoft.EntityFrameworkCore;
using Courses.API.Logs;

namespace Courses
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            LoggerConfigurationSetup.SetupLogger();

            // Add services to the container.
            builder.Services.AddDbContext<CoursesDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]);
            });

            builder.Services.AddRepository()
                            .AddServices()
                            .AddCreateReq()
                            .UpdateCreateReq();

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