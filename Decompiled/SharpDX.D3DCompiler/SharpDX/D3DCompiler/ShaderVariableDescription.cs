using System;
using System.Runtime.InteropServices;

namespace SharpDX.D3DCompiler;

public struct ShaderVariableDescription
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal struct __Native
	{
		public IntPtr Name;

		public int StartOffset;

		public int Size;

		public ShaderVariableFlags Flags;

		public IntPtr DefaultValue;

		public int StartTexture;

		public int TextureSize;

		public int StartSampler;

		public int SamplerSize;
	}

	public string Name;

	public int StartOffset;

	public int Size;

	public ShaderVariableFlags Flags;

	public IntPtr DefaultValue;

	public int StartTexture;

	public int TextureSize;

	public int StartSampler;

	public int SamplerSize;

	internal void __MarshalFree(ref __Native @ref)
	{
		Marshal.FreeHGlobal(@ref.Name);
	}

	internal void __MarshalFrom(ref __Native @ref)
	{
		Name = Marshal.PtrToStringAnsi(@ref.Name);
		StartOffset = @ref.StartOffset;
		Size = @ref.Size;
		Flags = @ref.Flags;
		DefaultValue = @ref.DefaultValue;
		StartTexture = @ref.StartTexture;
		TextureSize = @ref.TextureSize;
		StartSampler = @ref.StartSampler;
		SamplerSize = @ref.SamplerSize;
	}

	internal void __MarshalTo(ref __Native @ref)
	{
		@ref.Name = Marshal.StringToHGlobalAnsi(Name);
		@ref.StartOffset = StartOffset;
		@ref.Size = Size;
		@ref.Flags = Flags;
		@ref.DefaultValue = DefaultValue;
		@ref.StartTexture = StartTexture;
		@ref.TextureSize = TextureSize;
		@ref.StartSampler = StartSampler;
		@ref.SamplerSize = SamplerSize;
	}
}
