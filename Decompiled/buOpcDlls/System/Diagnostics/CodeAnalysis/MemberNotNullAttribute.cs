using System.Runtime.CompilerServices;

namespace System.Diagnostics.CodeAnalysis;

[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullableContext(1)]
[Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullable(0)]
[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
internal sealed class MemberNotNullAttribute : Attribute
{
	public string[] Members { get; }

	public MemberNotNullAttribute(string member)
	{
		Members = new string[1] { member };
	}

	public MemberNotNullAttribute(params string[] members)
	{
		Members = members;
	}
}
