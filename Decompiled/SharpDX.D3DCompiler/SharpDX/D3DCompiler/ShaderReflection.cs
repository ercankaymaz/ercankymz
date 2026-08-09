using System;
using System.Runtime.InteropServices;
using SharpDX.Direct3D;
using SharpDX.Mathematics.Interop;

namespace SharpDX.D3DCompiler;

[Guid("8d536ca1-0cca-4956-a837-786963755584")]
public class ShaderReflection : ComObject
{
	public ShaderDescription Description
	{
		get
		{
			GetDescription(out var descRef);
			return descRef;
		}
	}

	public int MoveInstructionCount => GetMoveInstructionCount();

	public int ConditionalMoveInstructionCount => GetConditionalMoveInstructionCount();

	public int ConversionInstructionCount => GetConversionInstructionCount();

	public int BitwiseInstructionCount => GetBitwiseInstructionCount();

	public InputPrimitive GeometryShaderSInputPrimitive => GetGeometryShaderSInputPrimitive();

	public RawBool IsSampleFrequencyShader => IsSampleFrequencyShader_();

	public int InterfaceSlotCount => GetInterfaceSlotCount();

	public FeatureLevel MinFeatureLevel
	{
		get
		{
			GetMinFeatureLevel(out var levelRef);
			return levelRef;
		}
	}

	public ShaderRequiresFlags RequiresFlags => GetRequiresFlags();

	public unsafe ShaderReflection(byte[] shaderBytecode)
	{
		IntPtr reflectorOut;
		fixed (byte* ptr = shaderBytecode)
		{
			void* ptr2 = ptr;
			D3D.Reflect((IntPtr)ptr2, shaderBytecode.Length, Utilities.GetGuidFromType(GetType()), out reflectorOut);
		}
		base.NativePointer = reflectorOut;
	}

	public ShaderReflection(IntPtr nativePtr)
		: base(nativePtr)
	{
	}

	public static explicit operator ShaderReflection(IntPtr nativePtr)
	{
		if (!(nativePtr == IntPtr.Zero))
		{
			return new ShaderReflection(nativePtr);
		}
		return null;
	}

