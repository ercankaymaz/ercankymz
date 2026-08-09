using Microsoft.CodeAnalysis;

namespace System.Runtime.CompilerServices;

[CompilerGenerated]
[System_002EDiagnostics_002EDiagnosticSource_002EEmbedded]
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Parameter | AttributeTargets.ReturnValue | AttributeTargets.GenericParameter, AllowMultiple = false, Inherited = false)]
internal sealed class System_002EDiagnostics_002EDiagnosticSource_002ENullableAttribute : Attribute
{
	public readonly byte[] NullableFlags;

	public System_002EDiagnostics_002EDiagnosticSource_002ENullableAttribute(byte P_0)
	{
		NullableFlags = new byte[1] { P_0 };
	}

	public System_002EDiagnostics_002EDiagnosticSource_002ENullableAttribute(byte[] P_0)
	{
		NullableFlags = P_0;
	}
}
