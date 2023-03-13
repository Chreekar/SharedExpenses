using Microsoft.OpenApi.Models;
using SharedExpenses.Framework.Repositories;
using SharedExpenses.Models.Settings;

namespace SharedExpenses.Web;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.Configure<ApplicationOptions>(builder.Configuration.GetSection(ApplicationOptions.Section));

        //builder.Services.AddSingleton<ICosmosRepository, CosmosRepository>();
        builder.Services.AddSingleton<ICosmosRepository, MockRepository>();

        var app = builder.Build();

        app.MapControllers();

        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            options.RoutePrefix = string.Empty;
        });

        app.UseCors(options =>
        {
            options.AllowAnyHeader();
            options.AllowAnyMethod();
            options.AllowAnyOrigin();
        });

        app.Run();
    }
}

