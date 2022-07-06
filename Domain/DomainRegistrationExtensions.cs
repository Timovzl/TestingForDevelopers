using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SillyCompany.Finance.TestingForDevelopers.Domain;

public static class DomainRegistrationExtensions
{
	public static IServiceCollection AddDomainLayer(this IServiceCollection services, IConfiguration _)
	{
		return services;
	}
}
