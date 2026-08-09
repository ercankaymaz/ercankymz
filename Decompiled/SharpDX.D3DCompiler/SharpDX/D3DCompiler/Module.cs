using System;
using System.Runtime.InteropServices;

namespace SharpDX.D3DCompiler;

[Guid("CAC701EE-80FC-4122-8242-10B39C8CEC34")]
public class Module : ComObject
{
	public unsafe Module(ShaderBytecode bytecode)
	{
		if (bytecode == null)
		{
			throw new ArgumentNullException("bytecode");
		}
		byte[] data = bytecode.Data;
		fixed (byte* ptr = &data[0])
		{
			void* value = ptr;
			D3D.LoadModule(new IntPtr(value), new PointerSize(data.Length), this);
		}
	}

	public Module(IntPtr nativePtr)
		: base(nativePtr)
	{
	}

	public static explicit operator Module(IntPtr nativePtr)
	{
		if (!(nativePtr == IntPtr.Zero))
		{
			return new Module(nativePtr);
		}
		return null;
	}

	internal unsafe void CreateInstance(string namespaceRef, ModuleInstance moduleInstanceOut)
	{
		IntPtr zero = IntPtr.Zero;
		IntPtr intPtr = Marshal.StringToHGlobalAnsi(namespaceRef);
		Result result = ((delegate* unmanaged[Stdcall]<void*, void*, void*, int>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + (nint)3 * (nint)sizeof(void*))))(_nativePointer, (void*)intPtr, &zero);
		moduleInstanceOut.NativePointer = zero;
		Marshal.FreeHGlobal(intPtr);
		result.CheckError();
	}
}
