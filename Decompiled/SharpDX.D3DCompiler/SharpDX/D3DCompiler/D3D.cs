using System;
using System.Runtime.InteropServices;
using SharpDX.Direct3D;
using SharpDX.Mathematics.Interop;

namespace SharpDX.D3DCompiler;

internal static class D3D
{
	public unsafe static void ReadFileToBlob(string fileNameRef, out Blob contentsOut)
	{
		IntPtr zero = IntPtr.Zero;
		Result result;
		fixed (char* param = fileNameRef)
		{
			result = D3DReadFileToBlob_(param, &zero);
		}
		if (zero != IntPtr.Zero)
		{
			contentsOut = new Blob(zero);
		}
		else
		{
			contentsOut = null;
		}
		result.CheckError();
	}

	[DllImport("d3dcompiler_47.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DReadFileToBlob")]
	private unsafe static extern int D3DReadFileToBlob_(void* param0, void* param1);

	public unsafe static void WriteBlobToFile(Blob blobRef, string fileNameRef, RawBool bOverwrite)
	{
		_ = IntPtr.Zero;
		IntPtr intPtr = CppObject.ToCallbackPtr<Blob>(blobRef);
		Result result;
		fixed (char* param = fileNameRef)
		{
			result = D3DWriteBlobToFile_((void*)intPtr, param, bOverwrite);
		}
		result.CheckError();
	}

	[DllImport("d3dcompiler_47.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DWriteBlobToFile")]
	private unsafe static extern int D3DWriteBlobToFile_(void* param0, void* param1, RawBool param2);

	public unsafe static Result Compile(IntPtr srcDataRef, PointerSize srcDataSize, string sourceNameRef, ShaderMacro[] definesRef, Include includeRef, string entrypointRef, string targetRef, ShaderFlags flags1, EffectFlags flags2, out Blob codeOut, out Blob errorMsgsOut)
	{
		ShaderMacro.__Native[] array = ((definesRef == null) ? null : new ShaderMacro.__Native[definesRef.Length]);
		IntPtr zero = IntPtr.Zero;
		IntPtr zero2 = IntPtr.Zero;
		IntPtr zero3 = IntPtr.Zero;
		IntPtr intPtr = Marshal.StringToHGlobalAnsi(sourceNameRef);
		if (definesRef != null)
		{
			for (int i = 0; i < definesRef.Length; i++)
			{
				definesRef?[i].__MarshalTo(ref array[i]);
			}
		}
		zero = CppObject.ToCallbackPtr<Include>(includeRef);
		IntPtr intPtr2 = Marshal.StringToHGlobalAnsi(entrypointRef);
		IntPtr intPtr3 = Marshal.StringToHGlobalAnsi(targetRef);
		Result result;
		fixed (ShaderMacro.__Native* ptr = array)
		{
			void* param = ptr;
			result = D3DCompile_((void*)srcDataRef, srcDataSize, (void*)intPtr, param, (void*)zero, (void*)intPtr2, (void*)intPtr3, (int)flags1, (int)flags2, &zero2, &zero3);
		}
		if (zero2 != IntPtr.Zero)
		{
			codeOut = new Blob(zero2);
		}
		else
		{
			codeOut = null;
		}
		if (zero3 != IntPtr.Zero)
		{
			errorMsgsOut = new Blob(zero3);
		}
		else
		{
			errorMsgsOut = null;
		}
		Marshal.FreeHGlobal(intPtr);
		if (definesRef != null)
		{
			for (int j = 0; j < definesRef.Length; j++)
			{
				definesRef?[j].__MarshalFree(ref array[j]);
			}
		}
		Marshal.FreeHGlobal(intPtr2);
		Marshal.FreeHGlobal(intPtr3);
		return result;
	}

	[DllImport("d3dcompiler_47.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DCompile")]
	private unsafe static extern int D3DCompile_(void* param0, void* param1, void* param2, void* param3, void* param4, void* param5, void* param6, int param7, int param8, void* param9, void* param10);

