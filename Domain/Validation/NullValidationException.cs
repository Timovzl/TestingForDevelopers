using System.Runtime.CompilerServices;

namespace SillyCompany.Finance.TestingForDevelopers.Domain.Validation;

/// <summary>
/// Similar to an <see cref="ArgumentNullException"/>, except in the form of a <see cref="ValidationException"/>.
/// </summary>
public class NullValidationException : ValidationException
{
	public string ParameterName { get; }

	public NullValidationException(Enum errorCode, string parameterName, [CallerFilePath] string? callerFilePath = null, [CallerMemberName] string? callerMemberName = null)
		: this(errorCode, parameterName, message: CreateErrorMessage(parameterName: parameterName, callerFilePath: callerFilePath, callerMemberName: callerMemberName))
	{
	}

	public NullValidationException(Enum errorCode, string parameterName, string message)
		: base(errorCode, message)
	{
		this.ParameterName = parameterName ?? throw new ArgumentNullException(nameof(parameterName));
	}

	private static string CreateErrorMessage(string? parameterName, string? callerFilePath, string? callerMemberName)
	{
		if (callerMemberName == ".ctor" && callerFilePath?.EndsWith(".cs") == true)
			parameterName = $"{Path.GetFileNameWithoutExtension(callerFilePath)} {parameterName}";

		return $"The following required data was missing: {parameterName}.";
	}
}
