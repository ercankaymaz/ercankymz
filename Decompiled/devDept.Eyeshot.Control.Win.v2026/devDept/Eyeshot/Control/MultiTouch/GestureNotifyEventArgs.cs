using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace devDept.Eyeshot.Control.MultiTouch;

public class GestureNotifyEventArgs : EventArgs
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Point _0023_003DzVhqV_0024ZuBzBGeqyIc1w_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IntPtr _0023_003DzQX8KzEJts2Xm5EcTig_003D_003D;

	public Point Location
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzVhqV_0024ZuBzBGeqyIc1w_003D_003D;
		}
	}

	public IntPtr TargetHwnd
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzQX8KzEJts2Xm5EcTig_003D_003D;
		}
	}

	internal GestureNotifyEventArgs(IntPtr _0023_003DzafzCBBQ_003D)
	{
		_0023_003DzirAC6ze4AS4guYNendC5yZ5TMzkXpZGjVJvc00mAPC0v._0023_003DzykQb7wpRwyKYM5sR3VpQ2BhxS_5Y _0023_003DzykQb7wpRwyKYM5sR3VpQ2BhxS_5Y = (_0023_003DzirAC6ze4AS4guYNendC5yZ5TMzkXpZGjVJvc00mAPC0v._0023_003DzykQb7wpRwyKYM5sR3VpQ2BhxS_5Y)Marshal.PtrToStructure(_0023_003DzafzCBBQ_003D, typeof(_0023_003DzirAC6ze4AS4guYNendC5yZ5TMzkXpZGjVJvc00mAPC0v._0023_003DzykQb7wpRwyKYM5sR3VpQ2BhxS_5Y));
		_0023_003DzJajQHFZmoQKE(new Point(_0023_003DzykQb7wpRwyKYM5sR3VpQ2BhxS_5Y._0023_003DzrFkXJJxZyCxL.x, _0023_003DzykQb7wpRwyKYM5sR3VpQ2BhxS_5Y._0023_003DzrFkXJJxZyCxL.y));
		_0023_003DzjVPjSpj1JcyU(_0023_003DzykQb7wpRwyKYM5sR3VpQ2BhxS_5Y._0023_003DzsjYp3p4_003D);
	}

	private void _0023_003DzJajQHFZmoQKE(Point _0023_003DzsLHxXyo_003D)
	{
		_0023_003DzVhqV_0024ZuBzBGeqyIc1w_003D_003D = _0023_003DzsLHxXyo_003D;
	}

	private void _0023_003DzjVPjSpj1JcyU(IntPtr _0023_003DzsLHxXyo_003D)
	{
		_0023_003DzQX8KzEJts2Xm5EcTig_003D_003D = _0023_003DzsLHxXyo_003D;
	}
}
