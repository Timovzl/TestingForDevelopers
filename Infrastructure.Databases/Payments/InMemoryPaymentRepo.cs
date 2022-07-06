using System.Collections.Concurrent;
using SillyCompany.Finance.TestingForDevelopers.Domain.Payments;

namespace SillyCompany.Finance.TestingForDevelopers.Infrastructure.Databases.Payments;

internal class InMemoryPaymentRepo : IPaymentRepo
{
	private ConcurrentBag<Payment> Payments { get; } = new ConcurrentBag<Payment>();

	public Task Add(Payment instance)
	{
		this.Payments.Add(instance);
		return Task.CompletedTask;
	}
}
