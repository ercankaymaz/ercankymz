using System;
using System.Collections.Generic;

internal sealed class _0023_003Dz4bQB7f9e8mCtX_ivosmY4ynvt_I_0024VHY6ew_003D_003D
{
	public static double _0023_003Dzia9b_Y_HjeB9 = 1E-05;

	public static double _0023_003DziMBFML0_003D()
	{
		return Math.PI;
	}

	public static double _0023_003DzgTBh2DI_003D()
	{
		return 2.0 * _0023_003DziMBFML0_003D();
	}

	public static bool _0023_003Dzgr6OWgJnCIU5(double _0023_003DzBJFJHwk_003D, double _0023_003Dz40R7bAU_003D)
	{
		return Math.Abs(_0023_003DzBJFJHwk_003D - _0023_003Dz40R7bAU_003D) < 1E-08;
	}

	public static bool _0023_003Dzgr6OWgJnCIU5(double _0023_003DzBJFJHwk_003D, double _0023_003Dz40R7bAU_003D, double _0023_003Dz3e_0024V4rMqAC2d)
	{
		return Math.Abs(_0023_003DzBJFJHwk_003D - _0023_003Dz40R7bAU_003D) < _0023_003Dz3e_0024V4rMqAC2d;
	}

	public static Tuple<double, double> _0023_003DzpCFqicifCRJ_3loCCg_003D_003D(double _0023_003DzjbqS1qE_003D, double _0023_003Dz1v6oPQk_003D, double _0023_003Dzt_m8zV0_003D, double _0023_003DzpXu07aBHo4uJ)
	{
		double num = Math.Sqrt(_0023_003DzpXu07aBHo4uJ);
		double num2 = 2.0 * _0023_003DzjbqS1qE_003D;
		double num3 = ((!(_0023_003Dz1v6oPQk_003D < 0.0)) ? ((0.0 - _0023_003Dz1v6oPQk_003D - num) / num2) : ((0.0 - _0023_003Dz1v6oPQk_003D + num) / num2));
		double item = _0023_003Dzt_m8zV0_003D / _0023_003DzjbqS1qE_003D / num3;
		return Tuple.Create(num3, item);
	}

	public static uint _0023_003DzduXNaEJiW25_0024(uint _0023_003DzyzK8swU_003D, _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003DzpF1pkP4_003D)
	{
		if (!_0023_003DzpF1pkP4_003D._0023_003Dz73g2ov8e6Mnc() && _0023_003DzyzK8swU_003D == _0023_003DzpF1pkP4_003D._0023_003Dz14lzA48_003D() - 1)
		{
			return uint.MaxValue;
		}
		if (_0023_003DzyzK8swU_003D == _0023_003DzpF1pkP4_003D._0023_003Dz14lzA48_003D() - 1)
		{
			return 0u;
		}
		return _0023_003DzyzK8swU_003D + 1;
	}

	public static uint _0023_003DzduXNaEJiW25_0024(uint _0023_003DzyzK8swU_003D, List<_0023_003DzFojHQdGSdFDtEdoRCKp_0024w9o_003D> _0023_003DzpF1pkP4_003D)
	{
		if (_0023_003DzyzK8swU_003D == _0023_003DzpF1pkP4_003D.Count - 1)
		{
			return 0u;
		}
		return _0023_003DzyzK8swU_003D + 1;
	}

	public static uint _0023_003DzrbhIMkY6PI8C(uint _0023_003DzyzK8swU_003D, _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003DzpF1pkP4_003D)
	{
		if (!_0023_003DzpF1pkP4_003D._0023_003Dz73g2ov8e6Mnc() && _0023_003DzyzK8swU_003D == 0)
		{
			return uint.MaxValue;
		}
		if (_0023_003DzyzK8swU_003D == 0)
		{
			return _0023_003DzpF1pkP4_003D._0023_003Dz14lzA48_003D() - 1;
		}
		return _0023_003DzyzK8swU_003D - 1;
	}

	public static bool _0023_003DzQomQrwyFIumGSqAjXg_003D_003D(double _0023_003DzSXOFpUo_003D, double _0023_003DzPzO_0024GUk_003D, double _0023_003DzVa67bP8_003D)
	{
		if (_0023_003DzPzO_0024GUk_003D + 1E-08 > _0023_003DzSXOFpUo_003D)
		{
			return _0023_003DzPzO_0024GUk_003D < _0023_003DzVa67bP8_003D + 1E-08;
		}
		return false;
	}

	public static Tuple<double, double> _0023_003Dztag8Lp9xJLbL(double _0023_003Dz84KsKCc_003D, double _0023_003DzQEXDSA0_003D)
	{
		return Tuple.Create(Math.Min(_0023_003Dz84KsKCc_003D, _0023_003DzQEXDSA0_003D), Math.Max(_0023_003Dz84KsKCc_003D, _0023_003DzQEXDSA0_003D));
	}

