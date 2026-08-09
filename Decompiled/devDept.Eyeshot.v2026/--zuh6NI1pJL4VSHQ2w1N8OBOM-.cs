using System;

internal sealed class _0023_003Dzuh6NI1pJL4VSHQ2w1N8OBOM_003D
{
	private _0023_003Dz02qX0FU8_0024GTQIHsVOKeLlQY_003D _0023_003Dz1iBohgL71bme;

	private _0023_003Dzsk4LmP82P1PKGVhBJT9FCjg_003D _0023_003DzP5EG5JF6QJpl;

	public _0023_003Dzuh6NI1pJL4VSHQ2w1N8OBOM_003D(_0023_003Dz02qX0FU8_0024GTQIHsVOKeLlQY_003D _0023_003DzHDJXO07Z0oKC, _0023_003Dzsk4LmP82P1PKGVhBJT9FCjg_003D _0023_003DzpZ9im0izpG3k)
	{
		_0023_003Dz1iBohgL71bme = _0023_003DzHDJXO07Z0oKC;
		_0023_003DzP5EG5JF6QJpl = _0023_003DzpZ9im0izpG3k;
	}

	public _0023_003Dzuh6NI1pJL4VSHQ2w1N8OBOM_003D()
	{
		_0023_003Dz02qX0FU8_0024GTQIHsVOKeLlQY_003D _0023_003Dz02qX0FU8_0024GTQIHsVOKeLlQY_003D2 = new _0023_003Dz02qX0FU8_0024GTQIHsVOKeLlQY_003D();
		_0023_003Dzsk4LmP82P1PKGVhBJT9FCjg_003D _0023_003Dzsk4LmP82P1PKGVhBJT9FCjg_003D2 = new _0023_003Dzsk4LmP82P1PKGVhBJT9FCjg_003D();
		_0023_003Dz1iBohgL71bme = _0023_003Dz02qX0FU8_0024GTQIHsVOKeLlQY_003D2;
		_0023_003DzP5EG5JF6QJpl = _0023_003Dzsk4LmP82P1PKGVhBJT9FCjg_003D2;
	}

