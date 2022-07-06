namespace SillyCompany.Finance.TestingForDevelopers.Domain.Payments;

public interface IPaymentRepo
{
	Task Add(Payment instance);
}
