using Architect.AmbientContexts;
using Architect.DomainModeling;
using Architect.Identities;

namespace SillyCompany.Finance.TestingForDevelopers.Domain.Payments;

public sealed class Payment : Entity<PaymentId, decimal>
{
	public DateTime CreationDateTime { get; }
	public DateTime ModificationDateTime { get; private set; }
	public Amount Amount { get; }
	public string Description { get; }

	/// <summary>
	/// If and when the payment was actually performed.
	/// </summary>
	public DateTime? ExecutionDateTime { get; private set; }

	public Payment(Amount amount, string description)
		: base(DistributedId.CreateId())
	{
		this.CreationDateTime = Clock.UtcNow;
		this.ModificationDateTime = this.CreationDateTime;
		this.Amount = amount ?? throw new NullValidationException(ErrorCode.Payment_AmountNull, nameof(description));
		this.Description = description ?? throw new NullValidationException(ErrorCode.Payment_DescriptionNull, nameof(description));
	}

	public void MarkAsExecuted()
	{
		if (this.ExecutionDateTime is not null)
			throw new InvalidOperationException($"Attempted to execute {this}, which was already executed on {this.ExecutionDateTime:O}.");

		this.ExecutionDateTime = Clock.UtcNow;
		this.ModificationDateTime = this.ExecutionDateTime.Value;
	}
}
