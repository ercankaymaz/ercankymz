using System;
using System.Runtime.InteropServices;

namespace SharpDX.D3DCompiler;

internal struct ShaderData
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal struct __Native
	{
		public IntPtr BytecodePtr;

		public IntPtr BytecodeLength;
	}

	public IntPtr BytecodePtr;

	public PointerSize BytecodeLength;

	internal void __MarshalFree(ref __Native @ref)
	{
	}

	internal void __MarshalFrom(ref __Native @ref)
	{
		BytecodePtr = @ref.BytecodePtr;
		BytecodeLength = @ref.BytecodeLength;
	}

	internal void __MarshalTo(ref __Native @ref)
	{
		@ref.BytecodePtr = BytecodePtr;
		@ref.BytecodeLength = BytecodeLength;
	}
}
