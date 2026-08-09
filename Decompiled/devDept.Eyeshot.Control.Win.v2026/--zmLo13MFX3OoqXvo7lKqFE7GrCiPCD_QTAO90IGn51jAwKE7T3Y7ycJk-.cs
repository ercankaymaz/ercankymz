using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using devDept.Eyeshot.Control.MultiTouch;
using devDept.Eyeshot.Control.MultiTouch.Interop;

internal sealed class _0023_003DzmLo13MFX3OoqXvo7lKqFE7GrCiPCD_QTAO90IGn51jAwKE7T3Y7ycJk_003D : IHwndWrapper
{
	[Serializable]
	private sealed class _0023_003DzP0sFNwY_003D
	{
		public static readonly _0023_003DzP0sFNwY_003D _0023_003Dz84eeg84_003D = new _0023_003DzP0sFNwY_003D();

		public static EventHandler _0023_003DzaHGH1hbgwYjXN0b91A_003D_003D;

		public static EventHandler _0023_003DzFI7KrfXyM3iZieuWrg_003D_003D;

		internal void _0023_003Dzn2LnLn3eShYujw_0024UoQ_003D_003D(object _0023_003Dz7dLpRsk_003D, EventArgs _0023_003Dz1SmHC4c_003D)
		{
		}

		internal void _0023_003DzarQKjKkqwIETY8eNxQ_003D_003D(object _0023_003Dz7dLpRsk_003D, EventArgs _0023_003Dz1SmHC4c_003D)
		{
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly IntPtr _0023_003DzqaDw32VE99EJ;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private EventHandler _0023_003DzZhkMwfXvAowq;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private EventHandler _0023_003Dz2ED6b8LPds4V;

	public IntPtr Handle => _0023_003DzqaDw32VE99EJ;

	public object Source => _0023_003DzqaDw32VE99EJ;

	public bool IsHandleCreated => _0023_003DzirAC6ze4AS4guYNendC5yZ5TMzkXpZGjVJvc00mAPC0v._0023_003Dzl39Y8_0024o_003D(_0023_003DzqaDw32VE99EJ);

	public event EventHandler HandleCreated
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = _0023_003DzZhkMwfXvAowq;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref _0023_003DzZhkMwfXvAowq, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = _0023_003DzZhkMwfXvAowq;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref _0023_003DzZhkMwfXvAowq, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler HandleDestroyed
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = _0023_003Dz2ED6b8LPds4V;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref _0023_003Dz2ED6b8LPds4V, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = _0023_003Dz2ED6b8LPds4V;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref _0023_003Dz2ED6b8LPds4V, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public _0023_003DzmLo13MFX3OoqXvo7lKqFE7GrCiPCD_QTAO90IGn51jAwKE7T3Y7ycJk_003D(IntPtr _0023_003DzVg1BG_0024g_003D)
	{
		_0023_003DzqaDw32VE99EJ = _0023_003DzVg1BG_0024g_003D;
		HandleCreated += delegate
		{
		};
		HandleDestroyed += _0023_003DzP0sFNwY_003D._0023_003Dz84eeg84_003D._0023_003DzarQKjKkqwIETY8eNxQ_003D_003D;
	}

	public Point PointToClient(Point _0023_003DzxGL6Kng_003D)
	{
		POINT _0023_003DzCldu5gNueqKB = new POINT
		{
			x = _0023_003DzxGL6Kng_003D.X,
			y = _0023_003DzxGL6Kng_003D.Y
		};
		_0023_003DzirAC6ze4AS4guYNendC5yZ5TMzkXpZGjVJvc00mAPC0v._0023_003Dz3fa9dBqDESKU(_0023_003DzqaDw32VE99EJ, ref _0023_003DzCldu5gNueqKB);
		return new Point(_0023_003DzCldu5gNueqKB.x, _0023_003DzCldu5gNueqKB.y);
	}

	internal void _0023_003DzMHcytw295NXj()
	{
		_0023_003Dz2ED6b8LPds4V(this, EventArgs.Empty);
	}
}
