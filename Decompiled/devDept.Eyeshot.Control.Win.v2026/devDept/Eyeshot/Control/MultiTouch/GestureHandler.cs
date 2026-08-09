using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using devDept.Eyeshot.Control.MultiTouch.Interop;

namespace devDept.Eyeshot.Control.MultiTouch;

public class GestureHandler : Handler
{
	[Serializable]
	private sealed class _0023_003DzP0sFNwY_003D
	{
		public static readonly _0023_003DzP0sFNwY_003D _0023_003Dz84eeg84_003D = new _0023_003DzP0sFNwY_003D();

		internal void _0023_003DzumrxFrJRHkkBMMXfTpzC3oA_003D(object _0023_003Dz7dLpRsk_003D, GestureEventArgs _0023_003Dz1SmHC4c_003D)
		{
		}
	}

	private static class _0023_003DzPAKYrYOI1xrP
	{
		public static readonly uint _0023_003DzVksw1k0_003D = _0023_003DzcVpgg9_00249JTh7(1u, 0u);

		public static readonly uint _0023_003DzWilFfKY_003D = _0023_003DzcVpgg9_00249JTh7(2u, 0u);

		public static readonly uint _0023_003DzzPZt3Jk_003D = _0023_003DzcVpgg9_00249JTh7(4u, 1u);

		public static readonly uint _0023_003Dz9366CJQ_003D = _0023_003DzcVpgg9_00249JTh7(4u, 0u);

		public static readonly uint _0023_003Dz6Z6FKzg_003D = _0023_003DzcVpgg9_00249JTh7(4u, 4u);

		public static readonly uint _0023_003Dz1aRphPbDcRO7 = _0023_003DzcVpgg9_00249JTh7(7u, 0u);

		public static readonly uint _0023_003DzO82VU7Y_003D = _0023_003DzcVpgg9_00249JTh7(5u, 1u);

		public static readonly uint _0023_003Dzt8Cbq9Q_003D = _0023_003DzcVpgg9_00249JTh7(5u, 0u);

		public static readonly uint _0023_003DzqyucBrs_003D = _0023_003DzcVpgg9_00249JTh7(5u, 4u);

		public static readonly uint _0023_003DzEwFGTHMV1yL20ba0_0024Q_003D_003D = _0023_003DzcVpgg9_00249JTh7(6u, 0u);

		public static readonly uint _0023_003DzN1cdwHE_003D = _0023_003DzcVpgg9_00249JTh7(3u, 1u);

		public static readonly uint _0023_003DzvXi1plw_003D = _0023_003DzcVpgg9_00249JTh7(3u, 0u);

