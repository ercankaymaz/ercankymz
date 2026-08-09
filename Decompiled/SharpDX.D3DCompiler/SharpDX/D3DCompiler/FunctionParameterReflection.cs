using System;
using System.Runtime.InteropServices;

namespace SharpDX.D3DCompiler;

[Guid("42757488-334F-47FE-982E-1A65D08CC462")]
public class FunctionParameterReflection : CppObject
{
	public ParameterDescription Description
	{
		get
		{
			GetDescription(out var descRef);
			return descRef;
		}
	}

	public FunctionParameterReflection(IntPtr nativePtr)
		: base(nativePtr)
	{
	}

	public static explicit operator FunctionParameterReflection(IntPtr nativePtr)
	{
		if (!(nativePtr == IntPtr.Zero))
		{
			return new FunctionParameterReflection(nativePtr);
		}
		return null;
	}

	internal unsafe void GetDescription(out ParameterDescription descRef)
	{
		ParameterDescription.__Native @ref = default(ParameterDescription.__Native);
		descRef = default(ParameterDescription);
		Result result = ((delegate* unmanaged[Stdcall]<void*, void*, int>)(*(*(IntPtr**)_nativePointer)))(_nativePointer, &@ref);
		descRef.__MarshalFrom(ref @ref);
		result.CheckError();
	}
}
