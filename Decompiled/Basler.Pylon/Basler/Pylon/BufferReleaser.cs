using System;
using System.Runtime.InteropServices;

namespace Basler.Pylon;

internal class BufferReleaser
{
	public delegate void BufferCallbackDelegateXY(int A_0);

	public unsafe void DoFree(int bufferContext)
	{
		if (0 != bufferContext)
		{
			if (null == global::_003CModule_003E.gcroot_003CBasler_003A_003APylon_003A_003AIBufferFactory_0020_005E_003E_002E_002EP_0024AAUIBufferFactory_0040Pylon_0040Basler_0040_0040((gcroot_003CBasler_003A_003APylon_003A_003AIBufferFactory_0020_005E_003E*)bufferContext))
			{
				((GCHandle)global::_003CModule_003E.gcroot_003CSystem_003A_003ARuntime_003A_003AInteropServices_003A_003AGCHandle_0020_005E_003E_002E_002D_003E((gcroot_003CSystem_003A_003ARuntime_003A_003AInteropServices_003A_003AGCHandle_0020_005E_003E*)(bufferContext + 16))).Free();
			}
			else
			{
				global::_003CModule_003E.gcroot_003CBasler_003A_003APylon_003A_003AIBufferFactory_0020_005E_003E_002E_002D_003E((gcroot_003CBasler_003A_003APylon_003A_003AIBufferFactory_0020_005E_003E*)bufferContext).FreeBuffer(global::_003CModule_003E.gcroot_003CSystem_003A_003AObject_0020_005E_003E_002E_002EP_0024AAVObject_0040System_0040_0040((gcroot_003CSystem_003A_003AObject_0020_005E_003E*)(bufferContext + 4)), (IntPtr)global::_003CModule_003E.gcroot_003CSystem_003A_003AIntPtr_0020_005E_003E_002E_002EP_0024AA__ZVIntPtr_0040System_0040_0040((gcroot_003CSystem_003A_003AIntPtr_0020_005E_003E*)(bufferContext + 8)), global::_003CModule_003E.gcroot_003CSystem_003A_003AObject_0020_005E_003E_002E_002EP_0024AAVObject_0040System_0040_0040((gcroot_003CSystem_003A_003AObject_0020_005E_003E*)(bufferContext + 12)));
			}
			global::_003CModule_003E.Basler_002EPylon_002ENativeBufferContext_002E_007Bdtor_007D((NativeBufferContext*)bufferContext);
			global::_003CModule_003E.delete((void*)bufferContext, 20u);
		}
	}
}
