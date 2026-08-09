using System;

internal sealed class _0023_003DzmsQJ9cCJlXj_0024saxQYXW69Ao_003D
{
	private _0023_003DzvuOZoIN8OtKD0PJWGr1cmIk_003D _0023_003DzRKxBhzpH2B27;

	public _0023_003DzmsQJ9cCJlXj_0024saxQYXW69Ao_003D(_0023_003DzvuOZoIN8OtKD0PJWGr1cmIk_003D _0023_003Dzt2EQ2fGeANKe)
	{
		_0023_003DzRKxBhzpH2B27 = _0023_003Dzt2EQ2fGeANKe;
	}

	public _0023_003DzmsQJ9cCJlXj_0024saxQYXW69Ao_003D()
	{
		_0023_003DzvuOZoIN8OtKD0PJWGr1cmIk_003D _0023_003DzvuOZoIN8OtKD0PJWGr1cmIk_003D2 = new _0023_003DzvuOZoIN8OtKD0PJWGr1cmIk_003D();
		_0023_003DzRKxBhzpH2B27 = _0023_003DzvuOZoIN8OtKD0PJWGr1cmIk_003D2;
	}

	public void _0023_003Dzz8DDgng_003D(int _0023_003DzDtqAooE_003D, int _0023_003DzpGjKR04_003D, double _0023_003DztKROdcY_003D, double[] _0023_003Dzyk2fsPo_003D, int _0023_003DzVwzJWWz_0024BCSn, int _0023_003DzPha_0024VJlONheb, double[] _0023_003DzvXOLtKg_003D, int _0023_003Dz4chJLWqlzf4p, int _0023_003DzGWhj1O1jhTmW, ref double[] _0023_003DzE8QrneA_003D, int _0023_003Dz2aqhBwM2q2_0024U, int _0023_003Dzs0UaYks_003D)
	{
		double num = 0.0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		int num7 = 0;
		int num8 = 0;
		int num9 = -1 + _0023_003DzVwzJWWz_0024BCSn;
		int num10 = -1 + _0023_003Dz4chJLWqlzf4p;
		int num11 = -1 - _0023_003Dzs0UaYks_003D + _0023_003Dz2aqhBwM2q2_0024U;
		num3 = 0;
		if (_0023_003DzDtqAooE_003D < 0)
		{
			num3 = 1;
		}
		else if (_0023_003DzpGjKR04_003D < 0)
		{
			num3 = 2;
		}
		else if (_0023_003DzPha_0024VJlONheb == 0)
		{
			num3 = 5;
		}
		else if (_0023_003DzGWhj1O1jhTmW == 0)
		{
			num3 = 7;
		}
		else if (_0023_003Dzs0UaYks_003D < Math.Max(1, _0023_003DzDtqAooE_003D))
		{
			num3 = 9;
		}
		if (num3 != 0)
		{
			_0023_003DzRKxBhzpH2B27._0023_003Dzz8DDgng_003D(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911650), num3);
		}
		else
		{
			if (_0023_003DzDtqAooE_003D == 0 || _0023_003DzpGjKR04_003D == 0 || _0023_003DztKROdcY_003D == 0.0)
			{
				return;
			}
			num6 = ((_0023_003DzGWhj1O1jhTmW > 0) ? 1 : (1 - (_0023_003DzpGjKR04_003D - 1) * _0023_003DzGWhj1O1jhTmW));
			if (_0023_003DzPha_0024VJlONheb == 1)
			{
				for (num5 = 1; num5 <= _0023_003DzpGjKR04_003D; num5++)
				{
					if (_0023_003DzvXOLtKg_003D[num6 + num10] != 0.0)
					{
						num = _0023_003DztKROdcY_003D * _0023_003DzvXOLtKg_003D[num6 + num10];
						num8 = num5 * _0023_003Dzs0UaYks_003D + num11;
						for (num2 = 1; num2 <= _0023_003DzDtqAooE_003D; num2++)
						{
							_0023_003DzE8QrneA_003D[num2 + num8] += _0023_003Dzyk2fsPo_003D[num2 + num9] * num;
						}
					}
					num6 += _0023_003DzGWhj1O1jhTmW;
				}
				return;
			}
			num7 = ((_0023_003DzPha_0024VJlONheb > 0) ? 1 : (1 - (_0023_003DzDtqAooE_003D - 1) * _0023_003DzPha_0024VJlONheb));
			for (num5 = 1; num5 <= _0023_003DzpGjKR04_003D; num5++)
			{
				if (_0023_003DzvXOLtKg_003D[num6 + num10] != 0.0)
				{
					num = _0023_003DztKROdcY_003D * _0023_003DzvXOLtKg_003D[num6 + num10];
					num4 = num7;
					num8 = num5 * _0023_003Dzs0UaYks_003D + num11;
					for (num2 = 1; num2 <= _0023_003DzDtqAooE_003D; num2++)
					{
						_0023_003DzE8QrneA_003D[num2 + num8] += _0023_003Dzyk2fsPo_003D[num4 + num9] * num;
						num4 += _0023_003DzPha_0024VJlONheb;
					}
				}
				num6 += _0023_003DzGWhj1O1jhTmW;
			}
		}
	}
}
