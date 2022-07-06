using Microsoft.Extensions.Logging;
using Moq;
using SillyCompany.Finance.TestingForDevelopers.Application.Payments;
using SillyCompany.Finance.TestingForDevelopers.Domain.Payments;
using Xunit;

namespace SillyCompany.Finance.TestingForDevelopers.Application.UnitTests.Payments;

public class PaymentApplicationServiceTests
{
	private Mock<ILogger<PaymentApplicationService>> MockLogger { get; }
	private Mock<IPaymentRepo> MockPaymentRepo { get; }
	private PaymentApplicationService Instance { get; }

	public PaymentApplicationServiceTests()
	{
		this.MockLogger = new Mock<ILogger<PaymentApplicationService>>();
		this.MockPaymentRepo = new Mock<IPaymentRepo>();
		this.Instance = new PaymentApplicationService(this.MockLogger.Object, this.MockPaymentRepo.Object);
	}

	// NOTE: Should be verified by the integration test
	[Fact]
	public async Task CreatePayment_Regularly_ShouldAddToRepo()
	{
		await this.Instance.CreatePayment(1.23m, "Test");

		this.MockPaymentRepo.Verify(r => r.Add(It.IsAny<Payment>()), Times.Once);
	}

	// NOTE: Worthwhile?
	// NOTE: Could be obsolete if the integration test already includes this
	[Fact]
	public async Task CreatePayment_Regularly_ShouldWriteExpectedLogEntry()
	{
		await this.Instance.CreatePayment(1.23m, "Test");

		// Mocking ILogger<T> is a bit convoluted
		this.MockLogger.Verify(
			x => x.Log(
				LogLevel.Information,
				It.IsAny<EventId>(),
				It.Is<It.IsAnyType>((state, _) => state.ToString()!.Contains("creat", StringComparison.OrdinalIgnoreCase)),
				null,
				It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
			Times.Once);
	}
}
