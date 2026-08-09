using System;
using System.Runtime.CompilerServices;

namespace Basler.Pylon.Internal;

internal class WaitObjectHelper
{
	public unsafe static IntPtr Duplicate(void* h)
	{
		void* ptr = (void*)(-1);
		void* currentProcess = global::_003CModule_003E.GetCurrentProcess();
		if (global::_003CModule_003E.DuplicateHandle(currentProcess, h, currentProcess, &ptr, 0u, 0, 2u) == 0)
		{
			throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AInvalidOperationException_003E(new InvalidOperationException("Unable to create new handle."), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1BG_0040OIPNDMGI_0040_003F_0024AAW_003F_0024AAa_003F_0024AAi_003F_0024AAt_003F_0024AAO_003F_0024AAb_003F_0024AAj_003F_0024AAe_003F_0024AAc_003F_0024AAt_0040));
		}
		return (IntPtr)ptr;
	}

	private unsafe static void RaiseInvalidObjectStateException(string A_0)
	{
		throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003AInvalidOperationException_003E(new InvalidOperationException(A_0), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1BG_0040OIPNDMGI_0040_003F_0024AAW_003F_0024AAa_003F_0024AAi_003F_0024AAt_003F_0024AAO_003F_0024AAb_003F_0024AAj_003F_0024AAe_003F_0024AAc_003F_0024AAt_0040));
	}
}
