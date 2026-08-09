using System;
using System.Runtime.InteropServices;

namespace SharpDX.D3DCompiler;

public struct ShaderTypeDescription
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal struct __Native
	{
		public ShaderVariableClass Class;

		public ShaderVariableType Type;

		public int RowCount;

		public int ColumnCount;

		public int ElementCount;

		public int MemberCount;

		public int Offset;

		public IntPtr Name;
	}

	public ShaderVariableClass Class;

	public ShaderVariableType Type;

	public int RowCount;

	public int ColumnCount;

	public int ElementCount;

	public int MemberCount;

	public int Offset;

	public string Name;

	internal void __MarshalFree(ref __Native @ref)
	{
		Marshal.FreeHGlobal(@ref.Name);
	}

	internal void __MarshalFrom(ref __Native @ref)
	{
		Class = @ref.Class;
		Type = @ref.Type;
		RowCount = @ref.RowCount;
		ColumnCount = @ref.ColumnCount;
		ElementCount = @ref.ElementCount;
		MemberCount = @ref.MemberCount;
		Offset = @ref.Offset;
		Name = Marshal.PtrToStringAnsi(@ref.Name);
	}

	internal void __MarshalTo(ref __Native @ref)
	{
		@ref.Class = Class;
		@ref.Type = Type;
		@ref.RowCount = RowCount;
		@ref.ColumnCount = ColumnCount;
		@ref.ElementCount = ElementCount;
		@ref.MemberCount = MemberCount;
		@ref.Offset = Offset;
		@ref.Name = Marshal.StringToHGlobalAnsi(Name);
	}
}
