using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using devDept.Eyeshot.Control.MultiTouch.Interop;

namespace devDept.Eyeshot.Control.MultiTouch;

public class GestureEventArgs : EventArgs
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly uint _0023_003DzUKj93JtR6_0024vN;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private uint _0023_003DztMDrm48ZoJdxtfH_HQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ulong _0023_003DzAZ2xyF31Ew_0024CBV3SGINN6l4_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Point _0023_003DzVhqV_0024ZuBzBGeqyIc1w_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzlWggRTlUkDBjBVc9BPwLcm8_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Point _0023_003Dz25Joc2vbpgOocJfmzg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzGg90pXE6BVI2wz5QLYqYG0k_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Size _0023_003Dzd3itp6WDucqFvYgPxGbkKx8_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Size _0023_003Dz7zTJGyUjrjd9AGBmOMnfI1q3I0wl;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GestureEventArgs _0023_003Dz5HIGyAaMqq5oXyI1RrXvlIE_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GestureEventArgs _0023_003Dzp8RRGzo8uPgE8__7jQ_003D_003D;

	[CLSCompliant(false)]
	public uint GestureId
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DztMDrm48ZoJdxtfH_HQ_003D_003D;
		}
	}

	[CLSCompliant(false)]
	public ulong GestureArguments
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzAZ2xyF31Ew_0024CBV3SGINN6l4_003D;
		}
	}

	public Point Location
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzVhqV_0024ZuBzBGeqyIc1w_003D_003D;
		}
	}

	public bool IsBegin => (_0023_003DzUKj93JtR6_0024vN & 1) != 0;

	public bool IsEnd => (_0023_003DzUKj93JtR6_0024vN & 4) != 0;

	public bool IsInertia => (_0023_003DzUKj93JtR6_0024vN & 2) != 0;

	public double RotateAngle
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzlWggRTlUkDBjBVc9BPwLcm8_003D;
		}
	}

	public Point Center
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz25Joc2vbpgOocJfmzg_003D_003D;
		}
	}

	public double ZoomFactor
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzGg90pXE6BVI2wz5QLYqYG0k_003D;
		}
	}

	public Size PanTranslation
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzd3itp6WDucqFvYgPxGbkKx8_003D;
		}
	}

	public Size PanVelocity
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz7zTJGyUjrjd9AGBmOMnfI1q3I0wl;
		}
	}

	public GestureEventArgs LastBeginEvent
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz5HIGyAaMqq5oXyI1RrXvlIE_003D;
		}
	}

	public GestureEventArgs LastEvent
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzp8RRGzo8uPgE8__7jQ_003D_003D;
		}
	}

	internal GestureEventArgs(GestureHandler _0023_003DztHRM7V0_003D, ref GESTUREINFO _0023_003DzgIuoxHYlD0FI3bORBg_003D_003D)
	{
		_0023_003DzUKj93JtR6_0024vN = _0023_003DzgIuoxHYlD0FI3bORBg_003D_003D.dwFlags;
		_0023_003Dzn4WOeDzz0oMl(_0023_003DzgIuoxHYlD0FI3bORBg_003D_003D.dwID);
		_0023_003DzuoevAb4ZLgxp(_0023_003DzgIuoxHYlD0FI3bORBg_003D_003D.ullArguments);
		_0023_003Dzr5hyXymz_634(_0023_003DztHRM7V0_003D._0023_003DzqBy5Mo6bNoWA());
		_0023_003DzdiSdIHfXpS8i(_0023_003DztHRM7V0_003D._0023_003DzKMlM0XSEvASL());
		_0023_003DzvpPrUFpJyAWJ(_0023_003DztHRM7V0_003D._0023_003Dzh7DXocqFKQyn(), ref _0023_003DzgIuoxHYlD0FI3bORBg_003D_003D);
		if (IsBegin)
		{
			_0023_003DzdiSdIHfXpS8i(null);
			_0023_003Dzr5hyXymz_634(null);
		}
	}

	private void _0023_003DzvpPrUFpJyAWJ(IHwndWrapper _0023_003Dz0S0Jl9lP04FX, ref GESTUREINFO _0023_003DzgIuoxHYlD0FI3bORBg_003D_003D)
	{
		_0023_003DzJajQHFZmoQKE(_0023_003Dz0S0Jl9lP04FX.PointToClient(new Point(_0023_003DzgIuoxHYlD0FI3bORBg_003D_003D.ptsLocation.x, _0023_003DzgIuoxHYlD0FI3bORBg_003D_003D.ptsLocation.y)));
		_0023_003DzBBc2FjgLhYr_(Location);
		switch (GestureId)
		{
		case 5u:
		{
			ushort num = (ushort)(IsBegin ? 0 : LastEvent.GestureArguments);
			_0023_003DzJkpi4LEJJDKa(_0023_003DzirAC6ze4AS4guYNendC5yZ5TMzkXpZGjVJvc00mAPC0v._0023_003DzYEYlCZJxFeH2HJyJN3dT0Oynhr02ZTAeYYDk_0024xa_0024lvyH((ushort)(_0023_003DzgIuoxHYlD0FI3bORBg_003D_003D.ullArguments - num)));
			break;
		}
		case 3u:
		{
			Point point = (IsBegin ? Location : LastBeginEvent.Location);
			_0023_003DzBBc2FjgLhYr_(new Point((Location.X + point.X) / 2, (Location.Y + point.Y) / 2));
			_0023_003Dzz0ixn0ZlT5y7(IsBegin ? 1.0 : ((double)_0023_003DzgIuoxHYlD0FI3bORBg_003D_003D.ullArguments / (double)LastEvent.GestureArguments));
			break;
		}
		case 4u:
		{
			_0023_003DzOqzjbGMAugvn(IsBegin ? new Size(0, 0) : new Size(Location.X - LastEvent.Location.X, Location.Y - LastEvent.Location.Y));
			int _0023_003DzKbehXyo_003D = _0023_003DzirAC6ze4AS4guYNendC5yZ5TMzkXpZGjVJvc00mAPC0v._0023_003DzitlDEou_vdz3((long)_0023_003DzgIuoxHYlD0FI3bORBg_003D_003D.ullArguments);
			_0023_003Dz3g5379FBYRL6gTrfVsskfzY_003D(new Size(_0023_003DzirAC6ze4AS4guYNendC5yZ5TMzkXpZGjVJvc00mAPC0v._0023_003DzizbxK0cPigbL(_0023_003DzKbehXyo_003D), _0023_003DzirAC6ze4AS4guYNendC5yZ5TMzkXpZGjVJvc00mAPC0v._0023_003DzsmbrAmDVouwi(_0023_003DzKbehXyo_003D)));
			break;
		}
		}
	}

	private void _0023_003Dzn4WOeDzz0oMl(uint _0023_003DzsLHxXyo_003D)
	{
		_0023_003DztMDrm48ZoJdxtfH_HQ_003D_003D = _0023_003DzsLHxXyo_003D;
	}

	private void _0023_003DzuoevAb4ZLgxp(ulong _0023_003DzsLHxXyo_003D)
	{
		_0023_003DzAZ2xyF31Ew_0024CBV3SGINN6l4_003D = _0023_003DzsLHxXyo_003D;
	}

	private void _0023_003DzJajQHFZmoQKE(Point _0023_003DzsLHxXyo_003D)
	{
		_0023_003DzVhqV_0024ZuBzBGeqyIc1w_003D_003D = _0023_003DzsLHxXyo_003D;
	}

	private void _0023_003DzJkpi4LEJJDKa(double _0023_003DzsLHxXyo_003D)
	{
		_0023_003DzlWggRTlUkDBjBVc9BPwLcm8_003D = _0023_003DzsLHxXyo_003D;
	}

	private void _0023_003DzBBc2FjgLhYr_(Point _0023_003DzsLHxXyo_003D)
	{
		_0023_003Dz25Joc2vbpgOocJfmzg_003D_003D = _0023_003DzsLHxXyo_003D;
	}

	private void _0023_003Dzz0ixn0ZlT5y7(double _0023_003DzsLHxXyo_003D)
	{
		_0023_003DzGg90pXE6BVI2wz5QLYqYG0k_003D = _0023_003DzsLHxXyo_003D;
	}

	private void _0023_003DzOqzjbGMAugvn(Size _0023_003DzsLHxXyo_003D)
	{
		_0023_003Dzd3itp6WDucqFvYgPxGbkKx8_003D = _0023_003DzsLHxXyo_003D;
	}

	private void _0023_003Dz3g5379FBYRL6gTrfVsskfzY_003D(Size _0023_003DzsLHxXyo_003D)
	{
		_0023_003Dz7zTJGyUjrjd9AGBmOMnfI1q3I0wl = _0023_003DzsLHxXyo_003D;
	}

	internal void _0023_003DzdiSdIHfXpS8i(GestureEventArgs _0023_003DzsLHxXyo_003D)
	{
		_0023_003Dz5HIGyAaMqq5oXyI1RrXvlIE_003D = _0023_003DzsLHxXyo_003D;
	}

	internal void _0023_003Dzr5hyXymz_634(GestureEventArgs _0023_003DzsLHxXyo_003D)
	{
		_0023_003Dzp8RRGzo8uPgE8__7jQ_003D_003D = _0023_003DzsLHxXyo_003D;
	}
}
