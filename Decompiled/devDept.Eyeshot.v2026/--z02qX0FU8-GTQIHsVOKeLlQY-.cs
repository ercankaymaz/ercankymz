using System;

internal sealed class _0023_003Dz02qX0FU8_0024GTQIHsVOKeLlQY_003D
{
	public void _0023_003Dzz8DDgng_003D(int _0023_003DzpGjKR04_003D, double[] _0023_003Dzyk2fsPo_003D, int _0023_003DzVwzJWWz_0024BCSn, int _0023_003DzPha_0024VJlONheb, ref double _0023_003DzIUgu2LtnOfe7, ref double _0023_003Dz_0024C0pdx_R2pZX)
	{
		int num = 0;
		double num2 = 0.0;
		int num3 = -1 + _0023_003DzVwzJWWz_0024BCSn;
		if (_0023_003DzpGjKR04_003D <= 0)
		{
			return;
		}
		for (num = 1; (_0023_003DzPha_0024VJlONheb >= 0) ? (num <= 1 + (_0023_003DzpGjKR04_003D - 1) * _0023_003DzPha_0024VJlONheb) : (num >= 1 + (_0023_003DzpGjKR04_003D - 1) * _0023_003DzPha_0024VJlONheb); num += _0023_003DzPha_0024VJlONheb)
		{
			if (_0023_003Dzyk2fsPo_003D[num + num3] != 0.0)
			{
				num2 = Math.Abs(_0023_003Dzyk2fsPo_003D[num + num3]);
				if (_0023_003DzIUgu2LtnOfe7 < num2)
				{
					_0023_003Dz_0024C0pdx_R2pZX = 1.0 + _0023_003Dz_0024C0pdx_R2pZX * Math.Pow(_0023_003DzIUgu2LtnOfe7 / num2, 2.0);
					_0023_003DzIUgu2LtnOfe7 = num2;
				}
				else
				{
					_0023_003Dz_0024C0pdx_R2pZX += Math.Pow(num2 / _0023_003DzIUgu2LtnOfe7, 2.0);
				}
			}
		}
	}
}
