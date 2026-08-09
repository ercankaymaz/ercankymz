using System;
using SharpDX.Direct3D;

namespace SharpDX.D3DCompiler;

public class ShaderSignature : IDisposable
{
	public byte[] Data { get; private set; }

	public ShaderSignature(IntPtr ptr, int size)
	{
		Data = new byte[size];
		Utilities.Read(ptr, Data, 0, Data.Length);
	}

	public ShaderSignature(Blob blob)
	{
		Data = new byte[(int)blob.BufferSize];
		Utilities.Read(blob.BufferPointer, Data, 0, Data.Length);
		blob.Dispose();
	}

	public ShaderSignature(DataStream data)
	{
		Data = new byte[data.Length];
		data.Read(Data, 0, Data.Length);
	}

	public ShaderSignature(byte[] data)
	{
		Data = data;
	}

	public unsafe static ShaderSignature GetInputOutputSignature(byte[] shaderBytecode)
	{
		Blob signatureBlobOut;
		fixed (byte* ptr = shaderBytecode)
		{
			void* ptr2 = ptr;
			if (D3D.GetInputAndOutputSignatureBlob((IntPtr)ptr2, shaderBytecode.Length, out signatureBlobOut).Failure)
			{
				return null;
			}
		}
		return new ShaderSignature(signatureBlobOut);
	}

	public unsafe static ShaderSignature GetInputSignature(byte[] shaderBytecode)
	{
		Blob signatureBlobOut;
		fixed (byte* ptr = shaderBytecode)
		{
			void* ptr2 = ptr;
			if (D3D.GetInputSignatureBlob((IntPtr)ptr2, shaderBytecode.Length, out signatureBlobOut).Failure)
			{
				return null;
			}
		}
		return new ShaderSignature(signatureBlobOut);
	}

	public unsafe static ShaderSignature GetOutputSignature(byte[] shaderBytecode)
	{
		Blob signatureBlobOut;
		fixed (byte* ptr = shaderBytecode)
		{
			void* ptr2 = ptr;
			if (D3D.GetOutputSignatureBlob((IntPtr)ptr2, shaderBytecode.Length, out signatureBlobOut).Failure)
			{
				return null;
			}
		}
		return new ShaderSignature(signatureBlobOut);
	}

	public static implicit operator byte[](ShaderSignature shaderSignature)
	{
		return shaderSignature?.Data;
	}

	public void Dispose()
	{
	}
}
