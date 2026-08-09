using System;
using System.Runtime.InteropServices;

namespace SharpDX.D3DCompiler;

[Guid("469E07F7-045A-48D5-AA12-68A478CDF75D")]
public class ModuleInstance : ComObject
{
	public ModuleInstance(Module module)
		: this(string.Empty, module)
	{
	}

	public ModuleInstance(string namespaceRef, Module module)
	{
		if (module == null)
		{
			throw new ArgumentNullException("module");
		}
		module.CreateInstance(namespaceRef, this);
	}

	public ModuleInstance(IntPtr nativePtr)
		: base(nativePtr)
	{
	}

	public static explicit operator ModuleInstance(IntPtr nativePtr)
	{
		if (!(nativePtr == IntPtr.Zero))
		{
			return new ModuleInstance(nativePtr);
		}
		return null;
	}

	public unsafe Result BindConstantBuffer(int uSrcSlot, int uDstSlot, int cbDstOffset)
	{
		return ((delegate* unmanaged[Stdcall]<void*, int, int, int, int>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + (nint)3 * (nint)sizeof(void*))))(_nativePointer, uSrcSlot, uDstSlot, cbDstOffset);
	}

	public unsafe Result BindConstantBufferByName(string nameRef, int uDstSlot, int cbDstOffset)
	{
		IntPtr intPtr = Marshal.StringToHGlobalAnsi(nameRef);
		Result result = ((delegate* unmanaged[Stdcall]<void*, void*, int, int, int>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + (nint)4 * (nint)sizeof(void*))))(_nativePointer, (void*)intPtr, uDstSlot, cbDstOffset);
		Marshal.FreeHGlobal(intPtr);
		return result;
	}

	public unsafe Result BindResource(int uSrcSlot, int uDstSlot, int uCount)
	{
		return ((delegate* unmanaged[Stdcall]<void*, int, int, int, int>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + (nint)5 * (nint)sizeof(void*))))(_nativePointer, uSrcSlot, uDstSlot, uCount);
	}

	public unsafe Result BindResourceByName(string nameRef, int uDstSlot, int uCount)
	{
		IntPtr intPtr = Marshal.StringToHGlobalAnsi(nameRef);
		Result result = ((delegate* unmanaged[Stdcall]<void*, void*, int, int, int>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + (nint)6 * (nint)sizeof(void*))))(_nativePointer, (void*)intPtr, uDstSlot, uCount);
		Marshal.FreeHGlobal(intPtr);
		return result;
	}

	public unsafe Result BindSampler(int uSrcSlot, int uDstSlot, int uCount)
	{
		return ((delegate* unmanaged[Stdcall]<void*, int, int, int, int>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + (nint)7 * (nint)sizeof(void*))))(_nativePointer, uSrcSlot, uDstSlot, uCount);
	}

	public unsafe Result BindSamplerByName(string nameRef, int uDstSlot, int uCount)
	{
		IntPtr intPtr = Marshal.StringToHGlobalAnsi(nameRef);
		Result result = ((delegate* unmanaged[Stdcall]<void*, void*, int, int, int>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + (nint)8 * (nint)sizeof(void*))))(_nativePointer, (void*)intPtr, uDstSlot, uCount);
		Marshal.FreeHGlobal(intPtr);
		return result;
	}

	public unsafe Result BindUnorderedAccessView(int uSrcSlot, int uDstSlot, int uCount)
	{
		return ((delegate* unmanaged[Stdcall]<void*, int, int, int, int>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + (nint)9 * (nint)sizeof(void*))))(_nativePointer, uSrcSlot, uDstSlot, uCount);
	}

	public unsafe Result BindUnorderedAccessViewByName(string nameRef, int uDstSlot, int uCount)
	{
		IntPtr intPtr = Marshal.StringToHGlobalAnsi(nameRef);
		Result result = ((delegate* unmanaged[Stdcall]<void*, void*, int, int, int>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + (nint)10 * (nint)sizeof(void*))))(_nativePointer, (void*)intPtr, uDstSlot, uCount);
		Marshal.FreeHGlobal(intPtr);
		return result;
	}

	public unsafe Result BindResourceAsUnorderedAccessView(int uSrcSrvSlot, int uDstUavSlot, int uCount)
	{
		return ((delegate* unmanaged[Stdcall]<void*, int, int, int, int>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + (nint)11 * (nint)sizeof(void*))))(_nativePointer, uSrcSrvSlot, uDstUavSlot, uCount);
	}

	public unsafe Result BindResourceAsUnorderedAccessViewByName(string srvNameRef, int uDstUavSlot, int uCount)
	{
		IntPtr intPtr = Marshal.StringToHGlobalAnsi(srvNameRef);
		Result result = ((delegate* unmanaged[Stdcall]<void*, void*, int, int, int>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + (nint)12 * (nint)sizeof(void*))))(_nativePointer, (void*)intPtr, uDstUavSlot, uCount);
		Marshal.FreeHGlobal(intPtr);
		return result;
	}
}