	public double _0023_003Dzz8DDgng_003D(string _0023_003Dzy1tKBYQ_003D, string _0023_003Dzw5jlr_0024DM5PEE, string _0023_003DzHotF83QZN0XJ, int _0023_003DzDtqAooE_003D, int _0023_003DzpGjKR04_003D, double[] _0023_003DzE8QrneA_003D, int _0023_003Dz2aqhBwM2q2_0024U, int _0023_003Dzs0UaYks_003D, ref double[] _0023_003DzUvl_D7g_003D, int _0023_003DzSiwxa0IjGuoh)
	{
		bool flag = false;
		int num = 0;
		int num2 = 0;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		int num6 = -1 - _0023_003Dzs0UaYks_003D + _0023_003Dz2aqhBwM2q2_0024U;
		int num7 = -1 + _0023_003DzSiwxa0IjGuoh;
		_0023_003Dzy1tKBYQ_003D = _0023_003Dzy1tKBYQ_003D.Substring(0, 1);
		_0023_003Dzw5jlr_0024DM5PEE = _0023_003Dzw5jlr_0024DM5PEE.Substring(0, 1);
		_0023_003DzHotF83QZN0XJ = _0023_003DzHotF83QZN0XJ.Substring(0, 1);
		if (Math.Min(_0023_003DzDtqAooE_003D, _0023_003DzpGjKR04_003D) == 0)
		{
			num5 = 0.0;
		}
		else if (_0023_003DzP5EG5JF6QJpl._0023_003Dzz8DDgng_003D(_0023_003Dzy1tKBYQ_003D, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911366)))
		{
			if (_0023_003DzP5EG5JF6QJpl._0023_003Dzz8DDgng_003D(_0023_003DzHotF83QZN0XJ, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911455)))
			{
				num5 = 1.0;
				if (_0023_003DzP5EG5JF6QJpl._0023_003Dzz8DDgng_003D(_0023_003Dzw5jlr_0024DM5PEE, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911455)))
				{
					for (num2 = 1; num2 <= _0023_003DzpGjKR04_003D; num2++)
					{
						for (num = 1; num <= Math.Min(_0023_003DzDtqAooE_003D, num2 - 1); num++)
						{
							num5 = Math.Max(num5, Math.Abs(_0023_003DzE8QrneA_003D[num + num2 * _0023_003Dzs0UaYks_003D + num6]));
						}
					}
				}
				else
				{
					for (num2 = 1; num2 <= _0023_003DzpGjKR04_003D; num2++)
					{
						for (num = num2 + 1; num <= _0023_003DzDtqAooE_003D; num++)
						{
							num5 = Math.Max(num5, Math.Abs(_0023_003DzE8QrneA_003D[num + num2 * _0023_003Dzs0UaYks_003D + num6]));
						}
					}
				}
			}
			else
			{
				num5 = 0.0;
				if (_0023_003DzP5EG5JF6QJpl._0023_003Dzz8DDgng_003D(_0023_003Dzw5jlr_0024DM5PEE, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911455)))
				{
					for (num2 = 1; num2 <= _0023_003DzpGjKR04_003D; num2++)
					{
						for (num = 1; num <= Math.Min(_0023_003DzDtqAooE_003D, num2); num++)
						{
							num5 = Math.Max(num5, Math.Abs(_0023_003DzE8QrneA_003D[num + num2 * _0023_003Dzs0UaYks_003D + num6]));
						}
					}
				}
				else
				{
					for (num2 = 1; num2 <= _0023_003DzpGjKR04_003D; num2++)
					{
						for (num = num2; num <= _0023_003DzDtqAooE_003D; num++)
						{
							num5 = Math.Max(num5, Math.Abs(_0023_003DzE8QrneA_003D[num + num2 * _0023_003Dzs0UaYks_003D + num6]));
						}
					}
				}
			}
		}
		else if (_0023_003DzP5EG5JF6QJpl._0023_003Dzz8DDgng_003D(_0023_003Dzy1tKBYQ_003D, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910999)) || _0023_003Dzy1tKBYQ_003D == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302912388))
		{
			num5 = 0.0;
			flag = _0023_003DzP5EG5JF6QJpl._0023_003Dzz8DDgng_003D(_0023_003DzHotF83QZN0XJ, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911455));
			if (_0023_003DzP5EG5JF6QJpl._0023_003Dzz8DDgng_003D(_0023_003Dzw5jlr_0024DM5PEE, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911455)))
			{
				for (num2 = 1; num2 <= _0023_003DzpGjKR04_003D; num2++)
				{
					if (flag && num2 <= _0023_003DzDtqAooE_003D)
					{
						num4 = 1.0;
						for (num = 1; num <= num2 - 1; num++)
						{
							num4 += Math.Abs(_0023_003DzE8QrneA_003D[num + num2 * _0023_003Dzs0UaYks_003D + num6]);
						}
					}
					else
					{
						num4 = 0.0;
						for (num = 1; num <= Math.Min(_0023_003DzDtqAooE_003D, num2); num++)
						{
							num4 += Math.Abs(_0023_003DzE8QrneA_003D[num + num2 * _0023_003Dzs0UaYks_003D + num6]);
						}
					}
					num5 = Math.Max(num5, num4);
				}
			}
			else
			{
				for (num2 = 1; num2 <= _0023_003DzpGjKR04_003D; num2++)
				{
					if (flag)
					{
						num4 = 1.0;
						for (num = num2 + 1; num <= _0023_003DzDtqAooE_003D; num++)
						{
							num4 += Math.Abs(_0023_003DzE8QrneA_003D[num + num2 * _0023_003Dzs0UaYks_003D + num6]);
						}
					}
					else
					{
						num4 = 0.0;
						for (num = num2; num <= _0023_003DzDtqAooE_003D; num++)
						{
							num4 += Math.Abs(_0023_003DzE8QrneA_003D[num + num2 * _0023_003Dzs0UaYks_003D + num6]);
						}
					}
					num5 = Math.Max(num5, num4);
				}
			}
		}
		else if (_0023_003DzP5EG5JF6QJpl._0023_003Dzz8DDgng_003D(_0023_003Dzy1tKBYQ_003D, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911423)))
		{
			if (_0023_003DzP5EG5JF6QJpl._0023_003Dzz8DDgng_003D(_0023_003Dzw5jlr_0024DM5PEE, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911455)))
			{
				if (_0023_003DzP5EG5JF6QJpl._0023_003Dzz8DDgng_003D(_0023_003DzHotF83QZN0XJ, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911455)))
				{
					for (num = 1; num <= _0023_003DzDtqAooE_003D; num++)
					{
						_0023_003DzUvl_D7g_003D[num + num7] = 1.0;
					}
					for (num2 = 1; num2 <= _0023_003DzpGjKR04_003D; num2++)
					{
						for (num = 1; num <= Math.Min(_0023_003DzDtqAooE_003D, num2 - 1); num++)
						{
							_0023_003DzUvl_D7g_003D[num + num7] += Math.Abs(_0023_003DzE8QrneA_003D[num + num2 * _0023_003Dzs0UaYks_003D + num6]);
						}
					}
				}
				else
				{
					for (num = 1; num <= _0023_003DzDtqAooE_003D; num++)
					{
						_0023_003DzUvl_D7g_003D[num + num7] = 0.0;
					}
					for (num2 = 1; num2 <= _0023_003DzpGjKR04_003D; num2++)
					{
						for (num = 1; num <= Math.Min(_0023_003DzDtqAooE_003D, num2); num++)
						{
							_0023_003DzUvl_D7g_003D[num + num7] += Math.Abs(_0023_003DzE8QrneA_003D[num + num2 * _0023_003Dzs0UaYks_003D + num6]);
						}
					}
				}
			}
			else if (_0023_003DzP5EG5JF6QJpl._0023_003Dzz8DDgng_003D(_0023_003DzHotF83QZN0XJ, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911455)))
			{
				for (num = 1; num <= _0023_003DzpGjKR04_003D; num++)
				{
					_0023_003DzUvl_D7g_003D[num + num7] = 1.0;
				}
				for (num = _0023_003DzpGjKR04_003D + 1; num <= _0023_003DzDtqAooE_003D; num++)
				{
					_0023_003DzUvl_D7g_003D[num + num7] = 0.0;
				}
				for (num2 = 1; num2 <= _0023_003DzpGjKR04_003D; num2++)
				{
					for (num = num2 + 1; num <= _0023_003DzDtqAooE_003D; num++)
					{
						_0023_003DzUvl_D7g_003D[num + num7] += Math.Abs(_0023_003DzE8QrneA_003D[num + num2 * _0023_003Dzs0UaYks_003D + num6]);
					}
				}
			}
			else
			{
				for (num = 1; num <= _0023_003DzDtqAooE_003D; num++)
				{
					_0023_003DzUvl_D7g_003D[num + num7] = 0.0;
				}
				for (num2 = 1; num2 <= _0023_003DzpGjKR04_003D; num2++)
				{
					for (num = num2; num <= _0023_003DzDtqAooE_003D; num++)
					{
						_0023_003DzUvl_D7g_003D[num + num7] += Math.Abs(_0023_003DzE8QrneA_003D[num + num2 * _0023_003Dzs0UaYks_003D + num6]);
					}
				}
			}
			num5 = 0.0;
			for (num = 1; num <= _0023_003DzDtqAooE_003D; num++)
			{
				num5 = Math.Max(num5, _0023_003DzUvl_D7g_003D[num + num7]);
			}
		}
		else if (_0023_003DzP5EG5JF6QJpl._0023_003Dzz8DDgng_003D(_0023_003Dzy1tKBYQ_003D, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911036)) || _0023_003DzP5EG5JF6QJpl._0023_003Dzz8DDgng_003D(_0023_003Dzy1tKBYQ_003D, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911012)))
		{
			if (_0023_003DzP5EG5JF6QJpl._0023_003Dzz8DDgng_003D(_0023_003Dzw5jlr_0024DM5PEE, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911455)))
			{
				if (_0023_003DzP5EG5JF6QJpl._0023_003Dzz8DDgng_003D(_0023_003DzHotF83QZN0XJ, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911455)))
				{
					num3 = 1.0;
					num4 = Math.Min(_0023_003DzDtqAooE_003D, _0023_003DzpGjKR04_003D);
					for (num2 = 2; num2 <= _0023_003DzpGjKR04_003D; num2++)
					{
						_0023_003Dz1iBohgL71bme._0023_003Dzz8DDgng_003D(Math.Min(_0023_003DzDtqAooE_003D, num2 - 1), _0023_003DzE8QrneA_003D, 1 + num2 * _0023_003Dzs0UaYks_003D + num6, 1, ref num3, ref num4);
					}
				}
				else
				{
					num3 = 0.0;
					num4 = 1.0;
					for (num2 = 1; num2 <= _0023_003DzpGjKR04_003D; num2++)
					{
						_0023_003Dz1iBohgL71bme._0023_003Dzz8DDgng_003D(Math.Min(_0023_003DzDtqAooE_003D, num2), _0023_003DzE8QrneA_003D, 1 + num2 * _0023_003Dzs0UaYks_003D + num6, 1, ref num3, ref num4);
					}
				}
			}
			else if (_0023_003DzP5EG5JF6QJpl._0023_003Dzz8DDgng_003D(_0023_003DzHotF83QZN0XJ, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911455)))
			{
				num3 = 1.0;
				num4 = Math.Min(_0023_003DzDtqAooE_003D, _0023_003DzpGjKR04_003D);
				for (num2 = 1; num2 <= _0023_003DzpGjKR04_003D; num2++)
				{
					_0023_003Dz1iBohgL71bme._0023_003Dzz8DDgng_003D(_0023_003DzDtqAooE_003D - num2, _0023_003DzE8QrneA_003D, Math.Min(_0023_003DzDtqAooE_003D, num2 + 1) + num2 * _0023_003Dzs0UaYks_003D + num6, 1, ref num3, ref num4);
				}
			}
			else
			{
				num3 = 0.0;
				num4 = 1.0;
				for (num2 = 1; num2 <= _0023_003DzpGjKR04_003D; num2++)
				{
					_0023_003Dz1iBohgL71bme._0023_003Dzz8DDgng_003D(_0023_003DzDtqAooE_003D - num2 + 1, _0023_003DzE8QrneA_003D, num2 + num2 * _0023_003Dzs0UaYks_003D + num6, 1, ref num3, ref num4);
				}
			}
			num5 = num3 * Math.Sqrt(num4);
		}
		return num5;
	}
}
