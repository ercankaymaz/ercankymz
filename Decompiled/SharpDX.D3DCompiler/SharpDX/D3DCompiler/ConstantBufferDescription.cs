using System;
using System.Runtime.InteropServices;

namespace SharpDX.D3DCompiler;

public struct ConstantBufferDescription
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal struct __Native
	{
		public IntPtr Name;

		public ConstantBufferType Type;

		public int VariableCount;

		public int Size;

		public ConstantBufferFlags Flags;
	}

	public string Name;

	public ConstantBufferType Type;

	public int VariableCount;

	public int Size;

	public ConstantBufferFlags Flags;

	internal void __MarshalFree(ref __Native @ref)
	{
		Marshal.FreeHGlobal(@ref.Name);
	}

	internal void __MarshalFrom(ref __Native @ref)
	{
		Name = Marshal.PtrToStringAnsi(@ref.Name);
		Type = @ref.Type;
		VariableCount = @ref.VariableCount;
		Size = @ref.Size;
		Flags = @ref.Flags;
	}

	internal void __MarshalTo(ref __Native @ref)
	{
		@ref.Name = Marshal.StringToHGlobalAnsi(Name);
		@ref.Type = Type;
		@ref.VariableCount = VariableCount;
		@ref.Size = Size;
		@ref.Flags = Flags;
	}
}
