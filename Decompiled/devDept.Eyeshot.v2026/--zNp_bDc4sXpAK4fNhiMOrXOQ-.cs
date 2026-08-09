using System;

internal sealed class _0023_003DzNp_bDc4sXpAK4fNhiMOrXOQ_003D
{
	public double _0023_003Dzz8DDgng_003D(int _0023_003DzpGjKR04_003D, double[] _0023_003Dzyk2fsPo_003D, int _0023_003DzVwzJWWz_0024BCSn, int _0023_003DzPha_0024VJlONheb)
	{
		int num = 0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		int num6 = -1 + _0023_003DzVwzJWWz_0024BCSn;
		if (_0023_003DzpGjKR04_003D < 1 || _0023_003DzPha_0024VJlONheb < 1)
		{
			return 0.0;
		}
		if (_0023_003DzpGjKR04_003D == 1)
		{
			return Math.Abs(_0023_003Dzyk2fsPo_003D[1 + num6]);
		}
		num4 = 0.0;
		num5 = 1.0;
		for (num = 1; (_0023_003DzPha_0024VJlONheb >= 0) ? (num <= 1 + (_0023_003DzpGjKR04_003D - 1) * _0023_003DzPha_0024VJlONheb) : (num >= 1 + (_0023_003DzpGjKR04_003D - 1) * _0023_003DzPha_0024VJlONheb); num += _0023_003DzPha_0024VJlONheb)
		{
			if (_0023_003Dzyk2fsPo_003D[num + num6] != 0.0)
			{
				num2 = Math.Abs(_0023_003Dzyk2fsPo_003D[num + num6]);
				if (num4 < num2)
				{
					num5 = 1.0 + num5 * Math.Pow(num4 / num2, 2.0);
					num4 = num2;
				}
				else
				{
					num5 += Math.Pow(num2 / num4, 2.0);
				}
			}
		}
		return num4 * Math.Sqrt(num5);
	}
}
