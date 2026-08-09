using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace std;

[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct locale
{
	[StructLayout(LayoutKind.Sequential, Size = 4)]
	[CLSCompliant(false)]
	[NativeCppClass]
	public struct id
	{
	}

	[StructLayout(LayoutKind.Sequential, Size = 8)]
	[CLSCompliant(false)]
	[NativeCppClass]
	public struct facet
	{
	}
}