	public unsafe static Result Compile2(IntPtr srcDataRef, PointerSize srcDataSize, string sourceNameRef, ShaderMacro[] definesRef, Include includeRef, string entrypointRef, string targetRef, ShaderFlags flags1, EffectFlags flags2, SecondaryDataFlags secondaryDataFlags, IntPtr secondaryDataRef, PointerSize secondaryDataSize, out Blob codeOut, out Blob errorMsgsOut)
	{
		ShaderMacro.__Native[] array = ((definesRef == null) ? null : new ShaderMacro.__Native[definesRef.Length]);
		IntPtr zero = IntPtr.Zero;
		IntPtr zero2 = IntPtr.Zero;
		IntPtr zero3 = IntPtr.Zero;
		IntPtr intPtr = Marshal.StringToHGlobalAnsi(sourceNameRef);
		if (definesRef != null)
		{
			for (int i = 0; i < definesRef.Length; i++)
			{
				definesRef?[i].__MarshalTo(ref array[i]);
			}
		}
		zero = CppObject.ToCallbackPtr<Include>(includeRef);
		IntPtr intPtr2 = Marshal.StringToHGlobalAnsi(entrypointRef);
		IntPtr intPtr3 = Marshal.StringToHGlobalAnsi(targetRef);
		Result result;
		fixed (ShaderMacro.__Native* ptr = array)
		{
			void* param = ptr;
			result = D3DCompile2_((void*)srcDataRef, srcDataSize, (void*)intPtr, param, (void*)zero, (void*)intPtr2, (void*)intPtr3, (int)flags1, (int)flags2, (int)secondaryDataFlags, (void*)secondaryDataRef, secondaryDataSize, &zero2, &zero3);
		}
		if (zero2 != IntPtr.Zero)
		{
			codeOut = new Blob(zero2);
		}
		else
		{
			codeOut = null;
		}
		if (zero3 != IntPtr.Zero)
		{
			errorMsgsOut = new Blob(zero3);
		}
		else
		{
			errorMsgsOut = null;
		}
		Marshal.FreeHGlobal(intPtr);
		if (definesRef != null)
		{
			for (int j = 0; j < definesRef.Length; j++)
			{
				definesRef?[j].__MarshalFree(ref array[j]);
			}
		}
		Marshal.FreeHGlobal(intPtr2);
		Marshal.FreeHGlobal(intPtr3);
		return result;
	}

	[DllImport("d3dcompiler_47.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DCompile2")]
	private unsafe static extern int D3DCompile2_(void* param0, void* param1, void* param2, void* param3, void* param4, void* param5, void* param6, int param7, int param8, int param9, void* param10, void* param11, void* param12, void* param13);

	public unsafe static Result CompileFromFile(string fileNameRef, ShaderMacro[] definesRef, Include includeRef, string entrypointRef, string targetRef, ShaderFlags flags1, EffectFlags flags2, out Blob codeOut, out Blob errorMsgsOut)
	{
		ShaderMacro.__Native[] array = ((definesRef == null) ? null : new ShaderMacro.__Native[definesRef.Length]);
		IntPtr zero = IntPtr.Zero;
		IntPtr zero2 = IntPtr.Zero;
		IntPtr zero3 = IntPtr.Zero;
		if (definesRef != null)
		{
			for (int i = 0; i < definesRef.Length; i++)
			{
				definesRef?[i].__MarshalTo(ref array[i]);
			}
		}
		zero = CppObject.ToCallbackPtr<Include>(includeRef);
		IntPtr intPtr = Marshal.StringToHGlobalAnsi(entrypointRef);
		IntPtr intPtr2 = Marshal.StringToHGlobalAnsi(targetRef);
		Result result;
		fixed (ShaderMacro.__Native* ptr = array)
		{
			void* param = ptr;
			fixed (char* param2 = fileNameRef)
			{
				result = D3DCompileFromFile_(param2, param, (void*)zero, (void*)intPtr, (void*)intPtr2, (int)flags1, (int)flags2, &zero2, &zero3);
			}
		}
		if (zero2 != IntPtr.Zero)
		{
			codeOut = new Blob(zero2);
		}
		else
		{
			codeOut = null;
		}
		if (zero3 != IntPtr.Zero)
		{
			errorMsgsOut = new Blob(zero3);
		}
		else
		{
			errorMsgsOut = null;
		}
		if (definesRef != null)
		{
			for (int j = 0; j < definesRef.Length; j++)
			{
				definesRef?[j].__MarshalFree(ref array[j]);
			}
		}
		Marshal.FreeHGlobal(intPtr);
		Marshal.FreeHGlobal(intPtr2);
		return result;
	}

