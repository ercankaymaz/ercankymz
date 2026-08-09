using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace devDept.Eyeshot.Control;

public class CameraMoveEventArgs : EventArgs
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly Viewport _0023_003DzWOovklGI8FlC9cuHJA_003D_003D;

	public Viewport Viewport
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzWOovklGI8FlC9cuHJA_003D_003D;
		}
	}

	public CameraMoveEventArgs(Viewport viewport)
	{
		_0023_003DzWOovklGI8FlC9cuHJA_003D_003D = viewport;
	}
}
