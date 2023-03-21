using H3Cocktails.Handler;
using Microsoft.EntityFrameworkCore;

namespace H3Cocktails
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Adds the CocktailContext
            builder.Services.AddDbContext<CocktailContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("CocktailContext"));
            });
            //Add DrinkHandler to service collection, to use DI
            builder.Services.AddTransient<DrinkHandler>();

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