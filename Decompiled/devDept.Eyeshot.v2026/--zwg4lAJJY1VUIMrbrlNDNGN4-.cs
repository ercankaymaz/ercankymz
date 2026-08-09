using System;

internal sealed class _0023_003Dzwg4lAJJY1VUIMrbrlNDNGN4_003D
{
	public void _0023_003Dzz8DDgng_003D(int _0023_003DzmQTFaQA_003D, double[] _0023_003DzK_0024fbiW0_003D, int _0023_003Dzx0hyf0lftOUh, double[] _0023_003Dz8wjMonY_003D, int _0023_003Dz6_0024ZesPV2zhrz, ref double[] _0023_003DzK54IWU0_003D, int _0023_003Dzsa6UI3Aa2df6, double _0023_003Dz9fYhSnY_003D, ref double _0023_003DzNbqUwRtZQ9SZ, ref double[] _0023_003DzUvl_D7g_003D, int _0023_003DzSiwxa0IjGuoh)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		int num6 = -1 + _0023_003Dzx0hyf0lftOUh;
		int num7 = -1 + _0023_003Dz6_0024ZesPV2zhrz;
		int num8 = -1 + _0023_003Dzsa6UI3Aa2df6;
		int num9 = -1 + _0023_003DzSiwxa0IjGuoh;
		num3 = _0023_003DzK_0024fbiW0_003D[2 + num6] - _0023_003DzK_0024fbiW0_003D[1 + num6];
		num4 = num3 * (_0023_003DzK_0024fbiW0_003D[2 + num6] + _0023_003DzK_0024fbiW0_003D[1 + num6]);
		if (_0023_003DzmQTFaQA_003D == 1)
		{
			if (1.0 + 4.0 * _0023_003Dz9fYhSnY_003D * (_0023_003Dz8wjMonY_003D[2 + num7] * _0023_003Dz8wjMonY_003D[2 + num7] / (_0023_003DzK_0024fbiW0_003D[1 + num6] + 3.0 * _0023_003DzK_0024fbiW0_003D[2 + num6]) - _0023_003Dz8wjMonY_003D[1 + num7] * _0023_003Dz8wjMonY_003D[1 + num7] / (3.0 * _0023_003DzK_0024fbiW0_003D[1 + num6] + _0023_003DzK_0024fbiW0_003D[2 + num6])) / num3 > 0.0)
			{
				num = num4 + _0023_003Dz9fYhSnY_003D * (_0023_003Dz8wjMonY_003D[1 + num7] * _0023_003Dz8wjMonY_003D[1 + num7] + _0023_003Dz8wjMonY_003D[2 + num7] * _0023_003Dz8wjMonY_003D[2 + num7]);
				num2 = _0023_003Dz9fYhSnY_003D * _0023_003Dz8wjMonY_003D[1 + num7] * _0023_003Dz8wjMonY_003D[1 + num7] * num4;
				num5 = 2.0 * num2 / (num + Math.Sqrt(Math.Abs(num * num - 4.0 * num2)));
				num5 /= _0023_003DzK_0024fbiW0_003D[1 + num6] + Math.Sqrt(_0023_003DzK_0024fbiW0_003D[1 + num6] * _0023_003DzK_0024fbiW0_003D[1 + num6] + num5);
				_0023_003DzNbqUwRtZQ9SZ = _0023_003DzK_0024fbiW0_003D[1 + num6] + num5;
				_0023_003DzK54IWU0_003D[1 + num8] = 0.0 - num5;
				_0023_003DzK54IWU0_003D[2 + num8] = num3 - num5;
				_0023_003DzUvl_D7g_003D[1 + num9] = 2.0 * _0023_003DzK_0024fbiW0_003D[1 + num6] + num5;
				_0023_003DzUvl_D7g_003D[2 + num9] = _0023_003DzK_0024fbiW0_003D[1 + num6] + num5 + _0023_003DzK_0024fbiW0_003D[2 + num6];
			}
			else
			{
				num = 0.0 - num4 + _0023_003Dz9fYhSnY_003D * (_0023_003Dz8wjMonY_003D[1 + num7] * _0023_003Dz8wjMonY_003D[1 + num7] + _0023_003Dz8wjMonY_003D[2 + num7] * _0023_003Dz8wjMonY_003D[2 + num7]);
				num2 = _0023_003Dz9fYhSnY_003D * _0023_003Dz8wjMonY_003D[2 + num7] * _0023_003Dz8wjMonY_003D[2 + num7] * num4;
				num5 = ((!(num > 0.0)) ? ((num - Math.Sqrt(num * num + 4.0 * num2)) / 2.0) : (-2.0 * num2 / (num + Math.Sqrt(num * num + 4.0 * num2))));
				num5 /= _0023_003DzK_0024fbiW0_003D[2 + num6] + Math.Sqrt(Math.Abs(_0023_003DzK_0024fbiW0_003D[2 + num6] * _0023_003DzK_0024fbiW0_003D[2 + num6] + num5));
				_0023_003DzNbqUwRtZQ9SZ = _0023_003DzK_0024fbiW0_003D[2 + num6] + num5;
				_0023_003DzK54IWU0_003D[1 + num8] = 0.0 - (num3 + num5);
				_0023_003DzK54IWU0_003D[2 + num8] = 0.0 - num5;
				_0023_003DzUvl_D7g_003D[1 + num9] = _0023_003DzK_0024fbiW0_003D[1 + num6] + num5 + _0023_003DzK_0024fbiW0_003D[2 + num6];
				_0023_003DzUvl_D7g_003D[2 + num9] = 2.0 * _0023_003DzK_0024fbiW0_003D[2 + num6] + num5;
			}
		}
		else
		{
			num = 0.0 - num4 + _0023_003Dz9fYhSnY_003D * (_0023_003Dz8wjMonY_003D[1 + num7] * _0023_003Dz8wjMonY_003D[1 + num7] + _0023_003Dz8wjMonY_003D[2 + num7] * _0023_003Dz8wjMonY_003D[2 + num7]);
			num2 = _0023_003Dz9fYhSnY_003D * _0023_003Dz8wjMonY_003D[2 + num7] * _0023_003Dz8wjMonY_003D[2 + num7] * num4;
			num5 = ((!(num > 0.0)) ? (2.0 * num2 / (0.0 - num + Math.Sqrt(num * num + 4.0 * num2))) : ((num + Math.Sqrt(num * num + 4.0 * num2)) / 2.0));
			num5 /= _0023_003DzK_0024fbiW0_003D[2 + num6] + Math.Sqrt(_0023_003DzK_0024fbiW0_003D[2 + num6] * _0023_003DzK_0024fbiW0_003D[2 + num6] + num5);
			_0023_003DzNbqUwRtZQ9SZ = _0023_003DzK_0024fbiW0_003D[2 + num6] + num5;
			_0023_003DzK54IWU0_003D[1 + num8] = 0.0 - (num3 + num5);
			_0023_003DzK54IWU0_003D[2 + num8] = 0.0 - num5;
			_0023_003DzUvl_D7g_003D[1 + num9] = _0023_003DzK_0024fbiW0_003D[1 + num6] + num5 + _0023_003DzK_0024fbiW0_003D[2 + num6];
			_0023_003DzUvl_D7g_003D[2 + num9] = 2.0 * _0023_003DzK_0024fbiW0_003D[2 + num6] + num5;
		}
	}
}
