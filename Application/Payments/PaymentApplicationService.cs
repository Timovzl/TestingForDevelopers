using Architect.DomainModeling;
using Microsoft.Extensions.Logging;
using SillyCompany.Finance.TestingForDevelopers.Contracts.Payments.V1;
using SillyCompany.Finance.TestingForDevelopers.Domain.Payments;

namespace SillyCompany.Finance.TestingForDevelopers.Application.Payments;

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

	public async Task CreatePayment(decimal amount, string description)
	{
		this.Logger.LogInformation("Creating payment of {amount}.", amount);

		var payment = new Payment(
			new Amount(amount),
			description);

		await this.PaymentRepo.Add(payment);
	}
}
