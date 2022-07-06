using SillyCompany.Finance.TestingForDevelopers.Domain.Payments;
using SillyCompany.Finance.TestingForDevelopers.Domain.Validation;
using Xunit;

namespace SillyCompany.Finance.TestingForDevelopers.Domain.UnitTests.Payments;

public class AmountTests
{
	[Fact]
	public void Construct_Regularly_ShouldReturnExpectedData()
	{
		var result = new Amount(1.23m);

		Assert.Equal(1.23m, result.Value);
	}

	[Fact]
	public void Construct_WithTooManyDecimalPlaces_ShouldThrow()
	{
		var exception = Assert.Throws<ValidationException>(() => new Amount(1.234m));
		Assert.Contains("Amount_TooManyDecimalPlaces", exception.Message);
	}
}
