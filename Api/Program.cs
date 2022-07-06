using SillyCompany.Finance.TestingForDevelopers.Application;
using SillyCompany.Finance.TestingForDevelopers.Application.ExceptionHandlers;
using SillyCompany.Finance.TestingForDevelopers.Infrastructure.Databases;
using Prometheus;

namespace SillyCompany.Finance.TestingForDevelopers.Api;

internal static class Program
{
	public static async Task Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		builder.Services.AddApplicationLayer(builder.Configuration);
		builder.Services.AddDatabaseInfrastructureLayer(builder.Configuration);

		builder.Services.AddHealthChecks();

		var app = builder.Build();
		
		if (builder.Environment.IsDevelopment())
			app.UseDeveloperExceptionPage();

		app.UseExceptionHandler(app => app.Run(async context =>
			await context.RequestServices.GetRequiredService<RequestExceptionHandler>().HandleExceptionAsync()));

		app.UseRouting();

		// Expose a health check endpoint
		app.UseHealthChecks("/health");

		// Expose Prometheus metrics
		app.UseEndpoints(endpoints => endpoints.MapMetrics());

		await app.RunAsync();
	}
}
