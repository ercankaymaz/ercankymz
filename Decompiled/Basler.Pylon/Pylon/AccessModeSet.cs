using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Pylon;

[StructLayout(LayoutKind.Sequential, Size = 4)]
[NativeCppClass]
internal struct AccessModeSet
{
	[SpecialName]
	public unsafe static void _003CMarshalCopy_003E(AccessModeSet* A_0, AccessModeSet* A_1)
	{
		global::_003CModule_003E.Pylon_002EAccessModeSet_002E_007Bctor_007D(A_0, A_1);
	}

	[SpecialName]
	public unsafe static void _003CMarshalDestroy_003E(AccessModeSet* A_0)
	{
		global::_003CModule_003E.Pylon_002EAccessModeSet_002E_007Bdtor_007D(A_0);
	}
}
