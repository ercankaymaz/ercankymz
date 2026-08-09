using System;
using System.Diagnostics;
using devDept.Geometry;

internal ref struct _0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D(double _0023_003DzBJFJHwk_003D = 0.0, double _0023_003Dz40R7bAU_003D = 0.0)
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public double _0023_003Dzyk2fsPo_003D = _0023_003DzBJFJHwk_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public double _0023_003DzvXOLtKg_003D = _0023_003Dz40R7bAU_003D;

	public double _0023_003DzEi_F9g8kJ9d2()
	{
		return _0023_003Dzyk2fsPo_003D * _0023_003Dzyk2fsPo_003D + _0023_003DzvXOLtKg_003D * _0023_003DzvXOLtKg_003D;
	}

	public double _0023_003Dz4m952JDFwKpj()
	{
		return Math.Sqrt(_0023_003DzEi_F9g8kJ9d2());
	}

	public double _0023_003DzbV1eOjg_003D()
	{
		double num = _0023_003Dz4m952JDFwKpj();
		_0023_003Dzyk2fsPo_003D /= num;
		_0023_003DzvXOLtKg_003D /= num;
		return num;
	}

	public static _0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D operator +([_0023_003Dz5unSlvr7pBWUwRMeMe_0024a4Te0kJiH] in _0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D _0023_003DzjbqS1qE_003D, [_0023_003Dz5unSlvr7pBWUwRMeMe_0024a4Te0kJiH] in _0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D _0023_003Dz1v6oPQk_003D)
	{
		return new _0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D(_0023_003DzjbqS1qE_003D._0023_003Dzyk2fsPo_003D + _0023_003Dz1v6oPQk_003D._0023_003Dzyk2fsPo_003D, _0023_003DzjbqS1qE_003D._0023_003DzvXOLtKg_003D + _0023_003Dz1v6oPQk_003D._0023_003DzvXOLtKg_003D);
	}

	public static _0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D operator -([_0023_003Dz5unSlvr7pBWUwRMeMe_0024a4Te0kJiH] in _0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D _0023_003DzjbqS1qE_003D, [_0023_003Dz5unSlvr7pBWUwRMeMe_0024a4Te0kJiH] in _0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D _0023_003Dz1v6oPQk_003D)
	{
		return new _0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D(_0023_003DzjbqS1qE_003D._0023_003Dzyk2fsPo_003D - _0023_003Dz1v6oPQk_003D._0023_003Dzyk2fsPo_003D, _0023_003DzjbqS1qE_003D._0023_003DzvXOLtKg_003D - _0023_003Dz1v6oPQk_003D._0023_003DzvXOLtKg_003D);
	}

	public static double operator *([_0023_003Dz5unSlvr7pBWUwRMeMe_0024a4Te0kJiH] in _0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D _0023_003DzjbqS1qE_003D, [_0023_003Dz5unSlvr7pBWUwRMeMe_0024a4Te0kJiH] in _0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D _0023_003Dz1v6oPQk_003D)
	{
		return _0023_003DzjbqS1qE_003D._0023_003Dzyk2fsPo_003D * _0023_003Dz1v6oPQk_003D._0023_003Dzyk2fsPo_003D + _0023_003DzjbqS1qE_003D._0023_003DzvXOLtKg_003D * _0023_003Dz1v6oPQk_003D._0023_003DzvXOLtKg_003D;
	}

	public static _0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D operator *([_0023_003Dz5unSlvr7pBWUwRMeMe_0024a4Te0kJiH] in _0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D _0023_003DzjbqS1qE_003D, in double _0023_003Dz1v6oPQk_003D)
	{
		return new _0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D(_0023_003DzjbqS1qE_003D._0023_003Dzyk2fsPo_003D * _0023_003Dz1v6oPQk_003D, _0023_003DzjbqS1qE_003D._0023_003DzvXOLtKg_003D * _0023_003Dz1v6oPQk_003D);
	}

	public static _0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D operator *(in double _0023_003Dz1v6oPQk_003D, [_0023_003Dz5unSlvr7pBWUwRMeMe_0024a4Te0kJiH] in _0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D _0023_003DzjbqS1qE_003D)
	{
		return _0023_003DzjbqS1qE_003D * _0023_003Dz1v6oPQk_003D;
	}

	public bool _0023_003DzPgAtIBTcbwwF()
	{
		return _0023_003Dz4m952JDFwKpj() < 1E-09;
	}

	public static bool _0023_003DzC7AXskgBNXCE(_0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D _0023_003Dz_eY3Y4c_003D, _0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D _0023_003Dz77g161c_003D)
	{
		return _0023_003DzC7AXskgBNXCE(_0023_003Dz_eY3Y4c_003D, _0023_003Dz77g161c_003D, Utility._0023_003DzheSR8QM7q9ya);
	}

	public static bool _0023_003DzC7AXskgBNXCE(_0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D _0023_003Dz_eY3Y4c_003D, _0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D _0023_003Dz77g161c_003D, double _0023_003Dzm0CYiiE_003D)
	{
		return Math.Abs(Math.Abs(_0023_003Dz_eY3Y4c_003D * _0023_003Dz77g161c_003D) - 1.0) < _0023_003Dzm0CYiiE_003D;
	}
}