		public static readonly uint _0023_003DzQzbGEFc_003D = _0023_003DzcVpgg9_00249JTh7(3u, 4u);
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static readonly EventHandler<GestureEventArgs> _0023_003Dzi8JbZt_f4uNj = _0023_003DzP0sFNwY_003D._0023_003Dz84eeg84_003D._0023_003DzumrxFrJRHkkBMMXfTpzC3oA_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly Dictionary<uint, EventHandler<GestureEventArgs>> _0023_003DzQMgIu3UkbU4l = new Dictionary<uint, EventHandler<GestureEventArgs>>
	{
		{
			_0023_003DzPAKYrYOI1xrP._0023_003DzVksw1k0_003D,
			_0023_003Dzi8JbZt_f4uNj
		},
		{
			_0023_003DzPAKYrYOI1xrP._0023_003DzWilFfKY_003D,
			_0023_003Dzi8JbZt_f4uNj
		},
		{
			_0023_003DzPAKYrYOI1xrP._0023_003DzzPZt3Jk_003D,
			_0023_003Dzi8JbZt_f4uNj
		},
		{
			_0023_003DzPAKYrYOI1xrP._0023_003Dz9366CJQ_003D,
			_0023_003Dzi8JbZt_f4uNj
		},
		{
			_0023_003DzPAKYrYOI1xrP._0023_003Dz6Z6FKzg_003D,
			_0023_003Dzi8JbZt_f4uNj
		},
		{
			_0023_003DzPAKYrYOI1xrP._0023_003Dz1aRphPbDcRO7,
			_0023_003Dzi8JbZt_f4uNj
		},
		{
			_0023_003DzPAKYrYOI1xrP._0023_003DzO82VU7Y_003D,
			_0023_003Dzi8JbZt_f4uNj
		},
		{
			_0023_003DzPAKYrYOI1xrP._0023_003Dzt8Cbq9Q_003D,
			_0023_003Dzi8JbZt_f4uNj
		},
		{
			_0023_003DzPAKYrYOI1xrP._0023_003DzqyucBrs_003D,
			_0023_003Dzi8JbZt_f4uNj
		},
		{
			_0023_003DzPAKYrYOI1xrP._0023_003DzEwFGTHMV1yL20ba0_0024Q_003D_003D,
			_0023_003Dzi8JbZt_f4uNj
		},
		{
			_0023_003DzPAKYrYOI1xrP._0023_003DzN1cdwHE_003D,
			_0023_003Dzi8JbZt_f4uNj
		},
		{
			_0023_003DzPAKYrYOI1xrP._0023_003DzvXi1plw_003D,
			_0023_003Dzi8JbZt_f4uNj
		},
		{
			_0023_003DzPAKYrYOI1xrP._0023_003DzQzbGEFc_003D,
			_0023_003Dzi8JbZt_f4uNj
		}
	};

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GestureEventArgs _0023_003Dz5HIGyAaMqq5oXyI1RrXvlIE_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GestureEventArgs _0023_003Dzp8RRGzo8uPgE8__7jQ_003D_003D;

	public event EventHandler<GestureEventArgs> Begin
	{
		add
		{
			Dictionary<uint, EventHandler<GestureEventArgs>> dictionary = _0023_003DzQMgIu3UkbU4l;
			uint _0023_003DzVksw1k0_003D = _0023_003DzPAKYrYOI1xrP._0023_003DzVksw1k0_003D;
			dictionary[_0023_003DzVksw1k0_003D] = (EventHandler<GestureEventArgs>)Delegate.Combine(dictionary[_0023_003DzVksw1k0_003D], value);
		}
		remove
		{
			Dictionary<uint, EventHandler<GestureEventArgs>> dictionary = _0023_003DzQMgIu3UkbU4l;
			uint _0023_003DzVksw1k0_003D = _0023_003DzPAKYrYOI1xrP._0023_003DzVksw1k0_003D;
			dictionary[_0023_003DzVksw1k0_003D] = (EventHandler<GestureEventArgs>)Delegate.Remove(dictionary[_0023_003DzVksw1k0_003D], value);
		}
	}

	public event EventHandler<GestureEventArgs> End
	{
		add
		{
			Dictionary<uint, EventHandler<GestureEventArgs>> dictionary = _0023_003DzQMgIu3UkbU4l;
			uint _0023_003DzWilFfKY_003D = _0023_003DzPAKYrYOI1xrP._0023_003DzWilFfKY_003D;
			dictionary[_0023_003DzWilFfKY_003D] = (EventHandler<GestureEventArgs>)Delegate.Combine(dictionary[_0023_003DzWilFfKY_003D], value);
		}
		remove
		{
			Dictionary<uint, EventHandler<GestureEventArgs>> dictionary = _0023_003DzQMgIu3UkbU4l;
			uint _0023_003DzWilFfKY_003D = _0023_003DzPAKYrYOI1xrP._0023_003DzWilFfKY_003D;
			dictionary[_0023_003DzWilFfKY_003D] = (EventHandler<GestureEventArgs>)Delegate.Remove(dictionary[_0023_003DzWilFfKY_003D], value);
		}
	}

