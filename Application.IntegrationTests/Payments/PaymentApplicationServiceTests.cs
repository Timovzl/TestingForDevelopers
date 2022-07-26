using Xunit;

namespace SillyCompany.Finance.TestingForDevelopers.Application.IntegrationTests.Payments;

public class PaymentApplicationServiceTests : IntegrationTestBase
{
	[Fact]
	public void CreatePayment_Regularly_ShouldHaveExpectedEffect()
	{
		// Set up any ambient dependencies
		// using var clockScope = new ClockScope(DateTime.UnixEpoch);

		// Register any mocks, overwriting the original dependencies
		//var mockLogger = new Mock<ILogger<PaymentApplicationService>>();
		//this.ConfigureServices(services => services.AddSingleton(mockLogger.Object));

		// Construct the request model (from contracts)
		// var request = new CreatePaymentRequest(...);

		// Use our base class' utility method to invoke the use case in-memory via MicroGetClient, testing the entire HTTP pipeline
		// The utility method throws if a non-success status code is received
		// await this.GetApiResponse<IPaymentClient>(client => client.CreatePayment(request));

		// Or, if there is a response type:
		// var response = await this.GetApiResponse<IPaymentClient, CreatePaymentResponse>(client => client.CreatePayment(request));

		// Perform assertions on the RESULT or the EFFECT of the operation

		// Assert on the response:
		// Assert.NotNull(response);
		// Assert.Equal(1, response.ObjectCount);

		// Or assert directly on the database changes:
		// Assert.Equal(1, Convert.ToInt32(await this.ExecuteScalar("SELECT COUNT(*) FROM QueuedPushRequest;")));

		// Or assert on the object stored in the database:
		// var repo = this.Host.Services.GetRequiredService<PaymentRepo>();
		// var payments = await repo.ListAll();
		// var payment = Assert.Single(payments);
		// Assert.Equal(1.23m, payment.Amount.Value);
		// Assert.Equal("Test", payment.Description);
		// Assert.Equal(DateTime.UnixEpoch, payment.CreationDateTime);
		// Assert.Equal(DateTime.UnixEpoch, payment.ModificationDateTime);
		// Assert.Null(payment.ExecutionDateTime);
	}
}
