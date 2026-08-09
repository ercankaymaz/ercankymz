using System;
using System.Runtime.InteropServices;
using SharpDX.Direct3D;

namespace SharpDX.D3DCompiler;

[Guid("59A6CD0E-E10D-4C1F-88C0-63ABA1DAF30E")]
public class Linker : ComObject
{
	public Linker()
	{
		D3D.CreateLinker(this);
	}

	public ShaderBytecode Link(ModuleInstance module, string entryPointName, string targetName, int flags)
	{
		Blob shaderBlobOut;
		Blob errorBufferOut;
		Result result = Link(module, entryPointName, targetName, flags, out shaderBlobOut, out errorBufferOut);
		if (result.Failure)
		{
			if (errorBufferOut != null)
			{
				throw new CompilationException(result, Utilities.BlobToString(errorBufferOut));
			}
			throw new SharpDXException(result);
		}
		return new ShaderBytecode(shaderBlobOut);
	}

	public Linker(IntPtr nativePtr)
		: base(nativePtr)
	{
	}

	public static explicit operator Linker(IntPtr nativePtr)
	{
		if (!(nativePtr == IntPtr.Zero))
		{
			return new Linker(nativePtr);
		}
		return null;
	}

	internal unsafe Result Link(ModuleInstance entryRef, string entryNameRef, string targetNameRef, int uFlags, out Blob shaderBlobOut, out Blob errorBufferOut)
	{
		IntPtr zero = IntPtr.Zero;
		IntPtr zero2 = IntPtr.Zero;
		IntPtr zero3 = IntPtr.Zero;
		zero = CppObject.ToCallbackPtr<ModuleInstance>(entryRef);
		IntPtr intPtr = Marshal.StringToHGlobalAnsi(entryNameRef);
		IntPtr intPtr2 = Marshal.StringToHGlobalAnsi(targetNameRef);
		Result result = ((delegate* unmanaged[Stdcall]<void*, void*, void*, void*, int, void*, void*, int>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + (nint)3 * (nint)sizeof(void*))))(_nativePointer, (void*)zero, (void*)intPtr, (void*)intPtr2, uFlags, &zero2, &zero3);
		if (zero2 != IntPtr.Zero)
		{
			shaderBlobOut = new Blob(zero2);
		}
		else
		{
			shaderBlobOut = null;
		}
		if (zero3 != IntPtr.Zero)
		{
			errorBufferOut = new Blob(zero3);
		}
		else
		{
			errorBufferOut = null;
		}
		Marshal.FreeHGlobal(intPtr);
		Marshal.FreeHGlobal(intPtr2);
		return result;
	}

	public unsafe void UseLibrary(ModuleInstance libraryMIRef)
	{
		IntPtr zero = IntPtr.Zero;
		zero = CppObject.ToCallbackPtr<ModuleInstance>(libraryMIRef);
		((Result)((delegate* unmanaged[Stdcall]<void*, void*, int>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + (nint)4 * (nint)sizeof(void*))))(_nativePointer, (void*)zero)).CheckError();
	}

	public unsafe void AddClipPlaneFromCBuffer(int uCBufferSlot, int uCBufferEntry)
	{
		((Result)((delegate* unmanaged[Stdcall]<void*, int, int, int>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + (nint)5 * (nint)sizeof(void*))))(_nativePointer, uCBufferSlot, uCBufferEntry)).CheckError();
	}
}
