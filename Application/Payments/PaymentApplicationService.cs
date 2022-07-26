using Architect.DomainModeling;
using Microsoft.Extensions.Logging;
using SillyCompany.Finance.TestingForDevelopers.Contracts.Payments.V1;
using SillyCompany.Finance.TestingForDevelopers.Domain.Payments;

namespace SillyCompany.Finance.TestingForDevelopers.Application.Payments;

/// <summary>
/// Provides use cases related to payments.
/// </summary>
public class PaymentApplicationService : IPaymentClient, IApplicationService
{
	private ILogger<PaymentApplicationService> Logger { get; }
	private IPaymentRepo PaymentRepo { get; }

	public PaymentApplicationService(
		ILogger<PaymentApplicationService> logger,
		IPaymentRepo paymentRepo)
	{
		this.Logger = logger;
		this.PaymentRepo = paymentRepo;
	}

	/// <summary>
	/// A use case that creates a payment based on the given input.
	/// </summary>
	public async Task CreatePayment(decimal amount, string description)
	{
		this.Logger.LogInformation("Creating payment of EUR {amount}.", amount);

		var payment = new Payment(
			new Amount(amount),
			description);

		await this.PaymentRepo.Add(payment);
	}
}
