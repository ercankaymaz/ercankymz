using System;

internal sealed class _0023_003Dz3Ev05LvnwCgMjitCDCzs6iA_003D
{
	public int _0023_003Dzz8DDgng_003D(int _0023_003DzpGjKR04_003D, double[] _0023_003Dzkyw2mdM_003D, int _0023_003Dzcg5G72corELm, int _0023_003DzPha_0024VJlONheb)
	{
		int num = 0;
		double num2 = 0.0;
		int num3 = 0;
		int num4 = 0;
		int num5 = -1 + _0023_003Dzcg5G72corELm;
		num = 0;
		if (_0023_003DzpGjKR04_003D < 1 || _0023_003DzPha_0024VJlONheb <= 0)
		{
			return num;
		}
		num = 1;
		if (_0023_003DzpGjKR04_003D == 1)
		{
			return num;
		}
		if (_0023_003DzPha_0024VJlONheb != 1)
		{
			num4 = 1;
			num2 = Math.Abs(_0023_003Dzkyw2mdM_003D[1 + num5]);
			num4 += _0023_003DzPha_0024VJlONheb;
			for (num3 = 2; num3 <= _0023_003DzpGjKR04_003D; num3++)
			{
				if (!(Math.Abs(_0023_003Dzkyw2mdM_003D[num4 + num5]) <= num2))
				{
					num = num3;
					num2 = Math.Abs(_0023_003Dzkyw2mdM_003D[num4 + num5]);
				}
				num4 += _0023_003DzPha_0024VJlONheb;
			}
			return num;
		}
		num2 = Math.Abs(_0023_003Dzkyw2mdM_003D[1 + num5]);
		for (num3 = 2; num3 <= _0023_003DzpGjKR04_003D; num3++)
		{
			if (!(Math.Abs(_0023_003Dzkyw2mdM_003D[num3 + num5]) <= num2))
			{
				num = num3;
				num2 = Math.Abs(_0023_003Dzkyw2mdM_003D[num3 + num5]);
			}
		}
		return num;
	}
}
