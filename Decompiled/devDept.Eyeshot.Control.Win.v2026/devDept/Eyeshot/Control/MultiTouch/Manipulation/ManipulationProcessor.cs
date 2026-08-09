using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using devDept.Eyeshot.Control.MultiTouch.ManipulationInterop;

namespace devDept.Eyeshot.Control.MultiTouch.Manipulation;

public class ManipulationProcessor : _0023_003DzfZu1a4qc5Ln5PPti2bpNuiycQGMU3mmh9cvl2sOxrIPU, IDisposable
{
	[Serializable]
	private sealed class _0023_003DzP0sFNwY_003D
	{
		public static readonly _0023_003DzP0sFNwY_003D _0023_003Dz84eeg84_003D = new _0023_003DzP0sFNwY_003D();

		public static EventHandler<ManipulationStartedEventArgs> _0023_003Dz2zlFeC4cfkR48_0024vmtg_003D_003D;

		public static EventHandler<ManipulationDeltaEventArgs> _0023_003DzxCYZ_0024daLZHOeBYZQVw_003D_003D;

		public static EventHandler<ManipulationCompletedEventArgs> _0023_003DzvynqMsd8ViX1_b1zCQ_003D_003D;

		internal void _0023_003DzoHWoIR4mcJr7qr9rIA_003D_003D(object _0023_003Dz7dLpRsk_003D, ManipulationStartedEventArgs _0023_003Dz1SmHC4c_003D)
		{
		}

		internal void _0023_003DznGHSI_7_0024t7towgXyUA_003D_003D(object _0023_003Dz7dLpRsk_003D, ManipulationDeltaEventArgs _0023_003Dz1SmHC4c_003D)
		{
		}

