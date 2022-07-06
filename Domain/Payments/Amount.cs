using Architect.DomainModeling;

namespace SillyCompany.Finance.TestingForDevelopers.Domain.Payments;

/// <summary>
/// A monetary amount in euros.
/// </summary>
[SourceGenerated]
public sealed partial class Amount : WrapperValueObject<decimal>
{
	public decimal Value { get; }

	public Amount(decimal value)
	{
		this.Value = value;

		if (this.Value * 100 % 1m != 0m)
			throw new ValidationException(ErrorCode.Amount_TooManyDecimalPlaces, "An amount must not have more than 2 decimal places.");
	}
}
