using System;
using System.Runtime.InteropServices;
using SharpDX.Direct3D;

namespace SharpDX.D3DCompiler;

[Guid("54133220-1CE8-43D3-8236-9855C5CEECFF")]
public class FunctionLinkingGraph : ComObject
{
	private const int ReturnParameterIndex = -1;

	public string LastErrorString => Utilities.BlobToString(LastError);

	public Blob LastError
	{
		get
		{
			GetLastError(out var errorBufferOut);
			return errorBufferOut;
		}
	}

	public FunctionLinkingGraph()
	{
		D3D.CreateFunctionLinkingGraph(0, this);
	}

	public LinkingNode SetInputSignature(params ParameterDescription[] parameters)
	{
		SetInputSignature(parameters, parameters.Length, out var inputNodeOut);
		return inputNodeOut;
	}

	public LinkingNode SetOutputSignature(params ParameterDescription[] parameters)
	{
		SetOutputSignature(parameters, parameters.Length, out var outputNodeOut);
		return outputNodeOut;
	}

	public ModuleInstance CreateModuleInstance()
	{
		ModuleInstance moduleInstanceOut;
		Blob errorBufferOut;
		Result result = CreateModuleInstance(out moduleInstanceOut, out errorBufferOut);
		if (result.Failure)
		{
			if (errorBufferOut != null)
			{
				throw new CompilationException(result, Utilities.BlobToString(errorBufferOut));
			}
			throw new SharpDXException(result);
		}
		return moduleInstanceOut;
	}

	public LinkingNode CallFunction(Module moduleWithFunctionPrototypeRef, string functionNameRef)
	{
		return CallFunction(string.Empty, moduleWithFunctionPrototypeRef, functionNameRef);
	}

	public void PassValue(LinkingNode sourceNode, LinkingNode destinationNode, int destinationParameterIndex)
	{
		PassValue(sourceNode, -1, destinationNode, destinationParameterIndex);
	}

	public string GenerateHlsl(int uFlags)
	{
		GenerateHlsl(0, out var bufferOut);
		string result = Utilities.BlobToString(bufferOut);
		bufferOut.Dispose();
		return result;
	}

	public FunctionLinkingGraph(IntPtr nativePtr)
		: base(nativePtr)
	{
	}

	public static explicit operator FunctionLinkingGraph(IntPtr nativePtr)
	{
		if (!(nativePtr == IntPtr.Zero))
		{
			return new FunctionLinkingGraph(nativePtr);
		}
		return null;
	}