	public event EventHandler<GestureEventArgs> PanBegin
	{
		add
		{
			Dictionary<uint, EventHandler<GestureEventArgs>> dictionary = _0023_003DzQMgIu3UkbU4l;
			uint _0023_003DzzPZt3Jk_003D = _0023_003DzPAKYrYOI1xrP._0023_003DzzPZt3Jk_003D;
			dictionary[_0023_003DzzPZt3Jk_003D] = (EventHandler<GestureEventArgs>)Delegate.Combine(dictionary[_0023_003DzzPZt3Jk_003D], value);
		}
		remove
		{
			Dictionary<uint, EventHandler<GestureEventArgs>> dictionary = _0023_003DzQMgIu3UkbU4l;
			uint _0023_003DzzPZt3Jk_003D = _0023_003DzPAKYrYOI1xrP._0023_003DzzPZt3Jk_003D;
			dictionary[_0023_003DzzPZt3Jk_003D] = (EventHandler<GestureEventArgs>)Delegate.Remove(dictionary[_0023_003DzzPZt3Jk_003D], value);
		}
	}

	public event EventHandler<GestureEventArgs> Pan
	{
		add
		{
			Dictionary<uint, EventHandler<GestureEventArgs>> dictionary = _0023_003DzQMgIu3UkbU4l;
			uint _0023_003Dz9366CJQ_003D = _0023_003DzPAKYrYOI1xrP._0023_003Dz9366CJQ_003D;
			dictionary[_0023_003Dz9366CJQ_003D] = (EventHandler<GestureEventArgs>)Delegate.Combine(dictionary[_0023_003Dz9366CJQ_003D], value);
		}
		remove
		{
			Dictionary<uint, EventHandler<GestureEventArgs>> dictionary = _0023_003DzQMgIu3UkbU4l;
			uint _0023_003Dz9366CJQ_003D = _0023_003DzPAKYrYOI1xrP._0023_003Dz9366CJQ_003D;
			dictionary[_0023_003Dz9366CJQ_003D] = (EventHandler<GestureEventArgs>)Delegate.Remove(dictionary[_0023_003Dz9366CJQ_003D], value);
		}
	}

	public event EventHandler<GestureEventArgs> PanEnd
	{
		add
		{
			Dictionary<uint, EventHandler<GestureEventArgs>> dictionary = _0023_003DzQMgIu3UkbU4l;
			uint _0023_003Dz6Z6FKzg_003D = _0023_003DzPAKYrYOI1xrP._0023_003Dz6Z6FKzg_003D;
			dictionary[_0023_003Dz6Z6FKzg_003D] = (EventHandler<GestureEventArgs>)Delegate.Combine(dictionary[_0023_003Dz6Z6FKzg_003D], value);
		}
		remove
		{
			Dictionary<uint, EventHandler<GestureEventArgs>> dictionary = _0023_003DzQMgIu3UkbU4l;
			uint _0023_003Dz6Z6FKzg_003D = _0023_003DzPAKYrYOI1xrP._0023_003Dz6Z6FKzg_003D;
			dictionary[_0023_003Dz6Z6FKzg_003D] = (EventHandler<GestureEventArgs>)Delegate.Remove(dictionary[_0023_003Dz6Z6FKzg_003D], value);
		}
	}

	public event EventHandler<GestureEventArgs> PressAndTap
	{
		add
		{
			Dictionary<uint, EventHandler<GestureEventArgs>> dictionary = _0023_003DzQMgIu3UkbU4l;
			uint _0023_003Dz1aRphPbDcRO = _0023_003DzPAKYrYOI1xrP._0023_003Dz1aRphPbDcRO7;
			dictionary[_0023_003Dz1aRphPbDcRO] = (EventHandler<GestureEventArgs>)Delegate.Combine(dictionary[_0023_003Dz1aRphPbDcRO], value);
		}
		remove
		{
			Dictionary<uint, EventHandler<GestureEventArgs>> dictionary = _0023_003DzQMgIu3UkbU4l;
			uint _0023_003Dz1aRphPbDcRO = _0023_003DzPAKYrYOI1xrP._0023_003Dz1aRphPbDcRO7;
			dictionary[_0023_003Dz1aRphPbDcRO] = (EventHandler<GestureEventArgs>)Delegate.Remove(dictionary[_0023_003Dz1aRphPbDcRO], value);
		}
	}

