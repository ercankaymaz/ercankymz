using System;
using System.Runtime.InteropServices;
using SharpDX.Direct3D;

namespace SharpDX.D3DCompiler;

public struct InputBindingDescription
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal struct __Native
	{
		public IntPtr Name;

		public ShaderInputType Type;

		public int BindPoint;

		public int BindCount;

		public ShaderInputFlags Flags;

		public ResourceReturnType ReturnType;

		public ShaderResourceViewDimension Dimension;

		public int NumSamples;
	}

	public string Name;

	public ShaderInputType Type;

	public int BindPoint;

	public int BindCount;

	public ShaderInputFlags Flags;

	public ResourceReturnType ReturnType;

	public ShaderResourceViewDimension Dimension;

	public int NumSamples;

	internal void __MarshalFree(ref __Native @ref)
	{
		Marshal.FreeHGlobal(@ref.Name);
	}

	internal void __MarshalFrom(ref __Native @ref)
	{
		Name = Marshal.PtrToStringAnsi(@ref.Name);
		Type = @ref.Type;
		BindPoint = @ref.BindPoint;
		BindCount = @ref.BindCount;
		Flags = @ref.Flags;
		ReturnType = @ref.ReturnType;
		Dimension = @ref.Dimension;
		NumSamples = @ref.NumSamples;
	}

	internal void __MarshalTo(ref __Native @ref)
	{
		@ref.Name = Marshal.StringToHGlobalAnsi(Name);
		@ref.Type = Type;
		@ref.BindPoint = BindPoint;
		@ref.BindCount = BindCount;
		@ref.Flags = Flags;
		@ref.ReturnType = ReturnType;
		@ref.Dimension = Dimension;
		@ref.NumSamples = NumSamples;
	}
}
