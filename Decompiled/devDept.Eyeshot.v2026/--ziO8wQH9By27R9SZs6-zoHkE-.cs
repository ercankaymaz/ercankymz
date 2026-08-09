using System;

internal sealed class _0023_003DziO8wQH9By27R9SZs6_0024zoHkE_003D
{
	public void _0023_003Dzz8DDgng_003D(double _0023_003DzE8QrneA_003D, double _0023_003DzH9VU2k0_003D, double _0023_003DzshZYG54_003D, ref double _0023_003Dz4pdDTYs_003D, ref double _0023_003DzdMc_0024SUk_003D, ref double _0023_003Dzr1rvoN4_003D, ref double _0023_003DzPdP3FZ4_003D)
	{
		int num = 0;
		int num2 = 0;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		double num6 = 0.0;
		double num7 = 0.0;
		double num8 = 0.0;
		double num9 = 0.0;
		double num10 = 0.0;
		double num11 = 0.0;
		double num12 = 0.0;
		double num13 = 0.0;
		num11 = _0023_003DzE8QrneA_003D + _0023_003DzshZYG54_003D;
		num9 = _0023_003DzE8QrneA_003D - _0023_003DzshZYG54_003D;
		num6 = Math.Abs(num9);
		num12 = _0023_003DzH9VU2k0_003D + _0023_003DzH9VU2k0_003D;
		num3 = Math.Abs(num12);
		if (Math.Abs(_0023_003DzE8QrneA_003D) > Math.Abs(_0023_003DzshZYG54_003D))
		{
			num5 = _0023_003DzE8QrneA_003D;
			num4 = _0023_003DzshZYG54_003D;
		}
		else
		{
			num5 = _0023_003DzshZYG54_003D;
			num4 = _0023_003DzE8QrneA_003D;
		}
		num10 = ((num6 > num3) ? (num6 * Math.Sqrt(1.0 + Math.Pow(num3 / num6, 2.0))) : ((!(num6 < num3)) ? (num3 * Math.Sqrt(2.0)) : (num3 * Math.Sqrt(1.0 + Math.Pow(num6 / num3, 2.0)))));
		if (num11 < 0.0)
		{
			_0023_003Dz4pdDTYs_003D = 0.5 * (num11 - num10);
			num = -1;
			_0023_003DzdMc_0024SUk_003D = num5 / _0023_003Dz4pdDTYs_003D * num4 - _0023_003DzH9VU2k0_003D / _0023_003Dz4pdDTYs_003D * _0023_003DzH9VU2k0_003D;
		}
		else if (num11 > 0.0)
		{
			_0023_003Dz4pdDTYs_003D = 0.5 * (num11 + num10);
			num = 1;
			_0023_003DzdMc_0024SUk_003D = num5 / _0023_003Dz4pdDTYs_003D * num4 - _0023_003DzH9VU2k0_003D / _0023_003Dz4pdDTYs_003D * _0023_003DzH9VU2k0_003D;
		}
		else
		{
			_0023_003Dz4pdDTYs_003D = 0.5 * num10;
			_0023_003DzdMc_0024SUk_003D = -0.5 * num10;
			num = 1;
		}
		if (num9 >= 0.0)
		{
			num7 = num9 + num10;
			num2 = 1;
		}
		else
		{
			num7 = num9 - num10;
			num2 = -1;
		}
		if (Math.Abs(num7) > num3)
		{
			num8 = (0.0 - num12) / num7;
			_0023_003DzPdP3FZ4_003D = 1.0 / Math.Sqrt(1.0 + num8 * num8);
			_0023_003Dzr1rvoN4_003D = num8 * _0023_003DzPdP3FZ4_003D;
		}
		else if (num3 == 0.0)
		{
			_0023_003Dzr1rvoN4_003D = 1.0;
			_0023_003DzPdP3FZ4_003D = 0.0;
		}
		else
		{
			num13 = (0.0 - num7) / num12;
			_0023_003Dzr1rvoN4_003D = 1.0 / Math.Sqrt(1.0 + num13 * num13);
			_0023_003DzPdP3FZ4_003D = num13 * _0023_003Dzr1rvoN4_003D;
		}
		if (num == num2)
		{
			num13 = _0023_003Dzr1rvoN4_003D;
			_0023_003Dzr1rvoN4_003D = 0.0 - _0023_003DzPdP3FZ4_003D;
			_0023_003DzPdP3FZ4_003D = num13;
		}
	}
}
