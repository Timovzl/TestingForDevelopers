namespace SillyCompany.Finance.TestingForDevelopers.Contracts.Payments.V1;

public interface IPaymentClient
{
	Task CreatePayment(decimal amount, string description);
}
