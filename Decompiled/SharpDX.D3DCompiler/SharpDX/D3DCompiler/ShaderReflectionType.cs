using System;
using System.Runtime.InteropServices;

namespace SharpDX.D3DCompiler;

[Guid("6E6FFA6A-9BAE-4613-A51E-91652D508C21")]
public class ShaderReflectionType : CppObject
{
	public ShaderTypeDescription Description
	{
		get
		{
			GetDescription(out var descRef);
			return descRef;
		}
	}

	public ShaderReflectionType SubType => GetSubType();

	public ShaderReflectionType BaseClass => GetBaseClass();

	public int NumInterfaces => GetNumInterfaces();

	public bool IsEqual(ShaderReflectionType typeRef)
	{
		return IsEqual_(typeRef) == Result.Ok;
	}

	public bool IsOfType(ShaderReflectionType typeRef)
	{
		return IsOfType_(typeRef) == Result.Ok;
	}

	public bool ImplementsInterface(ShaderReflectionType baseRef)
	{
		return ImplementsInterface_(baseRef) == Result.Ok;
	}

	public ShaderReflectionType(IntPtr nativePtr)
		: base(nativePtr)
	{
	}

	public static explicit operator ShaderReflectionType(IntPtr nativePtr)
	{
		if (!(nativePtr == IntPtr.Zero))
		{
			return new ShaderReflectionType(nativePtr);
		}
		return null;
	}

	internal unsafe void GetDescription(out ShaderTypeDescription descRef)
	{
		ShaderTypeDescription.__Native @ref = default(ShaderTypeDescription.__Native);
		descRef = default(ShaderTypeDescription);
		Result result = ((delegate* unmanaged[Stdcall]<void*, void*, int>)(*(*(IntPtr**)_nativePointer)))(_nativePointer, &@ref);
		descRef.__MarshalFrom(ref @ref);
		result.CheckError();
	}

	public unsafe ShaderReflectionType GetMemberType(int index)
	{
		IntPtr zero = IntPtr.Zero;
		zero = ((delegate* unmanaged[Stdcall]<void*, int, IntPtr>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + sizeof(void*))))(_nativePointer, index);
		if (zero != IntPtr.Zero)
		{
			return new ShaderReflectionType(zero);
		}
		return null;
	}

	public unsafe ShaderReflectionType GetMemberType(string name)
	{
		IntPtr zero = IntPtr.Zero;
		IntPtr intPtr = Marshal.StringToHGlobalAnsi(name);
		zero = ((delegate* unmanaged[Stdcall]<void*, void*, IntPtr>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + (nint)2 * (nint)sizeof(void*))))(_nativePointer, (void*)intPtr);
		ShaderReflectionType result = ((!(zero != IntPtr.Zero)) ? null : new ShaderReflectionType(zero));
		Marshal.FreeHGlobal(intPtr);
		return result;
	}

	public unsafe string GetMemberTypeName(int index)
	{
		return Marshal.PtrToStringAnsi(((delegate* unmanaged[Stdcall]<void*, int, IntPtr>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + (nint)3 * (nint)sizeof(void*))))(_nativePointer, index));
	}

	internal unsafe Result IsEqual_(ShaderReflectionType typeRef)
	{
		IntPtr zero = IntPtr.Zero;
		zero = CppObject.ToCallbackPtr<ShaderReflectionType>(typeRef);
		return ((delegate* unmanaged[Stdcall]<void*, void*, int>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + (nint)4 * (nint)sizeof(void*))))(_nativePointer, (void*)zero);
	}

	internal unsafe ShaderReflectionType GetSubType()
	{
		IntPtr zero = IntPtr.Zero;
		zero = ((delegate* unmanaged[Stdcall]<void*, IntPtr>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + (nint)5 * (nint)sizeof(void*))))(_nativePointer);
		if (zero != IntPtr.Zero)
		{
			return new ShaderReflectionType(zero);
		}
		return null;
	}

	internal unsafe ShaderReflectionType GetBaseClass()
	{
		IntPtr zero = IntPtr.Zero;
		zero = ((delegate* unmanaged[Stdcall]<void*, IntPtr>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + (nint)6 * (nint)sizeof(void*))))(_nativePointer);
		if (zero != IntPtr.Zero)
		{
			return new ShaderReflectionType(zero);
		}
		return null;
	}

	internal unsafe int GetNumInterfaces()
	{
		return ((delegate* unmanaged[Stdcall]<void*, int>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + (nint)7 * (nint)sizeof(void*))))(_nativePointer);
	}

	public unsafe ShaderReflectionType GetInterface(int uIndex)
	{
		IntPtr zero = IntPtr.Zero;
		zero = ((delegate* unmanaged[Stdcall]<void*, int, IntPtr>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + (nint)8 * (nint)sizeof(void*))))(_nativePointer, uIndex);
		if (zero != IntPtr.Zero)
		{
			return new ShaderReflectionType(zero);
		}
		return null;
	}

	internal unsafe Result IsOfType_(ShaderReflectionType typeRef)
	{
		IntPtr zero = IntPtr.Zero;
		zero = CppObject.ToCallbackPtr<ShaderReflectionType>(typeRef);
		return ((delegate* unmanaged[Stdcall]<void*, void*, int>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + (nint)9 * (nint)sizeof(void*))))(_nativePointer, (void*)zero);
	}

	internal unsafe Result ImplementsInterface_(ShaderReflectionType baseRef)
	{
		IntPtr zero = IntPtr.Zero;
		zero = CppObject.ToCallbackPtr<ShaderReflectionType>(baseRef);
		return ((delegate* unmanaged[Stdcall]<void*, void*, int>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + (nint)10 * (nint)sizeof(void*))))(_nativePointer, (void*)zero);
	}
}
