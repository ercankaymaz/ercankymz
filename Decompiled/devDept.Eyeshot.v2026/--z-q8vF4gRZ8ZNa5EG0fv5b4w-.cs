using System;

internal sealed class _0023_003Dz_0024q8vF4gRZ8ZNa5EG0fv5b4w_003D
{
	public void _0023_003Dzz8DDgng_003D(int _0023_003DzAebOrkw_003D, int _0023_003DzGLwmegk_003D, ref double[] _0023_003Dz8wjMonY_003D, int _0023_003Dz6_0024ZesPV2zhrz, int _0023_003DzBmiQDfU_003D, double _0023_003DzO7MpazE_003D, ref double _0023_003Dzug0CzBWNLXq5, ref double _0023_003Dzkw6DW2x_jbrr, ref double _0023_003DzE0Vvfh69LUFt, ref double _0023_003Dzs7NKFeY_003D, ref double _0023_003DzPhxN6ym4gw7e, ref double _0023_003DzjpcQ0pSubuxt, bool _0023_003DzDNBJhIE_003D)
	{
		int num = 0;
		int num2 = 0;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		int num6 = -1 + _0023_003Dz6_0024ZesPV2zhrz;
		if (_0023_003DzGLwmegk_003D - _0023_003DzAebOrkw_003D - 1 <= 0)
		{
			return;
		}
		num = 4 * _0023_003DzAebOrkw_003D + _0023_003DzBmiQDfU_003D - 3;
		num4 = _0023_003Dz8wjMonY_003D[num + 4 + num6];
		num3 = (_0023_003Dzug0CzBWNLXq5 = _0023_003Dz8wjMonY_003D[num + num6] - _0023_003DzO7MpazE_003D);
		_0023_003Dzkw6DW2x_jbrr = 0.0 - _0023_003Dz8wjMonY_003D[num + num6];
		if (_0023_003DzDNBJhIE_003D)
		{
			if (_0023_003DzBmiQDfU_003D == 0)
			{
				for (num = 4 * _0023_003DzAebOrkw_003D; num <= 4 * (_0023_003DzGLwmegk_003D - 3); num += 4)
				{
					_0023_003Dz8wjMonY_003D[num - 2 + num6] = num3 + _0023_003Dz8wjMonY_003D[num - 1 + num6];
					num5 = _0023_003Dz8wjMonY_003D[num + 1 + num6] / _0023_003Dz8wjMonY_003D[num - 2 + num6];
					num3 = num3 * num5 - _0023_003DzO7MpazE_003D;
					_0023_003Dzug0CzBWNLXq5 = Math.Min(_0023_003Dzug0CzBWNLXq5, num3);
					_0023_003Dz8wjMonY_003D[num + num6] = _0023_003Dz8wjMonY_003D[num - 1 + num6] * num5;
					num4 = Math.Min(_0023_003Dz8wjMonY_003D[num + num6], num4);
				}
			}
			else
			{
				for (num = 4 * _0023_003DzAebOrkw_003D; num <= 4 * (_0023_003DzGLwmegk_003D - 3); num += 4)
				{
					_0023_003Dz8wjMonY_003D[num - 3 + num6] = num3 + _0023_003Dz8wjMonY_003D[num + num6];
					num5 = _0023_003Dz8wjMonY_003D[num + 2 + num6] / _0023_003Dz8wjMonY_003D[num - 3 + num6];
					num3 = num3 * num5 - _0023_003DzO7MpazE_003D;
					_0023_003Dzug0CzBWNLXq5 = Math.Min(_0023_003Dzug0CzBWNLXq5, num3);
					_0023_003Dz8wjMonY_003D[num - 1 + num6] = _0023_003Dz8wjMonY_003D[num + num6] * num5;
					num4 = Math.Min(_0023_003Dz8wjMonY_003D[num - 1 + num6], num4);
				}
			}
			_0023_003DzjpcQ0pSubuxt = num3;
			_0023_003DzE0Vvfh69LUFt = _0023_003Dzug0CzBWNLXq5;
			num = 4 * (_0023_003DzGLwmegk_003D - 2) - _0023_003DzBmiQDfU_003D;
			num2 = num + 2 * _0023_003DzBmiQDfU_003D - 1;
			_0023_003Dz8wjMonY_003D[num - 2 + num6] = _0023_003DzjpcQ0pSubuxt + _0023_003Dz8wjMonY_003D[num2 + num6];
			_0023_003Dz8wjMonY_003D[num + num6] = _0023_003Dz8wjMonY_003D[num2 + 2 + num6] * (_0023_003Dz8wjMonY_003D[num2 + num6] / _0023_003Dz8wjMonY_003D[num - 2 + num6]);
			_0023_003DzPhxN6ym4gw7e = _0023_003Dz8wjMonY_003D[num2 + 2 + num6] * (_0023_003DzjpcQ0pSubuxt / _0023_003Dz8wjMonY_003D[num - 2 + num6]) - _0023_003DzO7MpazE_003D;
			_0023_003Dzug0CzBWNLXq5 = Math.Min(_0023_003Dzug0CzBWNLXq5, _0023_003DzPhxN6ym4gw7e);
			_0023_003Dzkw6DW2x_jbrr = _0023_003Dzug0CzBWNLXq5;
			num += 4;
			num2 = num + 2 * _0023_003DzBmiQDfU_003D - 1;
			_0023_003Dz8wjMonY_003D[num - 2 + num6] = _0023_003DzPhxN6ym4gw7e + _0023_003Dz8wjMonY_003D[num2 + num6];
			_0023_003Dz8wjMonY_003D[num + num6] = _0023_003Dz8wjMonY_003D[num2 + 2 + num6] * (_0023_003Dz8wjMonY_003D[num2 + num6] / _0023_003Dz8wjMonY_003D[num - 2 + num6]);
			_0023_003Dzs7NKFeY_003D = _0023_003Dz8wjMonY_003D[num2 + 2 + num6] * (_0023_003DzPhxN6ym4gw7e / _0023_003Dz8wjMonY_003D[num - 2 + num6]) - _0023_003DzO7MpazE_003D;
			_0023_003Dzug0CzBWNLXq5 = Math.Min(_0023_003Dzug0CzBWNLXq5, _0023_003Dzs7NKFeY_003D);
		}
		else
		{
			if (_0023_003DzBmiQDfU_003D == 0)
			{
				for (num = 4 * _0023_003DzAebOrkw_003D; num <= 4 * (_0023_003DzGLwmegk_003D - 3); num += 4)
				{
					_0023_003Dz8wjMonY_003D[num - 2 + num6] = num3 + _0023_003Dz8wjMonY_003D[num - 1 + num6];
					if (num3 < 0.0)
					{
						return;
					}
					_0023_003Dz8wjMonY_003D[num + num6] = _0023_003Dz8wjMonY_003D[num + 1 + num6] * (_0023_003Dz8wjMonY_003D[num - 1 + num6] / _0023_003Dz8wjMonY_003D[num - 2 + num6]);
					num3 = _0023_003Dz8wjMonY_003D[num + 1 + num6] * (num3 / _0023_003Dz8wjMonY_003D[num - 2 + num6]) - _0023_003DzO7MpazE_003D;
					_0023_003Dzug0CzBWNLXq5 = Math.Min(_0023_003Dzug0CzBWNLXq5, num3);
					num4 = Math.Min(num4, _0023_003Dz8wjMonY_003D[num + num6]);
				}
			}
			else
			{
				for (num = 4 * _0023_003DzAebOrkw_003D; num <= 4 * (_0023_003DzGLwmegk_003D - 3); num += 4)
				{
					_0023_003Dz8wjMonY_003D[num - 3 + num6] = num3 + _0023_003Dz8wjMonY_003D[num + num6];
					if (num3 < 0.0)
					{
						return;
					}
					_0023_003Dz8wjMonY_003D[num - 1 + num6] = _0023_003Dz8wjMonY_003D[num + 2 + num6] * (_0023_003Dz8wjMonY_003D[num + num6] / _0023_003Dz8wjMonY_003D[num - 3 + num6]);
					num3 = _0023_003Dz8wjMonY_003D[num + 2 + num6] * (num3 / _0023_003Dz8wjMonY_003D[num - 3 + num6]) - _0023_003DzO7MpazE_003D;
					_0023_003Dzug0CzBWNLXq5 = Math.Min(_0023_003Dzug0CzBWNLXq5, num3);
					num4 = Math.Min(num4, _0023_003Dz8wjMonY_003D[num - 1 + num6]);
				}
			}
			_0023_003DzjpcQ0pSubuxt = num3;
			_0023_003DzE0Vvfh69LUFt = _0023_003Dzug0CzBWNLXq5;
			num = 4 * (_0023_003DzGLwmegk_003D - 2) - _0023_003DzBmiQDfU_003D;
			num2 = num + 2 * _0023_003DzBmiQDfU_003D - 1;
			_0023_003Dz8wjMonY_003D[num - 2 + num6] = _0023_003DzjpcQ0pSubuxt + _0023_003Dz8wjMonY_003D[num2 + num6];
			if (_0023_003DzjpcQ0pSubuxt < 0.0)
			{
				return;
			}
			_0023_003Dz8wjMonY_003D[num + num6] = _0023_003Dz8wjMonY_003D[num2 + 2 + num6] * (_0023_003Dz8wjMonY_003D[num2 + num6] / _0023_003Dz8wjMonY_003D[num - 2 + num6]);
			_0023_003DzPhxN6ym4gw7e = _0023_003Dz8wjMonY_003D[num2 + 2 + num6] * (_0023_003DzjpcQ0pSubuxt / _0023_003Dz8wjMonY_003D[num - 2 + num6]) - _0023_003DzO7MpazE_003D;
			_0023_003Dzug0CzBWNLXq5 = Math.Min(_0023_003Dzug0CzBWNLXq5, _0023_003DzPhxN6ym4gw7e);
			_0023_003Dzkw6DW2x_jbrr = _0023_003Dzug0CzBWNLXq5;
			num += 4;
			num2 = num + 2 * _0023_003DzBmiQDfU_003D - 1;
			_0023_003Dz8wjMonY_003D[num - 2 + num6] = _0023_003DzPhxN6ym4gw7e + _0023_003Dz8wjMonY_003D[num2 + num6];
			if (_0023_003DzPhxN6ym4gw7e < 0.0)
			{
				return;
			}
			_0023_003Dz8wjMonY_003D[num + num6] = _0023_003Dz8wjMonY_003D[num2 + 2 + num6] * (_0023_003Dz8wjMonY_003D[num2 + num6] / _0023_003Dz8wjMonY_003D[num - 2 + num6]);
			_0023_003Dzs7NKFeY_003D = _0023_003Dz8wjMonY_003D[num2 + 2 + num6] * (_0023_003DzPhxN6ym4gw7e / _0023_003Dz8wjMonY_003D[num - 2 + num6]) - _0023_003DzO7MpazE_003D;
			_0023_003Dzug0CzBWNLXq5 = Math.Min(_0023_003Dzug0CzBWNLXq5, _0023_003Dzs7NKFeY_003D);
		}
		_0023_003Dz8wjMonY_003D[num + 2 + num6] = _0023_003Dzs7NKFeY_003D;
		_0023_003Dz8wjMonY_003D[4 * _0023_003DzGLwmegk_003D - _0023_003DzBmiQDfU_003D + num6] = num4;
	}
}
