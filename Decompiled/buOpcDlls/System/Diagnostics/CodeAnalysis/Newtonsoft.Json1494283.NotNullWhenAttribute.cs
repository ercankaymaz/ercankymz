namespace System.Diagnostics.CodeAnalysis;

[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
internal sealed class Newtonsoft_002EJson1494283_002ENotNullWhenAttribute : Attribute
{
	public bool ReturnValue { get; }

	public Newtonsoft_002EJson1494283_002ENotNullWhenAttribute(bool returnValue)
	{
		ReturnValue = returnValue;
	}
}
