using System;

internal sealed class _0023_003DzgqaT2_0024U28l7ZlkCHcdhTEf4_003D
{
	public void _0023_003Dzz8DDgng_003D(int _0023_003DzpGjKR04_003D, ref double[] _0023_003Dzyk2fsPo_003D, int _0023_003DzVwzJWWz_0024BCSn, int _0023_003DzPha_0024VJlONheb, ref double[] _0023_003DzvXOLtKg_003D, int _0023_003Dz4chJLWqlzf4p, int _0023_003DzGWhj1O1jhTmW, ref double[] _0023_003DzshZYG54_003D, int _0023_003DzvjXugQ9hIwn6, int _0023_003DzgLQ6sVnWlb_U)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		double num5 = 0.0;
		double num6 = 0.0;
		double num7 = 0.0;
		double num8 = 0.0;
		int num9 = -1 + _0023_003DzVwzJWWz_0024BCSn;
		int num10 = -1 + _0023_003Dz4chJLWqlzf4p;
		int num11 = -1 + _0023_003DzvjXugQ9hIwn6;
		num3 = 1;
		num4 = 1;
		num2 = 1;
		for (num = 1; num <= _0023_003DzpGjKR04_003D; num++)
		{
			num5 = _0023_003Dzyk2fsPo_003D[num3 + num9];
			num6 = _0023_003DzvXOLtKg_003D[num4 + num10];
			if (num6 == 0.0)
			{
				_0023_003DzshZYG54_003D[num2 + num11] = 1.0;
			}
			else if (num5 == 0.0)
			{
				_0023_003DzshZYG54_003D[num2 + num11] = 0.0;
				_0023_003DzvXOLtKg_003D[num4 + num10] = 1.0;
				_0023_003Dzyk2fsPo_003D[num3 + num9] = num6;
			}
			else if (Math.Abs(num5) > Math.Abs(num6))
			{
				num7 = num6 / num5;
				num8 = Math.Sqrt(1.0 + num7 * num7);
				_0023_003DzshZYG54_003D[num2 + num11] = 1.0 / num8;
				_0023_003DzvXOLtKg_003D[num4 + num10] = num7 * _0023_003DzshZYG54_003D[num2 + num11];
				_0023_003Dzyk2fsPo_003D[num3 + num9] = num5 * num8;
			}
			else
			{
				num7 = num5 / num6;
				num8 = Math.Sqrt(1.0 + num7 * num7);
				_0023_003DzvXOLtKg_003D[num4 + num10] = 1.0 / num8;
				_0023_003DzshZYG54_003D[num2 + num11] = num7 * _0023_003DzvXOLtKg_003D[num4 + num10];
				_0023_003Dzyk2fsPo_003D[num3 + num9] = num6 * num8;
			}
			num2 += _0023_003DzgLQ6sVnWlb_U;
			num4 += _0023_003DzGWhj1O1jhTmW;
			num3 += _0023_003DzPha_0024VJlONheb;
		}
	}
}
