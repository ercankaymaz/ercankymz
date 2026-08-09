using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using SharpDX.Direct3D;
using SharpDX.IO;
using SharpDX.Multimedia;

namespace SharpDX.D3DCompiler;

public class ShaderBytecode : IDisposable
{
	public const ShaderFlags Effect10 = (ShaderFlags)1073741824;

	public byte[] Data { get; private set; }

	public bool IsCompressed { get; private set; }

	public ShaderBytecode(DataStream data)
	{
		Data = new byte[data.Length];
		data.Read(Data, 0, Data.Length);
	}

	public ShaderBytecode(Stream data)
	{
		int num = (int)(data.Length - data.Position);
		byte[] array = new byte[num];
		data.Read(array, 0, num);
		Data = array;
	}

	public ShaderBytecode(byte[] buffer)
	{
		Data = buffer;
	}

	public ShaderBytecode(IntPtr buffer, int sizeInBytes)
	{
		Data = new byte[sizeInBytes];
		Utilities.Read(buffer, Data, 0, Data.Length);
	}

	protected internal ShaderBytecode(Blob blob)
	{
		Data = new byte[(int)blob.BufferSize];
		Utilities.Read(blob.BufferPointer, Data, 0, Data.Length);
		blob.Dispose();
	}

	public static CompilationResult Compile(string shaderSource, string profile, ShaderFlags shaderFlags = ShaderFlags.OptimizationLevel1, EffectFlags effectFlags = EffectFlags.None, string sourceFileName = "unknown", SecondaryDataFlags secondaryDataFlags = SecondaryDataFlags.None, DataStream secondaryData = null)
	{
		if (string.IsNullOrEmpty(shaderSource))
		{
			throw new ArgumentNullException("shaderSource");
		}
		IntPtr intPtr = Marshal.StringToHGlobalAnsi(shaderSource);
		try
		{
			return Compile(intPtr, shaderSource.Length, null, profile, shaderFlags, effectFlags, null, null, sourceFileName, secondaryDataFlags, secondaryData);
		}
		finally
		{
			if (intPtr != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(intPtr);
			}
		}
	}

	public static CompilationResult Compile(string shaderSource, string entryPoint, string profile, ShaderFlags shaderFlags = ShaderFlags.OptimizationLevel1, EffectFlags effectFlags = EffectFlags.None, string sourceFileName = "unknown", SecondaryDataFlags secondaryDataFlags = SecondaryDataFlags.None, DataStream secondaryData = null)
	{
		if (string.IsNullOrEmpty(shaderSource))
		{
			throw new ArgumentNullException("shaderSource");
		}
		IntPtr intPtr = Marshal.StringToHGlobalAnsi(shaderSource);
		try
		{
			return Compile(intPtr, shaderSource.Length, entryPoint, profile, shaderFlags, effectFlags, null, null, sourceFileName, secondaryDataFlags, secondaryData);
		}
		finally
		{
			if (intPtr != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(intPtr);
			}
		}
	}

	public static CompilationResult Compile(string shaderSource, string profile, ShaderFlags shaderFlags, EffectFlags effectFlags, ShaderMacro[] defines, Include include, string sourceFileName = "unknown", SecondaryDataFlags secondaryDataFlags = SecondaryDataFlags.None, DataStream secondaryData = null)
	{
		if (string.IsNullOrEmpty(shaderSource))
		{
			throw new ArgumentNullException("shaderSource");
		}
		IntPtr intPtr = Marshal.StringToHGlobalAnsi(shaderSource);
		try
		{
			return Compile(intPtr, shaderSource.Length, null, profile, shaderFlags, effectFlags, defines, include, sourceFileName, secondaryDataFlags, secondaryData);
		}
		finally
		{
			if (intPtr != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(intPtr);
			}
		}
	}

	public static CompilationResult Compile(byte[] shaderSource, string profile, ShaderFlags shaderFlags, EffectFlags effectFlags, ShaderMacro[] defines, Include include, string sourceFileName = "unknown", SecondaryDataFlags secondaryDataFlags = SecondaryDataFlags.None, DataStream secondaryData = null)
	{
		return Compile(shaderSource, null, profile, shaderFlags, effectFlags, defines, include, sourceFileName, secondaryDataFlags, secondaryData);
	}