	internal static void _0023_003Dzxd6BoZ4_003D(_0023_003DzDNNsCTSlechlGFK2FpSsPwo7AmNX _0023_003DzOLHnb2M_003D)
	{
		double _0023_003DzDSaZWik_003D = _0023_003DzOLHnb2M_003D._0023_003DzDSaZWik_003D;
		_0023_003DzOLHnb2M_003D._0023_003DzDSaZWik_003D = _0023_003DzOLHnb2M_003D._0023_003DzsK_Xndk_003D;
		_0023_003DzOLHnb2M_003D._0023_003DzsK_Xndk_003D = _0023_003DzDSaZWik_003D;
	}

	internal static void _0023_003Dzxd6BoZ4_003D(_0023_003Dz9EaLsos56zhlqklwSdaMHsBa9NYylORilg_003D_003D _0023_003DzOLHnb2M_003D)
	{
		_0023_003DzcQiRB3Mv_00246WF _0023_003DzrNyhm6g_003D = _0023_003DzOLHnb2M_003D._0023_003DzrNyhm6g_003D;
		_0023_003DzOLHnb2M_003D._0023_003DzrNyhm6g_003D = _0023_003DzOLHnb2M_003D._0023_003DztY_anuo_003D;
		_0023_003DzOLHnb2M_003D._0023_003DztY_anuo_003D = _0023_003DzrNyhm6g_003D;
	}

	public static void _0023_003Dzxd6BoZ4_003D(ref _0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D _0023_003Dz_Pbwmxzwl0tt, List<_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D> _0023_003DzSoDdsh8bO72L, int _0023_003DzyzK8swU_003D)
	{
		_0023_003Dz_0024q_0024nWvPiDZJQryypiUIrJ4w_003D value = _0023_003Dz_Pbwmxzwl0tt;
		_0023_003Dz_Pbwmxzwl0tt = _0023_003DzSoDdsh8bO72L[_0023_003DzyzK8swU_003D];
		_0023_003DzSoDdsh8bO72L[_0023_003DzyzK8swU_003D] = value;
	}

	public static double _0023_003DzeodsiXfATyembCsp8g_003D_003D(double _0023_003Dz6pajdGM_003D)
	{
		if (_0023_003Dz6pajdGM_003D >= 0.0 && _0023_003Dz6pajdGM_003D <= _0023_003DzgTBh2DI_003D())
		{
			return _0023_003Dz6pajdGM_003D;
		}
		return _0023_003Dz6pajdGM_003D - Math.Floor(_0023_003Dz6pajdGM_003D / _0023_003DzgTBh2DI_003D()) * _0023_003DzgTBh2DI_003D();
	}

	public static bool _0023_003DzzUp2VXs97Z27(double _0023_003Dz3veEI49c6b6Q, double _0023_003Dzym8rm2qBnh3b, double _0023_003Dz7l89E8fveted)
	{
		double num = _0023_003Dz3veEI49c6b6Q + _0023_003Dzym8rm2qBnh3b;
		if (_0023_003Dzym8rm2qBnh3b < 0.0)
		{
			return _0023_003Dzo6BKHqPOZ4_0024O(num, _0023_003Dz3veEI49c6b6Q, _0023_003Dz7l89E8fveted);
		}
		return _0023_003Dzo6BKHqPOZ4_0024O(_0023_003Dz3veEI49c6b6Q, num, _0023_003Dz7l89E8fveted);
	}

	public static double _0023_003DzFINJ6s3Z_0024n8G(double _0023_003DzFAg3lSY_003D, double _0023_003DzmXqPvvk_003D)
	{
		double num = _0023_003DzeodsiXfATyembCsp8g_003D_003D(_0023_003DzmXqPvvk_003D - _0023_003DzFAg3lSY_003D);
		if (num > _0023_003DziMBFML0_003D())
		{
			num -= _0023_003DzgTBh2DI_003D();
		}
		return num;
	}

	public static bool _0023_003Dzo6BKHqPOZ4_0024O(double _0023_003Dz3veEI49c6b6Q, double _0023_003DzSeznUY9fyh7N, double _0023_003Dz7l89E8fveted)
	{
		double num = _0023_003DzeodsiXfATyembCsp8g_003D_003D(_0023_003DzSeznUY9fyh7N - _0023_003Dz3veEI49c6b6Q);
		return _0023_003DzeodsiXfATyembCsp8g_003D_003D(_0023_003Dz7l89E8fveted - _0023_003Dz3veEI49c6b6Q) < num + 1E-08;
	}
}
