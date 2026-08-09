using Microsoft.CodeAnalysis;

namespace System.Runtime.CompilerServices;

[CompilerGenerated]
[Newtonsoft_002EJson_002EEmbedded]
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Parameter | AttributeTargets.ReturnValue | AttributeTargets.GenericParameter, AllowMultiple = false, Inherited = false)]
internal sealed class Newtonsoft_002EJson_002ENullableAttribute : Attribute
{
	public readonly byte[] NullableFlags;

	public Newtonsoft_002EJson_002ENullableAttribute(byte P_0)
	{
		NullableFlags = new byte[1] { P_0 };
	}

	public Newtonsoft_002EJson_002ENullableAttribute(byte[] P_0)
	{
		NullableFlags = P_0;
	}
}