	[DllImport("d3dcompiler_47.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DCompileFromFile")]
	private unsafe static extern int D3DCompileFromFile_(void* param0, void* param1, void* param2, void* param3, void* param4, int param5, int param6, void* param7, void* param8);

	public unsafe static void Preprocess(IntPtr srcDataRef, PointerSize srcDataSize, string sourceNameRef, ShaderMacro[] definesRef, Include includeRef, out Blob codeTextOut, out Blob errorMsgsOut)
	{
		ShaderMacro.__Native[] array = ((definesRef == null) ? null : new ShaderMacro.__Native[definesRef.Length]);
		IntPtr zero = IntPtr.Zero;
		IntPtr zero2 = IntPtr.Zero;
		IntPtr zero3 = IntPtr.Zero;
		IntPtr intPtr = Marshal.StringToHGlobalAnsi(sourceNameRef);
		if (definesRef != null)
		{
			for (int i = 0; i < definesRef.Length; i++)
			{
				definesRef?[i].__MarshalTo(ref array[i]);
			}
		}
		zero = CppObject.ToCallbackPtr<Include>(includeRef);
		Result result;
		fixed (ShaderMacro.__Native* ptr = array)
		{
			void* param = ptr;
			result = D3DPreprocess_((void*)srcDataRef, srcDataSize, (void*)intPtr, param, (void*)zero, &zero2, &zero3);
		}
		if (zero2 != IntPtr.Zero)
		{
			codeTextOut = new Blob(zero2);
		}
		else
		{
			codeTextOut = null;
		}
		if (zero3 != IntPtr.Zero)
		{
			errorMsgsOut = new Blob(zero3);
		}
		else
		{
			errorMsgsOut = null;
		}
		Marshal.FreeHGlobal(intPtr);
		if (definesRef != null)
		{
			for (int j = 0; j < definesRef.Length; j++)
			{
				definesRef?[j].__MarshalFree(ref array[j]);
			}
		}
		result.CheckError();
	}

	[DllImport("d3dcompiler_47.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DPreprocess")]
	private unsafe static extern int D3DPreprocess_(void* param0, void* param1, void* param2, void* param3, void* param4, void* param5, void* param6);

	public unsafe static void GetDebugInfo(IntPtr srcDataRef, PointerSize srcDataSize, out Blob debugInfoOut)
	{
		IntPtr zero = IntPtr.Zero;
		Result result = D3DGetDebugInfo_((void*)srcDataRef, srcDataSize, &zero);
		if (zero != IntPtr.Zero)
		{
			debugInfoOut = new Blob(zero);
		}
		else
		{
			debugInfoOut = null;
		}
		result.CheckError();
	}

	[DllImport("d3dcompiler_47.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DGetDebugInfo")]
	private unsafe static extern int D3DGetDebugInfo_(void* param0, void* param1, void* param2);

	public unsafe static void Reflect(IntPtr srcDataRef, PointerSize srcDataSize, Guid interfaceRef, out IntPtr reflectorOut)
	{
		Result result;
		fixed (IntPtr* ptr = &reflectorOut)
		{
			void* param = ptr;
			result = D3DReflect_((void*)srcDataRef, srcDataSize, &interfaceRef, param);
		}
		result.CheckError();
	}

	[DllImport("d3dcompiler_47.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DReflect")]
	private unsafe static extern int D3DReflect_(void* param0, void* param1, void* param2, void* param3);