	public static CompilationResult Compile(string shaderSource, string entryPoint, string profile, ShaderFlags shaderFlags, EffectFlags effectFlags, ShaderMacro[] defines, Include include, string sourceFileName = "unknown", SecondaryDataFlags secondaryDataFlags = SecondaryDataFlags.None, DataStream secondaryData = null)
	{
		if (string.IsNullOrEmpty(shaderSource))
		{
			throw new ArgumentNullException("shaderSource");
		}
		IntPtr intPtr = Marshal.StringToHGlobalAnsi(shaderSource);
		try
		{
			return Compile(intPtr, shaderSource.Length, entryPoint, profile, shaderFlags, effectFlags, defines, include, sourceFileName, secondaryDataFlags, secondaryData);
		}
		finally
		{
			if (intPtr != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(intPtr);
			}
		}
	}

	public unsafe static CompilationResult Compile(byte[] shaderSource, string entryPoint, string profile, ShaderFlags shaderFlags, EffectFlags effectFlags, ShaderMacro[] defines, Include include, string sourceFileName = "unknown", SecondaryDataFlags secondaryDataFlags = SecondaryDataFlags.None, DataStream secondaryData = null)
	{
		fixed (byte* ptr = &shaderSource[0])
		{
			void* ptr2 = ptr;
			return Compile((IntPtr)ptr2, shaderSource.Length, entryPoint, profile, shaderFlags, effectFlags, defines, include, sourceFileName, secondaryDataFlags, secondaryData);
		}
	}

	public static CompilationResult Compile(IntPtr textSource, int textSize, string entryPoint, string profile, ShaderFlags shaderFlags, EffectFlags effectFlags, ShaderMacro[] defines, Include include, string sourceFileName = "unknown", SecondaryDataFlags secondaryDataFlags = SecondaryDataFlags.None, DataStream secondaryData = null)
	{
		if (string.IsNullOrWhiteSpace(profile))
		{
			throw new ArgumentNullException("profile");
		}
		if (!profile.ToUpperInvariant().StartsWith("FX_") && !profile.ToUpperInvariant().StartsWith("LIB_") && string.IsNullOrWhiteSpace(entryPoint))
		{
			throw new ArgumentNullException("entryPoint");
		}
		Blob codeOut = null;
		Blob errorMsgsOut = null;
		Result result = D3D.Compile2(textSource, textSize, sourceFileName, PrepareMacros(defines), include, entryPoint, profile, shaderFlags, effectFlags, secondaryDataFlags, secondaryData?.DataPointer ?? IntPtr.Zero, (int)((secondaryData != null) ? secondaryData.Length : 0), out codeOut, out errorMsgsOut);
		if (result.Failure)
		{
			if (errorMsgsOut == null)
			{
				throw new SharpDXException(result);
			}
			if (Configuration.ThrowOnShaderCompileError)
			{
				throw new CompilationException(result, Utilities.BlobToString(errorMsgsOut));
			}
		}
		return new CompilationResult((codeOut != null) ? new ShaderBytecode(codeOut) : null, result, Utilities.BlobToString(errorMsgsOut));
	}

	public static CompilationResult Compile(byte[] shaderSource, string profile, ShaderFlags shaderFlags = ShaderFlags.OptimizationLevel1, EffectFlags effectFlags = EffectFlags.None, string sourceFileName = "unknown")
	{
		return Compile(shaderSource, null, profile, shaderFlags, effectFlags, null, null, sourceFileName);
	}

	public static CompilationResult Compile(byte[] shaderSource, string entryPoint, string profile, ShaderFlags shaderFlags = ShaderFlags.OptimizationLevel1, EffectFlags effectFlags = EffectFlags.None, string sourceFileName = "unknown")
	{
		return Compile(shaderSource, entryPoint, profile, shaderFlags, effectFlags, null, null, sourceFileName);
	}

	public static CompilationResult CompileFromFile(string fileName, string profile, ShaderFlags shaderFlags = ShaderFlags.OptimizationLevel1, EffectFlags effectFlags = EffectFlags.None, ShaderMacro[] defines = null, Include include = null)
	{
		return CompileFromFile(fileName, null, profile, shaderFlags, effectFlags, defines, include);
	}

