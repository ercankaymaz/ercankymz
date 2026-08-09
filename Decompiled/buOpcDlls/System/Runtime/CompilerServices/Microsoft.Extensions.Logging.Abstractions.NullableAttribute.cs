using Microsoft.CodeAnalysis;

namespace System.Runtime.CompilerServices;

[CompilerGenerated]
[Microsoft_002EExtensions_002ELogging_002EAbstractions_002EEmbedded]
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Parameter | AttributeTargets.ReturnValue | AttributeTargets.GenericParameter, AllowMultiple = false, Inherited = false)]
internal sealed class Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullableAttribute : Attribute
{
	public readonly byte[] NullableFlags;

	public Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullableAttribute(byte P_0)
	{
		NullableFlags = new byte[1] { P_0 };
	}

	public Microsoft_002EExtensions_002ELogging_002EAbstractions_002ENullableAttribute(byte[] P_0)
	{
		NullableFlags = P_0;
	}
}
