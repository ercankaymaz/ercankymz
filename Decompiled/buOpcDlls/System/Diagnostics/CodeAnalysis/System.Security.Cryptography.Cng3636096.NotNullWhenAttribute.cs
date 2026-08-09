namespace System.Diagnostics.CodeAnalysis;

[AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
internal sealed class System_002ESecurity_002ECryptography_002ECng3636096_002ENotNullWhenAttribute : Attribute
{
	public bool ReturnValue { get; }

	public System_002ESecurity_002ECryptography_002ECng3636096_002ENotNullWhenAttribute(bool returnValue)
	{
		ReturnValue = returnValue;
	}
}
