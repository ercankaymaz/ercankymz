namespace System.Diagnostics.CodeAnalysis;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter | AttributeTargets.ReturnValue, AllowMultiple = true, Inherited = false)]
internal sealed class System_002EFormats_002EAsn13538873_002ENotNullIfNotNullAttribute : Attribute
{
	public string ParameterName { get; }

	public System_002EFormats_002EAsn13538873_002ENotNullIfNotNullAttribute(string parameterName)
	{
		ParameterName = parameterName;
	}
}
