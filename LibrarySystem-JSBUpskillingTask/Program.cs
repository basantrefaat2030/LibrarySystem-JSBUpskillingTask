
using LibrarySystem.Core.Interfaces;
using LibrarySystem.Infrastructure.Repositories;
using LibrarySystem_JSBUpskillingTask.Data;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem_JSBUpskillingTask
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Add DbContext
            builder.Services.AddDbContext<LibraryContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("LibraryConnection")));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //object life time
            builder.Services.AddScoped<IBookRepository, BookRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
