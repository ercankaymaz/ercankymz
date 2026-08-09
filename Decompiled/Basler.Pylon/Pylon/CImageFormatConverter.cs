using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Pylon;

[StructLayout(LayoutKind.Sequential, Size = 48)]
[NativeCppClass]
internal struct CImageFormatConverter
{
	[StructLayout(LayoutKind.Sequential, Size = 4)]
	[CLSCompliant(false)]
	[NativeCppClass]
	public static struct IOutputPixelFormatEnum
	{
	}
}
