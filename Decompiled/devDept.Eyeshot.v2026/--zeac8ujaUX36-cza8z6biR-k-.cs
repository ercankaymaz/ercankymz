using System;

internal sealed class _0023_003Dzeac8ujaUX36_0024cza8z6biR_0024k_003D
{
	public double _0023_003Dzz8DDgng_003D(int _0023_003DzpGjKR04_003D, double[] _0023_003Dzkyw2mdM_003D, int _0023_003Dzcg5G72corELm, int _0023_003DzPha_0024VJlONheb)
	{
		double num = 0.0;
		double num2 = 0.0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = -1 + _0023_003Dzcg5G72corELm;
		num = 0.0;
		num2 = 0.0;
		if (_0023_003DzpGjKR04_003D <= 0 || _0023_003DzPha_0024VJlONheb <= 0)
		{
			return num;
		}
		if (_0023_003DzPha_0024VJlONheb != 1)
		{
			num5 = _0023_003DzpGjKR04_003D * _0023_003DzPha_0024VJlONheb;
			for (num3 = 1; (_0023_003DzPha_0024VJlONheb >= 0) ? (num3 <= num5) : (num3 >= num5); num3 += _0023_003DzPha_0024VJlONheb)
			{
				num2 += Math.Abs(_0023_003Dzkyw2mdM_003D[num3 + num6]);
			}
			return num2;
		}
		num4 = _0023_003Dzt81xN7aa_002489vTvlbYozS6TUjvqyF._0023_003Dz4vcHOP8_003D(_0023_003DzpGjKR04_003D, 6);
		if (num4 != 0)
		{
			for (num3 = 1; num3 <= num4; num3++)
			{
				num2 += Math.Abs(_0023_003Dzkyw2mdM_003D[num3 + num6]);
			}
			if (_0023_003DzpGjKR04_003D < 6)
			{
				goto IL_0105;
			}
		}
		for (num3 = num4 + 1; num3 <= _0023_003DzpGjKR04_003D; num3 += 6)
		{
			num2 += Math.Abs(_0023_003Dzkyw2mdM_003D[num3 + num6]) + Math.Abs(_0023_003Dzkyw2mdM_003D[num3 + 1 + num6]) + Math.Abs(_0023_003Dzkyw2mdM_003D[num3 + 2 + num6]) + Math.Abs(_0023_003Dzkyw2mdM_003D[num3 + 3 + num6]) + Math.Abs(_0023_003Dzkyw2mdM_003D[num3 + 4 + num6]) + Math.Abs(_0023_003Dzkyw2mdM_003D[num3 + 5 + num6]);
		}
		goto IL_0105;
		IL_0105:
		return num2;
	}
}
