using System;
using devDept.Geometry;
using devDept.Geometry.ConstraintSolver;

internal static class _0023_003DzMr7dyDtNhE5ce7x_0024P8Wmwj_B7hbJ
{
	public static ExpVector _0023_003DzvZMbgytPb1MBmFLfWQ_003D_003D(ExpVector _0023_003Dz63mFiXY_003D, Exp _0023_003Dz6pajdGM_003D)
	{
		Exp exp = Exp._0023_003DzHqHPcG0_003D(_0023_003Dz6pajdGM_003D);
		Exp exp2 = Exp._0023_003DzzFteY6c_003D(_0023_003Dz6pajdGM_003D);
		return new ExpVector(exp * _0023_003Dz63mFiXY_003D.x - exp2 * _0023_003Dz63mFiXY_003D.y, exp2 * _0023_003Dz63mFiXY_003D.x + exp * _0023_003Dz63mFiXY_003D.y, _0023_003Dz63mFiXY_003D.z);
	}

	public static Exp _0023_003Dz5wNeT2sDg28l(ExpVector _0023_003DzizVqTKE_003D, ExpVector _0023_003Dzt38nTwk_003D, bool _0023_003DzYRitoXujv8Dc)
	{
		Exp exp = _0023_003Dzt38nTwk_003D.x * _0023_003DzizVqTKE_003D.x + _0023_003Dzt38nTwk_003D.y * _0023_003DzizVqTKE_003D.y;
		Exp _0023_003DzBJFJHwk_003D = _0023_003DzizVqTKE_003D.x * _0023_003Dzt38nTwk_003D.y - _0023_003DzizVqTKE_003D.y * _0023_003Dzt38nTwk_003D.x;
		if (_0023_003DzYRitoXujv8Dc)
		{
			return Math.PI - Exp._0023_003DzmSWwcFA_003D(_0023_003DzBJFJHwk_003D, -exp);
		}
		return Exp._0023_003DzmSWwcFA_003D(_0023_003DzBJFJHwk_003D, exp);
	}

	public static Exp _0023_003DzwnmeKH36nol2(ExpVector _0023_003DzizVqTKE_003D, ExpVector _0023_003Dzt38nTwk_003D)
	{
		return Exp._0023_003DzmSWwcFA_003D(ExpVector._0023_003DzyJipUOg_003D(_0023_003DzizVqTKE_003D, _0023_003Dzt38nTwk_003D)._0023_003Dz9AfN_TRv_0024HgPy9WmXQ_003D_003D(), ExpVector._0023_003DzBWYOAtM_003D(_0023_003DzizVqTKE_003D, _0023_003Dzt38nTwk_003D));
	}

	public static double _0023_003Dz5wNeT2sDg28l(Vector3D _0023_003DzizVqTKE_003D, Vector3D _0023_003Dzt38nTwk_003D, bool _0023_003DzYRitoXujv8Dc)
	{
		double num = _0023_003Dzt38nTwk_003D.X * _0023_003DzizVqTKE_003D.X + _0023_003Dzt38nTwk_003D.Y * _0023_003DzizVqTKE_003D.Y;
		double y = _0023_003DzizVqTKE_003D.X * _0023_003Dzt38nTwk_003D.Y - _0023_003DzizVqTKE_003D.Y * _0023_003Dzt38nTwk_003D.X;
		if (_0023_003DzYRitoXujv8Dc)
		{
			return Math.PI - Math.Atan2(y, 0.0 - num);
		}
		return Math.Atan2(y, num);
	}

	public static double _0023_003DzwnmeKH36nol2(Vector3D _0023_003DzizVqTKE_003D, Vector3D _0023_003Dzt38nTwk_003D)
	{
		return Math.Atan2(Vector3D.Cross(_0023_003DzizVqTKE_003D, _0023_003Dzt38nTwk_003D).Length, Vector3D.Dot(_0023_003DzizVqTKE_003D, _0023_003Dzt38nTwk_003D));
	}

	public static Exp _0023_003DzRV_qN4O3vHon(ExpVector _0023_003DzB68dg9Q_003D, ExpVector _0023_003DzDVubtvo_003D, ExpVector _0023_003DzFj_0024IqDQ_003D, bool _0023_003DzUsRH_0024vc_003D)
	{
		if (_0023_003DzUsRH_0024vc_003D)
		{
			ExpVector expVector = _0023_003DzDVubtvo_003D - _0023_003DzFj_0024IqDQ_003D;
			return ExpVector._0023_003DzyJipUOg_003D(expVector, _0023_003DzDVubtvo_003D - _0023_003DzB68dg9Q_003D)._0023_003Dz9AfN_TRv_0024HgPy9WmXQ_003D_003D() / expVector._0023_003Dz9AfN_TRv_0024HgPy9WmXQ_003D_003D();
		}
		return Exp._0023_003Dz0v89Hn0_003D((_0023_003DzDVubtvo_003D.y - _0023_003DzFj_0024IqDQ_003D.y) * _0023_003DzB68dg9Q_003D.x + (_0023_003DzFj_0024IqDQ_003D.x - _0023_003DzDVubtvo_003D.x) * _0023_003DzB68dg9Q_003D.y + _0023_003DzDVubtvo_003D.x * _0023_003DzFj_0024IqDQ_003D.y - _0023_003DzFj_0024IqDQ_003D.x * _0023_003DzDVubtvo_003D.y) / Exp._0023_003Dzn7TsgvrQX_0024_7(Exp._0023_003DzKSdA2AY_003D(_0023_003DzFj_0024IqDQ_003D.x - _0023_003DzDVubtvo_003D.x) + Exp._0023_003DzKSdA2AY_003D(_0023_003DzFj_0024IqDQ_003D.y - _0023_003DzDVubtvo_003D.y));
	}
}