	public event EventHandler<GestureEventArgs> RotateBegin
	{
		add
		{
			Dictionary<uint, EventHandler<GestureEventArgs>> dictionary = _0023_003DzQMgIu3UkbU4l;
			uint _0023_003DzO82VU7Y_003D = _0023_003DzPAKYrYOI1xrP._0023_003DzO82VU7Y_003D;
			dictionary[_0023_003DzO82VU7Y_003D] = (EventHandler<GestureEventArgs>)Delegate.Combine(dictionary[_0023_003DzO82VU7Y_003D], value);
		}
		remove
		{
			Dictionary<uint, EventHandler<GestureEventArgs>> dictionary = _0023_003DzQMgIu3UkbU4l;
			uint _0023_003DzO82VU7Y_003D = _0023_003DzPAKYrYOI1xrP._0023_003DzO82VU7Y_003D;
			dictionary[_0023_003DzO82VU7Y_003D] = (EventHandler<GestureEventArgs>)Delegate.Remove(dictionary[_0023_003DzO82VU7Y_003D], value);
		}
	}

	public event EventHandler<GestureEventArgs> Rotate
	{
		add
		{
			Dictionary<uint, EventHandler<GestureEventArgs>> dictionary = _0023_003DzQMgIu3UkbU4l;
			uint _0023_003Dzt8Cbq9Q_003D = _0023_003DzPAKYrYOI1xrP._0023_003Dzt8Cbq9Q_003D;
			dictionary[_0023_003Dzt8Cbq9Q_003D] = (EventHandler<GestureEventArgs>)Delegate.Combine(dictionary[_0023_003Dzt8Cbq9Q_003D], value);
		}
		remove
		{
			Dictionary<uint, EventHandler<GestureEventArgs>> dictionary = _0023_003DzQMgIu3UkbU4l;
			uint _0023_003Dzt8Cbq9Q_003D = _0023_003DzPAKYrYOI1xrP._0023_003Dzt8Cbq9Q_003D;
			dictionary[_0023_003Dzt8Cbq9Q_003D] = (EventHandler<GestureEventArgs>)Delegate.Remove(dictionary[_0023_003Dzt8Cbq9Q_003D], value);
		}
	}

	public event EventHandler<GestureEventArgs> RotateEnd
	{
		add
		{
			Dictionary<uint, EventHandler<GestureEventArgs>> dictionary = _0023_003DzQMgIu3UkbU4l;
			uint _0023_003DzqyucBrs_003D = _0023_003DzPAKYrYOI1xrP._0023_003DzqyucBrs_003D;
			dictionary[_0023_003DzqyucBrs_003D] = (EventHandler<GestureEventArgs>)Delegate.Combine(dictionary[_0023_003DzqyucBrs_003D], value);
		}
		remove
		{
			Dictionary<uint, EventHandler<GestureEventArgs>> dictionary = _0023_003DzQMgIu3UkbU4l;
			uint _0023_003DzqyucBrs_003D = _0023_003DzPAKYrYOI1xrP._0023_003DzqyucBrs_003D;
			dictionary[_0023_003DzqyucBrs_003D] = (EventHandler<GestureEventArgs>)Delegate.Remove(dictionary[_0023_003DzqyucBrs_003D], value);
		}
	}

