using System;
using System.Diagnostics;

namespace devDept.Eyeshot.Control.Mouse3D;

public class MoveEventArgs : EventArgs
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DeviceInfo _0023_003DzIYSBIN5rnb7u;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal float[] _0023_003DzwJX1WcPTuBxj;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TranslationVector _0023_003DzglqQ7p4NmUSz29OO93Kj8tE_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private RotationVector _0023_003Dz82BbYQPDjQY_0024;

	public TranslationVector TranslationVector
	{
		get
		{
			return _0023_003DzglqQ7p4NmUSz29OO93Kj8tE_003D;
		}
		set
		{
			_0023_003DzglqQ7p4NmUSz29OO93Kj8tE_003D = value;
		}
	}

	public RotationVector RotationVector
	{
		get
		{
			return _0023_003Dz82BbYQPDjQY_0024;
		}
		set
		{
			_0023_003Dz82BbYQPDjQY_0024 = value;
		}
	}

	public DeviceInfo DeviceInfo
	{
		get
		{
			return _0023_003DzIYSBIN5rnb7u;
		}
		set
		{
			_0023_003DzIYSBIN5rnb7u = value;
		}
	}

	internal MoveEventArgs(DeviceInfo _0023_003Dzopmfnqc_003D, TranslationVector _0023_003DzUji6h6ltaAyxFOnw9V99dAk_003D, RotationVector _0023_003DzYrnVi6EDTYXT, float[] _0023_003DzwJX1WcPTuBxj = null)
	{
		_0023_003DzIYSBIN5rnb7u = _0023_003Dzopmfnqc_003D;
		_0023_003DzglqQ7p4NmUSz29OO93Kj8tE_003D = _0023_003DzUji6h6ltaAyxFOnw9V99dAk_003D;
		_0023_003Dz82BbYQPDjQY_0024 = _0023_003DzYrnVi6EDTYXT;
		this._0023_003DzwJX1WcPTuBxj = _0023_003DzwJX1WcPTuBxj;
	}

	internal MoveEventArgs(DeviceInfo _0023_003Dzopmfnqc_003D, TranslationVector _0023_003DzUji6h6ltaAyxFOnw9V99dAk_003D, float[] _0023_003DzwJX1WcPTuBxj = null)
	{
		_0023_003DzIYSBIN5rnb7u = _0023_003Dzopmfnqc_003D;
		_0023_003DzglqQ7p4NmUSz29OO93Kj8tE_003D = _0023_003DzUji6h6ltaAyxFOnw9V99dAk_003D;
		this._0023_003DzwJX1WcPTuBxj = _0023_003DzwJX1WcPTuBxj;
	}

	internal MoveEventArgs(DeviceInfo _0023_003Dzopmfnqc_003D, RotationVector _0023_003DzYrnVi6EDTYXT, float[] _0023_003DzwJX1WcPTuBxj = null)
	{
		_0023_003DzIYSBIN5rnb7u = _0023_003Dzopmfnqc_003D;
		_0023_003Dz82BbYQPDjQY_0024 = _0023_003DzYrnVi6EDTYXT;
		this._0023_003DzwJX1WcPTuBxj = _0023_003DzwJX1WcPTuBxj;
	}
}
