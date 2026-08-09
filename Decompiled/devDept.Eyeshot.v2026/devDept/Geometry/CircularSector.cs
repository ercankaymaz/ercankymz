using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace devDept.Geometry;

public class CircularSector
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Vector2D _0023_003DzZpJGZWqKUZ_00243q59QSg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Vector2D _0023_003DzMceFipG6e89Xy7qy7A_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003Dzqv08V9d_0024vTF2TL0Pv4pMRRU_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Interval _0023_003DziltOpF4do1C2k4fsSw_003D_003D;

	public Vector2D Start
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzZpJGZWqKUZ_00243q59QSg_003D_003D;
		}
	}

	public Vector2D End
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzMceFipG6e89Xy7qy7A_003D_003D;
		}
	}

	public double CentralAngle
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzqv08V9d_0024vTF2TL0Pv4pMRRU_003D;
		}
	}

	public Interval Domain
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DziltOpF4do1C2k4fsSw_003D_003D;
		}
	}

	public CircularSector(Vector2D start, Vector2D end)
	{
		_0023_003DztGdcVOA_003D(start, end);
	}

	public CircularSector(Vector2D v1, Vector2D v2, Vector2D pointIn)
	{
		_0023_003DzE8NmKSc_003D(v1);
		_0023_003DzEGrVsNI_003D(v2);
		double num = _0023_003DzhC77ON751qRg(Vector2D.SignedAngleBetween(v1, pointIn));
		double num2 = _0023_003DzhC77ON751qRg(Vector2D.SignedAngleBetween(v1, v2));
		if (num <= num2)
		{
			_0023_003DztGdcVOA_003D(v1, v2);
		}
		else
		{
			_0023_003DztGdcVOA_003D(v2, v1);
		}
	}

	private void _0023_003DzE8NmKSc_003D(Vector2D _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzZpJGZWqKUZ_00243q59QSg_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	private void _0023_003DzEGrVsNI_003D(Vector2D _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzMceFipG6e89Xy7qy7A_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	private void _0023_003DzSMCz4_7dOqiU(double _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003Dzqv08V9d_0024vTF2TL0Pv4pMRRU_003D = _0023_003DzPzO_0024GUk_003D;
	}

	private void _0023_003DzIumdvTEyzj98(Interval _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DziltOpF4do1C2k4fsSw_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	public bool Contains(Vector2D vector)
	{
		return _0023_003DzhC77ON751qRg(Vector2D.SignedAngleBetween(Start, vector)) < CentralAngle;
	}

	internal static double _0023_003DzhC77ON751qRg(double _0023_003Dz6pajdGM_003D)
	{
		if (!(_0023_003Dz6pajdGM_003D < 0.0))
		{
			return _0023_003Dz6pajdGM_003D;
		}
		return Math.PI * 2.0 + _0023_003Dz6pajdGM_003D;
	}

	private void _0023_003DztGdcVOA_003D(Vector2D _0023_003DzAqOpw0w_003D, Vector2D _0023_003Dzk64JNOo_003D)
	{
		_0023_003DzE8NmKSc_003D(_0023_003DzAqOpw0w_003D);
		_0023_003DzEGrVsNI_003D(_0023_003Dzk64JNOo_003D);
		_0023_003DzSMCz4_7dOqiU(_0023_003DzhC77ON751qRg(Vector2D.SignedAngleBetween(_0023_003DzAqOpw0w_003D, _0023_003Dzk64JNOo_003D)));
		double num = _0023_003DzhC77ON751qRg(_0023_003DzAqOpw0w_003D.Angle);
		_0023_003DzIumdvTEyzj98(new Interval(num, num + CentralAngle));
	}
}
