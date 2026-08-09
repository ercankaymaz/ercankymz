using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Pylon;

[StructLayout(LayoutKind.Sequential, Size = 8)]
[NativeCppClass]
internal struct CGrabResultPtr
{
	[StructLayout(LayoutKind.Sequential, Size = 16)]
	[NativeCppClass]
	[CLSCompliant(false)]
	public struct CGrabResultPtrImpl
	{
	}
}
