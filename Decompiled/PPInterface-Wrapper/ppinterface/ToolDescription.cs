using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using _003FA0x657f4e8c;

namespace ppinterface;

[StructLayout(LayoutKind.Sequential, Size = 4)]
[NativeCppClass]
internal struct ToolDescription
{
	[SpecialName]
	public unsafe static void _003CMarshalCopy_003E(ToolDescription* A_0, ToolDescription* A_1)
	{
		System.Runtime.CompilerServices.Unsafe.SkipInit(out __clr_placement_new_t _clr_placement_new_t);
		// IL initblk instruction
		System.Runtime.CompilerServices.Unsafe.InitBlock(ref _clr_placement_new_t, 0, 1);
		__clr_placement_new_t* ptr = &_clr_placement_new_t;
		__clr_placement_new_t _clr_placement_new_t2 = _clr_placement_new_t;
		try
		{
			if (A_0 != null)
			{
				global::_003CModule_003E.ppinterface_002EToolDescription_002E_007Bctor_007D(A_0, A_1);
			}
			return;
		}
		catch
		{
			//try-fault
			global::_003CModule_003E.delete(A_0, A_0, *ptr);
			throw;
		}
	}

	[SpecialName]
	public unsafe static void _003CMarshalDestroy_003E(ToolDescription* A_0)
	{
		global::_003CModule_003E.ppinterface_002EToolDescription_002E_007Bdtor_007D(A_0);
	}
}
