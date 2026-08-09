using System;

internal sealed class _0023_003Dz_B_0024qZWDicCKKsDyib9HwNZ4_003D
{
	public void _0023_003Dzz8DDgng_003D(double _0023_003DzHit7vU4_003D, double _0023_003DzFmiij5k_003D, double _0023_003DzNDN2q2o_003D, ref double _0023_003DzY3HB7_B0hXeJ, ref double _0023_003DzgVv_0024DJwPKMTE)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		double num6 = 0.0;
		double num7 = 0.0;
		double num8 = 0.0;
		double val = Math.Abs(_0023_003DzHit7vU4_003D);
		num7 = Math.Abs(_0023_003DzFmiij5k_003D);
		num8 = Math.Abs(_0023_003DzNDN2q2o_003D);
		num5 = Math.Min(val, num8);
		num6 = Math.Max(val, num8);
		if (num5 == 0.0)
		{
			_0023_003DzY3HB7_B0hXeJ = 0.0;
			if (num6 == 0.0)
			{
				_0023_003DzgVv_0024DJwPKMTE = num7;
			}
			else
			{
				_0023_003DzgVv_0024DJwPKMTE = Math.Max(num6, num7) * Math.Sqrt(1.0 + Math.Pow(Math.Min(num6, num7) / Math.Max(num6, num7), 2.0));
			}
			return;
		}
		if (num7 < num6)
		{
			num = 1.0 + num5 / num6;
			num2 = (num6 - num5) / num6;
			num3 = Math.Pow(num7 / num6, 2.0);
			num4 = 2.0 / (Math.Sqrt(num * num + num3) + Math.Sqrt(num2 * num2 + num3));
			_0023_003DzY3HB7_B0hXeJ = num5 * num4;
			_0023_003DzgVv_0024DJwPKMTE = num6 / num4;
			return;
		}
		num3 = num6 / num7;
		if (num3 == 0.0)
		{
			_0023_003DzY3HB7_B0hXeJ = num5 * num6 / num7;
			_0023_003DzgVv_0024DJwPKMTE = num7;
			return;
		}
		num = 1.0 + num5 / num6;
		num2 = (num6 - num5) / num6;
		num4 = 1.0 / (Math.Sqrt(1.0 + Math.Pow(num * num3, 2.0)) + Math.Sqrt(1.0 + Math.Pow(num2 * num3, 2.0)));
		_0023_003DzY3HB7_B0hXeJ = num5 * num4 * num3;
		_0023_003DzY3HB7_B0hXeJ += _0023_003DzY3HB7_B0hXeJ;
		_0023_003DzgVv_0024DJwPKMTE = num7 / (num4 + num4);
	}
}
