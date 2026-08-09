using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Pylon;

[StructLayout(LayoutKind.Sequential, Size = 92)]
[NativeCppClass]
internal struct CGrabResultData
{
	[StructLayout(LayoutKind.Sequential, Size = 432)]
	[CLSCompliant(false)]
	[NativeCppClass]
	[UnsafeValueType]
	public struct CGrabResultDataImpl
	{
	}
}