	public unsafe static void ReflectLibrary(IntPtr srcDataRef, PointerSize srcDataSize, Guid riid, out IntPtr reflectorOut)
	{
		Result result;
		fixed (IntPtr* ptr = &reflectorOut)
		{
			void* param = ptr;
			result = D3DReflectLibrary_((void*)srcDataRef, srcDataSize, &riid, param);
		}
		result.CheckError();
	}

	[DllImport("d3dcompiler_47.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DReflectLibrary")]
	private unsafe static extern int D3DReflectLibrary_(void* param0, void* param1, void* param2, void* param3);

	public unsafe static void Disassemble(IntPtr srcDataRef, PointerSize srcDataSize, DisassemblyFlags flags, string szComments, out Blob disassemblyOut)
	{
		IntPtr zero = IntPtr.Zero;
		IntPtr intPtr = Marshal.StringToHGlobalAnsi(szComments);
		Result result = D3DDisassemble_((void*)srcDataRef, srcDataSize, (int)flags, (void*)intPtr, &zero);
		if (zero != IntPtr.Zero)
		{
			disassemblyOut = new Blob(zero);
		}
		else
		{
			disassemblyOut = null;
		}
		Marshal.FreeHGlobal(intPtr);
		result.CheckError();
	}

	[DllImport("d3dcompiler_47.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DDisassemble")]
	private unsafe static extern int D3DDisassemble_(void* param0, void* param1, int param2, void* param3, void* param4);

	public unsafe static void DisassembleRegion(IntPtr srcDataRef, PointerSize srcDataSize, int flags, string szComments, PointerSize startByteOffset, PointerSize numInsts, out PointerSize finishByteOffsetRef, out Blob disassemblyOut)
	{
		finishByteOffsetRef = default(PointerSize);
		IntPtr zero = IntPtr.Zero;
		IntPtr intPtr = Marshal.StringToHGlobalAnsi(szComments);
		Result result;
		fixed (PointerSize* ptr = &finishByteOffsetRef)
		{
			void* param = ptr;
			result = D3DDisassembleRegion_((void*)srcDataRef, srcDataSize, flags, (void*)intPtr, startByteOffset, numInsts, param, &zero);
		}
		if (zero != IntPtr.Zero)
		{
			disassemblyOut = new Blob(zero);
		}
		else
		{
			disassemblyOut = null;
		}
		Marshal.FreeHGlobal(intPtr);
		result.CheckError();
	}

	[DllImport("d3dcompiler_47.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DDisassembleRegion")]
	private unsafe static extern int D3DDisassembleRegion_(void* param0, void* param1, int param2, void* param3, void* param4, void* param5, void* param6, void* param7);

	public unsafe static void CreateLinker(Linker linkerOut)
	{
		IntPtr zero = IntPtr.Zero;
		Result result = D3DCreateLinker_(&zero);
		linkerOut.NativePointer = zero;
		result.CheckError();
	}

	[DllImport("d3dcompiler_47.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DCreateLinker")]
	private unsafe static extern int D3DCreateLinker_(void* param0);

	public unsafe static Result LoadModule(IntPtr srcDataRef, PointerSize cbSrcDataSize, Module moduleOut)
	{
		IntPtr zero = IntPtr.Zero;
		Result result = D3DLoadModule_((void*)srcDataRef, cbSrcDataSize, &zero);
		moduleOut.NativePointer = zero;
		return result;
	}

	[DllImport("d3dcompiler_47.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DLoadModule")]
	private unsafe static extern int D3DLoadModule_(void* param0, void* param1, void* param2);

	public unsafe static void CreateFunctionLinkingGraph(int uFlags, FunctionLinkingGraph functionLinkingGraphOut)
	{
		IntPtr zero = IntPtr.Zero;
		Result result = D3DCreateFunctionLinkingGraph_(uFlags, &zero);
		functionLinkingGraphOut.NativePointer = zero;
		result.CheckError();
	}

	[DllImport("d3dcompiler_47.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DCreateFunctionLinkingGraph")]
	private unsafe static extern int D3DCreateFunctionLinkingGraph_(int param0, void* param1);