	public static CompilationResult CompileFromFile(string fileName, string entryPoint, string profile, ShaderFlags shaderFlags = ShaderFlags.OptimizationLevel1, EffectFlags effectFlags = EffectFlags.None, ShaderMacro[] defines = null, Include include = null)
	{
		return Compile(NativeFile.ReadAllText(fileName), entryPoint, profile, shaderFlags, effectFlags, defines, include, fileName);
	}

	public static ShaderBytecode Compress(params ShaderBytecode[] shaderBytecodes)
	{
		ShaderData[] array = new ShaderData[shaderBytecodes.Length];
		GCHandle[] array2 = new GCHandle[shaderBytecodes.Length];
		Blob compressedDataOut;
		try
		{
			for (int i = 0; i < array.Length; i++)
			{
				array2[i] = GCHandle.Alloc(shaderBytecodes[i].Data, GCHandleType.Pinned);
				array[i] = new ShaderData
				{
					BytecodePtr = array2[i].AddrOfPinnedObject(),
					BytecodeLength = shaderBytecodes[i].Data.Length
				};
			}
			D3D.CompressShaders(shaderBytecodes.Length, array, 1, out compressedDataOut);
		}
		finally
		{
			GCHandle[] array3 = array2;
			foreach (GCHandle gCHandle in array3)
			{
				gCHandle.Free();
			}
		}
		return new ShaderBytecode(compressedDataOut)
		{
			IsCompressed = true
		};
	}

	public unsafe ShaderBytecode[] Decompress()
	{
		Blob[] shadersOut = new Blob[1];
		int totalShadersRef;
		fixed (byte* data = Data)
		{
			void* ptr = data;
			D3D.DecompressShaders((IntPtr)ptr, Data.Length, 0, 0, null, 0, shadersOut, out totalShadersRef);
		}
		return Decompress(0, totalShadersRef);
	}

