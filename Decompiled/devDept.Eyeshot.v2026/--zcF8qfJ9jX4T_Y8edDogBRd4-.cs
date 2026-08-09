using System;

internal sealed class _0023_003DzcF8qfJ9jX4T_Y8edDogBRd4_003D
{
	public void _0023_003Dzz8DDgng_003D(double _0023_003DzE8QrneA_003D, double _0023_003DzH9VU2k0_003D, double _0023_003DzshZYG54_003D, ref double _0023_003Dz4pdDTYs_003D, ref double _0023_003DzdMc_0024SUk_003D)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		double num6 = 0.0;
		num6 = _0023_003DzE8QrneA_003D + _0023_003DzshZYG54_003D;
		num4 = Math.Abs(_0023_003DzE8QrneA_003D - _0023_003DzshZYG54_003D);
		num = Math.Abs(_0023_003DzH9VU2k0_003D + _0023_003DzH9VU2k0_003D);
		if (Math.Abs(_0023_003DzE8QrneA_003D) > Math.Abs(_0023_003DzshZYG54_003D))
		{
			num3 = _0023_003DzE8QrneA_003D;
			num2 = _0023_003DzshZYG54_003D;
		}
		else
		{
			num3 = _0023_003DzshZYG54_003D;
			num2 = _0023_003DzE8QrneA_003D;
		}
		num5 = ((num4 > num) ? (num4 * Math.Sqrt(1.0 + Math.Pow(num / num4, 2.0))) : ((!(num4 < num)) ? (num * Math.Sqrt(2.0)) : (num * Math.Sqrt(1.0 + Math.Pow(num4 / num, 2.0)))));
		if (num6 < 0.0)
		{
			_0023_003Dz4pdDTYs_003D = 0.5 * (num6 - num5);
			_0023_003DzdMc_0024SUk_003D = num3 / _0023_003Dz4pdDTYs_003D * num2 - _0023_003DzH9VU2k0_003D / _0023_003Dz4pdDTYs_003D * _0023_003DzH9VU2k0_003D;
		}
		else if (num6 > 0.0)
		{
			_0023_003Dz4pdDTYs_003D = 0.5 * (num6 + num5);
			_0023_003DzdMc_0024SUk_003D = num3 / _0023_003Dz4pdDTYs_003D * num2 - _0023_003DzH9VU2k0_003D / _0023_003Dz4pdDTYs_003D * _0023_003DzH9VU2k0_003D;
		}
		else
		{
			_0023_003Dz4pdDTYs_003D = 0.5 * num5;
			_0023_003DzdMc_0024SUk_003D = -0.5 * num5;
		}
	}
}