	public unsafe static PointerSize GetTraceInstructionOffsets(IntPtr srcDataRef, PointerSize srcDataSize, int flags, PointerSize startInstIndex, PointerSize numInsts, out PointerSize totalInstsRef)
	{
		totalInstsRef = default(PointerSize);
		Result result;
		PointerSize result2 = default(PointerSize);
		fixed (PointerSize* ptr = &totalInstsRef)
		{
			void* param = ptr;
			result = D3DGetTraceInstructionOffsets_((void*)srcDataRef, srcDataSize, flags, startInstIndex, numInsts, &result2, param);
		}
		result.CheckError();
		return result2;
	}

	[DllImport("d3dcompiler_47.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DGetTraceInstructionOffsets")]
	private unsafe static extern int D3DGetTraceInstructionOffsets_(void* param0, void* param1, int param2, void* param3, void* param4, void* param5, void* param6);

	public unsafe static Result GetInputSignatureBlob(IntPtr srcDataRef, PointerSize srcDataSize, out Blob signatureBlobOut)
	{
		IntPtr zero = IntPtr.Zero;
		Result result = D3DGetInputSignatureBlob_((void*)srcDataRef, srcDataSize, &zero);
		if (zero != IntPtr.Zero)
		{
			signatureBlobOut = new Blob(zero);
			return result;
		}
		signatureBlobOut = null;
		return result;
	}

	[DllImport("d3dcompiler_47.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DGetInputSignatureBlob")]
	private unsafe static extern int D3DGetInputSignatureBlob_(void* param0, void* param1, void* param2);

	public unsafe static Result GetOutputSignatureBlob(IntPtr srcDataRef, PointerSize srcDataSize, out Blob signatureBlobOut)
	{
		IntPtr zero = IntPtr.Zero;
		Result result = D3DGetOutputSignatureBlob_((void*)srcDataRef, srcDataSize, &zero);
		if (zero != IntPtr.Zero)
		{
			signatureBlobOut = new Blob(zero);
			return result;
		}
		signatureBlobOut = null;
		return result;
	}

	[DllImport("d3dcompiler_47.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DGetOutputSignatureBlob")]
	private unsafe static extern int D3DGetOutputSignatureBlob_(void* param0, void* param1, void* param2);

	public unsafe static Result GetInputAndOutputSignatureBlob(IntPtr srcDataRef, PointerSize srcDataSize, out Blob signatureBlobOut)
	{
		IntPtr zero = IntPtr.Zero;
		Result result = D3DGetInputAndOutputSignatureBlob_((void*)srcDataRef, srcDataSize, &zero);
		if (zero != IntPtr.Zero)
		{
			signatureBlobOut = new Blob(zero);
			return result;
		}
		signatureBlobOut = null;
		return result;
	}

	[DllImport("d3dcompiler_47.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DGetInputAndOutputSignatureBlob")]
	private unsafe static extern int D3DGetInputAndOutputSignatureBlob_(void* param0, void* param1, void* param2);

	public unsafe static Result StripShader(IntPtr shaderBytecodeRef, PointerSize bytecodeLength, StripFlags uStripFlags, out Blob strippedBlobOut)
	{
		IntPtr zero = IntPtr.Zero;
		Result result = D3DStripShader_((void*)shaderBytecodeRef, bytecodeLength, (int)uStripFlags, &zero);
		if (zero != IntPtr.Zero)
		{
			strippedBlobOut = new Blob(zero);
			return result;
		}
		strippedBlobOut = null;
		return result;
	}

	[DllImport("d3dcompiler_47.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DStripShader")]
	private unsafe static extern int D3DStripShader_(void* param0, void* param1, int param2, void* param3);

	public unsafe static void GetBlobPart(IntPtr srcDataRef, PointerSize srcDataSize, ShaderBytecodePart part, int flags, out Blob partOut)
	{
		IntPtr zero = IntPtr.Zero;
		Result result = D3DGetBlobPart_((void*)srcDataRef, srcDataSize, (int)part, flags, &zero);
		if (zero != IntPtr.Zero)
		{
			partOut = new Blob(zero);
		}
		else
		{
			partOut = null;
		}
		result.CheckError();
	}