		internal void _0023_003DzNqCLnoh4e3Eyxvx3CQ_003D_003D(object _0023_003Dz7dLpRsk_003D, ManipulationCompletedEventArgs _0023_003Dz1SmHC4c_003D)
		{
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly _0023_003Dz0Efd9UJQ2M53z6ZrhLrnA5wlp8xtqVUAbq3ptv_ismkoq01w5w_003D_003D _0023_003DzMA4_7fp9lkBc;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly _0023_003DzfZu1a4qc5Ln5PPti2bpNuiycQGMU3mmh9cvl2sOxrIPU _0023_003DzDafpaD8SNaDF;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private EventHandler<ManipulationStartedEventArgs> _0023_003DzKQlbeE7PRPeQ = _0023_003DzP0sFNwY_003D._0023_003Dz84eeg84_003D._0023_003DzoHWoIR4mcJr7qr9rIA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private EventHandler<ManipulationDeltaEventArgs> _0023_003Dz_00240A_PANomxaQ = delegate
	{
	};

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private EventHandler<ManipulationCompletedEventArgs> _0023_003DzSC7ViJvM8Pk5 = _0023_003DzP0sFNwY_003D._0023_003Dz84eeg84_003D._0023_003DzNqCLnoh4e3Eyxvx3CQ_003D_003D;

	public ProcessorManipulations SupportedManipulations
	{
		get
		{
			return (ProcessorManipulations)_0023_003DzMA4_7fp9lkBc.SupportedManipulations;
		}
		set
		{
			_0023_003DzMA4_7fp9lkBc.SupportedManipulations = (_0023_003DzsO08yiG6iZOUzgTTylonQQWn9NsY_0024lwXsFLT3VABX0NVuPwBH9s0h2VddQS_0024MYCvZHoh0tMZyssz9yVuHA_003D_003D)value;
		}
	}

	public PointF PivotPoint
	{
		get
		{
			return new PointF(_0023_003DzMA4_7fp9lkBc.PivotPointX, _0023_003DzMA4_7fp9lkBc.PivotPointY);
		}
		set
		{
			_0023_003DzMA4_7fp9lkBc.PivotPointX = value.X;
			_0023_003DzMA4_7fp9lkBc.PivotPointY = value.Y;
		}
	}

	public float PivotRadius
	{
		get
		{
			return _0023_003DzMA4_7fp9lkBc.PivotRadius;
		}
		set
		{
			_0023_003DzMA4_7fp9lkBc.PivotRadius = value;
		}
	}

	public VectorF Velocity => new VectorF(_0023_003DzMA4_7fp9lkBc.GetVelocityX(), _0023_003DzMA4_7fp9lkBc.GetVelocityY());

	public float ExpansionVelocity => _0023_003DzMA4_7fp9lkBc.GetExpansionVelocity();

	public float AngularVelocity => _0023_003DzMA4_7fp9lkBc.GetAngularVelocity();

	public float MinimumScaleRotateRadius
	{
		get
		{
			return _0023_003DzMA4_7fp9lkBc.MinimumScaleRotateRadius;
		}
		set
		{
			_0023_003DzMA4_7fp9lkBc.MinimumScaleRotateRadius = value;
		}
	}

	public event EventHandler<ManipulationStartedEventArgs> ManipulationStarted
	{
		[CompilerGenerated]
		add
		{
			EventHandler<ManipulationStartedEventArgs> eventHandler = _0023_003DzKQlbeE7PRPeQ;
			EventHandler<ManipulationStartedEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<ManipulationStartedEventArgs> value2 = (EventHandler<ManipulationStartedEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref _0023_003DzKQlbeE7PRPeQ, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<ManipulationStartedEventArgs> eventHandler = _0023_003DzKQlbeE7PRPeQ;
			EventHandler<ManipulationStartedEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<ManipulationStartedEventArgs> value2 = (EventHandler<ManipulationStartedEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref _0023_003DzKQlbeE7PRPeQ, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler<ManipulationDeltaEventArgs> ManipulationDelta
	{
		[CompilerGenerated]
		add
		{
			EventHandler<ManipulationDeltaEventArgs> eventHandler = _0023_003Dz_00240A_PANomxaQ;
			EventHandler<ManipulationDeltaEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<ManipulationDeltaEventArgs> value2 = (EventHandler<ManipulationDeltaEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref _0023_003Dz_00240A_PANomxaQ, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<ManipulationDeltaEventArgs> eventHandler = _0023_003Dz_00240A_PANomxaQ;
			EventHandler<ManipulationDeltaEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<ManipulationDeltaEventArgs> value2 = (EventHandler<ManipulationDeltaEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref _0023_003Dz_00240A_PANomxaQ, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler<ManipulationCompletedEventArgs> ManipulationCompleted
	{
		[CompilerGenerated]
		add
		{
			EventHandler<ManipulationCompletedEventArgs> eventHandler = _0023_003DzSC7ViJvM8Pk5;
			EventHandler<ManipulationCompletedEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<ManipulationCompletedEventArgs> value2 = (EventHandler<ManipulationCompletedEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref _0023_003DzSC7ViJvM8Pk5, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<ManipulationCompletedEventArgs> eventHandler = _0023_003DzSC7ViJvM8Pk5;
			EventHandler<ManipulationCompletedEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<ManipulationCompletedEventArgs> value2 = (EventHandler<ManipulationCompletedEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref _0023_003DzSC7ViJvM8Pk5, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public ManipulationProcessor(ProcessorManipulations supportedManipulations)
	{
		_0023_003DzMA4_7fp9lkBc = new devDept.Eyeshot.Control.MultiTouch.ManipulationInterop.ManipulationProcessor();
		_0023_003DzDafpaD8SNaDF = new _0023_003DzS7RDihgHrrBAan7ZSMSkXR7c79Q0zVF_jUWuSCmfpT5i(_0023_003DzMA4_7fp9lkBc, _0023_003DzyR9VTedOXnwE());
		try
		{
			SupportedManipulations = supportedManipulations;
		}
		catch (Exception ex)
		{
			Dispose();
			throw ex;
		}
	}

	internal virtual _0023_003DzfZu1a4qc5Ln5PPti2bpNuiycQGMU3mmh9cvl2sOxrIPU _0023_003DzyR9VTedOXnwE()
	{
		return this;
	}

	private void _0023_003DzesnXeVJFtCYlGZ1sXOziuTorRZSRdNAGzC2IjPITdsM0l02esLdeTWI_003D(float _0023_003Dz8GBMuoM_003D, float _0023_003DzJU0R6e0_003D)
	{
		_0023_003DzKQlbeE7PRPeQ(this, new ManipulationStartedEventArgs(_0023_003Dz8GBMuoM_003D, _0023_003DzJU0R6e0_003D));
	}

	void _0023_003DzfZu1a4qc5Ln5PPti2bpNuiycQGMU3mmh9cvl2sOxrIPU._0023_003DzKQlbeE7PRPeQ(float _0023_003Dz8GBMuoM_003D, float _0023_003DzJU0R6e0_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zesnXeVJFtCYlGZ1sXOziuTorRZSRdNAGzC2IjPITdsM0l02esLdeTWI=
		this._0023_003DzesnXeVJFtCYlGZ1sXOziuTorRZSRdNAGzC2IjPITdsM0l02esLdeTWI_003D(_0023_003Dz8GBMuoM_003D, _0023_003DzJU0R6e0_003D);
	}

	private void _0023_003Dzwoyki_0024f8Q0jiCDOhkTHc9_0024irX1K9vK1g9VNvsrkEFPXVZOlA5rAejM8_003D(float _0023_003Dz8GBMuoM_003D, float _0023_003DzJU0R6e0_003D, float _0023_003DzhK2DEjUfTQ76qrpzuxxIBsU_003D, float _0023_003DztuVEf_0024Q1UyI4_gvLtTG7MTY_003D, float _0023_003DzP30oAoQWfCXT, float _0023_003DzYie_61YoJvq_, float _0023_003DzE5TsCsAD5DAt, float _0023_003DzVsHJQ_0024X3leRJwaWvnQ9rlaE_003D, float _0023_003DzSFM4LeAE3_mVvblqBlo_fQQ_003D, float _0023_003DzSwhHuzqbWI5tFEom9_O_VOo_003D, float _0023_003DzMXd5cVQshyu6eZkzuOuSxmU_003D, float _0023_003DzHFOJHTZRJWDwpGQBKMP9ilw_003D)
	{
		_0023_003Dz_00240A_PANomxaQ(this, new ManipulationDeltaEventArgs(_0023_003Dz8GBMuoM_003D, _0023_003DzJU0R6e0_003D, _0023_003DzhK2DEjUfTQ76qrpzuxxIBsU_003D, _0023_003DztuVEf_0024Q1UyI4_gvLtTG7MTY_003D, _0023_003DzP30oAoQWfCXT, _0023_003DzYie_61YoJvq_, _0023_003DzE5TsCsAD5DAt, _0023_003DzVsHJQ_0024X3leRJwaWvnQ9rlaE_003D, _0023_003DzSFM4LeAE3_mVvblqBlo_fQQ_003D, _0023_003DzSwhHuzqbWI5tFEom9_O_VOo_003D, _0023_003DzMXd5cVQshyu6eZkzuOuSxmU_003D, _0023_003DzHFOJHTZRJWDwpGQBKMP9ilw_003D));
	}

	void _0023_003DzfZu1a4qc5Ln5PPti2bpNuiycQGMU3mmh9cvl2sOxrIPU._0023_003Dz_00240A_PANomxaQ(float _0023_003Dz8GBMuoM_003D, float _0023_003DzJU0R6e0_003D, float _0023_003DzhK2DEjUfTQ76qrpzuxxIBsU_003D, float _0023_003DztuVEf_0024Q1UyI4_gvLtTG7MTY_003D, float _0023_003DzP30oAoQWfCXT, float _0023_003DzYie_61YoJvq_, float _0023_003DzE5TsCsAD5DAt, float _0023_003DzVsHJQ_0024X3leRJwaWvnQ9rlaE_003D, float _0023_003DzSFM4LeAE3_mVvblqBlo_fQQ_003D, float _0023_003DzSwhHuzqbWI5tFEom9_O_VOo_003D, float _0023_003DzMXd5cVQshyu6eZkzuOuSxmU_003D, float _0023_003DzHFOJHTZRJWDwpGQBKMP9ilw_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zwoyki$f8Q0jiCDOhkTHc9$irX1K9vK1g9VNvsrkEFPXVZOlA5rAejM8=
		this._0023_003Dzwoyki_0024f8Q0jiCDOhkTHc9_0024irX1K9vK1g9VNvsrkEFPXVZOlA5rAejM8_003D(_0023_003Dz8GBMuoM_003D, _0023_003DzJU0R6e0_003D, _0023_003DzhK2DEjUfTQ76qrpzuxxIBsU_003D, _0023_003DztuVEf_0024Q1UyI4_gvLtTG7MTY_003D, _0023_003DzP30oAoQWfCXT, _0023_003DzYie_61YoJvq_, _0023_003DzE5TsCsAD5DAt, _0023_003DzVsHJQ_0024X3leRJwaWvnQ9rlaE_003D, _0023_003DzSFM4LeAE3_mVvblqBlo_fQQ_003D, _0023_003DzSwhHuzqbWI5tFEom9_O_VOo_003D, _0023_003DzMXd5cVQshyu6eZkzuOuSxmU_003D, _0023_003DzHFOJHTZRJWDwpGQBKMP9ilw_003D);
	}

	private void _0023_003DzDICPAZcA7cNilan8ZTR8lcmWWZMHB6CUxy_0024fmZyQbh8RbBC1oAcBqbg_003D(float _0023_003Dz8GBMuoM_003D, float _0023_003DzJU0R6e0_003D, float _0023_003DzVsHJQ_0024X3leRJwaWvnQ9rlaE_003D, float _0023_003DzSFM4LeAE3_mVvblqBlo_fQQ_003D, float _0023_003DzSwhHuzqbWI5tFEom9_O_VOo_003D, float _0023_003DzMXd5cVQshyu6eZkzuOuSxmU_003D, float _0023_003DzHFOJHTZRJWDwpGQBKMP9ilw_003D)
	{
		_0023_003DzSC7ViJvM8Pk5(this, new ManipulationCompletedEventArgs(_0023_003Dz8GBMuoM_003D, _0023_003DzJU0R6e0_003D, _0023_003DzVsHJQ_0024X3leRJwaWvnQ9rlaE_003D, _0023_003DzSFM4LeAE3_mVvblqBlo_fQQ_003D, _0023_003DzSwhHuzqbWI5tFEom9_O_VOo_003D, _0023_003DzMXd5cVQshyu6eZkzuOuSxmU_003D, _0023_003DzHFOJHTZRJWDwpGQBKMP9ilw_003D));
	}

	void _0023_003DzfZu1a4qc5Ln5PPti2bpNuiycQGMU3mmh9cvl2sOxrIPU._0023_003DzSC7ViJvM8Pk5(float _0023_003Dz8GBMuoM_003D, float _0023_003DzJU0R6e0_003D, float _0023_003DzVsHJQ_0024X3leRJwaWvnQ9rlaE_003D, float _0023_003DzSFM4LeAE3_mVvblqBlo_fQQ_003D, float _0023_003DzSwhHuzqbWI5tFEom9_O_VOo_003D, float _0023_003DzMXd5cVQshyu6eZkzuOuSxmU_003D, float _0023_003DzHFOJHTZRJWDwpGQBKMP9ilw_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zDICPAZcA7cNilan8ZTR8lcmWWZMHB6CUxy$fmZyQbh8RbBC1oAcBqbg=
		this._0023_003DzDICPAZcA7cNilan8ZTR8lcmWWZMHB6CUxy_0024fmZyQbh8RbBC1oAcBqbg_003D(_0023_003Dz8GBMuoM_003D, _0023_003DzJU0R6e0_003D, _0023_003DzVsHJQ_0024X3leRJwaWvnQ9rlaE_003D, _0023_003DzSFM4LeAE3_mVvblqBlo_fQQ_003D, _0023_003DzSwhHuzqbWI5tFEom9_O_VOo_003D, _0023_003DzMXd5cVQshyu6eZkzuOuSxmU_003D, _0023_003DzHFOJHTZRJWDwpGQBKMP9ilw_003D);
	}

	public void CompleteManipulation()
	{
		_0023_003DzMA4_7fp9lkBc.CompleteManipulation();
	}

	[CLSCompliant(false)]
	public void ProcessDown(uint manipulationId, PointF location)
	{
		_0023_003DzMA4_7fp9lkBc.ProcessDown(manipulationId, location.X, location.Y);
	}

	[CLSCompliant(false)]
	public void ProcessMove(uint manipulationId, PointF location)
	{
		_0023_003DzMA4_7fp9lkBc.ProcessMove(manipulationId, location.X, location.Y);
	}

	[CLSCompliant(false)]
	public void ProcessUp(uint manipulationId, PointF location)
	{
		_0023_003DzMA4_7fp9lkBc.ProcessUp(manipulationId, location.X, location.Y);
	}

	[CLSCompliant(false)]
	public void ProcessDownWithTime(uint manipulationId, PointF location, int timestamp)
	{
		_0023_003DzMA4_7fp9lkBc.ProcessDownWithTime(manipulationId, location.X, location.Y, timestamp);
	}

	[CLSCompliant(false)]
	public void ProcessMoveWithTime(uint manipulationId, PointF location, int timestamp)
	{
		_0023_003DzMA4_7fp9lkBc.ProcessMoveWithTime(manipulationId, location.X, location.Y, timestamp);
	}

	[CLSCompliant(false)]
	public void ProcessUpWithTime(uint manipulationId, PointF location, int timestamp)
	{
		_0023_003DzMA4_7fp9lkBc.ProcessUpWithTime(manipulationId, location.X, location.Y, timestamp);
	}

	protected virtual void Dispose(bool dispose)
	{
		if (dispose)
		{
			GC.SuppressFinalize(this);
			Marshal.ReleaseComObject(_0023_003DzMA4_7fp9lkBc);
			_0023_003DzDafpaD8SNaDF.Dispose();
		}
	}

	public void Dispose()
	{
		Dispose(dispose: true);
	}
}
