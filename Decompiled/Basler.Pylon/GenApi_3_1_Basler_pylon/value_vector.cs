using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace GenApi_3_1_Basler_pylon;

[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct value_vector
{
	[StructLayout(LayoutKind.Sequential, Size = 4)]
	[NativeCppClass]
	[CLSCompliant(false)]
	public struct const_iterator
	{
	}

	[StructLayout(LayoutKind.Sequential, Size = 4)]
	[CLSCompliant(false)]
	[NativeCppClass]
	public struct iterator
	{
	}
}
