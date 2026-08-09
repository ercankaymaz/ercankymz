using System;

internal static class _0023_003Dz6huvP0yWdScitb7UJQ_003D_003D
{
	internal static string _0023_003DzqvDxsQb5gVmK5P_aOg_003D_003D;

	public static double _0023_003DzMeLY8V4_003D(double _0023_003DzBJFJHwk_003D)
	{
		if (_0023_003DzBJFJHwk_003D < 0.0)
		{
			return -1.0;
		}
		return 1.0;
	}

	public static bool _0023_003Dzo5HYhFiPdo0F(double _0023_003DzBJFJHwk_003D)
	{
		if (Math.Abs(_0023_003DzBJFJHwk_003D) < 1E-07)
		{
			return true;
		}
		return false;
	}

	public static double _0023_003DzezTples_003D()
	{
		double num = 1.0;
		while (1.0 < 1.0 + num)
		{
			num /= 2.0;
		}
		return 2.0 * num;
	}

	public static double _0023_003DzO3ViABFE1HgY(double _0023_003DzBJFJHwk_003D)
	{
		double num = 1000.0;
		while (_0023_003DzBJFJHwk_003D < _0023_003DzBJFJHwk_003D + num)
		{
			num /= 2.0;
		}
		return 2.0 * num;
	}

	public static float _0023_003DzzHiBoJxVwD7g(float _0023_003DzBJFJHwk_003D)
	{
		float num = 1000f;
		while (_0023_003DzBJFJHwk_003D < _0023_003DzBJFJHwk_003D + num)
		{
			num /= 2f;
		}
		return 2f * num;
	}

	public static void _0023_003DzxOQN_00247oigEZJJ9weNg_003D_003D(bool _0023_003DzInnreZ4_003D, string _0023_003DzuahRn9M_003D)
	{
	}

	public static bool _0023_003DzpjszHLaIb3xgNeFRLtH2jv8_003D(double _0023_003DzjbqS1qE_003D, double _0023_003Dz1v6oPQk_003D, double _0023_003Dzt_m8zV0_003D, double _0023_003DzXrexKjY_003D, double _0023_003DzbfrNXYE_003D, double _0023_003DzhidJeNw_003D, ref double _0023_003Dz_eY3Y4c_003D, ref double _0023_003Dz77g161c_003D)
	{
		double num = _0023_003DzjbqS1qE_003D * _0023_003DzXrexKjY_003D - _0023_003Dzt_m8zV0_003D * _0023_003Dz1v6oPQk_003D;
		if (_0023_003Dzo5HYhFiPdo0F(num))
		{
			return false;
		}
		double num2 = 1.0 / num;
		_0023_003Dz_eY3Y4c_003D = num2 * (_0023_003DzXrexKjY_003D * _0023_003DzbfrNXYE_003D - _0023_003Dz1v6oPQk_003D * _0023_003DzhidJeNw_003D);
		_0023_003Dz77g161c_003D = num2 * ((0.0 - _0023_003Dzt_m8zV0_003D) * _0023_003DzbfrNXYE_003D + _0023_003DzjbqS1qE_003D * _0023_003DzhidJeNw_003D);
		return true;
	}

	public static bool _0023_003DzrHz5RVh71YJ92yKC93hy11ZjStD1fhJklA_003D_003D(_0023_003DzmKBPh7nOT6nY _0023_003DzFj_0024IqDQ_003D, _0023_003DzmKBPh7nOT6nY _0023_003DzjdeMMkk_003D, ref double _0023_003Dz77g161c_003D, _0023_003DzmKBPh7nOT6nY _0023_003Dzm4eSPQQ_003D, _0023_003DzmKBPh7nOT6nY _0023_003DzR8q4i70_003D, ref double _0023_003DzNDQ_E88_003D)
	{
		double _0023_003DzjbqS1qE_003D = _0023_003DzjdeMMkk_003D._0023_003DzBJFJHwk_003D - _0023_003DzFj_0024IqDQ_003D._0023_003DzBJFJHwk_003D;
		double _0023_003Dzt_m8zV0_003D = _0023_003DzjdeMMkk_003D._0023_003Dz40R7bAU_003D - _0023_003DzFj_0024IqDQ_003D._0023_003Dz40R7bAU_003D;
		double num = _0023_003DzR8q4i70_003D._0023_003DzBJFJHwk_003D - _0023_003Dzm4eSPQQ_003D._0023_003DzBJFJHwk_003D;
		double num2 = _0023_003DzR8q4i70_003D._0023_003Dz40R7bAU_003D - _0023_003Dzm4eSPQQ_003D._0023_003Dz40R7bAU_003D;
		double _0023_003DzbfrNXYE_003D = _0023_003Dzm4eSPQQ_003D._0023_003DzBJFJHwk_003D - _0023_003DzFj_0024IqDQ_003D._0023_003DzBJFJHwk_003D;
		double _0023_003DzhidJeNw_003D = _0023_003Dzm4eSPQQ_003D._0023_003Dz40R7bAU_003D - _0023_003DzFj_0024IqDQ_003D._0023_003Dz40R7bAU_003D;
		return _0023_003DzpjszHLaIb3xgNeFRLtH2jv8_003D(_0023_003DzjbqS1qE_003D, 0.0 - num, _0023_003Dzt_m8zV0_003D, 0.0 - num2, _0023_003DzbfrNXYE_003D, _0023_003DzhidJeNw_003D, ref _0023_003Dz77g161c_003D, ref _0023_003DzNDQ_E88_003D);
	}

