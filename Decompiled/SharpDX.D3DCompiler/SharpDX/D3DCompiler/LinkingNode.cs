using System;
using System.Runtime.InteropServices;

namespace SharpDX.D3DCompiler;

[Guid("D80DD70C-8D2F-4751-94A1-03C79B3556DB")]
public class LinkingNode : ComObject
{
	public LinkingNode(IntPtr nativePtr)
		: base(nativePtr)
	{
	}

	public static explicit operator LinkingNode(IntPtr nativePtr)
	{
		if (!(nativePtr == IntPtr.Zero))
		{
			return new LinkingNode(nativePtr);
		}
		return null;
	}
}
