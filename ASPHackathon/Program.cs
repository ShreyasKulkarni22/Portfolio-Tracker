using DAL;
using Microsoft.EntityFrameworkCore;
using Service;

namespace ASPHackathon
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<FlightDetailsDBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("FlightDetailsDBContext") ?? throw new InvalidOperationException("Connection string 'FlightDetailsDBContext' not found.")));

            // Add services to the container.
            builder.Services.AddScoped<IFlightService, FlightService>();
            builder.Services.AddScoped<IFlightRepository, FlightRepository>();

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

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}