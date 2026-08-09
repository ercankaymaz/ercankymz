namespace System.Diagnostics.CodeAnalysis;

[AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
internal sealed class System_002ESecurity_002ECryptography_002ECng3636096_002EDoesNotReturnIfAttribute : Attribute
{
	public bool ParameterValue { get; }

	public System_002ESecurity_002ECryptography_002ECng3636096_002EDoesNotReturnIfAttribute(bool parameterValue)
	{
		ParameterValue = parameterValue;
	}
}