	public event EventHandler<GestureEventArgs> TwoFingerTap
	{
		add
		{
			Dictionary<uint, EventHandler<GestureEventArgs>> dictionary = _0023_003DzQMgIu3UkbU4l;
			uint _0023_003DzEwFGTHMV1yL20ba0_0024Q_003D_003D = _0023_003DzPAKYrYOI1xrP._0023_003DzEwFGTHMV1yL20ba0_0024Q_003D_003D;
			dictionary[_0023_003DzEwFGTHMV1yL20ba0_0024Q_003D_003D] = (EventHandler<GestureEventArgs>)Delegate.Combine(dictionary[_0023_003DzEwFGTHMV1yL20ba0_0024Q_003D_003D], value);
		}
		remove
		{
			Dictionary<uint, EventHandler<GestureEventArgs>> dictionary = _0023_003DzQMgIu3UkbU4l;
			uint _0023_003DzEwFGTHMV1yL20ba0_0024Q_003D_003D = _0023_003DzPAKYrYOI1xrP._0023_003DzEwFGTHMV1yL20ba0_0024Q_003D_003D;
			dictionary[_0023_003DzEwFGTHMV1yL20ba0_0024Q_003D_003D] = (EventHandler<GestureEventArgs>)Delegate.Remove(dictionary[_0023_003DzEwFGTHMV1yL20ba0_0024Q_003D_003D], value);
		}
	}

	public event EventHandler<GestureEventArgs> ZoomBegin
	{
		add
		{
			Dictionary<uint, EventHandler<GestureEventArgs>> dictionary = _0023_003DzQMgIu3UkbU4l;
			uint _0023_003DzN1cdwHE_003D = _0023_003DzPAKYrYOI1xrP._0023_003DzN1cdwHE_003D;
			dictionary[_0023_003DzN1cdwHE_003D] = (EventHandler<GestureEventArgs>)Delegate.Combine(dictionary[_0023_003DzN1cdwHE_003D], value);
		}
		remove
		{
			Dictionary<uint, EventHandler<GestureEventArgs>> dictionary = _0023_003DzQMgIu3UkbU4l;
			uint _0023_003DzN1cdwHE_003D = _0023_003DzPAKYrYOI1xrP._0023_003DzN1cdwHE_003D;
			dictionary[_0023_003DzN1cdwHE_003D] = (EventHandler<GestureEventArgs>)Delegate.Remove(dictionary[_0023_003DzN1cdwHE_003D], value);
		}
	}

	public event EventHandler<GestureEventArgs> Zoom
	{
		add
		{
			Dictionary<uint, EventHandler<GestureEventArgs>> dictionary = _0023_003DzQMgIu3UkbU4l;
			uint _0023_003DzvXi1plw_003D = _0023_003DzPAKYrYOI1xrP._0023_003DzvXi1plw_003D;
			dictionary[_0023_003DzvXi1plw_003D] = (EventHandler<GestureEventArgs>)Delegate.Combine(dictionary[_0023_003DzvXi1plw_003D], value);
		}
		remove
		{
			Dictionary<uint, EventHandler<GestureEventArgs>> dictionary = _0023_003DzQMgIu3UkbU4l;
			uint _0023_003DzvXi1plw_003D = _0023_003DzPAKYrYOI1xrP._0023_003DzvXi1plw_003D;
			dictionary[_0023_003DzvXi1plw_003D] = (EventHandler<GestureEventArgs>)Delegate.Remove(dictionary[_0023_003DzvXi1plw_003D], value);
		}
	}

	public event EventHandler<GestureEventArgs> ZoomEnd
	{
		add
		{
			Dictionary<uint, EventHandler<GestureEventArgs>> dictionary = _0023_003DzQMgIu3UkbU4l;
			uint _0023_003DzQzbGEFc_003D = _0023_003DzPAKYrYOI1xrP._0023_003DzQzbGEFc_003D;
			dictionary[_0023_003DzQzbGEFc_003D] = (EventHandler<GestureEventArgs>)Delegate.Combine(dictionary[_0023_003DzQzbGEFc_003D], value);
		}
		remove
		{
			Dictionary<uint, EventHandler<GestureEventArgs>> dictionary = _0023_003DzQMgIu3UkbU4l;
			uint _0023_003DzQzbGEFc_003D = _0023_003DzPAKYrYOI1xrP._0023_003DzQzbGEFc_003D;
			dictionary[_0023_003DzQzbGEFc_003D] = (EventHandler<GestureEventArgs>)Delegate.Remove(dictionary[_0023_003DzQzbGEFc_003D], value);
		}
	}

