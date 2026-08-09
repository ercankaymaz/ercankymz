using System;
using System.Runtime.InteropServices;

namespace SharpDX.D3DCompiler;

[Guid("54384F1B-5B3E-4BB7-AE01-60BA3097CBB6")]
public class LibraryReflection : ComObject
{
	public FunctionReflection[] Functions
	{
		get
		{
			FunctionReflection[] array = new FunctionReflection[Description.FunctionCount];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = GetFunctionByIndex(i);
			}
			return array;
		}
	}

	public LibraryDescription Description
	{
		get
		{
			GetDescription(out var descRef);
			return descRef;
		}
	}

	public unsafe LibraryReflection(byte[] libraryBytecode)
	{
		IntPtr reflectorOut;
		fixed (byte* ptr = libraryBytecode)
		{
			void* ptr2 = ptr;
			D3D.ReflectLibrary((IntPtr)ptr2, libraryBytecode.Length, Utilities.GetGuidFromType(GetType()), out reflectorOut);
		}
		base.NativePointer = reflectorOut;
	}

	public LibraryReflection(IntPtr nativePtr)
		: base(nativePtr)
	{
	}

	public static explicit operator LibraryReflection(IntPtr nativePtr)
	{
		if (!(nativePtr == IntPtr.Zero))
		{
			return new LibraryReflection(nativePtr);
		}
		return null;
	}

	internal unsafe void GetDescription(out LibraryDescription descRef)
	{
		LibraryDescription.__Native @ref = default(LibraryDescription.__Native);
		descRef = default(LibraryDescription);
		Result result = ((delegate* unmanaged[Stdcall]<void*, void*, int>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + (nint)3 * (nint)sizeof(void*))))(_nativePointer, &@ref);
		descRef.__MarshalFrom(ref @ref);
		result.CheckError();
	}

	public unsafe FunctionReflection GetFunctionByIndex(int functionIndex)
	{
		IntPtr zero = IntPtr.Zero;
		zero = ((delegate* unmanaged[Stdcall]<void*, int, IntPtr>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + (nint)4 * (nint)sizeof(void*))))(_nativePointer, functionIndex);
		if (zero != IntPtr.Zero)
		{
			return new FunctionReflection(zero);
		}
		return null;
	}
}