	[DllImport("d3dcompiler_47.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DGetBlobPart")]
	private unsafe static extern int D3DGetBlobPart_(void* param0, void* param1, int param2, int param3, void* param4);

	public unsafe static void SetBlobPart(IntPtr srcDataRef, PointerSize srcDataSize, ShaderBytecodePart part, int flags, IntPtr partRef, PointerSize partSize, out Blob newShaderOut)
	{
		IntPtr zero = IntPtr.Zero;
		Result result = D3DSetBlobPart_((void*)srcDataRef, srcDataSize, (int)part, flags, (void*)partRef, partSize, &zero);
		if (zero != IntPtr.Zero)
		{
			newShaderOut = new Blob(zero);
		}
		else
		{
			newShaderOut = null;
		}
		result.CheckError();
	}

	[DllImport("d3dcompiler_47.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DSetBlobPart")]
	private unsafe static extern int D3DSetBlobPart_(void* param0, void* param1, int param2, int param3, void* param4, void* param5, void* param6);

	public unsafe static void CreateBlob(PointerSize size, out Blob blobOut)
	{
		IntPtr zero = IntPtr.Zero;
		Result result = D3DCreateBlob_(size, &zero);
		if (zero != IntPtr.Zero)
		{
			blobOut = new Blob(zero);
		}
		else
		{
			blobOut = null;
		}
		result.CheckError();
	}

	[DllImport("d3dcompiler_47.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DCreateBlob")]
	private unsafe static extern int D3DCreateBlob_(void* param0, void* param1);

	public unsafe static void CompressShaders(int uNumShaders, ShaderData[] shaderDataRef, int uFlags, out Blob compressedDataOut)
	{
		ShaderData.__Native[] array = new ShaderData.__Native[shaderDataRef.Length];
		IntPtr zero = IntPtr.Zero;
		for (int i = 0; i < shaderDataRef.Length; i++)
		{
			shaderDataRef[i].__MarshalTo(ref array[i]);
		}
		Result result;
		fixed (ShaderData.__Native* ptr = array)
		{
			void* param = ptr;
			result = D3DCompressShaders_(uNumShaders, param, uFlags, &zero);
		}
		if (zero != IntPtr.Zero)
		{
			compressedDataOut = new Blob(zero);
		}
		else
		{
			compressedDataOut = null;
		}
		for (int j = 0; j < shaderDataRef.Length; j++)
		{
			shaderDataRef[j].__MarshalFree(ref array[j]);
		}
		result.CheckError();
	}

	[DllImport("d3dcompiler_47.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DCompressShaders")]
	private unsafe static extern int D3DCompressShaders_(int param0, void* param1, int param2, void* param3);

	public unsafe static void DecompressShaders(IntPtr srcDataRef, PointerSize srcDataSize, int uNumShaders, int uStartIndex, int[] indicesRef, int uFlags, Blob[] shadersOut, out int totalShadersRef)
	{
		IntPtr* ptr = null;
		ptr = stackalloc IntPtr[shadersOut.Length];
		Result result;
		fixed (int* ptr2 = &totalShadersRef)
		{
			void* param = ptr2;
			fixed (int* ptr3 = indicesRef)
			{
				void* param2 = ptr3;
				result = D3DDecompressShaders_((void*)srcDataRef, srcDataSize, uNumShaders, uStartIndex, param2, uFlags, ptr, param);
			}
		}
		for (int i = 0; i < shadersOut.Length; i++)
		{
			if (ptr[i] != IntPtr.Zero)
			{
				shadersOut[i] = new Blob(ptr[i]);
			}
			else
			{
				shadersOut[i] = null;
			}
		}
		result.CheckError();
	}

	[DllImport("d3dcompiler_47.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "D3DDecompressShaders")]
	private unsafe static extern int D3DDecompressShaders_(void* param0, void* param1, int param2, int param3, void* param4, int param5, void* param6, void* param7);
}
