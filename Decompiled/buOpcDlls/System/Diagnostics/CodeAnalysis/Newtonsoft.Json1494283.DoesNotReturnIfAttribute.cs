namespace System.Diagnostics.CodeAnalysis;

[AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
internal class Newtonsoft_002EJson1494283_002EDoesNotReturnIfAttribute : Attribute
{
	public bool ParameterValue { get; }

	public Newtonsoft_002EJson1494283_002EDoesNotReturnIfAttribute(bool parameterValue)
	{
		ParameterValue = parameterValue;
	}
}