	public unsafe ShaderBytecode[] Decompress(int startIndex, int numShaders)
	{
		if (numShaders == 0)
		{
			return null;
		}
		Blob[] array = new Blob[numShaders];
		fixed (byte* data = Data)
		{
			void* ptr = data;
			D3D.DecompressShaders((IntPtr)ptr, Data.Length, numShaders, startIndex, null, 0, array, out var _);
		}
		ShaderBytecode[] array2 = new ShaderBytecode[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] != null)
			{
				array2[i] = new ShaderBytecode(array[i]);
			}
		}
		return array2;
	}

	public unsafe ShaderBytecode[] Decompress(int[] indices)
	{
		if (indices.Length == 0)
		{
			return null;
		}
		Blob[] array = new Blob[indices.Length];
		fixed (byte* data = Data)
		{
			void* ptr = data;
			D3D.DecompressShaders((IntPtr)ptr, Data.Length, indices.Length, 0, indices, 0, array, out var _);
		}
		ShaderBytecode[] array2 = new ShaderBytecode[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] != null)
			{
				array2[i] = new ShaderBytecode(array[i]);
			}
		}
		return array2;
	}

	public string Disassemble()
	{
		return Disassemble(DisassemblyFlags.None, null);
	}

	public string Disassemble(DisassemblyFlags flags)
	{
		return Disassemble(flags, null);
	}

	public unsafe string Disassemble(DisassemblyFlags flags, string comments)
	{
		Blob disassemblyOut;
		fixed (byte* data = Data)
		{
			void* ptr = data;
			D3D.Disassemble((IntPtr)ptr, Data.Length, flags, comments, out disassemblyOut);
		}
		return Utilities.BlobToString(disassemblyOut);
	}

	public unsafe string DisassembleRegion(DisassemblyFlags flags, string comments, PointerSize startByteOffset, PointerSize numberOfInstructions, out PointerSize finishByteOffsetRef)
	{
		Blob disassemblyOut;
		fixed (byte* data = Data)
		{
			void* ptr = data;
			D3D.DisassembleRegion((IntPtr)ptr, Data.Length, (int)flags, comments, startByteOffset, numberOfInstructions, out finishByteOffsetRef, out disassemblyOut);
		}
		return Utilities.BlobToString(disassemblyOut);
	}

	public unsafe PointerSize GetTraceInstructionOffsets(bool isIncludingNonExecutableCode, PointerSize startInstIndex, PointerSize numInsts, out PointerSize totalInstsRef)
	{
		fixed (byte* data = Data)
		{
			void* ptr = data;
			return D3D.GetTraceInstructionOffsets((IntPtr)ptr, Data.Length, isIncludingNonExecutableCode ? 1 : 0, startInstIndex, numInsts, out totalInstsRef);
		}
	}

	public unsafe ShaderBytecode GetPart(ShaderBytecodePart part)
	{
		Blob partOut;
		fixed (byte* data = Data)
		{
			void* ptr = data;
			D3D.GetBlobPart((IntPtr)ptr, Data.Length, part, 0, out partOut);
		}
		return new ShaderBytecode(partOut);
	}

	public unsafe ShaderBytecode SetPart(ShaderBytecodePart part, DataStream partData)
	{
		Blob newShaderOut;
		fixed (byte* data = Data)
		{
			void* ptr = data;
			D3D.SetBlobPart((IntPtr)ptr, Data.Length, part, 0, partData.DataPointer, (int)partData.Length, out newShaderOut);
		}
		return new ShaderBytecode(newShaderOut);
	}

	public static ShaderBytecode Load(Stream stream)
	{
		return new ShaderBytecode(Utilities.ReadStream(stream));
	}

	public void Save(Stream stream)
	{
		if (Data.Length != 0)
		{
			stream.Write(Data, 0, Data.Length);
		}
	}

	public static string Preprocess(string shaderSource, ShaderMacro[] defines = null, Include include = null, string sourceFileName = "")
	{
		string compilationErrors = null;
		if (string.IsNullOrEmpty(shaderSource))
		{
			throw new ArgumentNullException("shaderSource");
		}
		IntPtr intPtr = Marshal.StringToHGlobalAnsi(shaderSource);
		try
		{
			return Preprocess(intPtr, shaderSource.Length, defines, include, out compilationErrors, sourceFileName);
		}
		finally
		{
			if (intPtr != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(intPtr);
			}
		}
	}

	public static string Preprocess(byte[] shaderSource, ShaderMacro[] defines = null, Include include = null, string sourceFileName = "")
	{
		string compilationErrors = null;
		return Preprocess(shaderSource, defines, include, out compilationErrors, sourceFileName);
	}

	public unsafe static string Preprocess(byte[] shaderSource, ShaderMacro[] defines, Include include, out string compilationErrors, string sourceFileName = "")
	{
		fixed (byte* ptr = &shaderSource[0])
		{
			void* ptr2 = ptr;
			return Preprocess((IntPtr)ptr2, shaderSource.Length, defines, include, out compilationErrors, sourceFileName);
		}
	}

	public static string Preprocess(IntPtr shaderSourcePtr, int shaderSourceLength, ShaderMacro[] defines, Include include, out string compilationErrors, string sourceFileName = "")
	{
		Blob codeTextOut = null;
		Blob errorMsgsOut = null;
		compilationErrors = null;
		try
		{
			D3D.Preprocess(shaderSourcePtr, shaderSourceLength, sourceFileName, PrepareMacros(defines), include, out codeTextOut, out errorMsgsOut);
		}
		catch (SharpDXException ex)
		{
			if (errorMsgsOut != null)
			{
				compilationErrors = Utilities.BlobToString(errorMsgsOut);
				throw new CompilationException(ex.ResultCode, compilationErrors);
			}
			throw;
		}
		return Utilities.BlobToString(codeTextOut);
	}

	public static string Preprocess(string shaderSource, ShaderMacro[] defines, Include include, out string compilationErrors, string sourceFileName = "")
	{
		if (string.IsNullOrEmpty(shaderSource))
		{
			throw new ArgumentNullException("shaderSource");
		}
		IntPtr intPtr = Marshal.StringToHGlobalAnsi(shaderSource);
		try
		{
			return Preprocess(intPtr, shaderSource.Length, defines, include, out compilationErrors, sourceFileName);
		}
		finally
		{
			if (intPtr != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(intPtr);
			}
		}
	}

	public static string PreprocessFromFile(string fileName)
	{
		string compilationErrors = null;
		if (fileName == null)
		{
			throw new ArgumentNullException("fileName");
		}
		string text = NativeFile.ReadAllText(fileName);
		if (string.IsNullOrEmpty(text))
		{
			throw new ArgumentNullException("fileName");
		}
		return Preprocess(Encoding.ASCII.GetBytes(text), null, null, out compilationErrors, fileName);
	}

	public static string PreprocessFromFile(string fileName, ShaderMacro[] defines, Include include)
	{
		string compilationErrors = null;
		return PreprocessFromFile(fileName, defines, include, out compilationErrors);
	}

	public static string PreprocessFromFile(string fileName, ShaderMacro[] defines, Include include, out string compilationErrors)
	{
		if (fileName == null)
		{
			throw new ArgumentNullException("fileName");
		}
		return Preprocess(NativeFile.ReadAllText(fileName), defines, include, out compilationErrors);
	}

	public unsafe ShaderBytecode Strip(StripFlags flags)
	{
		Blob strippedBlobOut;
		fixed (byte* data = Data)
		{
			void* ptr = data;
			if (D3D.StripShader((IntPtr)ptr, Data.Length, flags, out strippedBlobOut).Failure)
			{
				return null;
			}
		}
		return new ShaderBytecode(strippedBlobOut);
	}

	public static implicit operator byte[](ShaderBytecode shaderBytecode)
	{
		return shaderBytecode.Data;
	}

	public static ShaderBytecode FromStream(Stream stream)
	{
		return new ShaderBytecode(stream);
	}

	public static ShaderBytecode FromFile(string fileName)
	{
		return new ShaderBytecode(NativeFile.ReadAllBytes(fileName));
	}

	internal static ShaderMacro[] PrepareMacros(ShaderMacro[] macros)
	{
		if (macros == null)
		{
			return null;
		}
		if (macros.Length == 0)
		{
			return null;
		}
		if (macros[macros.Length - 1].Name == null && macros[macros.Length - 1].Definition == null)
		{
			return macros;
		}
		ShaderMacro[] array = new ShaderMacro[macros.Length + 1];
		Array.Copy(macros, array, macros.Length);
		array[macros.Length] = new ShaderMacro(null, null);
		return array;
	}

	public void Dispose()
	{
	}

	public ShaderProfile GetVersion()
	{
		byte[] data = Data;
		uint num = BitConverter.ToUInt32(data, 28);
		int num2 = -1;
		int num3 = -1;
		for (int i = 0; i < num; i++)
		{
			int num4 = BitConverter.ToInt32(data, 32 + 4 * i);
			FourCC fourCC = BitConverter.ToUInt32(data, num4);
			if (fourCC == (FourCC)"SHEX" || fourCC == (FourCC)"SHDR")
			{
				num2 = num4;
			}
			if (fourCC == (FourCC)"Aon9")
			{
				num3 = num4;
			}
		}
		if (num2 == -1)
		{
			throw new ArgumentException("Cannot find the chunk with version in provided bytecode");
		}
		int token = BitConverter.ToInt32(data, num2 + 8);
		int num5 = DecodeValue(token, 0, 3);
		int num6 = DecodeValue(token, 4, 7);
		ShaderVersion shaderVersion = (ShaderVersion)DecodeValue(token, 16, 31);
		int profileMinor = 0;
		int profileMajor = 0;
		if (num3 != -1 && num6 == 4 && num5 == 0)
		{
			byte b = (byte)((shaderVersion == ShaderVersion.VertexShader) ? 254u : 255u);
			byte b2 = byte.MaxValue;
			int num7 = num3 + 16;
			long num8 = num3 + 8 + BitConverter.ToUInt32(data, num3 + 4);
			for (int j = num7; j < num8; j += 4)
			{
				if (data[j + 2] == b && data[j + 3] == b2)
				{
					profileMinor = ((data[j] != 1) ? 1 : 3);
					break;
				}
			}
			profileMajor = 9;
		}
		return new ShaderProfile(shaderVersion, num6, num5, profileMajor, profileMinor);
	}

	private static int DecodeValue(int token, int start, int end)
	{
		int num = 0;
		for (int i = start; i <= end; i++)
		{
			num |= 1 << i;
		}
		return (token & num) >> start;
	}
}
