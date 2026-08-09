using System;
using System.Runtime.InteropServices;

namespace SharpDX.D3DCompiler;

[Guid("51F23923-F3E5-4BD1-91CB-606177D8DB4C")]
public class ShaderReflectionVariable : CppObject
{
	public ShaderVariableDescription Description
	{
		get
		{
			GetDescription(out var descRef);
			return descRef;
		}
	}

	public ConstantBuffer Buffer => GetBuffer();

	public ShaderReflectionVariable(IntPtr nativePtr)
		: base(nativePtr)
	{
	}

	public static explicit operator ShaderReflectionVariable(IntPtr nativePtr)
	{
		if (!(nativePtr == IntPtr.Zero))
		{
			return new ShaderReflectionVariable(nativePtr);
		}
		return null;
	}

	internal unsafe void GetDescription(out ShaderVariableDescription descRef)
	{
		ShaderVariableDescription.__Native @ref = default(ShaderVariableDescription.__Native);
		descRef = default(ShaderVariableDescription);
		Result result = ((delegate* unmanaged[Stdcall]<void*, void*, int>)(*(*(IntPtr**)_nativePointer)))(_nativePointer, &@ref);
		descRef.__MarshalFrom(ref @ref);
		result.CheckError();
	}

	public unsafe ShaderReflectionType GetVariableType()
	{
		IntPtr zero = IntPtr.Zero;
		zero = ((delegate* unmanaged[Stdcall]<void*, IntPtr>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + sizeof(void*))))(_nativePointer);
		if (zero != IntPtr.Zero)
		{
			return new ShaderReflectionType(zero);
		}
		return null;
	}

	internal unsafe ConstantBuffer GetBuffer()
	{
		IntPtr zero = IntPtr.Zero;
		zero = ((delegate* unmanaged[Stdcall]<void*, IntPtr>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + (nint)2 * (nint)sizeof(void*))))(_nativePointer);
		if (zero != IntPtr.Zero)
		{
			return new ConstantBuffer(zero);
		}
		return null;
	}

	public unsafe int GetInterfaceSlot(int uArrayIndex)
	{
		return ((delegate* unmanaged[Stdcall]<void*, int, int>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + (nint)3 * (nint)sizeof(void*))))(_nativePointer, uArrayIndex);
	}
}
