using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using devDept.Eyeshot.Control.MultiTouch.ManipulationInterop;

namespace devDept.Eyeshot.Control.MultiTouch.Manipulation;

public class InertiaProcessor : _0023_003DzfZu1a4qc5Ln5PPti2bpNuiycQGMU3mmh9cvl2sOxrIPU, IDisposable
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly _0023_003DzjMF2RVhjjylO5Y9gNQiFNuMv_EDuQPz3AyfqYoTDxrujKpqOU2nGWi4_003D _0023_003DzuUY5Ic0WpildqfO90R4wxyo_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly ManipulationInertiaProcessor _0023_003DzPKbLZ_0024mf8oYdjGHqXBIv8QY_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly _0023_003DzS7RDihgHrrBAan7ZSMSkXR7c79Q0zVF_jUWuSCmfpT5i _0023_003DzDafpaD8SNaDF;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzRPwyhMS5E_0024MEXFxSWQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dzkiz5T1WXswC5Egw7LQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IGUITimer _0023_003DzzqZSJNo_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzsDJDhd3sK4QT0P0QLEH_YLF7EYeW;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzZWBAGE7zEhJ_W2ohnkgHwwAZZ_0024Sw;

	public int MaxInertiaSteps
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzsDJDhd3sK4QT0P0QLEH_YLF7EYeW;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzsDJDhd3sK4QT0P0QLEH_YLF7EYeW = value;
		}
	}

	public int InertiaTimerInterval
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzZWBAGE7zEhJ_W2ohnkgHwwAZZ_0024Sw;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzZWBAGE7zEhJ_W2ohnkgHwwAZZ_0024Sw = value;
		}
	}

	public bool InInertia => _0023_003Dzkiz5T1WXswC5Egw7LQ_003D_003D;

	public VectorF InitialVelocity
	{
		get
		{
			return new VectorF(_0023_003DzuUY5Ic0WpildqfO90R4wxyo_003D.InitialVelocityX, _0023_003DzuUY5Ic0WpildqfO90R4wxyo_003D.InitialVelocityY);
		}
		set
		{
			_0023_003DzuUY5Ic0WpildqfO90R4wxyo_003D.InitialVelocityX = value.X;
			_0023_003DzuUY5Ic0WpildqfO90R4wxyo_003D.InitialVelocityY = value.Y;
		}
	}

	public float InitialAngularVelocity
	{
		get
		{
			return _0023_003DzuUY5Ic0WpildqfO90R4wxyo_003D.InitialAngularVelocity;
		}
		set
		{
			_0023_003DzuUY5Ic0WpildqfO90R4wxyo_003D.InitialAngularVelocity = value;
		}
	}

	public float InitialExpansionVelocity
	{
		get
		{
			return _0023_003DzuUY5Ic0WpildqfO90R4wxyo_003D.InitialExpansionVelocity;
		}
		set
		{
			_0023_003DzuUY5Ic0WpildqfO90R4wxyo_003D.InitialExpansionVelocity = value;
		}
	}

	public float InitialRadius
	{
		get
		{
			return _0023_003DzuUY5Ic0WpildqfO90R4wxyo_003D.InitialRadius;
		}
		set
		{
			_0023_003DzuUY5Ic0WpildqfO90R4wxyo_003D.InitialRadius = value;
		}
	}

	public RectangleF Boundary
	{
		get
		{
			return new RectangleF(_0023_003DzuUY5Ic0WpildqfO90R4wxyo_003D.BoundaryLeft, _0023_003DzuUY5Ic0WpildqfO90R4wxyo_003D.BoundaryTop, _0023_003DzuUY5Ic0WpildqfO90R4wxyo_003D.BoundaryRight - _0023_003DzuUY5Ic0WpildqfO90R4wxyo_003D.BoundaryLeft, _0023_003DzuUY5Ic0WpildqfO90R4wxyo_003D.BoundaryBottom - _0023_003DzuUY5Ic0WpildqfO90R4wxyo_003D.BoundaryTop);
		}
		set
		{
			_0023_003DzuUY5Ic0WpildqfO90R4wxyo_003D.BoundaryLeft = value.Left;
			_0023_003DzuUY5Ic0WpildqfO90R4wxyo_003D.BoundaryRight = value.Right;
			_0023_003DzuUY5Ic0WpildqfO90R4wxyo_003D.BoundaryTop = value.Top;
			_0023_003DzuUY5Ic0WpildqfO90R4wxyo_003D.BoundaryBottom = value.Bottom;
		}
	}

	public RectangleF ElasticMargin
	{
		get
		{
			return new RectangleF(_0023_003DzuUY5Ic0WpildqfO90R4wxyo_003D.ElasticMarginLeft, _0023_003DzuUY5Ic0WpildqfO90R4wxyo_003D.ElasticMarginTop, _0023_003DzuUY5Ic0WpildqfO90R4wxyo_003D.ElasticMarginRight - _0023_003DzuUY5Ic0WpildqfO90R4wxyo_003D.ElasticMarginLeft, _0023_003DzuUY5Ic0WpildqfO90R4wxyo_003D.ElasticMarginBottom - _0023_003DzuUY5Ic0WpildqfO90R4wxyo_003D.ElasticMarginTop);
		}
		set
		{
			_0023_003DzuUY5Ic0WpildqfO90R4wxyo_003D.ElasticMarginLeft = value.Left;
			_0023_003DzuUY5Ic0WpildqfO90R4wxyo_003D.ElasticMarginRight = value.Right;
			_0023_003DzuUY5Ic0WpildqfO90R4wxyo_003D.ElasticMarginTop = value.Top;
			_0023_003DzuUY5Ic0WpildqfO90R4wxyo_003D.ElasticMarginBottom = value.Bottom;
		}
	}

	public float DesiredDisplacement
	{
		get
		{
			return _0023_003DzuUY5Ic0WpildqfO90R4wxyo_003D.DesiredDisplacement;
		}
		set
		{
			_0023_003DzuUY5Ic0WpildqfO90R4wxyo_003D.DesiredDisplacement = value;
		}
	}

	public float DesiredRotation
	{
		get
		{
			return _0023_003DzuUY5Ic0WpildqfO90R4wxyo_003D.DesiredRotation;
		}
		set
		{
			_0023_003DzuUY5Ic0WpildqfO90R4wxyo_003D.DesiredRotation = value;
		}
	}

	public float DesiredExpansion
	{
		get
		{
			return _0023_003DzuUY5Ic0WpildqfO90R4wxyo_003D.DesiredExpansion;
		}
		set
		{
			_0023_003DzuUY5Ic0WpildqfO90R4wxyo_003D.DesiredExpansion = value;
		}
	}

	public float DesiredDeceleration
	{
		get
		{
			return _0023_003DzuUY5Ic0WpildqfO90R4wxyo_003D.DesiredDeceleration;
		}
		set
		{
			_0023_003DzuUY5Ic0WpildqfO90R4wxyo_003D.DesiredDeceleration = value;
		}
	}

	public float DesiredAngularDeceleration
	{
		get
		{
			return _0023_003DzuUY5Ic0WpildqfO90R4wxyo_003D.DesiredAngularDeceleration;
		}
		set
		{
			_0023_003DzuUY5Ic0WpildqfO90R4wxyo_003D.DesiredAngularDeceleration = value;
		}
	}

	public float DesiredExpansionDeceleration
	{
		get
		{
			return _0023_003DzuUY5Ic0WpildqfO90R4wxyo_003D.DesiredExpansionDeceleration;
		}
		set
		{
			_0023_003DzuUY5Ic0WpildqfO90R4wxyo_003D.DesiredExpansionDeceleration = value;
		}
	}

	internal InertiaProcessor(ManipulationInertiaProcessor _0023_003DzQwBtpgo_003D)
	{
		_0023_003DzuUY5Ic0WpildqfO90R4wxyo_003D = new devDept.Eyeshot.Control.MultiTouch.ManipulationInterop.InertiaProcessor();
		_0023_003DzPKbLZ_0024mf8oYdjGHqXBIv8QY_003D = _0023_003DzQwBtpgo_003D;
		_0023_003DzDafpaD8SNaDF = new _0023_003DzS7RDihgHrrBAan7ZSMSkXR7c79Q0zVF_jUWuSCmfpT5i(_0023_003DzuUY5Ic0WpildqfO90R4wxyo_003D, _0023_003DzQwBtpgo_003D);
		MaxInertiaSteps = 200;
		InertiaTimerInterval = 15;
	}

	private void _0023_003DzLxupB9Y5WdQNI7T4_0024Q_003D_003D()
	{
		_0023_003DzRPwyhMS5E_0024MEXFxSWQ_003D_003D = 0;
		_0023_003DzzqZSJNo_003D.Stop();
		_0023_003Dzkiz5T1WXswC5Egw7LQ_003D_003D = false;
	}

	private void _0023_003DzesnXeVJFtCYlGZ1sXOziuTorRZSRdNAGzC2IjPITdsM0l02esLdeTWI_003D(float _0023_003Dz8GBMuoM_003D, float _0023_003DzJU0R6e0_003D)
	{
		_0023_003DzLxupB9Y5WdQNI7T4_0024Q_003D_003D();
		_0023_003DzPKbLZ_0024mf8oYdjGHqXBIv8QY_003D._0023_003DzpBtpuT9gpYxN()._0023_003DzKQlbeE7PRPeQ(_0023_003Dz8GBMuoM_003D, _0023_003DzJU0R6e0_003D);
	}

	void _0023_003DzfZu1a4qc5Ln5PPti2bpNuiycQGMU3mmh9cvl2sOxrIPU._0023_003DzKQlbeE7PRPeQ(float _0023_003Dz8GBMuoM_003D, float _0023_003DzJU0R6e0_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zesnXeVJFtCYlGZ1sXOziuTorRZSRdNAGzC2IjPITdsM0l02esLdeTWI=
		this._0023_003DzesnXeVJFtCYlGZ1sXOziuTorRZSRdNAGzC2IjPITdsM0l02esLdeTWI_003D(_0023_003Dz8GBMuoM_003D, _0023_003DzJU0R6e0_003D);
	}

	private void _0023_003Dzwoyki_0024f8Q0jiCDOhkTHc9_0024irX1K9vK1g9VNvsrkEFPXVZOlA5rAejM8_003D(float _0023_003Dz8GBMuoM_003D, float _0023_003DzJU0R6e0_003D, float _0023_003DzhK2DEjUfTQ76qrpzuxxIBsU_003D, float _0023_003DztuVEf_0024Q1UyI4_gvLtTG7MTY_003D, float _0023_003DzP30oAoQWfCXT, float _0023_003DzYie_61YoJvq_, float _0023_003DzE5TsCsAD5DAt, float _0023_003DzVsHJQ_0024X3leRJwaWvnQ9rlaE_003D, float _0023_003DzSFM4LeAE3_mVvblqBlo_fQQ_003D, float _0023_003DzSwhHuzqbWI5tFEom9_O_VOo_003D, float _0023_003DzMXd5cVQshyu6eZkzuOuSxmU_003D, float _0023_003DzHFOJHTZRJWDwpGQBKMP9ilw_003D)
	{
		_0023_003DzPKbLZ_0024mf8oYdjGHqXBIv8QY_003D._0023_003DzpBtpuT9gpYxN()._0023_003Dz_00240A_PANomxaQ(_0023_003Dz8GBMuoM_003D, _0023_003DzJU0R6e0_003D, _0023_003DzhK2DEjUfTQ76qrpzuxxIBsU_003D, _0023_003DztuVEf_0024Q1UyI4_gvLtTG7MTY_003D, _0023_003DzP30oAoQWfCXT, _0023_003DzYie_61YoJvq_, _0023_003DzE5TsCsAD5DAt, _0023_003DzVsHJQ_0024X3leRJwaWvnQ9rlaE_003D, _0023_003DzSFM4LeAE3_mVvblqBlo_fQQ_003D, _0023_003DzSwhHuzqbWI5tFEom9_O_VOo_003D, _0023_003DzMXd5cVQshyu6eZkzuOuSxmU_003D, _0023_003DzHFOJHTZRJWDwpGQBKMP9ilw_003D);
	}

	void _0023_003DzfZu1a4qc5Ln5PPti2bpNuiycQGMU3mmh9cvl2sOxrIPU._0023_003Dz_00240A_PANomxaQ(float _0023_003Dz8GBMuoM_003D, float _0023_003DzJU0R6e0_003D, float _0023_003DzhK2DEjUfTQ76qrpzuxxIBsU_003D, float _0023_003DztuVEf_0024Q1UyI4_gvLtTG7MTY_003D, float _0023_003DzP30oAoQWfCXT, float _0023_003DzYie_61YoJvq_, float _0023_003DzE5TsCsAD5DAt, float _0023_003DzVsHJQ_0024X3leRJwaWvnQ9rlaE_003D, float _0023_003DzSFM4LeAE3_mVvblqBlo_fQQ_003D, float _0023_003DzSwhHuzqbWI5tFEom9_O_VOo_003D, float _0023_003DzMXd5cVQshyu6eZkzuOuSxmU_003D, float _0023_003DzHFOJHTZRJWDwpGQBKMP9ilw_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zwoyki$f8Q0jiCDOhkTHc9$irX1K9vK1g9VNvsrkEFPXVZOlA5rAejM8=
		this._0023_003Dzwoyki_0024f8Q0jiCDOhkTHc9_0024irX1K9vK1g9VNvsrkEFPXVZOlA5rAejM8_003D(_0023_003Dz8GBMuoM_003D, _0023_003DzJU0R6e0_003D, _0023_003DzhK2DEjUfTQ76qrpzuxxIBsU_003D, _0023_003DztuVEf_0024Q1UyI4_gvLtTG7MTY_003D, _0023_003DzP30oAoQWfCXT, _0023_003DzYie_61YoJvq_, _0023_003DzE5TsCsAD5DAt, _0023_003DzVsHJQ_0024X3leRJwaWvnQ9rlaE_003D, _0023_003DzSFM4LeAE3_mVvblqBlo_fQQ_003D, _0023_003DzSwhHuzqbWI5tFEom9_O_VOo_003D, _0023_003DzMXd5cVQshyu6eZkzuOuSxmU_003D, _0023_003DzHFOJHTZRJWDwpGQBKMP9ilw_003D);
	}

	private void _0023_003DzDICPAZcA7cNilan8ZTR8lcmWWZMHB6CUxy_0024fmZyQbh8RbBC1oAcBqbg_003D(float _0023_003Dz8GBMuoM_003D, float _0023_003DzJU0R6e0_003D, float _0023_003DzVsHJQ_0024X3leRJwaWvnQ9rlaE_003D, float _0023_003DzSFM4LeAE3_mVvblqBlo_fQQ_003D, float _0023_003DzSwhHuzqbWI5tFEom9_O_VOo_003D, float _0023_003DzMXd5cVQshyu6eZkzuOuSxmU_003D, float _0023_003DzHFOJHTZRJWDwpGQBKMP9ilw_003D)
	{
		if (_0023_003Dzkiz5T1WXswC5Egw7LQ_003D_003D)
		{
			_0023_003DzLxupB9Y5WdQNI7T4_0024Q_003D_003D();
		}
		else if (!_0023_003DzPKbLZ_0024mf8oYdjGHqXBIv8QY_003D._0023_003DzFCqW91f6uyZGLrY6KQ_003D_003D())
		{
			_0023_003Dzkiz5T1WXswC5Egw7LQ_003D_003D = true;
			_0023_003DzzqZSJNo_003D.Interval = InertiaTimerInterval;
			_0023_003DzzqZSJNo_003D.Tick += _0023_003Dz17Af5h3pVd2yq2Qqzb1nYoT2iwCtIEeQvXZYRbF_cn9q1L9dlac5g7DVUkvcCU2ogQ_003D_003D;
			_0023_003DzuUY5Ic0WpildqfO90R4wxyo_003D.InitialOriginX = _0023_003Dz8GBMuoM_003D;
			_0023_003DzuUY5Ic0WpildqfO90R4wxyo_003D.InitialOriginY = _0023_003DzJU0R6e0_003D;
			_0023_003DzuUY5Ic0WpildqfO90R4wxyo_003D.Reset();
			_0023_003DzzqZSJNo_003D.Start();
		}
	}

	void _0023_003DzfZu1a4qc5Ln5PPti2bpNuiycQGMU3mmh9cvl2sOxrIPU._0023_003DzSC7ViJvM8Pk5(float _0023_003Dz8GBMuoM_003D, float _0023_003DzJU0R6e0_003D, float _0023_003DzVsHJQ_0024X3leRJwaWvnQ9rlaE_003D, float _0023_003DzSFM4LeAE3_mVvblqBlo_fQQ_003D, float _0023_003DzSwhHuzqbWI5tFEom9_O_VOo_003D, float _0023_003DzMXd5cVQshyu6eZkzuOuSxmU_003D, float _0023_003DzHFOJHTZRJWDwpGQBKMP9ilw_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zDICPAZcA7cNilan8ZTR8lcmWWZMHB6CUxy$fmZyQbh8RbBC1oAcBqbg=
		this._0023_003DzDICPAZcA7cNilan8ZTR8lcmWWZMHB6CUxy_0024fmZyQbh8RbBC1oAcBqbg_003D(_0023_003Dz8GBMuoM_003D, _0023_003DzJU0R6e0_003D, _0023_003DzVsHJQ_0024X3leRJwaWvnQ9rlaE_003D, _0023_003DzSFM4LeAE3_mVvblqBlo_fQQ_003D, _0023_003DzSwhHuzqbWI5tFEom9_O_VOo_003D, _0023_003DzMXd5cVQshyu6eZkzuOuSxmU_003D, _0023_003DzHFOJHTZRJWDwpGQBKMP9ilw_003D);
	}

	public void Dispose()
	{
		Marshal.ReleaseComObject(_0023_003DzuUY5Ic0WpildqfO90R4wxyo_003D);
		_0023_003DzzqZSJNo_003D.Stop();
		_0023_003DzzqZSJNo_003D.Dispose();
	}

	internal void _0023_003DzE7F37dg_003D(IGUITimer _0023_003Dz5OWWt7s_003D)
	{
		_0023_003DzzqZSJNo_003D = _0023_003Dz5OWWt7s_003D;
	}

	private void _0023_003Dz17Af5h3pVd2yq2Qqzb1nYoT2iwCtIEeQvXZYRbF_cn9q1L9dlac5g7DVUkvcCU2ogQ_003D_003D(object _0023_003Dz7dLpRsk_003D, EventArgs _0023_003Dz1SmHC4c_003D)
	{
		_0023_003DzRPwyhMS5E_0024MEXFxSWQ_003D_003D++;
		if (_0023_003DzRPwyhMS5E_0024MEXFxSWQ_003D_003D > MaxInertiaSteps)
		{
			_0023_003DzLxupB9Y5WdQNI7T4_0024Q_003D_003D();
			_0023_003DzuUY5Ic0WpildqfO90R4wxyo_003D.Complete();
		}
		else
		{
			_0023_003DzuUY5Ic0WpildqfO90R4wxyo_003D.Process();
		}
	}
}
