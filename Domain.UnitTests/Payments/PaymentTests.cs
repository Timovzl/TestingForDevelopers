using Architect.AmbientContexts;
using SillyCompany.Finance.TestingForDevelopers.Domain.Validation;
using SillyCompany.Finance.TestingForDevelopers.Testing.Common.Builders;
using Xunit;

namespace SillyCompany.Finance.TestingForDevelopers.Domain.UnitTests.Payments;

public class PaymentTests
{
	[Fact]
	public void Construct_Regularly_ShouldReturnExpectedResult()
	{
		// Control ambient dependencies
		using var clockScope = new ClockScope(() => DateTime.UnixEpoch);

		var result = new PaymentDummyBuilder()
			.WithAmount(1.23m)
			.WithDescription("Test")
			.Build();

		Assert.Equal(DateTime.UnixEpoch, result.CreationDateTime);
		Assert.Equal(DateTime.UnixEpoch, result.ModificationDateTime);
		Assert.Equal(1.23m, result.Amount.Value);
		Assert.Equal("Test", result.Description);
		Assert.Null(result.ExecutionDateTime);
	}

	[Fact]
	public void Construct_WithNullAmount_ShouldThrow()
	{
		var exception = Assert.Throws<NullValidationException>(() => new PaymentDummyBuilder().WithAmount(null).Build());
		Assert.Contains("Payment_AmountNull", exception.Message);
	}

	[Fact]
	public void Construct_WithNullDescription_ShouldThrow()
	{
		var exception = Assert.Throws<NullValidationException>(() => new PaymentDummyBuilder().WithDescription(null).Build());
		Assert.Contains("Payment_DescriptionNull", exception.Message);
	}

	[Fact]
	public void MarkAsExecuted_Regularly_ShouldHaveExpectedEffect()
	{
		var instance = new PaymentDummyBuilder().Build();

		using var clockScope = new ClockScope(() => DateTime.UnixEpoch);

		instance.MarkAsExecuted();

		Assert.Equal(DateTime.UnixEpoch, instance.ExecutionDateTime);
		Assert.Equal(DateTime.UnixEpoch, instance.ModificationDateTime);
	}

	[Fact]
	public void MarkAsExecuted_WhenAlreadyExecuted_ShouldThrow()
	{
		var instance = new PaymentDummyBuilder().Build();

		using var clockScope = new ClockScope(() => DateTime.UnixEpoch);

		instance.MarkAsExecuted();

		var exception = Assert.Throws<InvalidOperationException>(() => instance.MarkAsExecuted());
		Assert.Contains("execut", exception.Message, StringComparison.OrdinalIgnoreCase);
	}
}
