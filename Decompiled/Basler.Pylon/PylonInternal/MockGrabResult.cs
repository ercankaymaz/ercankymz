using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PylonInternal;

[StructLayout(LayoutKind.Sequential, Size = 160)]
[UnsafeValueType]
[NativeCppClass]
internal struct MockGrabResult
{
	[StructLayout(LayoutKind.Sequential, Size = 92)]
	[NativeCppClass]
	internal struct CreatableGrabResultData
	{
	}
}
