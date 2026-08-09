using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using boost.detail;

namespace boost;

[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003CPylon_003A_003ACBufferData_003E
{
}
[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct shared_ptr_003CPylon_003A_003ACGrabResultData_003E
{
	[SpecialName]
	public unsafe static void _003CMarshalCopy_003E(shared_ptr_003CPylon_003A_003ACGrabResultData_003E* A_0, shared_ptr_003CPylon_003A_003ACGrabResultData_003E* A_1)
	{
		*(int*)A_0 = *(int*)A_1;
		int num = (((int*)A_0)[1] = ((int*)A_1)[1]);
		if (num != 0)
		{
			Interlocked.Increment(ref *(int*)(num + 4));
		}
	}

	[SpecialName]
	public unsafe static void _003CMarshalDestroy_003E(shared_ptr_003CPylon_003A_003ACGrabResultData_003E* A_0)
	{
		uint num = ((uint*)A_0)[1];
		if (num != 0)
		{
			global::_003CModule_003E.boost_002Edetail_002Esp_counted_base_002Erelease((sp_counted_base*)(int)num);
		}
	}
}
