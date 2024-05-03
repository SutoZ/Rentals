using Microsoft.EntityFrameworkCore;
using Rental.Core.Extensions;
using Rental.Host;
using Rental.Infrastructure.DatabaseContext;
using Rental.Infrastructure.Extensions;
using Serilog;
using Serilog.Exceptions;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwagger();
        builder.Services.AddCoreServices();
        builder.Services.AddHealthChecks();


        builder.Host.UseSerilog((context, configuration) =>
        {
            configuration.ReadFrom.Configuration(context.Configuration)
                .Enrich.WithExceptionDetails()
                .WriteTo.Seq("http://localhost:5343");
        });

        builder.Services.AddRepositoryServices();

        builder.Services.AddDbConnection<RentalContext>(builder.Configuration);
        builder.Services.AddResponseCaching();

        var app = builder.Build();

        app.UseSerilogRequestLogging(configure => configure.EnrichDiagnosticContext = Enricher.HttpRequestEnricher);
        app.MapHealthChecks("/health");

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();
        
        app.MapControllers();


        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<RentalContext>();

        if (await dbContext.Database.CanConnectAsync())
        {
            if (dbContext.Database.GetPendingMigrations().Any())
            {
                await dbContext.Database.MigrateAsync();
            }
        }

        app.UseCors();
        app.UseResponseCaching();

        app.Run();
    }
}