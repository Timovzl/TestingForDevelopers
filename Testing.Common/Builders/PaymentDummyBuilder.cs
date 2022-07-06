using Architect.DomainModeling;
using SillyCompany.Finance.TestingForDevelopers.Domain.Payments;

namespace SillyCompany.Finance.TestingForDevelopers.Testing.Common.Builders;

[SourceGenerated]
public partial class PaymentDummyBuilder : DummyBuilder<Payment, PaymentDummyBuilder>
{
	public PaymentDummyBuilder WithAmount(decimal value) => this.WithAmount(new Amount(value));
}
