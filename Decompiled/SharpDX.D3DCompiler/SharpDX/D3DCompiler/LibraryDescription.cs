using System;
using System.Runtime.InteropServices;

namespace SharpDX.D3DCompiler;

public struct LibraryDescription
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal struct __Native
	{
		public IntPtr Creator;

		public int Flags;

		public int FunctionCount;
	}

	public string Creator;

	public int Flags;

	public int FunctionCount;

	internal void __MarshalFree(ref __Native @ref)
	{
		Marshal.FreeHGlobal(@ref.Creator);
	}

	internal void __MarshalFrom(ref __Native @ref)
	{
		Creator = Marshal.PtrToStringAnsi(@ref.Creator);
		Flags = @ref.Flags;
		FunctionCount = @ref.FunctionCount;
	}

	internal void __MarshalTo(ref __Native @ref)
	{
		@ref.Creator = Marshal.StringToHGlobalAnsi(Creator);
		@ref.Flags = Flags;
		@ref.FunctionCount = FunctionCount;
	}
}
