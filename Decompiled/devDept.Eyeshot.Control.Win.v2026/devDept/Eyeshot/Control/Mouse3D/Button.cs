using System;
using System.Diagnostics;

namespace devDept.Eyeshot.Control.Mouse3D;

public class Button
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private uint _0023_003DzM6jfOIo_003D;

	[CLSCompliant(false)]
	public uint Pressed => _0023_003DzM6jfOIo_003D;

	public Button(byte b1, byte b2, byte b3, byte b4)
	{
		_0023_003DzM6jfOIo_003D = (uint)(b1 + (b2 << 8) + (b3 << 16) + (b4 << 24));
	}
}
