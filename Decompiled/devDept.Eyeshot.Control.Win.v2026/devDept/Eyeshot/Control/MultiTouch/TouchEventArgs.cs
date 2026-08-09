using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using devDept.Eyeshot.Control.MultiTouch.Interop;

namespace devDept.Eyeshot.Control.MultiTouch;

public class TouchEventArgs : EventArgs
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly IHwndWrapper _0023_003DzxIjbZNskco_0024P;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly float _0023_003DzZXSqjjzTmTyn;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly float _0023_003DzQ0PH8UnHK_q7;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Point _0023_003DzVhqV_0024ZuBzBGeqyIc1w_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dz4vf_00242fAisxuFfHTuOA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzJa5aFZMWnkbg58p8Xg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DziS2Mv_PT_0024FM7z08b3g_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DateTime _0023_003Dz9inDK3jwFkt6F973sA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzfqxASGkTSXMPzH3pSg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Size? _0023_003DzaCknSSmL2Uw85UIUCQ_003D_003D;

	public Point Location
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzVhqV_0024ZuBzBGeqyIc1w_003D_003D;
		}
	}

	public int Id
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz4vf_00242fAisxuFfHTuOA_003D_003D;
		}
	}

	public int Flags
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzJa5aFZMWnkbg58p8Xg_003D_003D;
		}
	}

	public int Mask
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DziS2Mv_PT_0024FM7z08b3g_003D_003D;
		}
	}

	public DateTime AbsoluteTime
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz9inDK3jwFkt6F973sA_003D_003D;
		}
	}

	public int Time
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzfqxASGkTSXMPzH3pSg_003D_003D;
		}
	}

	public Size? ContactSize
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzaCknSSmL2Uw85UIUCQ_003D_003D;
		}
	}

	public bool IsPrimaryContact => (Flags & 0x10) != 0;

	public bool IsTouchMove => _0023_003DzomGNYZzm5wzR(1);

	public bool IsTouchDown => _0023_003DzomGNYZzm5wzR(2);

	public bool IsTouchUp => _0023_003DzomGNYZzm5wzR(4);

	public bool IsTouchInRange => _0023_003DzomGNYZzm5wzR(8);

	public bool IsTouchNoCoalesce => _0023_003DzomGNYZzm5wzR(32);

	public bool IsTouchPen => _0023_003DzomGNYZzm5wzR(64);

	public bool IsTouchPalm => _0023_003DzomGNYZzm5wzR(128);

	internal TouchEventArgs(IHwndWrapper _0023_003Dz0S0Jl9lP04FX, float _0023_003Dz4l1xEQk_003D, float _0023_003Dz9Bea6Z0_003D, ref TOUCHINPUT _0023_003DzDwaCsfqrWlQm)
	{
		_0023_003DzxIjbZNskco_0024P = _0023_003Dz0S0Jl9lP04FX;
		_0023_003DzZXSqjjzTmTyn = 96f / _0023_003Dz4l1xEQk_003D;
		_0023_003DzQ0PH8UnHK_q7 = 96f / _0023_003Dz9Bea6Z0_003D;
		_0023_003Dz3KZAjcOXfPAx(ref _0023_003DzDwaCsfqrWlQm);
	}

	private bool _0023_003DzomGNYZzm5wzR(int _0023_003DzsLHxXyo_003D)
	{
		return (Flags & _0023_003DzsLHxXyo_003D) != 0;
	}

	private void _0023_003Dz3KZAjcOXfPAx(ref TOUCHINPUT _0023_003DzDwaCsfqrWlQm)
	{
		if ((_0023_003DzDwaCsfqrWlQm.dwMask & 4) != 0)
		{
			_0023_003DzMA_0024Hns_0024XoiwE(new Size(_0023_003DzPk6YxsImZbTP(_0023_003DzDwaCsfqrWlQm.cxContact / 100), _0023_003DzxaMmc8U6J4t7(_0023_003DzDwaCsfqrWlQm.cyContact / 100)));
		}
		_0023_003DzcblkeKE_003D(_0023_003DzDwaCsfqrWlQm.dwID);
		Point point = _0023_003DzxIjbZNskco_0024P.PointToClient(new Point(_0023_003DzDwaCsfqrWlQm.x / 100, _0023_003DzDwaCsfqrWlQm.y / 100));
		_0023_003DzJajQHFZmoQKE(new Point(_0023_003DzPk6YxsImZbTP(point.X), _0023_003DzxaMmc8U6J4t7(point.Y)));
		_0023_003DzvrM9yxU_003D(_0023_003DzDwaCsfqrWlQm.dwTime);
		TimeSpan timeSpan = TimeSpan.FromMilliseconds(Environment.TickCount - _0023_003DzDwaCsfqrWlQm.dwTime);
		_0023_003DzxPpdhxZARR8F(DateTime.Now - timeSpan);
		_0023_003Dzb9NEgwYghacF(_0023_003DzDwaCsfqrWlQm.dwMask);
		_0023_003Dz6zIkQNc_003D(_0023_003DzDwaCsfqrWlQm.dwFlags);
	}

	private int _0023_003DzPk6YxsImZbTP(int _0023_003DzsLHxXyo_003D)
	{
		return _0023_003DzsLHxXyo_003D;
	}

	private int _0023_003DzxaMmc8U6J4t7(int _0023_003DzsLHxXyo_003D)
	{
		return _0023_003DzsLHxXyo_003D;
	}

	private void _0023_003DzJajQHFZmoQKE(Point _0023_003DzsLHxXyo_003D)
	{
		_0023_003DzVhqV_0024ZuBzBGeqyIc1w_003D_003D = _0023_003DzsLHxXyo_003D;
	}

	private void _0023_003DzcblkeKE_003D(int _0023_003DzsLHxXyo_003D)
	{
		_0023_003Dz4vf_00242fAisxuFfHTuOA_003D_003D = _0023_003DzsLHxXyo_003D;
	}

	private void _0023_003Dz6zIkQNc_003D(int _0023_003DzsLHxXyo_003D)
	{
		_0023_003DzJa5aFZMWnkbg58p8Xg_003D_003D = _0023_003DzsLHxXyo_003D;
	}

	private void _0023_003Dzb9NEgwYghacF(int _0023_003DzsLHxXyo_003D)
	{
		_0023_003DziS2Mv_PT_0024FM7z08b3g_003D_003D = _0023_003DzsLHxXyo_003D;
	}

	private void _0023_003DzxPpdhxZARR8F(DateTime _0023_003DzsLHxXyo_003D)
	{
		_0023_003Dz9inDK3jwFkt6F973sA_003D_003D = _0023_003DzsLHxXyo_003D;
	}

	private void _0023_003DzvrM9yxU_003D(int _0023_003DzsLHxXyo_003D)
	{
		_0023_003DzfqxASGkTSXMPzH3pSg_003D_003D = _0023_003DzsLHxXyo_003D;
	}

	private void _0023_003DzMA_0024Hns_0024XoiwE(Size? _0023_003DzsLHxXyo_003D)
	{
		_0023_003DzaCknSSmL2Uw85UIUCQ_003D_003D = _0023_003DzsLHxXyo_003D;
	}
}
