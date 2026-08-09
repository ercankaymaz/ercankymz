using System;
using System.Runtime.InteropServices;

namespace SharpDX.D3DCompiler;

[Guid("207BCECB-D683-4A06-A8A3-9B149B9F73A4")]
public class FunctionReflection : CppObject
{
	public ConstantBuffer[] ConstantBuffers
	{
		get
		{
			ConstantBuffer[] array = new ConstantBuffer[Description.ConstantBuffers];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = GetConstantBufferByIndex(i);
			}
			return array;
		}
	}

	public FunctionParameterReflection[] Parameters
	{
		get
		{
			FunctionParameterReflection[] array = new FunctionParameterReflection[Description.FunctionParameterCount];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = GetFunctionParameter(i);
			}
			return array;
		}
	}

	public FunctionParameterReflection ReturnParameter
	{
		get
		{
			if (!Description.HasReturn)
			{
				throw new ArgumentException("Function has no return parameter, check function.Description.HasReturn before to call this function");
			}
			return GetFunctionParameter(-1);
		}
	}

	public InputBindingDescription[] ResourceBindings
	{
		get
		{
			InputBindingDescription[] array = new InputBindingDescription[Description.BoundResources];
			for (int i = 0; i < array.Length; i++)
			{
				GetResourceBindingDescription(i, out array[i]);
			}
			return array;
		}
	}

	public FunctionDescription Description
	{
		get
		{
			GetDescription(out var descRef);
			return descRef;
		}
	}

	public InputBindingDescription GetResourceBindingDescription(int index)
	{
		GetResourceBindingDescription(index, out var descRef);
		return descRef;
	}

	public InputBindingDescription GetResourceBindingDescription(string name)
	{
		GetResourceBindingDescByName(name, out var descRef);
		return descRef;
	}

	public FunctionReflection(IntPtr nativePtr)
		: base(nativePtr)
	{
	}

	public static explicit operator FunctionReflection(IntPtr nativePtr)
	{
		if (!(nativePtr == IntPtr.Zero))
		{
			return new FunctionReflection(nativePtr);
		}
		return null;
	}

	internal unsafe void GetDescription(out FunctionDescription descRef)
	{
		FunctionDescription.__Native @ref = default(FunctionDescription.__Native);
		descRef = default(FunctionDescription);
		Result result = ((delegate* unmanaged[Stdcall]<void*, void*, int>)(*(*(IntPtr**)_nativePointer)))(_nativePointer, &@ref);
		descRef.__MarshalFrom(ref @ref);
		result.CheckError();
	}

	public unsafe ConstantBuffer GetConstantBufferByIndex(int bufferIndex)
	{
		IntPtr zero = IntPtr.Zero;
		zero = ((delegate* unmanaged[Stdcall]<void*, int, IntPtr>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + sizeof(void*))))(_nativePointer, bufferIndex);
		if (zero != IntPtr.Zero)
		{
			return new ConstantBuffer(zero);
		}
		return null;
	}

	public unsafe ConstantBuffer GetConstantBufferByName(string name)
	{
		IntPtr zero = IntPtr.Zero;
		IntPtr intPtr = Marshal.StringToHGlobalAnsi(name);
		zero = ((delegate* unmanaged[Stdcall]<void*, void*, IntPtr>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + (nint)2 * (nint)sizeof(void*))))(_nativePointer, (void*)intPtr);
		ConstantBuffer result = ((!(zero != IntPtr.Zero)) ? null : new ConstantBuffer(zero));
		Marshal.FreeHGlobal(intPtr);
		return result;
	}

	public unsafe void GetResourceBindingDescription(int resourceIndex, out InputBindingDescription descRef)
	{
		InputBindingDescription.__Native @ref = default(InputBindingDescription.__Native);
		descRef = default(InputBindingDescription);
		Result result = ((delegate* unmanaged[Stdcall]<void*, int, void*, int>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + (nint)3 * (nint)sizeof(void*))))(_nativePointer, resourceIndex, &@ref);
		descRef.__MarshalFrom(ref @ref);
		result.CheckError();
	}

	public unsafe ShaderReflectionVariable GetVariableByName(string name)
	{
		IntPtr zero = IntPtr.Zero;
		IntPtr intPtr = Marshal.StringToHGlobalAnsi(name);
		zero = ((delegate* unmanaged[Stdcall]<void*, void*, IntPtr>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + (nint)4 * (nint)sizeof(void*))))(_nativePointer, (void*)intPtr);
		ShaderReflectionVariable result = ((!(zero != IntPtr.Zero)) ? null : new ShaderReflectionVariable(zero));
		Marshal.FreeHGlobal(intPtr);
		return result;
	}

	public unsafe void GetResourceBindingDescByName(string name, out InputBindingDescription descRef)
	{
		InputBindingDescription.__Native @ref = default(InputBindingDescription.__Native);
		descRef = default(InputBindingDescription);
		IntPtr intPtr = Marshal.StringToHGlobalAnsi(name);
		Result result = ((delegate* unmanaged[Stdcall]<void*, void*, void*, int>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + (nint)5 * (nint)sizeof(void*))))(_nativePointer, (void*)intPtr, &@ref);
		descRef.__MarshalFrom(ref @ref);
		Marshal.FreeHGlobal(intPtr);
		result.CheckError();
	}

	public unsafe FunctionParameterReflection GetFunctionParameter(int parameterIndex)
	{
		IntPtr zero = IntPtr.Zero;
		zero = ((delegate* unmanaged[Stdcall]<void*, int, IntPtr>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + (nint)6 * (nint)sizeof(void*))))(_nativePointer, parameterIndex);
		if (zero != IntPtr.Zero)
		{
			return new FunctionParameterReflection(zero);
		}
		return null;
	}
}
