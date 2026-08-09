using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;

namespace devDept.Eyeshot.Control.MultiTouch;

public abstract class Handler
{
	[Serializable]
	private sealed class _0023_003DzP0sFNwY_003D
	{
		public static readonly _0023_003DzP0sFNwY_003D _0023_003Dz84eeg84_003D = new _0023_003DzP0sFNwY_003D();

		public static EventHandler<_0023_003Dz_EkGrGLIPQQmfLRjHvi_0024dNjyjzY6wyYo66v_0024LUo_003D> _0023_003Dz2mENj0gBN8vary2WBg_003D_003D;

		internal void _0023_003DzI81xPiTrEwaYG_jaTA_003D_003D(object _0023_003Dz7dLpRsk_003D, _0023_003Dz_EkGrGLIPQQmfLRjHvi_0024dNjyjzY6wyYo66v_0024LUo_003D _0023_003Dz1SmHC4c_003D)
		{
		}
	}

	[Serializable]
	private sealed class _0023_003DzYHaYBmfhA7N6Ei6xYg_003D_003D<_0023_003DzWoS2eJk_003D> where _0023_003DzWoS2eJk_003D : Handler
	{
		public static readonly _0023_003DzYHaYBmfhA7N6Ei6xYg_003D_003D<_0023_003DzWoS2eJk_003D> _0023_003Dz84eeg84_003D = new _0023_003DzYHaYBmfhA7N6Ei6xYg_003D_003D<_0023_003DzWoS2eJk_003D>();

		public static EventHandler _0023_003DzJuvbzOkcJYLORKzQuQ_003D_003D;

		internal void _0023_003DzagHe_mXANBi2IYuj8w_003D_003D(object _0023_003Dz7dLpRsk_003D, EventArgs _0023_003Dz1SmHC4c_003D)
		{
			_0023_003Dz2EeEWwA_003D(_0023_003Dz7dLpRsk_003D);
		}
	}

	public static class DigitizerCapabilities
	{
		public static DigitizerStatus Status => (DigitizerStatus)_0023_003DzirAC6ze4AS4guYNendC5yZ5TMzkXpZGjVJvc00mAPC0v._0023_003Dz7zcHXTcW2z_00247vpDbkSCcSwU_003D((_0023_003DzirAC6ze4AS4guYNendC5yZ5TMzkXpZGjVJvc00mAPC0v._0023_003DztnVUK3HdJg3cERCIBQ_003D_003D)94);

		public static int MaxumumTouches => _0023_003DzirAC6ze4AS4guYNendC5yZ5TMzkXpZGjVJvc00mAPC0v._0023_003Dz7zcHXTcW2z_00247vpDbkSCcSwU_003D((_0023_003DzirAC6ze4AS4guYNendC5yZ5TMzkXpZGjVJvc00mAPC0v._0023_003DztnVUK3HdJg3cERCIBQ_003D_003D)95);

		public static bool IsIntegratedTouch => (Status & DigitizerStatus.IntegratedTouch) != 0;

		public static bool IsExternalTouch => (Status & DigitizerStatus.ExternalTouch) != 0;

		public static bool IsIntegratedPan => (Status & DigitizerStatus.IntegratedPan) != 0;

		public static bool IsExternalPan => (Status & DigitizerStatus.ExternalPan) != 0;

		public static bool IsMultiInput => (Status & DigitizerStatus.MultiInput) != 0;

		public static bool IsStackReady => (Status & DigitizerStatus.StackReady) != 0;

