using System;

internal sealed class _0023_003Dz4ecSr9d6omHnf01uWD7qe1Y_003D
{
	public void _0023_003Dzz8DDgng_003D(int _0023_003DzmQTFaQA_003D, double[] _0023_003DzK_0024fbiW0_003D, int _0023_003Dzx0hyf0lftOUh, double[] _0023_003Dz8wjMonY_003D, int _0023_003Dz6_0024ZesPV2zhrz, ref double[] _0023_003DzK54IWU0_003D, int _0023_003Dzsa6UI3Aa2df6, double _0023_003Dz9fYhSnY_003D, ref double _0023_003DzzGL1VHrUw_0024SH)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		int num6 = -1 + _0023_003Dzx0hyf0lftOUh;
		int num7 = -1 + _0023_003Dz6_0024ZesPV2zhrz;
		int num8 = -1 + _0023_003Dzsa6UI3Aa2df6;
		num3 = _0023_003DzK_0024fbiW0_003D[2 + num6] - _0023_003DzK_0024fbiW0_003D[1 + num6];
		if (_0023_003DzmQTFaQA_003D == 1)
		{
			if (1.0 + 2.0 * _0023_003Dz9fYhSnY_003D * (_0023_003Dz8wjMonY_003D[2 + num7] * _0023_003Dz8wjMonY_003D[2 + num7] - _0023_003Dz8wjMonY_003D[1 + num7] * _0023_003Dz8wjMonY_003D[1 + num7]) / num3 > 0.0)
			{
				num = num3 + _0023_003Dz9fYhSnY_003D * (_0023_003Dz8wjMonY_003D[1 + num7] * _0023_003Dz8wjMonY_003D[1 + num7] + _0023_003Dz8wjMonY_003D[2 + num7] * _0023_003Dz8wjMonY_003D[2 + num7]);
				num2 = _0023_003Dz9fYhSnY_003D * _0023_003Dz8wjMonY_003D[1 + num7] * _0023_003Dz8wjMonY_003D[1 + num7] * num3;
				num4 = 2.0 * num2 / (num + Math.Sqrt(Math.Abs(num * num - 4.0 * num2)));
				_0023_003DzzGL1VHrUw_0024SH = _0023_003DzK_0024fbiW0_003D[1 + num6] + num4;
				_0023_003DzK54IWU0_003D[1 + num8] = (0.0 - _0023_003Dz8wjMonY_003D[1 + num7]) / num4;
				_0023_003DzK54IWU0_003D[2 + num8] = _0023_003Dz8wjMonY_003D[2 + num7] / (num3 - num4);
			}
			else
			{
				num = 0.0 - num3 + _0023_003Dz9fYhSnY_003D * (_0023_003Dz8wjMonY_003D[1 + num7] * _0023_003Dz8wjMonY_003D[1 + num7] + _0023_003Dz8wjMonY_003D[2 + num7] * _0023_003Dz8wjMonY_003D[2 + num7]);
				num2 = _0023_003Dz9fYhSnY_003D * _0023_003Dz8wjMonY_003D[2 + num7] * _0023_003Dz8wjMonY_003D[2 + num7] * num3;
				num4 = ((!(num > 0.0)) ? ((num - Math.Sqrt(num * num + 4.0 * num2)) / 2.0) : (-2.0 * num2 / (num + Math.Sqrt(num * num + 4.0 * num2))));
				_0023_003DzzGL1VHrUw_0024SH = _0023_003DzK_0024fbiW0_003D[2 + num6] + num4;
				_0023_003DzK54IWU0_003D[1 + num8] = (0.0 - _0023_003Dz8wjMonY_003D[1 + num7]) / (num3 + num4);
				_0023_003DzK54IWU0_003D[2 + num8] = (0.0 - _0023_003Dz8wjMonY_003D[2 + num7]) / num4;
			}
			num5 = Math.Sqrt(_0023_003DzK54IWU0_003D[1 + num8] * _0023_003DzK54IWU0_003D[1 + num8] + _0023_003DzK54IWU0_003D[2 + num8] * _0023_003DzK54IWU0_003D[2 + num8]);
			_0023_003DzK54IWU0_003D[1 + num8] /= num5;
			_0023_003DzK54IWU0_003D[2 + num8] /= num5;
		}
		else
		{
			num = 0.0 - num3 + _0023_003Dz9fYhSnY_003D * (_0023_003Dz8wjMonY_003D[1 + num7] * _0023_003Dz8wjMonY_003D[1 + num7] + _0023_003Dz8wjMonY_003D[2 + num7] * _0023_003Dz8wjMonY_003D[2 + num7]);
			num2 = _0023_003Dz9fYhSnY_003D * _0023_003Dz8wjMonY_003D[2 + num7] * _0023_003Dz8wjMonY_003D[2 + num7] * num3;
			num4 = ((!(num > 0.0)) ? (2.0 * num2 / (0.0 - num + Math.Sqrt(num * num + 4.0 * num2))) : ((num + Math.Sqrt(num * num + 4.0 * num2)) / 2.0));
			_0023_003DzzGL1VHrUw_0024SH = _0023_003DzK_0024fbiW0_003D[2 + num6] + num4;
			_0023_003DzK54IWU0_003D[1 + num8] = (0.0 - _0023_003Dz8wjMonY_003D[1 + num7]) / (num3 + num4);
			_0023_003DzK54IWU0_003D[2 + num8] = (0.0 - _0023_003Dz8wjMonY_003D[2 + num7]) / num4;
			num5 = Math.Sqrt(_0023_003DzK54IWU0_003D[1 + num8] * _0023_003DzK54IWU0_003D[1 + num8] + _0023_003DzK54IWU0_003D[2 + num8] * _0023_003DzK54IWU0_003D[2 + num8]);
			_0023_003DzK54IWU0_003D[1 + num8] /= num5;
			_0023_003DzK54IWU0_003D[2 + num8] /= num5;
		}
	}
}