	public static double _0023_003Dz5ueuqj7UFizTIXEmUmkibac_003D(double _0023_003DzBJFJHwk_003D, double _0023_003Dz40R7bAU_003D)
	{
		if (_0023_003Dz40R7bAU_003D >= 0.0)
		{
			return (_0023_003DzBJFJHwk_003D >= 0.0) ? (_0023_003Dz40R7bAU_003D / (_0023_003DzBJFJHwk_003D + _0023_003Dz40R7bAU_003D)) : (1.0 - _0023_003DzBJFJHwk_003D / (0.0 - _0023_003DzBJFJHwk_003D + _0023_003Dz40R7bAU_003D));
		}
		return (_0023_003DzBJFJHwk_003D < 0.0) ? (2.0 - _0023_003Dz40R7bAU_003D / (0.0 - _0023_003DzBJFJHwk_003D - _0023_003Dz40R7bAU_003D)) : (3.0 + _0023_003DzBJFJHwk_003D / (_0023_003DzBJFJHwk_003D - _0023_003Dz40R7bAU_003D));
	}

	public static double _0023_003Dzl58WxhvL9C3Al5dW_0024w_003D_003D(double _0023_003DzjbqS1qE_003D, double _0023_003Dz1v6oPQk_003D, double _0023_003DzezTples_003D, double _0023_003DzNDQ_E88_003D, _0023_003Dz0mbRiACU2kDQ _0023_003Dz_0024Ix3IG0_003D)
	{
		double num = _0023_003Dz_0024Ix3IG0_003D._0023_003Dz7R4nzv0_003D(_0023_003DzjbqS1qE_003D);
		double num2 = _0023_003Dz_0024Ix3IG0_003D._0023_003Dz7R4nzv0_003D(_0023_003Dz1v6oPQk_003D);
		double num3 = _0023_003DzjbqS1qE_003D;
		double num4 = num;
		double num5 = _0023_003Dz1v6oPQk_003D - _0023_003DzjbqS1qE_003D;
		double num6 = num5;
		while (true)
		{
			if (Math.Abs(num4) < Math.Abs(num2))
			{
				_0023_003DzjbqS1qE_003D = _0023_003Dz1v6oPQk_003D;
				_0023_003Dz1v6oPQk_003D = num3;
				num3 = _0023_003DzjbqS1qE_003D;
				num = num2;
				num2 = num4;
				num4 = num;
			}
			double num7 = 2.0 * _0023_003DzezTples_003D * Math.Abs(_0023_003Dz1v6oPQk_003D) + _0023_003DzNDQ_E88_003D;
			double num8 = 0.5 * (num3 - _0023_003Dz1v6oPQk_003D);
			if (Math.Abs(num8) <= num7 || num2 == 0.0)
			{
				break;
			}
			if (Math.Abs(num5) < num7 || Math.Abs(num) <= Math.Abs(num2))
			{
				num5 = num8;
				num6 = num5;
			}
			else
			{
				double num9 = num2 / num;
				double num10;
				double num11;
				if (_0023_003DzjbqS1qE_003D == num3)
				{
					num10 = 2.0 * num8 * num9;
					num11 = 1.0 - num9;
				}
				else
				{
					num11 = num / num4;
					double num12 = num2 / num4;
					num10 = num9 * (2.0 * num8 * _0023_003DzjbqS1qE_003D * (num11 - num12) - (_0023_003Dz1v6oPQk_003D - _0023_003DzjbqS1qE_003D) * (num12 - 1.0));
					num11 = (num11 - 1.0) * (num12 - 1.0) * (num9 - 1.0);
				}
				if (num10 > 0.0)
				{
					num11 = 0.0 - num11;
				}
				else
				{
					num10 = 0.0 - num10;
				}
				num9 = num5;
				num5 = num6;
				if (2.0 * num10 < 3.0 * num8 * num11 - Math.Abs(num7 * num11) && num10 < Math.Abs(0.5 * num9 * num11))
				{
					num6 = num10 / num11;
				}
				else
				{
					num5 = num8;
					num6 = num5;
				}
			}
			_0023_003DzjbqS1qE_003D = _0023_003Dz1v6oPQk_003D;
			num = num2;
			_0023_003Dz1v6oPQk_003D = ((Math.Abs(num6) > num7) ? (_0023_003Dz1v6oPQk_003D + num6) : ((!(num8 > 0.0)) ? (_0023_003Dz1v6oPQk_003D - num7) : (_0023_003Dz1v6oPQk_003D + num7)));
			num2 = _0023_003Dz_0024Ix3IG0_003D._0023_003Dz7R4nzv0_003D(_0023_003Dz1v6oPQk_003D);
			if ((num2 > 0.0 && num4 > 0.0) || (num2 <= 0.0 && num4 <= 0.0))
			{
				num3 = _0023_003DzjbqS1qE_003D;
				num4 = num;
				num5 = _0023_003Dz1v6oPQk_003D - _0023_003DzjbqS1qE_003D;
				num6 = num5;
			}
		}
		return _0023_003Dz1v6oPQk_003D;
	}
}
