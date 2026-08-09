namespace System.Diagnostics.CodeAnalysis;

[AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
internal sealed class System_002EFormats_002EAsn13538873_002ENotNullWhenAttribute : Attribute
{
	public bool ReturnValue { get; }

	public System_002EFormats_002EAsn13538873_002ENotNullWhenAttribute(bool returnValue)
	{
		ReturnValue = returnValue;
	}
}
