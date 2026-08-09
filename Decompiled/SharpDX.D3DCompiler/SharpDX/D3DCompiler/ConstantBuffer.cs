using System;
using System.Runtime.InteropServices;

namespace SharpDX.D3DCompiler;

[Guid("EB62D63D-93DD-4318-8AE8-C6F83AD371B8")]
public class ConstantBuffer : CppObject
{
	public ConstantBufferDescription Description
	{
		get
		{
			GetDescription(out var descRef);
			return descRef;
		}
	}

	public ConstantBuffer(IntPtr nativePtr)
		: base(nativePtr)
	{
	}

	public static explicit operator ConstantBuffer(IntPtr nativePtr)
	{
		if (!(nativePtr == IntPtr.Zero))
		{
			return new ConstantBuffer(nativePtr);
		}
		return null;
	}

	internal unsafe void GetDescription(out ConstantBufferDescription descRef)
	{
		ConstantBufferDescription.__Native @ref = default(ConstantBufferDescription.__Native);
		descRef = default(ConstantBufferDescription);
		Result result = ((delegate* unmanaged[Stdcall]<void*, void*, int>)(*(*(IntPtr**)_nativePointer)))(_nativePointer, &@ref);
		descRef.__MarshalFrom(ref @ref);
		result.CheckError();
	}

	public unsafe ShaderReflectionVariable GetVariable(int index)
	{
		IntPtr zero = IntPtr.Zero;
		zero = ((delegate* unmanaged[Stdcall]<void*, int, IntPtr>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + sizeof(void*))))(_nativePointer, index);
		if (zero != IntPtr.Zero)
		{
			return new ShaderReflectionVariable(zero);
		}
		return null;
	}

	public unsafe ShaderReflectionVariable GetVariable(string name)
	{
		IntPtr zero = IntPtr.Zero;
		IntPtr intPtr = Marshal.StringToHGlobalAnsi(name);
		zero = ((delegate* unmanaged[Stdcall]<void*, void*, IntPtr>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + (nint)2 * (nint)sizeof(void*))))(_nativePointer, (void*)intPtr);
		ShaderReflectionVariable result = ((!(zero != IntPtr.Zero)) ? null : new ShaderReflectionVariable(zero));
		Marshal.FreeHGlobal(intPtr);
		return result;
	}
}