		public static bool IsMultiTouchReady => (Status & (DigitizerStatus.MultiInput | DigitizerStatus.StackReady)) != 0;
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly IHwndWrapper _0023_003DzxIjbZNskco_0024P;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static readonly Dictionary<object, object> _0023_003DzJAUf4pnk2ZyV = new Dictionary<object, object>();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DzirAC6ze4AS4guYNendC5yZ5TMzkXpZGjVJvc00mAPC0v._0023_003DzVMxxQ8H7UieE _0023_003DzBfE7DBemfcrU;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IntPtr _0023_003DzcMhO6ZbFGhb6;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float _0023_003DzZdIkIKl_gXa8WOnizQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float _0023_003DzDPjrL250s3Q3NUNMfA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private EventHandler<GestureNotifyEventArgs> _0023_003DzrWBcEOxnAdTb;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private EventHandler<_0023_003Dz_EkGrGLIPQQmfLRjHvi_0024dNjyjzY6wyYo66v_0024LUo_003D> _0023_003DzoZGswSI_003D;

	protected IntPtr ControlHandle
	{
		get
		{
			if (!_0023_003DzxIjbZNskco_0024P.IsHandleCreated)
			{
				return IntPtr.Zero;
			}
			return _0023_003DzxIjbZNskco_0024P.Handle;
		}
	}

