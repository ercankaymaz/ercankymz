using System;

internal sealed class _0023_003DzuEaiODUOWEFsEzQ3VWcwerg_003D
{
	private _0023_003DzvuOZoIN8OtKD0PJWGr1cmIk_003D _0023_003DzRKxBhzpH2B27;

	public _0023_003DzuEaiODUOWEFsEzQ3VWcwerg_003D(_0023_003DzvuOZoIN8OtKD0PJWGr1cmIk_003D _0023_003Dzt2EQ2fGeANKe)
	{
		_0023_003DzRKxBhzpH2B27 = _0023_003Dzt2EQ2fGeANKe;
	}

	public _0023_003DzuEaiODUOWEFsEzQ3VWcwerg_003D()
	{
		_0023_003DzvuOZoIN8OtKD0PJWGr1cmIk_003D _0023_003DzvuOZoIN8OtKD0PJWGr1cmIk_003D2 = new _0023_003DzvuOZoIN8OtKD0PJWGr1cmIk_003D();
		_0023_003DzRKxBhzpH2B27 = _0023_003DzvuOZoIN8OtKD0PJWGr1cmIk_003D2;
	}

	public void _0023_003Dzz8DDgng_003D(int _0023_003DzpGjKR04_003D, int _0023_003DzR5r3z0HtWrgJ, ref double[] _0023_003DznyCFEaY_003D, int _0023_003DzgGuxCXfH5eyc, ref double[] _0023_003DzK_0024fbiW0_003D, int _0023_003Dzx0hyf0lftOUh, ref double[] _0023_003DzGZTDgUk_003D, int _0023_003DzC591M8d1qYh8, ref double[] _0023_003DzH9VU2k0_003D, int _0023_003DzPB8Mb17HTSO6, int _0023_003DzHh03WyA_003D, ref int _0023_003DzhEXKXIU_003D)
	{
		int num = 0;
		int num2 = 0;
		double num3 = 0.0;
		double num4 = 0.0;
		int num5 = 0;
		int num6 = -1 + _0023_003DzgGuxCXfH5eyc;
		int num7 = -1 + _0023_003Dzx0hyf0lftOUh;
		int num8 = -1 + _0023_003DzC591M8d1qYh8;
		int num9 = -1 - _0023_003DzHh03WyA_003D + _0023_003DzPB8Mb17HTSO6;
		_0023_003DzhEXKXIU_003D = 0;
		if (_0023_003DzpGjKR04_003D < 0)
		{
			_0023_003DzhEXKXIU_003D = -1;
		}
		else if (_0023_003DzR5r3z0HtWrgJ < 0)
		{
			_0023_003DzhEXKXIU_003D = -2;
		}
		else if (_0023_003DzHh03WyA_003D < Math.Max(1, _0023_003DzpGjKR04_003D))
		{
			_0023_003DzhEXKXIU_003D = -7;
		}
		if (_0023_003DzhEXKXIU_003D != 0)
		{
			_0023_003DzRKxBhzpH2B27._0023_003Dzz8DDgng_003D(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302912092), -_0023_003DzhEXKXIU_003D);
		}
		else
		{
			if (_0023_003DzpGjKR04_003D == 0)
			{
				return;
			}
			if (_0023_003DzR5r3z0HtWrgJ == 1)
			{
				for (num = 1; num <= _0023_003DzpGjKR04_003D - 2; num++)
				{
					if (Math.Abs(_0023_003DzK_0024fbiW0_003D[num + num7]) >= Math.Abs(_0023_003DznyCFEaY_003D[num + num6]))
					{
						if (_0023_003DzK_0024fbiW0_003D[num + num7] == 0.0)
						{
							_0023_003DzhEXKXIU_003D = num;
							return;
						}
						num3 = _0023_003DznyCFEaY_003D[num + num6] / _0023_003DzK_0024fbiW0_003D[num + num7];
						_0023_003DzK_0024fbiW0_003D[num + 1 + num7] += (0.0 - num3) * _0023_003DzGZTDgUk_003D[num + num8];
						_0023_003DzH9VU2k0_003D[num + 1 + _0023_003DzHh03WyA_003D + num9] += (0.0 - num3) * _0023_003DzH9VU2k0_003D[num + _0023_003DzHh03WyA_003D + num9];
						_0023_003DznyCFEaY_003D[num + num6] = 0.0;
					}
					else
					{
						num3 = _0023_003DzK_0024fbiW0_003D[num + num7] / _0023_003DznyCFEaY_003D[num + num6];
						_0023_003DzK_0024fbiW0_003D[num + num7] = _0023_003DznyCFEaY_003D[num + num6];
						num4 = _0023_003DzK_0024fbiW0_003D[num + 1 + num7];
						_0023_003DzK_0024fbiW0_003D[num + 1 + num7] = _0023_003DzGZTDgUk_003D[num + num8] - num3 * num4;
						_0023_003DznyCFEaY_003D[num + num6] = _0023_003DzGZTDgUk_003D[num + 1 + num8];
						_0023_003DzGZTDgUk_003D[num + 1 + num8] = (0.0 - num3) * _0023_003DznyCFEaY_003D[num + num6];
						_0023_003DzGZTDgUk_003D[num + num8] = num4;
						num4 = _0023_003DzH9VU2k0_003D[num + _0023_003DzHh03WyA_003D + num9];
						_0023_003DzH9VU2k0_003D[num + _0023_003DzHh03WyA_003D + num9] = _0023_003DzH9VU2k0_003D[num + 1 + _0023_003DzHh03WyA_003D + num9];
						_0023_003DzH9VU2k0_003D[num + 1 + _0023_003DzHh03WyA_003D + num9] = num4 - num3 * _0023_003DzH9VU2k0_003D[num + 1 + _0023_003DzHh03WyA_003D + num9];
					}
				}
				if (_0023_003DzpGjKR04_003D > 1)
				{
					num = _0023_003DzpGjKR04_003D - 1;
					if (Math.Abs(_0023_003DzK_0024fbiW0_003D[num + num7]) >= Math.Abs(_0023_003DznyCFEaY_003D[num + num6]))
					{
						if (_0023_003DzK_0024fbiW0_003D[num + num7] == 0.0)
						{
							_0023_003DzhEXKXIU_003D = num;
							return;
						}
						num3 = _0023_003DznyCFEaY_003D[num + num6] / _0023_003DzK_0024fbiW0_003D[num + num7];
						_0023_003DzK_0024fbiW0_003D[num + 1 + num7] += (0.0 - num3) * _0023_003DzGZTDgUk_003D[num + num8];
						_0023_003DzH9VU2k0_003D[num + 1 + _0023_003DzHh03WyA_003D + num9] += (0.0 - num3) * _0023_003DzH9VU2k0_003D[num + _0023_003DzHh03WyA_003D + num9];
					}
					else
					{
						num3 = _0023_003DzK_0024fbiW0_003D[num + num7] / _0023_003DznyCFEaY_003D[num + num6];
						_0023_003DzK_0024fbiW0_003D[num + num7] = _0023_003DznyCFEaY_003D[num + num6];
						num4 = _0023_003DzK_0024fbiW0_003D[num + 1 + num7];
						_0023_003DzK_0024fbiW0_003D[num + 1 + num7] = _0023_003DzGZTDgUk_003D[num + num8] - num3 * num4;
						_0023_003DzGZTDgUk_003D[num + num8] = num4;
						num4 = _0023_003DzH9VU2k0_003D[num + _0023_003DzHh03WyA_003D + num9];
						_0023_003DzH9VU2k0_003D[num + _0023_003DzHh03WyA_003D + num9] = _0023_003DzH9VU2k0_003D[num + 1 + _0023_003DzHh03WyA_003D + num9];
						_0023_003DzH9VU2k0_003D[num + 1 + _0023_003DzHh03WyA_003D + num9] = num4 - num3 * _0023_003DzH9VU2k0_003D[num + 1 + _0023_003DzHh03WyA_003D + num9];
					}
				}
				if (_0023_003DzK_0024fbiW0_003D[_0023_003DzpGjKR04_003D + num7] == 0.0)
				{
					_0023_003DzhEXKXIU_003D = _0023_003DzpGjKR04_003D;
					return;
				}
			}
			else
			{
				for (num = 1; num <= _0023_003DzpGjKR04_003D - 2; num++)
				{
					if (Math.Abs(_0023_003DzK_0024fbiW0_003D[num + num7]) >= Math.Abs(_0023_003DznyCFEaY_003D[num + num6]))
					{
						if (_0023_003DzK_0024fbiW0_003D[num + num7] != 0.0)
						{
							num3 = _0023_003DznyCFEaY_003D[num + num6] / _0023_003DzK_0024fbiW0_003D[num + num7];
							_0023_003DzK_0024fbiW0_003D[num + 1 + num7] += (0.0 - num3) * _0023_003DzGZTDgUk_003D[num + num8];
							for (num2 = 1; num2 <= _0023_003DzR5r3z0HtWrgJ; num2++)
							{
								_0023_003DzH9VU2k0_003D[num + 1 + num2 * _0023_003DzHh03WyA_003D + num9] += (0.0 - num3) * _0023_003DzH9VU2k0_003D[num + num2 * _0023_003DzHh03WyA_003D + num9];
							}
							_0023_003DznyCFEaY_003D[num + num6] = 0.0;
							continue;
						}
						_0023_003DzhEXKXIU_003D = num;
						return;
					}
					num3 = _0023_003DzK_0024fbiW0_003D[num + num7] / _0023_003DznyCFEaY_003D[num + num6];
					_0023_003DzK_0024fbiW0_003D[num + num7] = _0023_003DznyCFEaY_003D[num + num6];
					num4 = _0023_003DzK_0024fbiW0_003D[num + 1 + num7];
					_0023_003DzK_0024fbiW0_003D[num + 1 + num7] = _0023_003DzGZTDgUk_003D[num + num8] - num3 * num4;
					_0023_003DznyCFEaY_003D[num + num6] = _0023_003DzGZTDgUk_003D[num + 1 + num8];
					_0023_003DzGZTDgUk_003D[num + 1 + num8] = (0.0 - num3) * _0023_003DznyCFEaY_003D[num + num6];
					_0023_003DzGZTDgUk_003D[num + num8] = num4;
					for (num2 = 1; num2 <= _0023_003DzR5r3z0HtWrgJ; num2++)
					{
						num4 = _0023_003DzH9VU2k0_003D[num + num2 * _0023_003DzHh03WyA_003D + num9];
						_0023_003DzH9VU2k0_003D[num + num2 * _0023_003DzHh03WyA_003D + num9] = _0023_003DzH9VU2k0_003D[num + 1 + num2 * _0023_003DzHh03WyA_003D + num9];
						_0023_003DzH9VU2k0_003D[num + 1 + num2 * _0023_003DzHh03WyA_003D + num9] = num4 - num3 * _0023_003DzH9VU2k0_003D[num + 1 + num2 * _0023_003DzHh03WyA_003D + num9];
					}
				}
				if (_0023_003DzpGjKR04_003D > 1)
				{
					num = _0023_003DzpGjKR04_003D - 1;
					if (Math.Abs(_0023_003DzK_0024fbiW0_003D[num + num7]) >= Math.Abs(_0023_003DznyCFEaY_003D[num + num6]))
					{
						if (_0023_003DzK_0024fbiW0_003D[num + num7] == 0.0)
						{
							_0023_003DzhEXKXIU_003D = num;
							return;
						}
						num3 = _0023_003DznyCFEaY_003D[num + num6] / _0023_003DzK_0024fbiW0_003D[num + num7];
						_0023_003DzK_0024fbiW0_003D[num + 1 + num7] += (0.0 - num3) * _0023_003DzGZTDgUk_003D[num + num8];
						for (num2 = 1; num2 <= _0023_003DzR5r3z0HtWrgJ; num2++)
						{
							_0023_003DzH9VU2k0_003D[num + 1 + num2 * _0023_003DzHh03WyA_003D + num9] += (0.0 - num3) * _0023_003DzH9VU2k0_003D[num + num2 * _0023_003DzHh03WyA_003D + num9];
						}
					}
					else
					{
						num3 = _0023_003DzK_0024fbiW0_003D[num + num7] / _0023_003DznyCFEaY_003D[num + num6];
						_0023_003DzK_0024fbiW0_003D[num + num7] = _0023_003DznyCFEaY_003D[num + num6];
						num4 = _0023_003DzK_0024fbiW0_003D[num + 1 + num7];
						_0023_003DzK_0024fbiW0_003D[num + 1 + num7] = _0023_003DzGZTDgUk_003D[num + num8] - num3 * num4;
						_0023_003DzGZTDgUk_003D[num + num8] = num4;
						for (num2 = 1; num2 <= _0023_003DzR5r3z0HtWrgJ; num2++)
						{
							num4 = _0023_003DzH9VU2k0_003D[num + num2 * _0023_003DzHh03WyA_003D + num9];
							_0023_003DzH9VU2k0_003D[num + num2 * _0023_003DzHh03WyA_003D + num9] = _0023_003DzH9VU2k0_003D[num + 1 + num2 * _0023_003DzHh03WyA_003D + num9];
							_0023_003DzH9VU2k0_003D[num + 1 + num2 * _0023_003DzHh03WyA_003D + num9] = num4 - num3 * _0023_003DzH9VU2k0_003D[num + 1 + num2 * _0023_003DzHh03WyA_003D + num9];
						}
					}
				}
				if (_0023_003DzK_0024fbiW0_003D[_0023_003DzpGjKR04_003D + num7] == 0.0)
				{
					_0023_003DzhEXKXIU_003D = _0023_003DzpGjKR04_003D;
					return;
				}
			}
			if (_0023_003DzR5r3z0HtWrgJ <= 2)
			{
				num2 = 1;
				while (true)
				{
					_0023_003DzH9VU2k0_003D[_0023_003DzpGjKR04_003D + num2 * _0023_003DzHh03WyA_003D + num9] /= _0023_003DzK_0024fbiW0_003D[_0023_003DzpGjKR04_003D + num7];
					if (_0023_003DzpGjKR04_003D > 1)
					{
						_0023_003DzH9VU2k0_003D[_0023_003DzpGjKR04_003D - 1 + num2 * _0023_003DzHh03WyA_003D + num9] = (_0023_003DzH9VU2k0_003D[_0023_003DzpGjKR04_003D - 1 + num2 * _0023_003DzHh03WyA_003D + num9] - _0023_003DzGZTDgUk_003D[_0023_003DzpGjKR04_003D - 1 + num8] * _0023_003DzH9VU2k0_003D[_0023_003DzpGjKR04_003D + num2 * _0023_003DzHh03WyA_003D + num9]) / _0023_003DzK_0024fbiW0_003D[_0023_003DzpGjKR04_003D - 1 + num7];
					}
					num5 = num2 * _0023_003DzHh03WyA_003D + num9;
					for (num = _0023_003DzpGjKR04_003D - 2; num >= 1; num += -1)
					{
						_0023_003DzH9VU2k0_003D[num + num5] = (_0023_003DzH9VU2k0_003D[num + num5] - _0023_003DzGZTDgUk_003D[num + num8] * _0023_003DzH9VU2k0_003D[num + 1 + num5] - _0023_003DznyCFEaY_003D[num + num6] * _0023_003DzH9VU2k0_003D[num + 2 + num5]) / _0023_003DzK_0024fbiW0_003D[num + num7];
					}
					if (num2 < _0023_003DzR5r3z0HtWrgJ)
					{
						num2++;
						continue;
					}
					break;
				}
				return;
			}
			for (num2 = 1; num2 <= _0023_003DzR5r3z0HtWrgJ; num2++)
			{
				_0023_003DzH9VU2k0_003D[_0023_003DzpGjKR04_003D + num2 * _0023_003DzHh03WyA_003D + num9] /= _0023_003DzK_0024fbiW0_003D[_0023_003DzpGjKR04_003D + num7];
				if (_0023_003DzpGjKR04_003D > 1)
				{
					_0023_003DzH9VU2k0_003D[_0023_003DzpGjKR04_003D - 1 + num2 * _0023_003DzHh03WyA_003D + num9] = (_0023_003DzH9VU2k0_003D[_0023_003DzpGjKR04_003D - 1 + num2 * _0023_003DzHh03WyA_003D + num9] - _0023_003DzGZTDgUk_003D[_0023_003DzpGjKR04_003D - 1 + num8] * _0023_003DzH9VU2k0_003D[_0023_003DzpGjKR04_003D + num2 * _0023_003DzHh03WyA_003D + num9]) / _0023_003DzK_0024fbiW0_003D[_0023_003DzpGjKR04_003D - 1 + num7];
				}
				num5 = num2 * _0023_003DzHh03WyA_003D + num9;
				for (num = _0023_003DzpGjKR04_003D - 2; num >= 1; num += -1)
				{
					_0023_003DzH9VU2k0_003D[num + num5] = (_0023_003DzH9VU2k0_003D[num + num5] - _0023_003DzGZTDgUk_003D[num + num8] * _0023_003DzH9VU2k0_003D[num + 1 + num5] - _0023_003DznyCFEaY_003D[num + num6] * _0023_003DzH9VU2k0_003D[num + 2 + num5]) / _0023_003DzK_0024fbiW0_003D[num + num7];
				}
			}
		}
	}
}
