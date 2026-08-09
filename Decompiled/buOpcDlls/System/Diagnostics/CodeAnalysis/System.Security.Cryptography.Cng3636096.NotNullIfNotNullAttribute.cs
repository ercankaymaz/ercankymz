namespace System.Diagnostics.CodeAnalysis;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter | AttributeTargets.ReturnValue, AllowMultiple = true, Inherited = false)]
internal sealed class System_002ESecurity_002ECryptography_002ECng3636096_002ENotNullIfNotNullAttribute : Attribute
{
	public string ParameterName { get; }

	public System_002ESecurity_002ECryptography_002ECng3636096_002ENotNullIfNotNullAttribute(string parameterName)
	{
		ParameterName = parameterName;
	}
}
