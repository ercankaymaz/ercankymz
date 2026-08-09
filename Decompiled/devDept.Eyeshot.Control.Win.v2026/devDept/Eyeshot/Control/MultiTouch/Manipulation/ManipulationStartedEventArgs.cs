using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace devDept.Eyeshot.Control.MultiTouch.Manipulation;

public class ManipulationStartedEventArgs : EventArgs
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private PointF _0023_003DzVhqV_0024ZuBzBGeqyIc1w_003D_003D;

	public PointF Location
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzVhqV_0024ZuBzBGeqyIc1w_003D_003D;
		}
	}

	public ManipulationStartedEventArgs(float x, float y)
	{
		_0023_003DzJajQHFZmoQKE(new PointF(x, y));
	}

	private void _0023_003DzJajQHFZmoQKE(PointF _0023_003DzsLHxXyo_003D)
	{
		_0023_003DzVhqV_0024ZuBzBGeqyIc1w_003D_003D = _0023_003DzsLHxXyo_003D;
	}
}
