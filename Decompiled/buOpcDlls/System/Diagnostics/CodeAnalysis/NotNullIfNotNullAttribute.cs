using System.Runtime.CompilerServices;

namespace System.Diagnostics.CodeAnalysis;

[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullableContext(1)]
[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(0)]
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter | AttributeTargets.ReturnValue, AllowMultiple = true, Inherited = false)]
internal sealed class NotNullIfNotNullAttribute : Attribute
{
	public string ParameterName { get; }

	public NotNullIfNotNullAttribute(string parameterName)
	{
		ParameterName = parameterName;
	}
}