	internal unsafe Result CreateModuleInstance(out ModuleInstance moduleInstanceOut, out Blob errorBufferOut)
	{
		IntPtr zero = IntPtr.Zero;
		IntPtr zero2 = IntPtr.Zero;
		Result result = ((delegate* unmanaged[Stdcall]<void*, void*, void*, int>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + (nint)3 * (nint)sizeof(void*))))(_nativePointer, &zero, &zero2);
		if (zero != IntPtr.Zero)
		{
			moduleInstanceOut = new ModuleInstance(zero);
		}
		else
		{
			moduleInstanceOut = null;
		}
		if (zero2 != IntPtr.Zero)
		{
			errorBufferOut = new Blob(zero2);
			return result;
		}
		errorBufferOut = null;
		return result;
	}

	internal unsafe void SetInputSignature(ParameterDescription[] inputParametersRef, int cInputParameters, out LinkingNode inputNodeOut)
	{
		ParameterDescription.__Native[] array = new ParameterDescription.__Native[inputParametersRef.Length];
		IntPtr zero = IntPtr.Zero;
		for (int i = 0; i < inputParametersRef.Length; i++)
		{
			inputParametersRef[i].__MarshalTo(ref array[i]);
		}
		Result result;
		fixed (ParameterDescription.__Native* ptr = array)
		{
			void* ptr2 = ptr;
			result = ((delegate* unmanaged[Stdcall]<void*, void*, int, void*, int>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + (nint)4 * (nint)sizeof(void*))))(_nativePointer, ptr2, cInputParameters, &zero);
		}
		if (zero != IntPtr.Zero)
		{
			inputNodeOut = new LinkingNode(zero);
		}
		else
		{
			inputNodeOut = null;
		}
		for (int j = 0; j < inputParametersRef.Length; j++)
		{
			inputParametersRef[j].__MarshalFree(ref array[j]);
		}
		result.CheckError();
	}

	public unsafe void SetOutputSignature(ParameterDescription[] outputParametersRef, int cOutputParameters, out LinkingNode outputNodeOut)
	{
		ParameterDescription.__Native[] array = new ParameterDescription.__Native[outputParametersRef.Length];
		IntPtr zero = IntPtr.Zero;
		for (int i = 0; i < outputParametersRef.Length; i++)
		{
			outputParametersRef[i].__MarshalTo(ref array[i]);
		}
		Result result;
		fixed (ParameterDescription.__Native* ptr = array)
		{
			void* ptr2 = ptr;
			result = ((delegate* unmanaged[Stdcall]<void*, void*, int, void*, int>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + (nint)5 * (nint)sizeof(void*))))(_nativePointer, ptr2, cOutputParameters, &zero);
		}
		if (zero != IntPtr.Zero)
		{
			outputNodeOut = new LinkingNode(zero);
		}
		else
		{
			outputNodeOut = null;
		}
		for (int j = 0; j < outputParametersRef.Length; j++)
		{
			outputParametersRef[j].__MarshalFree(ref array[j]);
		}
		result.CheckError();
	}

	public unsafe LinkingNode CallFunction(string moduleInstanceNamespaceRef, Module moduleWithFunctionPrototypeRef, string functionNameRef)
	{
		IntPtr zero = IntPtr.Zero;
		IntPtr zero2 = IntPtr.Zero;
		IntPtr intPtr = Marshal.StringToHGlobalAnsi(moduleInstanceNamespaceRef);
		zero = CppObject.ToCallbackPtr<Module>(moduleWithFunctionPrototypeRef);
		IntPtr intPtr2 = Marshal.StringToHGlobalAnsi(functionNameRef);
		Result result = ((delegate* unmanaged[Stdcall]<void*, void*, void*, void*, void*, int>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + (nint)6 * (nint)sizeof(void*))))(_nativePointer, (void*)intPtr, (void*)zero, (void*)intPtr2, &zero2);
		LinkingNode result2 = ((!(zero2 != IntPtr.Zero)) ? null : new LinkingNode(zero2));
		Marshal.FreeHGlobal(intPtr);
		Marshal.FreeHGlobal(intPtr2);
		result.CheckError();
		return result2;
	}

	public unsafe void PassValue(LinkingNode srcNodeRef, int srcParameterIndex, LinkingNode dstNodeRef, int dstParameterIndex)
	{
		IntPtr zero = IntPtr.Zero;
		IntPtr zero2 = IntPtr.Zero;
		zero = CppObject.ToCallbackPtr<LinkingNode>(srcNodeRef);
		zero2 = CppObject.ToCallbackPtr<LinkingNode>(dstNodeRef);
		((Result)((delegate* unmanaged[Stdcall]<void*, void*, int, void*, int, int>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + (nint)7 * (nint)sizeof(void*))))(_nativePointer, (void*)zero, srcParameterIndex, (void*)zero2, dstParameterIndex)).CheckError();
	}

	public unsafe void PassValueWithSwizzle(LinkingNode srcNodeRef, int srcParameterIndex, string srcSwizzleRef, LinkingNode dstNodeRef, int dstParameterIndex, string dstSwizzleRef)
	{
		IntPtr zero = IntPtr.Zero;
		IntPtr zero2 = IntPtr.Zero;
		zero = CppObject.ToCallbackPtr<LinkingNode>(srcNodeRef);
		IntPtr intPtr = Marshal.StringToHGlobalAnsi(srcSwizzleRef);
		zero2 = CppObject.ToCallbackPtr<LinkingNode>(dstNodeRef);
		IntPtr intPtr2 = Marshal.StringToHGlobalAnsi(dstSwizzleRef);
		Result result = ((delegate* unmanaged[Stdcall]<void*, void*, int, void*, void*, int, void*, int>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + (nint)8 * (nint)sizeof(void*))))(_nativePointer, (void*)zero, srcParameterIndex, (void*)intPtr, (void*)zero2, dstParameterIndex, (void*)intPtr2);
		Marshal.FreeHGlobal(intPtr);
		Marshal.FreeHGlobal(intPtr2);
		result.CheckError();
	}

	internal unsafe void GetLastError(out Blob errorBufferOut)
	{
		IntPtr zero = IntPtr.Zero;
		Result result = ((delegate* unmanaged[Stdcall]<void*, void*, int>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + (nint)9 * (nint)sizeof(void*))))(_nativePointer, &zero);
		if (zero != IntPtr.Zero)
		{
			errorBufferOut = new Blob(zero);
		}
		else
		{
			errorBufferOut = null;
		}
		result.CheckError();
	}

	public unsafe void GenerateHlsl(int uFlags, out Blob bufferOut)
	{
		IntPtr zero = IntPtr.Zero;
		Result result = ((delegate* unmanaged[Stdcall]<void*, int, void*, int>)(*(IntPtr*)((nint)(*(IntPtr*)_nativePointer) + (nint)10 * (nint)sizeof(void*))))(_nativePointer, uFlags, &zero);
		if (zero != IntPtr.Zero)
		{
			bufferOut = new Blob(zero);
		}
		else
		{
			bufferOut = null;
		}
		result.CheckError();
	}
}
