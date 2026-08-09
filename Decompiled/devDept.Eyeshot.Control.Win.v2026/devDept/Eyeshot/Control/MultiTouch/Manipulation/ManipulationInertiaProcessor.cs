using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

namespace devDept.Eyeshot.Control.MultiTouch.Manipulation;

public class ManipulationInertiaProcessor : ManipulationProcessor
{
	[Serializable]
	private sealed class _0023_003DzP0sFNwY_003D
	{
		public static readonly _0023_003DzP0sFNwY_003D _0023_003Dz84eeg84_003D = new _0023_003DzP0sFNwY_003D();

		public static EventHandler<BeforeInertiaEventArgs> _0023_003DzaHGH1hbgwYjXN0b91A_003D_003D;

		internal void _0023_003Dzn2LnLn3eShYujw_0024UoQ_003D_003D(object _0023_003Dz7dLpRsk_003D, BeforeInertiaEventArgs _0023_003Dz1SmHC4c_003D)
		{
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private InertiaProcessor _0023_003Dzn_zhQTL67x6j__0024IN0Q_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private EventHandler<BeforeInertiaEventArgs> _0023_003DzmkipFA9Mze4fVSNm6g_003D_003D;

	public InertiaProcessor InertiaProcessor => _0023_003Dzn_zhQTL67x6j__0024IN0Q_003D_003D;

	public event EventHandler<BeforeInertiaEventArgs> BeforeInertia
	{
		[CompilerGenerated]
		add
		{
			EventHandler<BeforeInertiaEventArgs> eventHandler = _0023_003DzmkipFA9Mze4fVSNm6g_003D_003D;
			EventHandler<BeforeInertiaEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<BeforeInertiaEventArgs> value2 = (EventHandler<BeforeInertiaEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref _0023_003DzmkipFA9Mze4fVSNm6g_003D_003D, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<BeforeInertiaEventArgs> eventHandler = _0023_003DzmkipFA9Mze4fVSNm6g_003D_003D;
			EventHandler<BeforeInertiaEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<BeforeInertiaEventArgs> value2 = (EventHandler<BeforeInertiaEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref _0023_003DzmkipFA9Mze4fVSNm6g_003D_003D, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public ManipulationInertiaProcessor(ProcessorManipulations supportedManipulations, IGUITimer timer)
		: base(supportedManipulations)
	{
		_0023_003Dzn_zhQTL67x6j__0024IN0Q_003D_003D._0023_003DzE7F37dg_003D(timer);
		BeforeInertia += delegate
		{
		};
	}

	[SpecialName]
	internal override _0023_003DzfZu1a4qc5Ln5PPti2bpNuiycQGMU3mmh9cvl2sOxrIPU _0023_003DzyR9VTedOXnwE()
	{
		if (_0023_003Dzn_zhQTL67x6j__0024IN0Q_003D_003D == null)
		{
			_0023_003Dzn_zhQTL67x6j__0024IN0Q_003D_003D = new InertiaProcessor(this);
		}
		return _0023_003Dzn_zhQTL67x6j__0024IN0Q_003D_003D;
	}

	protected override void Dispose(bool dispose)
	{
		if (dispose)
		{
			_0023_003Dzn_zhQTL67x6j__0024IN0Q_003D_003D.Dispose();
			base.Dispose(dispose);
		}
	}

	internal _0023_003DzfZu1a4qc5Ln5PPti2bpNuiycQGMU3mmh9cvl2sOxrIPU _0023_003DzpBtpuT9gpYxN()
	{
		return this;
	}

	internal bool _0023_003DzFCqW91f6uyZGLrY6KQ_003D_003D()
	{
		BeforeInertiaEventArgs e = new BeforeInertiaEventArgs();
		_0023_003DzmkipFA9Mze4fVSNm6g_003D_003D(this, e);
		return e.CancelInertia;
	}
}
