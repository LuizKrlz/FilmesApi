using FilmesApi.Data;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var connectionString = builder.Configuration.GetConnectionString("FilmeConnection");

        builder.Services.AddControllers();
        builder.Services.AddControllers().AddNewtonsoftJson();

        builder.Services.AddDbContext<FilmeContext>(
            opts => opts.UseMySql(
                connectionString,
                ServerVersion.AutoDetect(connectionString)
            )
        );

        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.MapControllers();

        app.Run();
    }
}