	internal unsafe void GetDescription(out ShaderDescription descRef)
	{
		ShaderDescription.__Native @ref = default(ShaderDescription.__Native);
		descRef = default(ShaderDescription);
		Result result = ((delegate* unmanaged[Stdcall]<void*, void*, int>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + (nint)3 * (nint)sizeof(void*))))(_nativePointer, &@ref);
		descRef.__MarshalFrom(ref @ref);
		result.CheckError();
	}

	public unsafe ConstantBuffer GetConstantBuffer(int index)
	{
		IntPtr zero = IntPtr.Zero;
		zero = ((delegate* unmanaged[Stdcall]<void*, int, IntPtr>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + (nint)4 * (nint)sizeof(void*))))(_nativePointer, index);
		if (zero != IntPtr.Zero)
		{
			return new ConstantBuffer(zero);
		}
		return null;
	}

	public unsafe ConstantBuffer GetConstantBuffer(string name)
	{
		IntPtr zero = IntPtr.Zero;
		IntPtr intPtr = Marshal.StringToHGlobalAnsi(name);
		zero = ((delegate* unmanaged[Stdcall]<void*, void*, IntPtr>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + (nint)5 * (nint)sizeof(void*))))(_nativePointer, (void*)intPtr);
		ConstantBuffer result = ((!(zero != IntPtr.Zero)) ? null : new ConstantBuffer(zero));
		Marshal.FreeHGlobal(intPtr);
		return result;
	}

	public unsafe InputBindingDescription GetResourceBindingDescription(int resourceIndex)
	{
		InputBindingDescription.__Native @ref = default(InputBindingDescription.__Native);
		InputBindingDescription result = default(InputBindingDescription);
		Result result2 = ((delegate* unmanaged[Stdcall]<void*, int, void*, int>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + (nint)6 * (nint)sizeof(void*))))(_nativePointer, resourceIndex, &@ref);
		result.__MarshalFrom(ref @ref);
		result2.CheckError();
		return result;
	}

	public unsafe ShaderParameterDescription GetInputParameterDescription(int parameterIndex)
	{
		ShaderParameterDescription.__Native @ref = default(ShaderParameterDescription.__Native);
		ShaderParameterDescription result = default(ShaderParameterDescription);
		Result result2 = ((delegate* unmanaged[Stdcall]<void*, int, void*, int>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + (nint)7 * (nint)sizeof(void*))))(_nativePointer, parameterIndex, &@ref);
		result.__MarshalFrom(ref @ref);
		result2.CheckError();
		return result;
	}

	public unsafe ShaderParameterDescription GetOutputParameterDescription(int parameterIndex)
	{
		ShaderParameterDescription.__Native @ref = default(ShaderParameterDescription.__Native);
		ShaderParameterDescription result = default(ShaderParameterDescription);
		Result result2 = ((delegate* unmanaged[Stdcall]<void*, int, void*, int>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + (nint)8 * (nint)sizeof(void*))))(_nativePointer, parameterIndex, &@ref);
		result.__MarshalFrom(ref @ref);
		result2.CheckError();
		return result;
	}

	public unsafe ShaderParameterDescription GetPatchConstantParameterDescription(int parameterIndex)
	{
		ShaderParameterDescription.__Native @ref = default(ShaderParameterDescription.__Native);
		ShaderParameterDescription result = default(ShaderParameterDescription);
		Result result2 = ((delegate* unmanaged[Stdcall]<void*, int, void*, int>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + (nint)9 * (nint)sizeof(void*))))(_nativePointer, parameterIndex, &@ref);
		result.__MarshalFrom(ref @ref);
		result2.CheckError();
		return result;
	}

	public unsafe ShaderReflectionVariable GetVariable(string name)
	{
		IntPtr zero = IntPtr.Zero;
		IntPtr intPtr = Marshal.StringToHGlobalAnsi(name);
		zero = ((delegate* unmanaged[Stdcall]<void*, void*, IntPtr>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + (nint)10 * (nint)sizeof(void*))))(_nativePointer, (void*)intPtr);
		ShaderReflectionVariable result = ((!(zero != IntPtr.Zero)) ? null : new ShaderReflectionVariable(zero));
		Marshal.FreeHGlobal(intPtr);
		return result;
	}

	public unsafe InputBindingDescription GetResourceBindingDescription(string name)
	{
		InputBindingDescription.__Native @ref = default(InputBindingDescription.__Native);
		InputBindingDescription result = default(InputBindingDescription);
		IntPtr intPtr = Marshal.StringToHGlobalAnsi(name);
		Result result2 = ((delegate* unmanaged[Stdcall]<void*, void*, void*, int>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + (nint)11 * (nint)sizeof(void*))))(_nativePointer, (void*)intPtr, &@ref);
		result.__MarshalFrom(ref @ref);
		Marshal.FreeHGlobal(intPtr);
		result2.CheckError();
		return result;
	}

	internal unsafe int GetMoveInstructionCount()
	{
		return ((delegate* unmanaged[Stdcall]<void*, int>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + (nint)12 * (nint)sizeof(void*))))(_nativePointer);
	}

	internal unsafe int GetConditionalMoveInstructionCount()
	{
		return ((delegate* unmanaged[Stdcall]<void*, int>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + (nint)13 * (nint)sizeof(void*))))(_nativePointer);
	}

	internal unsafe int GetConversionInstructionCount()
	{
		return ((delegate* unmanaged[Stdcall]<void*, int>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + (nint)14 * (nint)sizeof(void*))))(_nativePointer);
	}

	internal unsafe int GetBitwiseInstructionCount()
	{
		return ((delegate* unmanaged[Stdcall]<void*, int>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + (nint)15 * (nint)sizeof(void*))))(_nativePointer);
	}

	internal unsafe InputPrimitive GetGeometryShaderSInputPrimitive()
	{
		return ((delegate* unmanaged[Stdcall]<void*, InputPrimitive>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + (nint)16 * (nint)sizeof(void*))))(_nativePointer);
	}

	internal unsafe RawBool IsSampleFrequencyShader_()
	{
		return ((delegate* unmanaged[Stdcall]<void*, RawBool>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + (nint)17 * (nint)sizeof(void*))))(_nativePointer);
	}

	internal unsafe int GetInterfaceSlotCount()
	{
		return ((delegate* unmanaged[Stdcall]<void*, int>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + (nint)18 * (nint)sizeof(void*))))(_nativePointer);
	}

	internal unsafe void GetMinFeatureLevel(out FeatureLevel levelRef)
	{
		Result result;
		fixed (FeatureLevel* ptr = &levelRef)
		{
			void* ptr2 = ptr;
			result = ((delegate* unmanaged[Stdcall]<void*, void*, int>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + (nint)19 * (nint)sizeof(void*))))(_nativePointer, ptr2);
		}
		result.CheckError();
	}

	public unsafe int GetThreadGroupSize(out int sizeXRef, out int sizeYRef, out int sizeZRef)
	{
		int result;
		fixed (int* ptr = &sizeZRef)
		{
			void* ptr2 = ptr;
			fixed (int* ptr3 = &sizeYRef)
			{
				void* ptr4 = ptr3;
				fixed (int* ptr5 = &sizeXRef)
				{
					void* ptr6 = ptr5;
					result = ((delegate* unmanaged[Stdcall]<void*, void*, void*, void*, int>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + (nint)20 * (nint)sizeof(void*))))(_nativePointer, ptr6, ptr4, ptr2);
				}
			}
		}
		return result;
	}

	internal unsafe ShaderRequiresFlags GetRequiresFlags()
	{
		return ((delegate* unmanaged[Stdcall]<void*, ShaderRequiresFlags>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + (nint)21 * (nint)sizeof(void*))))(_nativePointer);
	}
}
