namespace System.Diagnostics.CodeAnalysis;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter | AttributeTargets.ReturnValue, AllowMultiple = true, Inherited = false)]
internal sealed class System_002EDiagnostics_002EDiagnosticSource3462135_002ENotNullIfNotNullAttribute : Attribute
{
	public string ParameterName { get; }

	public System_002EDiagnostics_002EDiagnosticSource3462135_002ENotNullIfNotNullAttribute(string parameterName)
	{
		ParameterName = parameterName;
	}
}