	internal GestureHandler(IHwndWrapper _0023_003Dz0S0Jl9lP04FX)
		: base(_0023_003Dz0S0Jl9lP04FX)
	{
	}

	private static uint _0023_003DzcVpgg9_00249JTh7(uint _0023_003Dz5ahpB3g_003D, uint _0023_003DzfVIARlg_003D)
	{
		return (_0023_003Dz5ahpB3g_003D << 3) + ((_0023_003Dz5ahpB3g_003D != 6 && _0023_003Dz5ahpB3g_003D != 7 && _0023_003Dz5ahpB3g_003D != 1 && _0023_003Dz5ahpB3g_003D != 2) ? (_0023_003DzfVIARlg_003D & 5) : 0);
	}

	protected override bool SetHWndTouchInfo()
	{
		GESTURECONFIG[] _0023_003DzT16gDfI_hvmn = new GESTURECONFIG[1]
		{
			new GESTURECONFIG
			{
				dwID = 0u,
				dwWant = 1u,
				dwBlock = 0u
			}
		};
		return _0023_003DzirAC6ze4AS4guYNendC5yZ5TMzkXpZGjVJvc00mAPC0v._0023_003Dz1dxd_00247YHT5vY(base.ControlHandle, 0u, 1u, _0023_003DzT16gDfI_hvmn, (uint)Marshal.SizeOf(typeof(GESTURECONFIG)));
	}

	internal GestureEventArgs _0023_003DzKMlM0XSEvASL()
	{
		return _0023_003Dz5HIGyAaMqq5oXyI1RrXvlIE_003D;
	}

	internal void _0023_003DzdiSdIHfXpS8i(GestureEventArgs _0023_003DzsLHxXyo_003D)
	{
		_0023_003Dz5HIGyAaMqq5oXyI1RrXvlIE_003D = _0023_003DzsLHxXyo_003D;
	}

	internal GestureEventArgs _0023_003DzqBy5Mo6bNoWA()
	{
		return _0023_003Dzp8RRGzo8uPgE8__7jQ_003D_003D;
	}

	internal void _0023_003Dzr5hyXymz_634(GestureEventArgs _0023_003DzsLHxXyo_003D)
	{
		_0023_003Dzp8RRGzo8uPgE8__7jQ_003D_003D = _0023_003DzsLHxXyo_003D;
	}

	[CLSCompliant(false)]
	protected override uint WindowProc(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam)
	{
		if ((long)msg != 281)
		{
			return 0u;
		}
		GESTUREINFO _0023_003Dz8YZToW83wH5j = new GESTUREINFO
		{
			cbSize = (uint)Marshal.SizeOf(typeof(GESTUREINFO))
		};
		if (!_0023_003DzirAC6ze4AS4guYNendC5yZ5TMzkXpZGjVJvc00mAPC0v._0023_003DzB_0024b_0024Gt6nyAdQ(lParam, ref _0023_003Dz8YZToW83wH5j))
		{
			throw new Exception(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348587846));
		}
		GestureEventArgs e = new GestureEventArgs(this, ref _0023_003Dz8YZToW83wH5j);
		try
		{
			_0023_003DzQMgIu3UkbU4l[_0023_003DzcVpgg9_00249JTh7(_0023_003Dz8YZToW83wH5j.dwID, _0023_003Dz8YZToW83wH5j.dwFlags)](this, e);
		}
		catch (ArgumentOutOfRangeException)
		{
		}
		_0023_003Dzr5hyXymz_634(e);
		if (e.IsBegin)
		{
			_0023_003DzdiSdIHfXpS8i(e);
		}
		_0023_003DzirAC6ze4AS4guYNendC5yZ5TMzkXpZGjVJvc00mAPC0v._0023_003Dz_0024F4IK44IRRf3(lParam);
		return 1u;
	}

	public void Detach()
	{
	}
}