	public float DpiX
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzZdIkIKl_gXa8WOnizQ_003D_003D;
		}
		[CompilerGenerated]
		protected set
		{
			_0023_003DzZdIkIKl_gXa8WOnizQ_003D_003D = value;
		}
	}

	public float DpiY
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzDPjrL250s3Q3NUNMfA_003D_003D;
		}
		[CompilerGenerated]
		protected set
		{
			_0023_003DzDPjrL250s3Q3NUNMfA_003D_003D = value;
		}
	}

	public event EventHandler<GestureNotifyEventArgs> GestureNotify
	{
		[CompilerGenerated]
		add
		{
			EventHandler<GestureNotifyEventArgs> eventHandler = _0023_003DzrWBcEOxnAdTb;
			EventHandler<GestureNotifyEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<GestureNotifyEventArgs> value2 = (EventHandler<GestureNotifyEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref _0023_003DzrWBcEOxnAdTb, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<GestureNotifyEventArgs> eventHandler = _0023_003DzrWBcEOxnAdTb;
			EventHandler<GestureNotifyEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<GestureNotifyEventArgs> value2 = (EventHandler<GestureNotifyEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref _0023_003DzrWBcEOxnAdTb, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	internal Handler(IHwndWrapper _0023_003Dz0S0Jl9lP04FX)
	{
		_0023_003DzxIjbZNskco_0024P = _0023_003Dz0S0Jl9lP04FX;
		if (_0023_003DzxIjbZNskco_0024P.IsHandleCreated)
		{
			_0023_003DzS9sBW50_003D();
		}
		else
		{
			_0023_003DzxIjbZNskco_0024P.HandleCreated += _0023_003DzmZquqHsuO0k4Vjscfw_003D_003D;
		}
	}

	protected abstract bool SetHWndTouchInfo();

	[CLSCompliant(false)]
	protected virtual uint WindowProc(IntPtr hWnd, int msg, IntPtr wparam, IntPtr lparam)
	{
		return 0u;
	}

	internal static T _0023_003Dz2u08Mcc_003D<T>(IHwndWrapper _0023_003Dz0S0Jl9lP04FX, out bool _0023_003DzNhabmH8_003D) where T : Handler
	{
		if (_0023_003DzJAUf4pnk2ZyV.ContainsKey(_0023_003Dz0S0Jl9lP04FX.Source))
		{
			_0023_003DzNhabmH8_003D = false;
			return (T)_0023_003DzJAUf4pnk2ZyV[_0023_003Dz0S0Jl9lP04FX.Source];
		}
		_0023_003Dz0S0Jl9lP04FX.HandleDestroyed += _0023_003DzYHaYBmfhA7N6Ei6xYg_003D_003D<T>._0023_003Dz84eeg84_003D._0023_003DzagHe_mXANBi2IYuj8w_003D_003D;
		T val = Activator.CreateInstance(typeof(T), BindingFlags.Instance | BindingFlags.Public | BindingFlags.InvokeMethod | BindingFlags.CreateInstance, null, new object[1] { _0023_003Dz0S0Jl9lP04FX }, Thread.CurrentThread.CurrentCulture) as T;
		_0023_003DzJAUf4pnk2ZyV.Add(_0023_003Dz0S0Jl9lP04FX.Source, val);
		_0023_003DzNhabmH8_003D = true;
		return val;
	}

	internal static void _0023_003Dz2EeEWwA_003D(object _0023_003DztHRM7V0_003D)
	{
		if (_0023_003DztHRM7V0_003D is TouchHandler touchHandler)
		{
			if (touchHandler.ParentWF != null)
			{
				_0023_003DzJAUf4pnk2ZyV.Remove(touchHandler.ParentWF._0023_003DzZUohT3Y_003D);
			}
		}
		else if (_0023_003DztHRM7V0_003D is _0023_003DzmLo13MFX3OoqXvo7lKqFE7GrCiPCD_QTAO90IGn51jAwKE7T3Y7ycJk_003D _0023_003DzmLo13MFX3OoqXvo7lKqFE7GrCiPCD_QTAO90IGn51jAwKE7T3Y7ycJk_003D2)
		{
			_0023_003DzJAUf4pnk2ZyV.Remove(_0023_003DzmLo13MFX3OoqXvo7lKqFE7GrCiPCD_QTAO90IGn51jAwKE7T3Y7ycJk_003D2.Handle);
		}
		else
		{
			_0023_003DzJAUf4pnk2ZyV.Remove(_0023_003DztHRM7V0_003D);
		}
	}

	private void _0023_003DzS9sBW50_003D()
	{
		if (!SetHWndTouchInfo())
		{
			throw new NotSupportedException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348587873));
		}
		_0023_003DzBfE7DBemfcrU = _0023_003DzQ9xuee7De1Ma;
		_0023_003DzcMhO6ZbFGhb6 = ((IntPtr.Size == 4) ? _0023_003DzirAC6ze4AS4guYNendC5yZ5TMzkXpZGjVJvc00mAPC0v._0023_003Dz2ZhGvdE_003D(_0023_003DzxIjbZNskco_0024P.Handle, -4, _0023_003DzBfE7DBemfcrU) : _0023_003DzirAC6ze4AS4guYNendC5yZ5TMzkXpZGjVJvc00mAPC0v._0023_003Dz006MPQkKdlcK(_0023_003DzxIjbZNskco_0024P.Handle, -4, _0023_003DzBfE7DBemfcrU));
		using (System.Drawing.Graphics graphics = System.Drawing.Graphics.FromHwnd(_0023_003DzxIjbZNskco_0024P.Handle))
		{
			DpiX = graphics.DpiX;
			DpiY = graphics.DpiY;
		}
		_0023_003DzHKs9aEm3O9Uc(_0023_003DzP0sFNwY_003D._0023_003Dz84eeg84_003D._0023_003DzI81xPiTrEwaYG_jaTA_003D_003D);
	}

	private uint _0023_003DzQ9xuee7De1Ma(IntPtr _0023_003DzVg1BG_0024g_003D, int _0023_003Dz1xK0BLg_003D, IntPtr _0023_003DzpZzvkAs_003D, IntPtr _0023_003DzafzCBBQ_003D)
	{
		_0023_003DzoZGswSI_003D(this, new _0023_003Dz_EkGrGLIPQQmfLRjHvi_0024dNjyjzY6wyYo66v_0024LUo_003D(_0023_003DzVg1BG_0024g_003D, _0023_003Dz1xK0BLg_003D, _0023_003DzpZzvkAs_003D, _0023_003DzafzCBBQ_003D));
		if ((long)_0023_003Dz1xK0BLg_003D == 282 && _0023_003DzrWBcEOxnAdTb != null)
		{
			_0023_003DzrWBcEOxnAdTb(this, new GestureNotifyEventArgs(_0023_003DzafzCBBQ_003D));
		}
		else
		{
			uint num = WindowProc(_0023_003DzVg1BG_0024g_003D, _0023_003Dz1xK0BLg_003D, _0023_003DzpZzvkAs_003D, _0023_003DzafzCBBQ_003D);
			if (num != 0)
			{
				return num;
			}
		}
		return _0023_003DzirAC6ze4AS4guYNendC5yZ5TMzkXpZGjVJvc00mAPC0v._0023_003DzoC_gT1LhHqeh(_0023_003DzcMhO6ZbFGhb6, _0023_003DzVg1BG_0024g_003D, _0023_003Dz1xK0BLg_003D, _0023_003DzpZzvkAs_003D, _0023_003DzafzCBBQ_003D);
	}

	internal IHwndWrapper _0023_003Dzh7DXocqFKQyn()
	{
		return _0023_003DzxIjbZNskco_0024P;
	}

	internal void _0023_003DzHKs9aEm3O9Uc(EventHandler<_0023_003Dz_EkGrGLIPQQmfLRjHvi_0024dNjyjzY6wyYo66v_0024LUo_003D> _0023_003DzsLHxXyo_003D)
	{
		EventHandler<_0023_003Dz_EkGrGLIPQQmfLRjHvi_0024dNjyjzY6wyYo66v_0024LUo_003D> eventHandler = _0023_003DzoZGswSI_003D;
		EventHandler<_0023_003Dz_EkGrGLIPQQmfLRjHvi_0024dNjyjzY6wyYo66v_0024LUo_003D> eventHandler2;
		do
		{
			eventHandler2 = eventHandler;
			EventHandler<_0023_003Dz_EkGrGLIPQQmfLRjHvi_0024dNjyjzY6wyYo66v_0024LUo_003D> value = (EventHandler<_0023_003Dz_EkGrGLIPQQmfLRjHvi_0024dNjyjzY6wyYo66v_0024LUo_003D>)Delegate.Combine(eventHandler2, _0023_003DzsLHxXyo_003D);
			eventHandler = Interlocked.CompareExchange(ref _0023_003DzoZGswSI_003D, value, eventHandler2);
		}
		while ((object)eventHandler != eventHandler2);
	}

	internal void _0023_003DzVJJ1_MEoYXwq(EventHandler<_0023_003Dz_EkGrGLIPQQmfLRjHvi_0024dNjyjzY6wyYo66v_0024LUo_003D> _0023_003DzsLHxXyo_003D)
	{
		EventHandler<_0023_003Dz_EkGrGLIPQQmfLRjHvi_0024dNjyjzY6wyYo66v_0024LUo_003D> eventHandler = _0023_003DzoZGswSI_003D;
		EventHandler<_0023_003Dz_EkGrGLIPQQmfLRjHvi_0024dNjyjzY6wyYo66v_0024LUo_003D> eventHandler2;
		do
		{
			eventHandler2 = eventHandler;
			EventHandler<_0023_003Dz_EkGrGLIPQQmfLRjHvi_0024dNjyjzY6wyYo66v_0024LUo_003D> value = (EventHandler<_0023_003Dz_EkGrGLIPQQmfLRjHvi_0024dNjyjzY6wyYo66v_0024LUo_003D>)Delegate.Remove(eventHandler2, _0023_003DzsLHxXyo_003D);
			eventHandler = Interlocked.CompareExchange(ref _0023_003DzoZGswSI_003D, value, eventHandler2);
		}
		while ((object)eventHandler != eventHandler2);
	}

	public static bool IsTouchWindows(IntPtr hWnd)
	{
		uint _0023_003Dz6_qLIrU_003D;
		return _0023_003DzirAC6ze4AS4guYNendC5yZ5TMzkXpZGjVJvc00mAPC0v._0023_003DzbzyQimOIi5_0024q(hWnd, out _0023_003Dz6_qLIrU_003D);
	}

	private void _0023_003DzmZquqHsuO0k4Vjscfw_003D_003D(object _0023_003Dz7dLpRsk_003D, EventArgs _0023_003Dz1SmHC4c_003D)
	{
		_0023_003DzS9sBW50_003D();
	}
}
