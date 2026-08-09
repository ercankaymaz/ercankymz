using System;

internal sealed class _0023_003DzyMPWeUVAxk_00243jxwxEyn7v0E_003D
{
	public void _0023_003Dzz8DDgng_003D(int _0023_003DzAebOrkw_003D, int _0023_003DzGLwmegk_003D, double[] _0023_003Dz8wjMonY_003D, int _0023_003Dz6_0024ZesPV2zhrz, int _0023_003DzBmiQDfU_003D, int _0023_003DzFdV5j8A9UZKh, double _0023_003Dzug0CzBWNLXq5, double _0023_003Dzkw6DW2x_jbrr, double _0023_003DzE0Vvfh69LUFt, double _0023_003Dzs7NKFeY_003D, double _0023_003DzINOsqfw_003D, double _0023_003DziIElqwU_003D, ref double _0023_003DzO7MpazE_003D, ref int _0023_003DzSvY_2Y9IBDEa, ref double _0023_003DzFmiij5k_003D)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		double num4 = 0.0;
		double num5 = 0.0;
		double num6 = 0.0;
		double num7 = 0.0;
		double num8 = 0.0;
		double num9 = 0.0;
		double num10 = 0.0;
		int num11 = -1 + _0023_003Dz6_0024ZesPV2zhrz;
		if (_0023_003Dzug0CzBWNLXq5 <= 0.0)
		{
			_0023_003DzO7MpazE_003D = 0.0 - _0023_003Dzug0CzBWNLXq5;
			_0023_003DzSvY_2Y9IBDEa = -1;
			return;
		}
		num2 = 4 * _0023_003DzGLwmegk_003D + _0023_003DzBmiQDfU_003D;
		if (_0023_003DzFdV5j8A9UZKh == _0023_003DzGLwmegk_003D)
		{
			if (_0023_003Dzug0CzBWNLXq5 == _0023_003Dzs7NKFeY_003D || _0023_003Dzug0CzBWNLXq5 == _0023_003DzINOsqfw_003D)
			{
				num5 = Math.Sqrt(_0023_003Dz8wjMonY_003D[num2 - 3 + num11]) * Math.Sqrt(_0023_003Dz8wjMonY_003D[num2 - 5 + num11]);
				num6 = Math.Sqrt(_0023_003Dz8wjMonY_003D[num2 - 7 + num11]) * Math.Sqrt(_0023_003Dz8wjMonY_003D[num2 - 9 + num11]);
				num4 = _0023_003Dz8wjMonY_003D[num2 - 7 + num11] + _0023_003Dz8wjMonY_003D[num2 - 5 + num11];
				if (_0023_003Dzug0CzBWNLXq5 == _0023_003Dzs7NKFeY_003D && _0023_003Dzkw6DW2x_jbrr == _0023_003DzINOsqfw_003D)
				{
					num9 = _0023_003DzE0Vvfh69LUFt - num4 - _0023_003DzE0Vvfh69LUFt * 0.25;
					num8 = ((!(num9 > 0.0) || !(num9 > num6)) ? (num4 - _0023_003Dzs7NKFeY_003D - (num5 + num6)) : (num4 - _0023_003Dzs7NKFeY_003D - num6 / num9 * num6));
					if (num8 > 0.0 && num8 > num5)
					{
						num10 = Math.Max(_0023_003Dzs7NKFeY_003D - num5 / num8 * num5, 0.5 * _0023_003Dzug0CzBWNLXq5);
						_0023_003DzSvY_2Y9IBDEa = -2;
					}
					else
					{
						num10 = 0.0;
						if (_0023_003Dzs7NKFeY_003D > num5)
						{
							num10 = _0023_003Dzs7NKFeY_003D - num5;
						}
						if (num4 > num5 + num6)
						{
							num10 = Math.Min(num10, num4 - (num5 + num6));
						}
						num10 = Math.Max(num10, 0.333 * _0023_003Dzug0CzBWNLXq5);
						_0023_003DzSvY_2Y9IBDEa = -3;
					}
				}
				else
				{
					_0023_003DzSvY_2Y9IBDEa = -4;
					num10 = 0.25 * _0023_003Dzug0CzBWNLXq5;
					if (_0023_003Dzug0CzBWNLXq5 == _0023_003Dzs7NKFeY_003D)
					{
						num7 = _0023_003Dzs7NKFeY_003D;
						num4 = 0.0;
						if (_0023_003Dz8wjMonY_003D[num2 - 5 + num11] > _0023_003Dz8wjMonY_003D[num2 - 7 + num11])
						{
							return;
						}
						num6 = _0023_003Dz8wjMonY_003D[num2 - 5 + num11] / _0023_003Dz8wjMonY_003D[num2 - 7 + num11];
						num3 = num2 - 9;
					}
					else
					{
						num3 = num2 - 2 * _0023_003DzBmiQDfU_003D;
						num6 = _0023_003Dz8wjMonY_003D[num3 - 2 + num11];
						num7 = _0023_003DzINOsqfw_003D;
						if (_0023_003Dz8wjMonY_003D[num3 - 4 + num11] > _0023_003Dz8wjMonY_003D[num3 - 2 + num11])
						{
							return;
						}
						num4 = _0023_003Dz8wjMonY_003D[num3 - 4 + num11] / _0023_003Dz8wjMonY_003D[num3 - 2 + num11];
						if (_0023_003Dz8wjMonY_003D[num2 - 9 + num11] > _0023_003Dz8wjMonY_003D[num2 - 11 + num11])
						{
							return;
						}
						num6 = _0023_003Dz8wjMonY_003D[num2 - 9 + num11] / _0023_003Dz8wjMonY_003D[num2 - 11 + num11];
						num3 = num2 - 13;
					}
					num4 += num6;
					for (num = num3; num >= 4 * _0023_003DzAebOrkw_003D - 1 + _0023_003DzBmiQDfU_003D; num += -4)
					{
						if (num6 == 0.0)
						{
							break;
						}
						num5 = num6;
						if (_0023_003Dz8wjMonY_003D[num + num11] > _0023_003Dz8wjMonY_003D[num - 2 + num11])
						{
							return;
						}
						num6 *= _0023_003Dz8wjMonY_003D[num + num11] / _0023_003Dz8wjMonY_003D[num - 2 + num11];
						num4 += num6;
						if (100.0 * Math.Max(num6, num5) < num4 || 0.563 < num4)
						{
							break;
						}
					}
					num4 *= 1.05;
					if (num4 < 0.563)
					{
						num10 = num7 * (1.0 - Math.Sqrt(num4)) / (1.0 + num4);
					}
				}
			}
			else if (_0023_003Dzug0CzBWNLXq5 == _0023_003DziIElqwU_003D)
			{
				_0023_003DzSvY_2Y9IBDEa = -5;
				num10 = 0.25 * _0023_003Dzug0CzBWNLXq5;
				num3 = num2 - 2 * _0023_003DzBmiQDfU_003D;
				num5 = _0023_003Dz8wjMonY_003D[num3 - 2 + num11];
				num6 = _0023_003Dz8wjMonY_003D[num3 - 6 + num11];
				num7 = _0023_003DziIElqwU_003D;
				if (_0023_003Dz8wjMonY_003D[num3 - 8 + num11] > num6 || _0023_003Dz8wjMonY_003D[num3 - 4 + num11] > num5)
				{
					return;
				}
				num4 = _0023_003Dz8wjMonY_003D[num3 - 8 + num11] / num6 * (1.0 + _0023_003Dz8wjMonY_003D[num3 - 4 + num11] / num5);
				if (_0023_003DzGLwmegk_003D - _0023_003DzAebOrkw_003D > 2)
				{
					num6 = _0023_003Dz8wjMonY_003D[num2 - 13 + num11] / _0023_003Dz8wjMonY_003D[num2 - 15 + num11];
					num4 += num6;
					for (num = num2 - 17; num >= 4 * _0023_003DzAebOrkw_003D - 1 + _0023_003DzBmiQDfU_003D; num += -4)
					{
						if (num6 == 0.0)
						{
							break;
						}
						num5 = num6;
						if (_0023_003Dz8wjMonY_003D[num + num11] > _0023_003Dz8wjMonY_003D[num - 2 + num11])
						{
							return;
						}
						num6 *= _0023_003Dz8wjMonY_003D[num + num11] / _0023_003Dz8wjMonY_003D[num - 2 + num11];
						num4 += num6;
						if (100.0 * Math.Max(num6, num5) < num4 || 0.563 < num4)
						{
							break;
						}
					}
					num4 *= 1.05;
				}
				if (num4 < 0.563)
				{
					num10 = num7 * (1.0 - Math.Sqrt(num4)) / (1.0 + num4);
				}
			}
			else
			{
				if (_0023_003DzSvY_2Y9IBDEa == -6)
				{
					_0023_003DzFmiij5k_003D += 0.333 * (1.0 - _0023_003DzFmiij5k_003D);
				}
				else if (_0023_003DzSvY_2Y9IBDEa == -18)
				{
					_0023_003DzFmiij5k_003D = 0.08325;
				}
				else
				{
					_0023_003DzFmiij5k_003D = 0.25;
				}
				num10 = _0023_003DzFmiij5k_003D * _0023_003Dzug0CzBWNLXq5;
				_0023_003DzSvY_2Y9IBDEa = -6;
			}
		}
		else if (_0023_003DzFdV5j8A9UZKh == _0023_003DzGLwmegk_003D + 1)
		{
			if (_0023_003Dzkw6DW2x_jbrr == _0023_003DzINOsqfw_003D && _0023_003DzE0Vvfh69LUFt == _0023_003DziIElqwU_003D)
			{
				_0023_003DzSvY_2Y9IBDEa = -7;
				num10 = 0.333 * _0023_003Dzkw6DW2x_jbrr;
				if (_0023_003Dz8wjMonY_003D[num2 - 5 + num11] > _0023_003Dz8wjMonY_003D[num2 - 7 + num11])
				{
					return;
				}
				num5 = _0023_003Dz8wjMonY_003D[num2 - 5 + num11] / _0023_003Dz8wjMonY_003D[num2 - 7 + num11];
				num6 = num5;
				if (num6 != 0.0)
				{
					for (num = 4 * _0023_003DzGLwmegk_003D - 9 + _0023_003DzBmiQDfU_003D; num >= 4 * _0023_003DzAebOrkw_003D - 1 + _0023_003DzBmiQDfU_003D; num += -4)
					{
						num4 = num5;
						if (_0023_003Dz8wjMonY_003D[num + num11] > _0023_003Dz8wjMonY_003D[num - 2 + num11])
						{
							return;
						}
						num5 *= _0023_003Dz8wjMonY_003D[num + num11] / _0023_003Dz8wjMonY_003D[num - 2 + num11];
						num6 += num5;
						if (100.0 * Math.Max(num5, num4) < num6)
						{
							break;
						}
					}
				}
				num6 = Math.Sqrt(1.05 * num6);
				num4 = _0023_003Dzkw6DW2x_jbrr / (1.0 + Math.Pow(num6, 2.0));
				num9 = 0.5 * _0023_003DzE0Vvfh69LUFt - num4;
				if (num9 > 0.0 && num9 > num6 * num4)
				{
					num10 = Math.Max(num10, num4 * (1.0 - 1.01 * num4 * (num6 / num9) * num6));
				}
				else
				{
					num10 = Math.Max(num10, num4 * (1.0 - 1.01 * num6));
					_0023_003DzSvY_2Y9IBDEa = -8;
				}
			}
			else
			{
				num10 = 0.25 * _0023_003Dzkw6DW2x_jbrr;
				if (_0023_003Dzkw6DW2x_jbrr == _0023_003DzINOsqfw_003D)
				{
					num10 = 0.5 * _0023_003Dzkw6DW2x_jbrr;
				}
				_0023_003DzSvY_2Y9IBDEa = -9;
			}
		}
		else if (_0023_003DzFdV5j8A9UZKh == _0023_003DzGLwmegk_003D + 2)
		{
			if (_0023_003DzE0Vvfh69LUFt == _0023_003DziIElqwU_003D && 2.0 * _0023_003Dz8wjMonY_003D[num2 - 5 + num11] < _0023_003Dz8wjMonY_003D[num2 - 7 + num11])
			{
				_0023_003DzSvY_2Y9IBDEa = -10;
				num10 = 0.333 * _0023_003DzE0Vvfh69LUFt;
				if (_0023_003Dz8wjMonY_003D[num2 - 5 + num11] > _0023_003Dz8wjMonY_003D[num2 - 7 + num11])
				{
					return;
				}
				num5 = _0023_003Dz8wjMonY_003D[num2 - 5 + num11] / _0023_003Dz8wjMonY_003D[num2 - 7 + num11];
				num6 = num5;
				if (num6 != 0.0)
				{
					for (num = 4 * _0023_003DzGLwmegk_003D - 9 + _0023_003DzBmiQDfU_003D; num >= 4 * _0023_003DzAebOrkw_003D - 1 + _0023_003DzBmiQDfU_003D; num += -4)
					{
						if (_0023_003Dz8wjMonY_003D[num + num11] > _0023_003Dz8wjMonY_003D[num - 2 + num11])
						{
							return;
						}
						num5 *= _0023_003Dz8wjMonY_003D[num + num11] / _0023_003Dz8wjMonY_003D[num - 2 + num11];
						num6 += num5;
						if (100.0 * num5 < num6)
						{
							break;
						}
					}
				}
				num6 = Math.Sqrt(1.05 * num6);
				num4 = _0023_003DzE0Vvfh69LUFt / (1.0 + Math.Pow(num6, 2.0));
				num9 = _0023_003Dz8wjMonY_003D[num2 - 7 + num11] + _0023_003Dz8wjMonY_003D[num2 - 9 + num11] - Math.Sqrt(_0023_003Dz8wjMonY_003D[num2 - 11 + num11]) * Math.Sqrt(_0023_003Dz8wjMonY_003D[num2 - 9 + num11]) - num4;
				num10 = ((!(num9 > 0.0) || !(num9 > num6 * num4)) ? Math.Max(num10, num4 * (1.0 - 1.01 * num6)) : Math.Max(num10, num4 * (1.0 - 1.01 * num4 * (num6 / num9) * num6)));
			}
			else
			{
				num10 = 0.25 * _0023_003DzE0Vvfh69LUFt;
				_0023_003DzSvY_2Y9IBDEa = -11;
			}
		}
		else if (_0023_003DzFdV5j8A9UZKh > _0023_003DzGLwmegk_003D + 2)
		{
			num10 = 0.0;
			_0023_003DzSvY_2Y9IBDEa = -12;
		}
		_0023_003DzO7MpazE_003D = num10;
	}
}
