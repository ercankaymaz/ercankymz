using System;

internal sealed class _0023_003DzB1GgDFVBr2UEI9pPDYiebNR9_ru7 : _0023_003Dz0uakMTYWSaT8ppzortQoqexp2pVbh6iAzzk43CsKE0LX
{
	private readonly _0023_003Dz4rzdYKa1XuIx_Imdw_WlPSpzrHlvzPor3A_003D_003D _0023_003DzhqrRQ_0024w_003D;

	private double[] _0023_003Dz7E3EGPQ_003D;

	private double[] _0023_003Dz6VxOhgk_003D;

	private _0023_003Dz5C5TPYnyp4Ol5tMpkkk8NyF7uKTui_0024PpCw_003D_003D _0023_003DzNHDUvwc_003D;

	private uint _0023_003DzPk4AAn8_003D;

	private uint _0023_003DzfLc_B0FQ6SSdNb85zw_003D_003D = 32u;

	private uint _0023_003DzU2_tzJQKCAuC;

	public _0023_003DzB1GgDFVBr2UEI9pPDYiebNR9_ru7(_0023_003Dz4rzdYKa1XuIx_Imdw_WlPSpzrHlvzPor3A_003D_003D _0023_003Dzl3DhHgI_003D, uint _0023_003Dz5IbFCrs_003D)
	{
		_0023_003DzhqrRQ_0024w_003D = _0023_003Dzl3DhHgI_003D;
		_0023_003DzU2_tzJQKCAuC = _0023_003Dz5IbFCrs_003D;
		double[] array = new double[_0023_003Dz5IbFCrs_003D];
		_0023_003Dzok1n28CyQDckbw7WSyLbYJK__0024H81KeE9vQ_003D_003D._0023_003Dzo6KAXJQ_003D(array, 0.0);
		double[] array2 = new double[_0023_003Dz5IbFCrs_003D];
		_0023_003Dzok1n28CyQDckbw7WSyLbYJK__0024H81KeE9vQ_003D_003D._0023_003Dzo6KAXJQ_003D(array2, 1.0);
		_0023_003Dz7E3EGPQ_003D = new double[_0023_003Dz5IbFCrs_003D];
		_0023_003Dz6VxOhgk_003D = new double[_0023_003Dz5IbFCrs_003D];
		_0023_003DzNHDUvwc_003D = new _0023_003Dz5C5TPYnyp4Ol5tMpkkk8NyF7uKTui_0024PpCw_003D_003D(Convert.ToUInt32((uint)(1 << Convert.ToInt32(_0023_003Dz5IbFCrs_003D))));
		_0023_003DzMkd41wQ_003D(array, array2);
	}

	public override _0023_003Dz4rzdYKa1XuIx_Imdw_WlPSpzrHlvzPor3A_003D_003D _0023_003DzI_00248m9Go_003D()
	{
		return _0023_003DzhqrRQ_0024w_003D;
	}

	public override void _0023_003DzttBXI_0024c_003D()
	{
		uint[] _0023_003Dz61IPlm0_003D = new uint[_0023_003DzNHDUvwc_003D._0023_003Dz14lzA48_003D()];
		_0023_003DzNHDUvwc_003D._0023_003DzttBXI_0024c_003D();
		_0023_003DzPk4AAn8_003D = 0u;
		for (uint num = 0u; num <= (uint)(1 << Convert.ToInt32(_0023_003DzU2_tzJQKCAuC)); num++)
		{
			_0023_003DzNHDUvwc_003D._0023_003DzyRujy0UHSSDxp3zrMg_003D_003D(_0023_003Dz61IPlm0_003D);
		}
	}

	public override void _0023_003DzHHef7hbFOmGP()
	{
		_0023_003DzNHDUvwc_003D._0023_003DzHHef7hbFOmGP();
		_0023_003DzttBXI_0024c_003D();
	}

	public override bool _0023_003Dze6U2VUyBaRq6(uint _0023_003DzoMNiNRw_003D)
	{
		uint num = 2 * _0023_003DzoMNiNRw_003D / (uint)((1 << Convert.ToInt32(_0023_003DzU2_tzJQKCAuC)) - 1);
		uint num2 = 1u;
		uint num3 = 1u;
		while (num2 < num)
		{
			num2 *= (uint)(1 << Convert.ToInt32(_0023_003DzU2_tzJQKCAuC));
			num3++;
		}
		int num4 = Convert.ToInt32(Convert.ToInt32(_0023_003DzU2_tzJQKCAuC) * (num3 - 1));
		uint num5 = Convert.ToUInt32(num + ((1 << num4) - 1) / (uint)((1 << Convert.ToInt32(_0023_003DzU2_tzJQKCAuC)) - 1));
		return _0023_003DzNHDUvwc_003D._0023_003Dze6U2VUyBaRq6((uint)(1 << Convert.ToInt32(_0023_003DzU2_tzJQKCAuC)) + num5);
	}

	public override uint _0023_003DzMkd41wQ_003D()
	{
		double[] array = new double[_0023_003DzU2_tzJQKCAuC];
		_0023_003Dzok1n28CyQDckbw7WSyLbYJK__0024H81KeE9vQ_003D_003D._0023_003Dzo6KAXJQ_003D(array, 0.0);
		double[] array2 = new double[_0023_003DzU2_tzJQKCAuC];
		_0023_003Dzok1n28CyQDckbw7WSyLbYJK__0024H81KeE9vQ_003D_003D._0023_003Dzo6KAXJQ_003D(array2, 1.0);
		return _0023_003DzMkd41wQ_003D(array, array2);
	}

	public override uint _0023_003DzMkd41wQ_003D(double[] _0023_003Dzis4t_0024iE_003D, double[] _0023_003DzG4OU504_003D)
	{
		double[] array = _0023_003Dzok1n28CyQDckbw7WSyLbYJK__0024H81KeE9vQ_003D_003D._0023_003Dzp9qY37s_003D(0u, _0023_003Dzis4t_0024iE_003D);
		double[] _0023_003Dzyk2fsPo_003D = _0023_003Dzok1n28CyQDckbw7WSyLbYJK__0024H81KeE9vQ_003D_003D._0023_003Dzp9qY37s_003D(0u, _0023_003DzG4OU504_003D);
		double[] array2 = new double[_0023_003DzU2_tzJQKCAuC];
		_0023_003DzttBXI_0024c_003D();
		_0023_003Dz6lGncTjN6Lvoy8Z4ebbI5fd5YT7n3USMLZ8_8WVYRfPlDeGSxIXlVlFDcAOn._0023_003DzVDEqEbgEl8eN(_0023_003Dzyk2fsPo_003D, array, array2);
		double num = 1E-12 * _0023_003Dz2r0HNeQGzT4RUytme3ESyC2QrG3puCjuXZyTNu3nY4_0024boKdwBASbP9Q_003D._0023_003DzrXB9c9B0CxqT(array2);
		if (num == 0.0)
		{
			num = Convert.ToUInt32(1E-12);
		}
		_0023_003Dz2r0HNeQGzT4RUytme3ESyC2QrG3puCjuXZyTNu3nY4_0024boKdwBASbP9Q_003D._0023_003Dz1l0EiMs_003D(0.0 - num, array);
		_0023_003Dz2r0HNeQGzT4RUytme3ESyC2QrG3puCjuXZyTNu3nY4_0024boKdwBASbP9Q_003D._0023_003Dz1l0EiMs_003D(num, _0023_003Dzyk2fsPo_003D);
		_0023_003Dz7E3EGPQ_003D = array;
		_0023_003Dz6lGncTjN6Lvoy8Z4ebbI5fd5YT7n3USMLZ8_8WVYRfPlDeGSxIXlVlFDcAOn._0023_003DzVDEqEbgEl8eN(_0023_003Dzyk2fsPo_003D, array, _0023_003Dz6VxOhgk_003D);
		for (uint num2 = 0u; num2 < _0023_003DzU2_tzJQKCAuC; num2++)
		{
			double num3 = _0023_003Dz6VxOhgk_003D[num2];
			double num4 = Convert.ToDouble((uint)(1 << (int)(_0023_003DzfLc_B0FQ6SSdNb85zw_003D_003D - 1)));
			num3 = _0023_003Dz6VxOhgk_003D[num2];
			_0023_003Dz6VxOhgk_003D[num2] = num4 / num3;
		}
		return 0u;
	}

	public uint _0023_003Dz14lzA48_003D()
	{
		return _0023_003DzPk4AAn8_003D;
	}

	public override bool _0023_003DzqRJnPHc_003D()
	{
		return _0023_003DzPk4AAn8_003D == 0;
	}

	public bool _0023_003DzSZ0NwQM_003D(uint _0023_003DzBpUNCVk_003D)
	{
		bool num = _0023_003DzMXXhrqmEHcwi((uint)(1 << Convert.ToInt32(_0023_003DzU2_tzJQKCAuC)), _0023_003DzfLc_B0FQ6SSdNb85zw_003D_003D - 1, _0023_003DzBpUNCVk_003D);
		if (num)
		{
			_0023_003DzPk4AAn8_003D++;
		}
		return num;
	}

	public bool _0023_003DzMusAlMc_003D(uint _0023_003DzBpUNCVk_003D)
	{
		bool flag = false;
		uint _0023_003DzTSeNR8Q_003D = (uint)(1 << Convert.ToInt32(_0023_003DzU2_tzJQKCAuC));
		if (!_0023_003DzqRJnPHc_003D())
		{
			flag = _0023_003DzDOP4yKuIt7HH(_0023_003DzTSeNR8Q_003D, _0023_003DzfLc_B0FQ6SSdNb85zw_003D_003D - 1, _0023_003DzBpUNCVk_003D);
		}
		if (flag)
		{
			_0023_003DzPk4AAn8_003D--;
		}
		return flag;
	}

	public bool _0023_003Dz8y9lXPc_003D(uint _0023_003DzBpUNCVk_003D)
	{
		uint[] _0023_003DzP6ZyoXz1ZRSJ = new uint[_0023_003DzU2_tzJQKCAuC];
		uint _0023_003DzTSeNR8Q_003D = (uint)(1 << Convert.ToInt32(_0023_003DzU2_tzJQKCAuC));
		uint _0023_003Dzalvl9z8_003D = 0u;
		uint _0023_003DzfNi7d4A_003D = Convert.ToUInt32(_0023_003DzfLc_B0FQ6SSdNb85zw_003D_003D - 1);
		if (!_0023_003Dzk1jtIDb_4xLqOyliUA_003D_003D(_0023_003DzhqrRQ_0024w_003D._0023_003DzYlRpapy_b5uM(_0023_003DzBpUNCVk_003D), _0023_003DzhqrRQ_0024w_003D, _0023_003DzP6ZyoXz1ZRSJ))
		{
			return false;
		}
		_0023_003Dz8lcXafU_0024Nky7(_0023_003DzP6ZyoXz1ZRSJ, ref _0023_003DzTSeNR8Q_003D, ref _0023_003DzfNi7d4A_003D, ref _0023_003Dzalvl9z8_003D);
		return _0023_003DzBA60zYYUQzVt(_0023_003DzTSeNR8Q_003D, _0023_003DzBpUNCVk_003D);
	}

	public uint _0023_003Dze_0024x00NTL1M0lIlVJnA_003D_003D(double[] _0023_003Dzl3DhHgI_003D, _0023_003DzGvGBBJxrudVhx1XU9jzwnU7ZhXTnnvmTx5rT9h4nsPcF _0023_003DzV_0024Ui4m7SpXBg)
	{
		uint[] _0023_003DzP6ZyoXz1ZRSJ = new uint[_0023_003DzU2_tzJQKCAuC];
		uint[] _0023_003DzLMGP75GKdMr = new uint[_0023_003DzU2_tzJQKCAuC];
		uint[] _0023_003DzOWW1TPcys1cE = new uint[_0023_003DzU2_tzJQKCAuC];
		uint _0023_003DzpGjKR04_003D = 0u;
		uint _0023_003DzfNi7d4A_003D = 0u;
		uint _0023_003Dz25a3MYc_003D = 0u;
		uint _0023_003DzTSeNR8Q_003D = 0u;
		double _0023_003DzKjjcAoU_003D = double.MaxValue;
		if (_0023_003DzqRJnPHc_003D())
		{
			return uint.MaxValue;
		}
		_0023_003Dzk1jtIDb_4xLqOyliUA_003D_003D(0u, _0023_003Dzl3DhHgI_003D, _0023_003DzP6ZyoXz1ZRSJ);
		_0023_003DzmMAoCIAkvzsHYMJI4w_003D_003D(_0023_003Dzl3DhHgI_003D, ref _0023_003DzKjjcAoU_003D, ref _0023_003DzpGjKR04_003D, _0023_003DzP6ZyoXz1ZRSJ, ref _0023_003DzLMGP75GKdMr, ref _0023_003DzOWW1TPcys1cE, ref _0023_003DzTSeNR8Q_003D, ref _0023_003DzfNi7d4A_003D, ref _0023_003Dz25a3MYc_003D, _0023_003DzV_0024Ui4m7SpXBg);
		return _0023_003DzpGjKR04_003D;
	}

	public uint _0023_003DzOdhQ_0024ZnIN0kiqVqwKg_003D_003D(double[] _0023_003Dzl3DhHgI_003D, ref double _0023_003DzKjjcAoU_003D, _0023_003DziKUZqG3nRQL0meMhiy_0024F1oWAZTcHFWcUug_003D_003D _0023_003DzV_0024Ui4m7SpXBg)
	{
		uint[] _0023_003DzP6ZyoXz1ZRSJ = new uint[_0023_003DzU2_tzJQKCAuC];
		uint[] _0023_003Dz6l3KtIYRGdK = new uint[_0023_003DzU2_tzJQKCAuC];
		uint[] _0023_003DzLMGP75GKdMr = new uint[_0023_003DzU2_tzJQKCAuC];
		uint[] _0023_003DzOWW1TPcys1cE = new uint[_0023_003DzU2_tzJQKCAuC];
		uint _0023_003DzpGjKR04_003D = 0u;
		uint _0023_003DzfNi7d4A_003D = 0u;
		uint _0023_003Dz25a3MYc_003D = 0u;
		uint _0023_003DzTSeNR8Q_003D = 0u;
		uint _0023_003DzTSeNR8Q_003D2 = 0u;
		uint num = uint.MaxValue;
		if (_0023_003DzqRJnPHc_003D())
		{
			return num;
		}
		_0023_003Dzk1jtIDb_4xLqOyliUA_003D_003D(_0023_003Dzl3DhHgI_003D, _0023_003DzP6ZyoXz1ZRSJ);
		_0023_003DzmMAoCIAkvzsHYMJI4w_003D_003D(_0023_003Dzl3DhHgI_003D, ref _0023_003DzKjjcAoU_003D, ref _0023_003DzpGjKR04_003D, _0023_003DzP6ZyoXz1ZRSJ, ref _0023_003DzLMGP75GKdMr, ref _0023_003DzOWW1TPcys1cE, ref _0023_003DzTSeNR8Q_003D2, ref _0023_003DzfNi7d4A_003D, ref _0023_003Dz25a3MYc_003D, _0023_003DzV_0024Ui4m7SpXBg);
		if (_0023_003DzpGjKR04_003D == num)
		{
			return num;
		}
		if (_0023_003Dz2r0HNeQGzT4RUytme3ESyC2QrG3puCjuXZyTNu3nY4_0024boKdwBASbP9Q_003D._0023_003DzOnakQO0_003D(_0023_003DzLMGP75GKdMr, 0u))
		{
			double _0023_003DzXrexKjY_003D = Math.Sqrt(_0023_003DzKjjcAoU_003D);
			_0023_003DzSZoFuKnhKiHn4IDB5sBUHU0_003D(_0023_003DzP6ZyoXz1ZRSJ, _0023_003DzXrexKjY_003D, _0023_003DzLMGP75GKdMr, _0023_003DzOWW1TPcys1cE);
		}
		_0023_003DzODVrRo_XTu5d(_0023_003DzLMGP75GKdMr, _0023_003DzOWW1TPcys1cE, ref _0023_003DzTSeNR8Q_003D, ref _0023_003DzfNi7d4A_003D, ref _0023_003Dz25a3MYc_003D, _0023_003Dz6l3KtIYRGdK);
		_0023_003Dz9o10SgQGgoRyhor6oQ_003D_003D(_0023_003Dzl3DhHgI_003D, ref _0023_003DzKjjcAoU_003D, ref _0023_003DzpGjKR04_003D, _0023_003DzP6ZyoXz1ZRSJ, _0023_003DzLMGP75GKdMr, _0023_003DzOWW1TPcys1cE, _0023_003DzTSeNR8Q_003D, _0023_003DzfNi7d4A_003D, _0023_003Dz25a3MYc_003D, _0023_003Dz6l3KtIYRGdK, _0023_003DzTSeNR8Q_003D2, 0u, _0023_003DzV_0024Ui4m7SpXBg);
		return _0023_003DzpGjKR04_003D;
	}

	public uint _0023_003Dz5GTlo5Dge2LL8a0OYQ_003D_003D(double[] _0023_003Dzis4t_0024iE_003D, double[] _0023_003DzG4OU504_003D, uint _0023_003DzOkHnHgY_003D, _0023_003Dz3GjzoP0yRzXuryLde64bDE8ETLkdYg_0024_8zq_0024JZI_003D _0023_003DzprTPZfc_003D, _0023_003DziKUZqG3nRQL0meMhiy_0024F1oWAZTcHFWcUug_003D_003D _0023_003DzV_0024Ui4m7SpXBg)
	{
		if (_0023_003DzqRJnPHc_003D())
		{
			return _0023_003DzOkHnHgY_003D;
		}
		uint[] array = new uint[_0023_003DzU2_tzJQKCAuC];
		uint[] array2 = new uint[_0023_003DzU2_tzJQKCAuC];
		_0023_003Dzk1jtIDb_4xLqOyliUA_003D_003D(_0023_003Dzis4t_0024iE_003D, array);
		_0023_003Dzk1jtIDb_4xLqOyliUA_003D_003D(_0023_003DzG4OU504_003D, array2);
		return _0023_003DzePxLYZ93niBtqDPkjwpwEks_003D(_0023_003Dzis4t_0024iE_003D, _0023_003DzG4OU504_003D, array, array2, _0023_003DzOkHnHgY_003D, _0023_003DzprTPZfc_003D, _0023_003DzV_0024Ui4m7SpXBg);
	}

	public override uint _0023_003Dzn02F2sW6Mcnqz62_0024vQ_003D_003D(double[] _0023_003Dzis4t_0024iE_003D, double[] _0023_003DzG4OU504_003D, uint _0023_003DzOkHnHgY_003D, _0023_003Dz3GjzoP0yRzXuryLde64bDE8ETLkdYg_0024_8zq_0024JZI_003D _0023_003DzprTPZfc_003D)
	{
		return _0023_003Dz5GTlo5Dge2LL8a0OYQ_003D_003D(_0023_003Dzis4t_0024iE_003D, _0023_003DzG4OU504_003D, _0023_003DzOkHnHgY_003D, _0023_003DzprTPZfc_003D, new _0023_003DziKUZqG3nRQL0meMhiy_0024F1oWAZTcHFWcUug_003D_003D());
	}

	private bool _0023_003Dzk1jtIDb_4xLqOyliUA_003D_003D(uint _0023_003DzurKrLc0_003D, _0023_003Dz4rzdYKa1XuIx_Imdw_WlPSpzrHlvzPor3A_003D_003D _0023_003Dzl3DhHgI_003D, uint[] _0023_003DzP6ZyoXz1ZRSJ)
	{
		bool result = true;
		for (uint num = 0u; num < _0023_003DzU2_tzJQKCAuC; num++)
		{
			double num2 = (_0023_003Dzl3DhHgI_003D._0023_003DzYBaDcXE_003D(_0023_003DzurKrLc0_003D + num) - _0023_003Dz7E3EGPQ_003D[num]) * _0023_003Dz6VxOhgk_003D[num];
			if (num2 < 0.0)
			{
				_0023_003DzP6ZyoXz1ZRSJ[num] = 0u;
				result = false;
			}
			else if (num2 >= (double)(uint)(1 << (int)(_0023_003DzfLc_B0FQ6SSdNb85zw_003D_003D - 1)))
			{
				_0023_003DzP6ZyoXz1ZRSJ[num] = (uint)((1 << (int)(_0023_003DzfLc_B0FQ6SSdNb85zw_003D_003D - 1)) - 1);
				result = false;
			}
			else
			{
				_0023_003DzP6ZyoXz1ZRSJ[num] = Convert.ToUInt32(Math.Floor(num2));
			}
		}
		return result;
	}

	private bool _0023_003Dzk1jtIDb_4xLqOyliUA_003D_003D(uint _0023_003DzurKrLc0_003D, double[] _0023_003Dzl3DhHgI_003D, uint[] _0023_003DzP6ZyoXz1ZRSJ)
	{
		bool result = true;
		for (uint num = 0u; num < _0023_003DzU2_tzJQKCAuC; num++)
		{
			double num2 = (_0023_003Dzl3DhHgI_003D[num] - _0023_003Dz7E3EGPQ_003D[num]) * _0023_003Dz6VxOhgk_003D[num];
			if (num2 < 0.0)
			{
				_0023_003DzP6ZyoXz1ZRSJ[num] = 0u;
				result = false;
			}
			else if (num2 >= (double)(uint)(1 << (int)(_0023_003DzfLc_B0FQ6SSdNb85zw_003D_003D - 1)))
			{
				_0023_003DzP6ZyoXz1ZRSJ[num] = (uint)((1 << (int)(_0023_003DzfLc_B0FQ6SSdNb85zw_003D_003D - 1)) - 1);
				result = false;
			}
			else
			{
				_0023_003DzP6ZyoXz1ZRSJ[num] = Convert.ToUInt32(Math.Floor(num2));
			}
		}
		return result;
	}

	private bool _0023_003Dzk1jtIDb_4xLqOyliUA_003D_003D(double[] _0023_003Dzl3DhHgI_003D, uint[] _0023_003DzP6ZyoXz1ZRSJ)
	{
		return _0023_003Dzk1jtIDb_4xLqOyliUA_003D_003D(0u, _0023_003Dzl3DhHgI_003D, _0023_003DzP6ZyoXz1ZRSJ);
	}

	private void _0023_003DzSZoFuKnhKiHn4IDB5sBUHU0_003D(uint[] _0023_003DzP6ZyoXz1ZRSJ, double _0023_003DzXrexKjY_003D, uint[] _0023_003DzLMGP75GKdMr3, uint[] _0023_003DzOWW1TPcys1cE)
	{
		for (uint num = 0u; num < _0023_003DzU2_tzJQKCAuC; num++)
		{
			uint num2 = (uint)(_0023_003DzXrexKjY_003D * _0023_003Dz6VxOhgk_003D[num]);
			if (num2 > _0023_003DzP6ZyoXz1ZRSJ[num])
			{
				_0023_003DzLMGP75GKdMr3[num] = 0u;
			}
			else
			{
				_0023_003DzLMGP75GKdMr3[num] = Convert.ToUInt32(_0023_003DzP6ZyoXz1ZRSJ[num] - num2);
			}
			if (num2 >= (uint)(1 << (int)(_0023_003DzfLc_B0FQ6SSdNb85zw_003D_003D - 1)) || _0023_003DzP6ZyoXz1ZRSJ[num] >= (uint)((1 << (int)(_0023_003DzfLc_B0FQ6SSdNb85zw_003D_003D - 1)) - (int)num2))
			{
				_0023_003DzOWW1TPcys1cE[num] = Convert.ToUInt32((1 << (int)(_0023_003DzfLc_B0FQ6SSdNb85zw_003D_003D - 1)) - 1);
			}
			else
			{
				_0023_003DzOWW1TPcys1cE[num] = Convert.ToUInt32(_0023_003DzP6ZyoXz1ZRSJ[num] + num2);
			}
		}
	}

	private void _0023_003DzztZJemr8L1qbF69TAw_003D_003D(uint _0023_003DzfNi7d4A_003D, uint[] _0023_003Dz6l3KtIYRGdK7)
	{
		uint num = (uint)(-1 << (int)_0023_003DzfNi7d4A_003D);
		for (uint num2 = 0u; num2 < _0023_003DzU2_tzJQKCAuC; num2++)
		{
			_0023_003Dz6l3KtIYRGdK7[num2] &= num;
		}
	}

	private void _0023_003Dzvu7U6_00240VJezCkSy6Cw_003D_003D(uint _0023_003DzfNi7d4A_003D, uint _0023_003Dz25a3MYc_003D, uint[] _0023_003Dz6l3KtIYRGdK7)
	{
		uint num = (uint)(~(1 << (int)_0023_003DzfNi7d4A_003D));
		uint num2 = 0u;
		while (num2 < _0023_003DzU2_tzJQKCAuC)
		{
			uint num3 = _0023_003Dz6l3KtIYRGdK7[num2];
			_0023_003Dz6l3KtIYRGdK7[num2] = num3 & num;
			num3 = _0023_003Dz6l3KtIYRGdK7[num2];
			_0023_003Dz6l3KtIYRGdK7[num2] = num3 | ((_0023_003Dz25a3MYc_003D & 1) << (int)_0023_003DzfNi7d4A_003D);
			num2++;
			_0023_003Dz25a3MYc_003D >>= 1;
		}
	}

	private uint _0023_003DzJnHd4Nx_0024fnZX(uint[] _0023_003DzP6ZyoXz1ZRSJ, uint _0023_003DzPHMCR7eDCYO1)
	{
		uint num = (uint)(1 << Convert.ToInt32(_0023_003DzPHMCR7eDCYO1));
		uint num2 = 0u;
		for (uint num3 = 0u; num3 < _0023_003DzU2_tzJQKCAuC; num3++)
		{
			uint num4 = (_0023_003DzP6ZyoXz1ZRSJ[num3] & num) >> (int)_0023_003DzPHMCR7eDCYO1;
			num2 |= num4 << Convert.ToInt32(num3);
		}
		return num2;
	}

	private bool _0023_003Dz6xtqw4UuCNMt(uint _0023_003DzyzK8swU_003D, _0023_003Dz4rzdYKa1XuIx_Imdw_WlPSpzrHlvzPor3A_003D_003D _0023_003DzB68dg9Q_003D, double[] _0023_003Dzx9Cxl24_003D, double[] _0023_003DzfR9NQLA_003D)
	{
		bool flag = true;
		uint num = _0023_003DzyzK8swU_003D;
		for (uint num2 = 0u; num2 < _0023_003DzU2_tzJQKCAuC; num2++)
		{
			flag &= _0023_003DzB68dg9Q_003D._0023_003DzYBaDcXE_003D(num) >= _0023_003Dzx9Cxl24_003D[num2];
			num++;
		}
		if (flag)
		{
			num = _0023_003DzyzK8swU_003D;
			for (uint num2 = 0u; num2 < _0023_003DzU2_tzJQKCAuC; num2++)
			{
				flag &= _0023_003DzB68dg9Q_003D._0023_003DzYBaDcXE_003D(num) <= _0023_003DzfR9NQLA_003D[num2];
				num++;
			}
		}
		return flag;
	}

	private bool _0023_003Dzmm4YvGHJKclXg5a4FQBIQuLDFj_0024L(uint[] _0023_003DzJVPbWSWPOY3E, uint[] _0023_003Dzkxu3JwNM1hME, uint[] _0023_003Dz1g2SfN4_oQmW, uint[] _0023_003Dzu_0024OlZaXg4Q_P)
	{
		bool flag = true;
		for (uint num = 0u; num < _0023_003DzU2_tzJQKCAuC; num++)
		{
			flag &= _0023_003DzJVPbWSWPOY3E[num] <= _0023_003Dzu_0024OlZaXg4Q_P[num];
		}
		if (flag)
		{
			for (uint num = 0u; num < _0023_003DzU2_tzJQKCAuC; num++)
			{
				flag &= _0023_003Dz1g2SfN4_oQmW[num] <= _0023_003Dzkxu3JwNM1hME[num];
			}
		}
		return flag;
	}

	private bool _0023_003Dzmm4YvGHJKclXg5a4FQBIQuLDFj_0024L(uint _0023_003DzfNi7d4A_003D, uint[] _0023_003Dz7nIi6dAQvB3e, uint[] _0023_003DzLMGP75GKdMr3, uint[] _0023_003DzOWW1TPcys1cE)
	{
		int _0023_003Dz77g161c_003D = 1 << (int)_0023_003DzfNi7d4A_003D;
		uint[] array = _0023_003DzWrlwfh7FsOZcM_0024LfR64hwptEhMBFqxqluw_003D_003D._0023_003Dzp9qY37s_003D(0u, _0023_003Dz7nIi6dAQvB3e);
		_0023_003Dz2r0HNeQGzT4RUytme3ESyC2QrG3puCjuXZyTNu3nY4_0024boKdwBASbP9Q_003D._0023_003Dz1l0EiMs_003D((uint)_0023_003Dz77g161c_003D, array);
		return _0023_003Dzmm4YvGHJKclXg5a4FQBIQuLDFj_0024L(_0023_003Dz7nIi6dAQvB3e, array, _0023_003DzLMGP75GKdMr3, _0023_003DzOWW1TPcys1cE);
	}

	private bool _0023_003DzWBGlfbfLVQRj(uint[] _0023_003DzJVPbWSWPOY3E, uint[] _0023_003Dzkxu3JwNM1hME, uint[] _0023_003Dz1g2SfN4_oQmW, uint[] _0023_003Dzu_0024OlZaXg4Q_P)
	{
		bool flag = true;
		for (uint num = 0u; num < _0023_003DzU2_tzJQKCAuC; num++)
		{
			flag &= _0023_003Dz1g2SfN4_oQmW[num] <= _0023_003DzJVPbWSWPOY3E[num];
		}
		if (flag)
		{
			for (uint num = 0u; num < _0023_003DzU2_tzJQKCAuC; num++)
			{
				flag &= _0023_003Dzkxu3JwNM1hME[num] <= _0023_003Dzu_0024OlZaXg4Q_P[num];
			}
		}
		return flag;
	}

	private bool _0023_003DzWBGlfbfLVQRj(uint _0023_003DzfNi7d4A_003D, uint[] _0023_003Dz7nIi6dAQvB3e, uint[] _0023_003DzLMGP75GKdMr3, uint[] _0023_003DzOWW1TPcys1cE)
	{
		int _0023_003Dz77g161c_003D = 1 << (int)_0023_003DzfNi7d4A_003D;
		uint[] array = _0023_003DzWrlwfh7FsOZcM_0024LfR64hwptEhMBFqxqluw_003D_003D._0023_003Dzp9qY37s_003D(0u, _0023_003Dz7nIi6dAQvB3e);
		_0023_003Dz2r0HNeQGzT4RUytme3ESyC2QrG3puCjuXZyTNu3nY4_0024boKdwBASbP9Q_003D._0023_003Dz1l0EiMs_003D((uint)_0023_003Dz77g161c_003D, array);
		return _0023_003DzWBGlfbfLVQRj(_0023_003Dz7nIi6dAQvB3e, array, _0023_003DzLMGP75GKdMr3, _0023_003DzOWW1TPcys1cE);
	}

	private bool _0023_003DzWBGlfbfLVQRj(uint[] _0023_003DzLMGP75GKdMr3, uint[] _0023_003DzOWW1TPcys1cE, uint _0023_003DzfNi7d4A_003D, uint[] _0023_003Dz7nIi6dAQvB3e)
	{
		int _0023_003Dz77g161c_003D = 1 << (int)_0023_003DzfNi7d4A_003D;
		uint[] array = _0023_003DzWrlwfh7FsOZcM_0024LfR64hwptEhMBFqxqluw_003D_003D._0023_003Dzp9qY37s_003D(0u, _0023_003Dz7nIi6dAQvB3e);
		_0023_003Dz2r0HNeQGzT4RUytme3ESyC2QrG3puCjuXZyTNu3nY4_0024boKdwBASbP9Q_003D._0023_003Dz1l0EiMs_003D((uint)_0023_003Dz77g161c_003D, array);
		return _0023_003DzWBGlfbfLVQRj(_0023_003DzLMGP75GKdMr3, _0023_003DzOWW1TPcys1cE, _0023_003Dz7nIi6dAQvB3e, array);
	}

	private void _0023_003Dz8lcXafU_0024Nky7(uint[] _0023_003DzP6ZyoXz1ZRSJ, ref uint _0023_003DzTSeNR8Q_003D, ref uint _0023_003DzfNi7d4A_003D, ref uint _0023_003Dzalvl9z8_003D)
	{
		uint _0023_003DzMlCq3wk_003D = 0u;
		_0023_003Dzalvl9z8_003D = _0023_003DzTSeNR8Q_003D;
		while (!_0023_003DzrP8KSXf4btlx(_0023_003DzTSeNR8Q_003D, ref _0023_003DzMlCq3wk_003D))
		{
			_0023_003DzfNi7d4A_003D--;
			uint num = _0023_003DzJnHd4Nx_0024fnZX(_0023_003DzP6ZyoXz1ZRSJ, _0023_003DzfNi7d4A_003D);
			_0023_003Dzalvl9z8_003D = _0023_003DzTSeNR8Q_003D;
			_0023_003DzTSeNR8Q_003D = _0023_003DzNHDUvwc_003D._0023_003DzYBaDcXE_003D(_0023_003DzMlCq3wk_003D + num);
		}
	}

	private void _0023_003Dz8lcXafU_0024Nky7(uint[] _0023_003DzP6ZyoXz1ZRSJ, ref uint _0023_003DzTSeNR8Q_003D, ref uint _0023_003DzfNi7d4A_003D, ref uint _0023_003Dz25a3MYc_003D, uint[] _0023_003Dz6l3KtIYRGdK7, ref uint _0023_003Dzalvl9z8_003D)
	{
		uint _0023_003DzMlCq3wk_003D = 0u;
		_0023_003Dzalvl9z8_003D = _0023_003DzTSeNR8Q_003D;
		while (!_0023_003DzrP8KSXf4btlx(_0023_003DzTSeNR8Q_003D, ref _0023_003DzMlCq3wk_003D))
		{
			_0023_003DzfNi7d4A_003D--;
			_0023_003Dz25a3MYc_003D = _0023_003DzJnHd4Nx_0024fnZX(_0023_003DzP6ZyoXz1ZRSJ, _0023_003DzfNi7d4A_003D);
			_0023_003Dzvu7U6_00240VJezCkSy6Cw_003D_003D(_0023_003DzfNi7d4A_003D, _0023_003Dz25a3MYc_003D, _0023_003Dz6l3KtIYRGdK7);
			_0023_003Dzalvl9z8_003D = _0023_003DzTSeNR8Q_003D;
			_0023_003DzTSeNR8Q_003D = Convert.ToUInt32(_0023_003DzNHDUvwc_003D._0023_003DzYBaDcXE_003D(_0023_003DzMlCq3wk_003D + _0023_003Dz25a3MYc_003D));
		}
	}

	private void _0023_003DzODVrRo_XTu5d(uint[] _0023_003DzLMGP75GKdMr3, uint[] _0023_003DzOWW1TPcys1cE, ref uint _0023_003DzTSeNR8Q_003D, ref uint _0023_003DzfNi7d4A_003D, ref uint _0023_003Dz25a3MYc_003D, uint[] _0023_003Dz6l3KtIYRGdK7)
	{
		uint num = 0u;
		uint num2 = _0023_003DzfLc_B0FQ6SSdNb85zw_003D_003D - 1 - 1;
		uint _0023_003DzMlCq3wk_003D = 0u;
		_0023_003DzTSeNR8Q_003D = Convert.ToUInt32(Convert.ToInt32(1u) << Convert.ToInt32(_0023_003DzU2_tzJQKCAuC));
		_0023_003DzfNi7d4A_003D = _0023_003DzfLc_B0FQ6SSdNb85zw_003D_003D - 1;
		_0023_003Dz25a3MYc_003D = 0u;
		_0023_003DzWrlwfh7FsOZcM_0024LfR64hwptEhMBFqxqluw_003D_003D._0023_003Dzo6KAXJQ_003D(_0023_003Dz6l3KtIYRGdK7, 0u);
		for (uint num3 = 0u; num3 < _0023_003DzU2_tzJQKCAuC; num3++)
		{
			num |= _0023_003DzLMGP75GKdMr3[num3] ^ _0023_003DzOWW1TPcys1cE[num3];
		}
		while (num2 != 0 && num >> (int)num2 == 0)
		{
			num2--;
		}
		num2++;
		while (_0023_003DzfNi7d4A_003D > num2 && !_0023_003DzrP8KSXf4btlx(_0023_003DzTSeNR8Q_003D, ref _0023_003DzMlCq3wk_003D))
		{
			_0023_003DzfNi7d4A_003D--;
			_0023_003Dz25a3MYc_003D = _0023_003DzJnHd4Nx_0024fnZX(_0023_003DzLMGP75GKdMr3, _0023_003DzfNi7d4A_003D);
			_0023_003Dzvu7U6_00240VJezCkSy6Cw_003D_003D(_0023_003DzfNi7d4A_003D, _0023_003Dz25a3MYc_003D, _0023_003Dz6l3KtIYRGdK7);
			_0023_003DzTSeNR8Q_003D = _0023_003DzNHDUvwc_003D._0023_003DzYBaDcXE_003D(_0023_003DzMlCq3wk_003D + _0023_003Dz25a3MYc_003D);
		}
	}

	private bool _0023_003DzMXXhrqmEHcwi(uint _0023_003DzTSeNR8Q_003D, uint _0023_003DzfNi7d4A_003D, uint _0023_003DzBpUNCVk_003D)
	{
		uint[] _0023_003DzP6ZyoXz1ZRSJ = new uint[_0023_003DzU2_tzJQKCAuC];
		uint _0023_003Dzalvl9z8_003D = 0u;
		if (!_0023_003Dzk1jtIDb_4xLqOyliUA_003D_003D(_0023_003DzhqrRQ_0024w_003D._0023_003DzYlRpapy_b5uM(_0023_003DzBpUNCVk_003D), _0023_003DzhqrRQ_0024w_003D, _0023_003DzP6ZyoXz1ZRSJ))
		{
			return false;
		}
		_0023_003Dz8lcXafU_0024Nky7(_0023_003DzP6ZyoXz1ZRSJ, ref _0023_003DzTSeNR8Q_003D, ref _0023_003DzfNi7d4A_003D, ref _0023_003Dzalvl9z8_003D);
		if (!_0023_003DzMj8qtldEJMoE(_0023_003DzTSeNR8Q_003D, _0023_003DzBpUNCVk_003D))
		{
			return _0023_003DzoKRYOI_W1tIK(_0023_003DzTSeNR8Q_003D, _0023_003DzfNi7d4A_003D, _0023_003DzBpUNCVk_003D);
		}
		return true;
	}

	private bool _0023_003DzDOP4yKuIt7HH(uint _0023_003DzTSeNR8Q_003D, uint _0023_003DzfNi7d4A_003D, uint _0023_003DzBpUNCVk_003D)
	{
		uint[] _0023_003DzP6ZyoXz1ZRSJ = new uint[_0023_003DzU2_tzJQKCAuC];
		uint _0023_003Dzalvl9z8_003D = 0u;
		if (!_0023_003Dzk1jtIDb_4xLqOyliUA_003D_003D(_0023_003DzhqrRQ_0024w_003D._0023_003DzYlRpapy_b5uM(_0023_003DzBpUNCVk_003D), _0023_003DzhqrRQ_0024w_003D, _0023_003DzP6ZyoXz1ZRSJ))
		{
			return false;
		}
		_0023_003Dz8lcXafU_0024Nky7(_0023_003DzP6ZyoXz1ZRSJ, ref _0023_003DzTSeNR8Q_003D, ref _0023_003DzfNi7d4A_003D, ref _0023_003Dzalvl9z8_003D);
		bool flag = _0023_003DzDOP4yKuIt7HH(_0023_003DzTSeNR8Q_003D, _0023_003DzBpUNCVk_003D);
		if (!flag || !_0023_003DzR3rGoOC2YQAzBMjVBQ_003D_003D(_0023_003DzTSeNR8Q_003D))
		{
			return flag;
		}
		uint num = (uint)(1 << Convert.ToInt32(_0023_003DzU2_tzJQKCAuC));
		while (_0023_003DzNPOSZFiDC_eEDhA0og_003D_003D(_0023_003Dzalvl9z8_003D) && (_0023_003DzTSeNR8Q_003D != num || _0023_003Dzalvl9z8_003D != num))
		{
			_0023_003DzoC4UzmP76zWw(_0023_003Dzalvl9z8_003D);
			_0023_003DzTSeNR8Q_003D = num;
			_0023_003DzfNi7d4A_003D = Convert.ToUInt32(_0023_003DzfLc_B0FQ6SSdNb85zw_003D_003D - 1);
			_0023_003Dz8lcXafU_0024Nky7(_0023_003DzP6ZyoXz1ZRSJ, ref _0023_003DzTSeNR8Q_003D, ref _0023_003DzfNi7d4A_003D, ref _0023_003Dzalvl9z8_003D);
		}
		return true;
	}

	private uint _0023_003DzePxLYZ93niBtqDPkjwpwEks_003D(double[] _0023_003Dzis4t_0024iE_003D, double[] _0023_003DzG4OU504_003D, uint[] _0023_003DzLMGP75GKdMr3, uint[] _0023_003DzOWW1TPcys1cE, uint _0023_003DzOkHnHgY_003D, _0023_003Dz3GjzoP0yRzXuryLde64bDE8ETLkdYg_0024_8zq_0024JZI_003D _0023_003DzprTPZfc_003D, _0023_003DziKUZqG3nRQL0meMhiy_0024F1oWAZTcHFWcUug_003D_003D _0023_003DzV_0024Ui4m7SpXBg)
	{
		uint num = Convert.ToUInt32((uint)(~(-1 << Convert.ToInt32(_0023_003DzU2_tzJQKCAuC))));
		uint[] array = new uint[_0023_003DzU2_tzJQKCAuC];
		uint _0023_003DzTSeNR8Q_003D = 0u;
		uint _0023_003DzfNi7d4A_003D = 0u;
		uint _0023_003Dz25a3MYc_003D = 0u;
		uint[] array2 = _0023_003DzJA4rUbs_003D._0023_003DzyPJRo5ax3Iiq_0024SVtgA_003D_003D(Convert.ToUInt32(2 * _0023_003DzfLc_B0FQ6SSdNb85zw_003D_003D * (Convert.ToInt32(1u) << Convert.ToInt32(_0023_003DzU2_tzJQKCAuC))));
		uint num2 = 0u;
		_0023_003DzODVrRo_XTu5d(_0023_003DzLMGP75GKdMr3, _0023_003DzOWW1TPcys1cE, ref _0023_003DzTSeNR8Q_003D, ref _0023_003DzfNi7d4A_003D, ref _0023_003Dz25a3MYc_003D, array);
		array2[num2] = (_0023_003DzfNi7d4A_003D << Convert.ToInt32(_0023_003DzU2_tzJQKCAuC)) + _0023_003Dz25a3MYc_003D;
		num2++;
		array2[num2] = _0023_003DzTSeNR8Q_003D;
		num2++;
		while (num2 != 0)
		{
			num2--;
			_0023_003DzTSeNR8Q_003D = array2[num2];
			num2--;
			uint num3 = array2[num2];
			_0023_003Dz25a3MYc_003D = num3 & num;
			_0023_003DzfNi7d4A_003D = num3 >> Convert.ToInt32(_0023_003DzU2_tzJQKCAuC);
			uint _0023_003DzMlCq3wk_003D = _0023_003DzNHDUvwc_003D._0023_003DzYlRpapy_b5uM(_0023_003DzTSeNR8Q_003D);
			if (_0023_003DzR3rGoOC2YQAzBMjVBQ_003D_003D(_0023_003DzMlCq3wk_003D, _0023_003DzNHDUvwc_003D))
			{
				continue;
			}
			_0023_003DzztZJemr8L1qbF69TAw_003D_003D(_0023_003DzfNi7d4A_003D, array);
			_0023_003Dzvu7U6_00240VJezCkSy6Cw_003D_003D(_0023_003DzfNi7d4A_003D, _0023_003Dz25a3MYc_003D, array);
			if (_0023_003DzrP8KSXf4btlx(_0023_003DzMlCq3wk_003D, _0023_003DzNHDUvwc_003D))
			{
				uint _0023_003DzrKoFmJY_003D = 0u;
				_0023_003Dzd6U3irV0D_00247F(ref _0023_003DzMlCq3wk_003D, _0023_003DzNHDUvwc_003D, ref _0023_003DzrKoFmJY_003D);
				_0023_003DzOkHnHgY_003D = ((!_0023_003DzWBGlfbfLVQRj(_0023_003DzfNi7d4A_003D, array, _0023_003DzLMGP75GKdMr3, _0023_003DzOWW1TPcys1cE)) ? _0023_003Dzrlyxmq_0024GILdrRvfzhwdB_1NCDnT3(_0023_003DzMlCq3wk_003D, _0023_003DzMlCq3wk_003D + _0023_003DzrKoFmJY_003D, _0023_003DzNHDUvwc_003D, 0u, _0023_003Dzis4t_0024iE_003D, 0u, _0023_003DzG4OU504_003D, _0023_003DzOkHnHgY_003D, _0023_003DzprTPZfc_003D, _0023_003DzV_0024Ui4m7SpXBg) : _0023_003DzKUaI7A5D6ZCCfHoeItFQz6btnLCen4bBcQ_003D_003D._0023_003Dz_0024hoIBOEIkIoU(_0023_003DzMlCq3wk_003D, _0023_003DzMlCq3wk_003D + _0023_003DzrKoFmJY_003D, _0023_003DzNHDUvwc_003D, _0023_003DzOkHnHgY_003D, _0023_003DzprTPZfc_003D, _0023_003DzV_0024Ui4m7SpXBg));
				continue;
			}
			num3 = --_0023_003DzfNi7d4A_003D << (int)_0023_003DzU2_tzJQKCAuC;
			_0023_003Dz25a3MYc_003D = (uint)((1 << (int)_0023_003DzU2_tzJQKCAuC) - 1);
			do
			{
				_0023_003Dzvu7U6_00240VJezCkSy6Cw_003D_003D(_0023_003DzfNi7d4A_003D, _0023_003Dz25a3MYc_003D, array);
				if (_0023_003Dzmm4YvGHJKclXg5a4FQBIQuLDFj_0024L(_0023_003DzfNi7d4A_003D, array, _0023_003DzLMGP75GKdMr3, _0023_003DzOWW1TPcys1cE))
				{
					array2[num2] = num3 + _0023_003Dz25a3MYc_003D;
					num2++;
					uint num4 = _0023_003DzNHDUvwc_003D._0023_003DzYBaDcXE_003D(_0023_003DzMlCq3wk_003D + _0023_003Dz25a3MYc_003D);
					array2[num2] = num4;
					num2++;
				}
			}
			while (_0023_003Dz25a3MYc_003D-- != 0);
		}
		return _0023_003DzOkHnHgY_003D;
	}

	private void _0023_003Dz9o10SgQGgoRyhor6oQ_003D_003D(double[] _0023_003Dzl3DhHgI_003D, ref double _0023_003DzKjjcAoU_003D, ref uint _0023_003DzpGjKR04_003D, uint[] _0023_003DzP6ZyoXz1ZRSJ, uint[] _0023_003DzLMGP75GKdMr3, uint[] _0023_003DzOWW1TPcys1cE, uint _0023_003DzTSeNR8Q_003D, uint _0023_003DzfNi7d4A_003D, uint _0023_003Dz25a3MYc_003D, uint[] _0023_003Dz6l3KtIYRGdK7, uint _0023_003DzMxPLMroTl4un, uint _0023_003DzZWqoAje8_0024WUO, _0023_003DziKUZqG3nRQL0meMhiy_0024F1oWAZTcHFWcUug_003D_003D _0023_003DzV_0024Ui4m7SpXBg)
	{
		uint num = (uint)(~(-1 << (int)_0023_003DzU2_tzJQKCAuC));
		uint num2 = 0u;
		uint[] array = _0023_003DzJA4rUbs_003D._0023_003DzyPJRo5ax3Iiq_0024SVtgA_003D_003D(2 * _0023_003DzfLc_B0FQ6SSdNb85zw_003D_003D * (uint)(1 << (int)_0023_003DzU2_tzJQKCAuC));
		uint num3 = 0u;
		array[num3] = (_0023_003DzfNi7d4A_003D << (int)_0023_003DzU2_tzJQKCAuC) + _0023_003Dz25a3MYc_003D;
		num3++;
		array[num3] = _0023_003DzTSeNR8Q_003D;
		num3++;
		while (num3 != 0 && _0023_003DzKjjcAoU_003D != 0.0)
		{
			num3--;
			_0023_003DzTSeNR8Q_003D = array[num3];
			num3--;
			uint num4 = array[num3];
			if (_0023_003DzTSeNR8Q_003D == _0023_003DzMxPLMroTl4un)
			{
				continue;
			}
			_0023_003Dz25a3MYc_003D = num4 & num;
			_0023_003DzfNi7d4A_003D = num4 >> (int)_0023_003DzU2_tzJQKCAuC;
			num2 = _0023_003DzNHDUvwc_003D._0023_003DzYlRpapy_b5uM(_0023_003DzTSeNR8Q_003D);
			if (_0023_003DzR3rGoOC2YQAzBMjVBQ_003D_003D(num2, _0023_003DzNHDUvwc_003D))
			{
				continue;
			}
			_0023_003DzztZJemr8L1qbF69TAw_003D_003D(_0023_003DzfNi7d4A_003D, _0023_003Dz6l3KtIYRGdK7);
			_0023_003Dzvu7U6_00240VJezCkSy6Cw_003D_003D(_0023_003DzfNi7d4A_003D, _0023_003Dz25a3MYc_003D, _0023_003Dz6l3KtIYRGdK7);
			if (!_0023_003Dzmm4YvGHJKclXg5a4FQBIQuLDFj_0024L(_0023_003DzfNi7d4A_003D, _0023_003Dz6l3KtIYRGdK7, _0023_003DzLMGP75GKdMr3, _0023_003DzOWW1TPcys1cE))
			{
				continue;
			}
			if (_0023_003DzrP8KSXf4btlx(num2, _0023_003DzNHDUvwc_003D))
			{
				uint _0023_003DzrKoFmJY_003D = 0u;
				_0023_003Dzd6U3irV0D_00247F(ref num2, _0023_003DzNHDUvwc_003D, ref _0023_003DzrKoFmJY_003D);
				if (_0023_003Dz9o10SgQGgoRyhor6oQ_003D_003D(num2, num2 + _0023_003DzrKoFmJY_003D, _0023_003Dzl3DhHgI_003D, ref _0023_003DzKjjcAoU_003D, ref _0023_003DzpGjKR04_003D, _0023_003DzV_0024Ui4m7SpXBg))
				{
					double _0023_003DzXrexKjY_003D = Math.Sqrt(_0023_003DzKjjcAoU_003D);
					_0023_003DzSZoFuKnhKiHn4IDB5sBUHU0_003D(_0023_003DzP6ZyoXz1ZRSJ, _0023_003DzXrexKjY_003D, _0023_003DzLMGP75GKdMr3, _0023_003DzOWW1TPcys1cE);
				}
				continue;
			}
			num4 = --_0023_003DzfNi7d4A_003D << (int)_0023_003DzU2_tzJQKCAuC;
			uint num5 = (uint)((1 << (int)_0023_003DzU2_tzJQKCAuC) - 1);
			do
			{
				_0023_003Dz25a3MYc_003D = (_0023_003DzZWqoAje8_0024WUO + num5) % (uint)(1 << (int)_0023_003DzU2_tzJQKCAuC);
				array[num3] = num4 + _0023_003Dz25a3MYc_003D;
				num3++;
				array[num3] = _0023_003DzNHDUvwc_003D._0023_003DzYBaDcXE_003D(num2 + _0023_003Dz25a3MYc_003D);
				num3++;
			}
			while (num5-- != 0);
		}
	}

	private void _0023_003DzmMAoCIAkvzsHYMJI4w_003D_003D(double[] _0023_003Dzl3DhHgI_003D, ref double _0023_003DzKjjcAoU_003D, ref uint _0023_003DzpGjKR04_003D, uint[] _0023_003DzP6ZyoXz1ZRSJ, ref uint[] _0023_003DzLMGP75GKdMr3, ref uint[] _0023_003DzOWW1TPcys1cE, ref uint _0023_003DzTSeNR8Q_003D, ref uint _0023_003DzfNi7d4A_003D, ref uint _0023_003Dz25a3MYc_003D, _0023_003DziKUZqG3nRQL0meMhiy_0024F1oWAZTcHFWcUug_003D_003D _0023_003DzV_0024Ui4m7SpXBg)
	{
		uint[] array = new uint[_0023_003DzU2_tzJQKCAuC];
		uint _0023_003DzrKoFmJY_003D = 0u;
		uint _0023_003DzMlCq3wk_003D = 0u;
		uint num = (_0023_003DzpGjKR04_003D = uint.MaxValue);
		_0023_003Dz25a3MYc_003D = 0u;
		_0023_003DzWrlwfh7FsOZcM_0024LfR64hwptEhMBFqxqluw_003D_003D._0023_003Dzo6KAXJQ_003D(_0023_003DzLMGP75GKdMr3, 0u);
		_0023_003DzWrlwfh7FsOZcM_0024LfR64hwptEhMBFqxqluw_003D_003D._0023_003Dzo6KAXJQ_003D(_0023_003DzOWW1TPcys1cE, (uint)((1 << (int)(_0023_003DzfLc_B0FQ6SSdNb85zw_003D_003D - 1)) - 1));
		uint _0023_003Dzalvl9z8_003D = (_0023_003DzTSeNR8Q_003D = (uint)(1 << (int)_0023_003DzU2_tzJQKCAuC));
		_0023_003DzfNi7d4A_003D = _0023_003DzfLc_B0FQ6SSdNb85zw_003D_003D - 1;
		_0023_003DzWrlwfh7FsOZcM_0024LfR64hwptEhMBFqxqluw_003D_003D._0023_003Dzo6KAXJQ_003D(array, 0u);
		_0023_003Dz8lcXafU_0024Nky7(_0023_003DzP6ZyoXz1ZRSJ, ref _0023_003DzTSeNR8Q_003D, ref _0023_003DzfNi7d4A_003D, ref _0023_003Dz25a3MYc_003D, array, ref _0023_003Dzalvl9z8_003D);
		if (_0023_003Dzd6U3irV0D_00247F(_0023_003DzTSeNR8Q_003D, ref _0023_003DzMlCq3wk_003D, ref _0023_003DzrKoFmJY_003D))
		{
			_0023_003Dz9o10SgQGgoRyhor6oQ_003D_003D(_0023_003DzMlCq3wk_003D, _0023_003DzMlCq3wk_003D + _0023_003DzrKoFmJY_003D, _0023_003Dzl3DhHgI_003D, ref _0023_003DzKjjcAoU_003D, ref _0023_003DzpGjKR04_003D, _0023_003DzV_0024Ui4m7SpXBg);
		}
		if (_0023_003DzpGjKR04_003D == num)
		{
			uint num2 = _0023_003Dz2r0HNeQGzT4RUytme3ESyC2QrG3puCjuXZyTNu3nY4_0024boKdwBASbP9Q_003D._0023_003DzyO3mlYHc_wH3(_0023_003Dz6VxOhgk_003D);
			uint _0023_003DzZWqoAje8_0024WUO = (uint)(_0023_003Dz25a3MYc_003D ^ (1 << (int)num2));
			if (_0023_003DzfNi7d4A_003D < _0023_003DzfLc_B0FQ6SSdNb85zw_003D_003D - 1)
			{
				_0023_003DzfNi7d4A_003D++;
			}
			_0023_003Dz25a3MYc_003D = _0023_003DzJnHd4Nx_0024fnZX(_0023_003DzP6ZyoXz1ZRSJ, _0023_003DzfNi7d4A_003D);
			_0023_003DzztZJemr8L1qbF69TAw_003D_003D(_0023_003DzfNi7d4A_003D, array);
			_0023_003Dz9o10SgQGgoRyhor6oQ_003D_003D(_0023_003Dzl3DhHgI_003D, ref _0023_003DzKjjcAoU_003D, ref _0023_003DzpGjKR04_003D, _0023_003DzP6ZyoXz1ZRSJ, _0023_003DzLMGP75GKdMr3, _0023_003DzOWW1TPcys1cE, _0023_003Dzalvl9z8_003D, _0023_003DzfNi7d4A_003D, _0023_003Dz25a3MYc_003D, array, _0023_003DzTSeNR8Q_003D, _0023_003DzZWqoAje8_0024WUO, _0023_003DzV_0024Ui4m7SpXBg);
			_0023_003DzTSeNR8Q_003D = _0023_003Dzalvl9z8_003D;
			if (_0023_003DzpGjKR04_003D == uint.MaxValue)
			{
				_0023_003DzTSeNR8Q_003D = (uint)(1 << (int)_0023_003DzU2_tzJQKCAuC);
				_0023_003DzfNi7d4A_003D = _0023_003DzfLc_B0FQ6SSdNb85zw_003D_003D - 1;
				_0023_003DzZWqoAje8_0024WUO = (_0023_003Dz25a3MYc_003D = 0u);
				_0023_003DzWrlwfh7FsOZcM_0024LfR64hwptEhMBFqxqluw_003D_003D._0023_003Dzo6KAXJQ_003D(array, 0u);
				_0023_003Dz9o10SgQGgoRyhor6oQ_003D_003D(_0023_003Dzl3DhHgI_003D, ref _0023_003DzKjjcAoU_003D, ref _0023_003DzpGjKR04_003D, _0023_003DzP6ZyoXz1ZRSJ, _0023_003DzLMGP75GKdMr3, _0023_003DzOWW1TPcys1cE, _0023_003DzTSeNR8Q_003D, _0023_003DzfNi7d4A_003D, _0023_003Dz25a3MYc_003D, array, _0023_003Dzalvl9z8_003D, _0023_003DzZWqoAje8_0024WUO, _0023_003DzV_0024Ui4m7SpXBg);
			}
		}
	}

	private bool _0023_003DzMj8qtldEJMoE(uint _0023_003DzTSeNR8Q_003D, uint _0023_003DzBpUNCVk_003D)
	{
		uint num = _0023_003DzNHDUvwc_003D._0023_003DzYlRpapy_b5uM(_0023_003DzTSeNR8Q_003D);
		uint num2 = _0023_003DzNHDUvwc_003D._0023_003DzYBaDcXE_003D(num);
		bool num3 = num2 < (uint)((1 << Convert.ToInt32(_0023_003DzU2_tzJQKCAuC)) - 1);
		if (num3)
		{
			_0023_003DzMdkihsQJa2bf._0023_003DzqTiQqGs_003D(_0023_003DzNHDUvwc_003D, (int)(num + 1), (int)(num + 1 + num2), _0023_003DzBpUNCVk_003D);
			num2++;
			_0023_003DzNHDUvwc_003D._0023_003DzSZ0NwQM_003D(num, num2);
			_0023_003DzNHDUvwc_003D._0023_003DzSZ0NwQM_003D(num + num2, _0023_003DzBpUNCVk_003D);
			_0023_003DzMdkihsQJa2bf._0023_003DzoQcRoMY_003D(num + 1, num + 1 + num2 - (num + 1), _0023_003DzNHDUvwc_003D);
		}
		return num3;
	}

	private bool _0023_003DzBA60zYYUQzVt(uint _0023_003DzTSeNR8Q_003D, uint _0023_003DzBpUNCVk_003D)
	{
		uint num = _0023_003DzNHDUvwc_003D._0023_003DzYlRpapy_b5uM(_0023_003DzTSeNR8Q_003D);
		uint num2 = _0023_003DzNHDUvwc_003D._0023_003DzYBaDcXE_003D(num);
		return _0023_003DzMdkihsQJa2bf._0023_003DzqTiQqGs_003D(_0023_003DzNHDUvwc_003D, (int)(num + 1), (int)(num + 1 + num2), _0023_003DzBpUNCVk_003D) != num + 1 + num2;
	}

	private bool _0023_003DzDOP4yKuIt7HH(uint _0023_003DzTSeNR8Q_003D, uint _0023_003DzBpUNCVk_003D)
	{
		uint num = _0023_003DzNHDUvwc_003D._0023_003DzYlRpapy_b5uM(_0023_003DzTSeNR8Q_003D);
		uint num2 = _0023_003DzNHDUvwc_003D._0023_003DzYBaDcXE_003D(num);
		bool num3 = _0023_003DzMdkihsQJa2bf._0023_003DzMusAlMc_003D(num + 1, num + 1 + num2, _0023_003DzNHDUvwc_003D, _0023_003DzBpUNCVk_003D) == num + num2;
		if (num3)
		{
			num2--;
			_0023_003DzNHDUvwc_003D._0023_003DzSZ0NwQM_003D(num, num2);
		}
		return num3;
	}

	private bool _0023_003DzoKRYOI_W1tIK(uint _0023_003DzTSeNR8Q_003D, uint _0023_003DzfNi7d4A_003D, uint _0023_003DzBpUNCVk_003D)
	{
		_0023_003DzNHDUvwc_003D._0023_003DzYBaDcXE_003D(_0023_003DzNHDUvwc_003D._0023_003DzYlRpapy_b5uM(_0023_003DzTSeNR8Q_003D));
		Convert.ToInt32(_0023_003DzU2_tzJQKCAuC);
		if (_0023_003DzfNi7d4A_003D == 0)
		{
			return false;
		}
		uint[] _0023_003Dz61IPlm0_003D = new uint[_0023_003DzNHDUvwc_003D._0023_003Dz14lzA48_003D()];
		uint[] array = new uint[_0023_003DzNHDUvwc_003D._0023_003Dz14lzA48_003D()];
		bool flag = true;
		for (uint num = 0u; num < (uint)(1 << Convert.ToInt32(_0023_003DzU2_tzJQKCAuC)); num++)
		{
			array[num] = _0023_003DzNHDUvwc_003D._0023_003DzyRujy0UHSSDxp3zrMg_003D_003D(_0023_003Dz61IPlm0_003D);
		}
		uint num2 = _0023_003DzNHDUvwc_003D._0023_003DzYlRpapy_b5uM(_0023_003DzTSeNR8Q_003D);
		for (uint num = 0u; num < (uint)(1 << Convert.ToInt32(_0023_003DzU2_tzJQKCAuC)); num++)
		{
			uint _0023_003DzELu0Pss_003D = array[num];
			uint num3 = _0023_003DzNHDUvwc_003D._0023_003DzYBaDcXE_003D(num2 + num);
			_0023_003DzNHDUvwc_003D._0023_003DzSZ0NwQM_003D(num2 + num, _0023_003DzELu0Pss_003D);
			array[num] = num3;
		}
		for (uint num = 1u; num < (uint)(1 << Convert.ToInt32(_0023_003DzU2_tzJQKCAuC)) && flag; num++)
		{
			flag = _0023_003DzMXXhrqmEHcwi(_0023_003DzTSeNR8Q_003D, _0023_003DzfNi7d4A_003D, array[num]);
		}
		return flag && _0023_003DzMXXhrqmEHcwi(_0023_003DzTSeNR8Q_003D, _0023_003DzfNi7d4A_003D, _0023_003DzBpUNCVk_003D);
	}

	private void _0023_003DzoC4UzmP76zWw(uint _0023_003DzTSeNR8Q_003D)
	{
		uint num = _0023_003DzNHDUvwc_003D._0023_003DzYlRpapy_b5uM(_0023_003DzTSeNR8Q_003D);
		uint num2 = (uint)(1 << Convert.ToInt32(_0023_003DzU2_tzJQKCAuC));
		uint num3 = 0u;
		while (num3 < num2)
		{
			_0023_003DzNHDUvwc_003D._0023_003DzYBaDcXE_003D(num);
			_0023_003DzNHDUvwc_003D._0023_003DzMusAlMc_003D(_0023_003DzNHDUvwc_003D._0023_003DzYBaDcXE_003D(num));
			_0023_003DzNHDUvwc_003D._0023_003DzSZ0NwQM_003D(num, 0u);
			num3++;
			num++;
		}
	}

	private bool _0023_003Dzd6U3irV0D_00247F(uint _0023_003DzTSeNR8Q_003D, ref uint _0023_003DzMlCq3wk_003D, ref uint _0023_003DzrKoFmJY_003D)
	{
		_0023_003DzMlCq3wk_003D = _0023_003DzNHDUvwc_003D._0023_003DzYlRpapy_b5uM(_0023_003DzTSeNR8Q_003D);
		return _0023_003Dzd6U3irV0D_00247F(ref _0023_003DzMlCq3wk_003D, _0023_003DzNHDUvwc_003D, ref _0023_003DzrKoFmJY_003D);
	}

	private bool _0023_003Dzd6U3irV0D_00247F(ref uint _0023_003DzMlCq3wk_003D, _0023_003DzflOFEhjyfgUAHLUM9yF1zxIDb5aaQRJ4MLHrF64_003D _0023_003DzpF1pkP4_003D, ref uint _0023_003DzrKoFmJY_003D)
	{
		_0023_003DzrKoFmJY_003D = 0u;
		uint num = _0023_003DzpF1pkP4_003D._0023_003DzYBaDcXE_003D(_0023_003DzMlCq3wk_003D);
		if (num < 8)
		{
			_0023_003DzrKoFmJY_003D = num;
			_0023_003DzMlCq3wk_003D++;
		}
		return _0023_003DzrKoFmJY_003D != 0;
	}

	private uint _0023_003Dzrlyxmq_0024GILdrRvfzhwdB_1NCDnT3(uint _0023_003DzRVoDPs0_003D, uint _0023_003DzDr1MUxo_003D, _0023_003DzflOFEhjyfgUAHLUM9yF1zxIDb5aaQRJ4MLHrF64_003D _0023_003DzpF1pkP4_003D, uint _0023_003DzGioKXNztqFyV, double[] _0023_003Dzis4t_0024iE_003D, uint _0023_003DzheDHP9qv_2fT, double[] _0023_003DzG4OU504_003D, uint _0023_003DzOkHnHgY_003D, _0023_003Dz3GjzoP0yRzXuryLde64bDE8ETLkdYg_0024_8zq_0024JZI_003D _0023_003DzprTPZfc_003D, _0023_003DziKUZqG3nRQL0meMhiy_0024F1oWAZTcHFWcUug_003D_003D _0023_003DzV_0024Ui4m7SpXBg)
	{
		while (_0023_003DzRVoDPs0_003D < _0023_003DzDr1MUxo_003D)
		{
			uint num = _0023_003DzpF1pkP4_003D._0023_003DzYBaDcXE_003D(_0023_003DzRVoDPs0_003D);
			_0023_003DzRVoDPs0_003D++;
			if (_0023_003Dz6xtqw4UuCNMt(_0023_003DzhqrRQ_0024w_003D._0023_003DzYlRpapy_b5uM(num), _0023_003DzhqrRQ_0024w_003D, _0023_003Dzis4t_0024iE_003D, _0023_003DzG4OU504_003D) && _0023_003DzV_0024Ui4m7SpXBg._0023_003Dz7_0024mrUE1_JLUdoHA1gg_003D_003D(num))
			{
				_0023_003DzprTPZfc_003D._0023_003DzccHNBKidQXxY(num);
				_0023_003DzOkHnHgY_003D++;
			}
		}
		return _0023_003DzOkHnHgY_003D;
	}

	private bool _0023_003Dz9o10SgQGgoRyhor6oQ_003D_003D(uint _0023_003DzRVoDPs0_003D, uint _0023_003DzDr1MUxo_003D, double[] _0023_003Dzl3DhHgI_003D, ref double _0023_003DzKjjcAoU_003D, ref uint _0023_003DzpGjKR04_003D, _0023_003DziKUZqG3nRQL0meMhiy_0024F1oWAZTcHFWcUug_003D_003D _0023_003DzV_0024Ui4m7SpXBg)
	{
		double num = _0023_003DzKjjcAoU_003D;
		while (_0023_003DzRVoDPs0_003D < _0023_003DzDr1MUxo_003D)
		{
			uint num2 = Convert.ToUInt32(_0023_003DzNHDUvwc_003D._0023_003DzYBaDcXE_003D(_0023_003DzRVoDPs0_003D));
			_0023_003DzRVoDPs0_003D++;
			double num3 = _0023_003DzKjjcAoU_003D;
			if (num2 != _0023_003DzpGjKR04_003D && _0023_003DzV_0024Ui4m7SpXBg._0023_003Dz7_0024mrUE1_JLUdoHA1gg_003D_003D(num2))
			{
				num3 = _0023_003Dz6lGncTjN6Lvoy8Z4ebbI5fd5YT7n3USMLZ8_8WVYRfPlDeGSxIXlVlFDcAOn._0023_003DzoUA4_8BuLamYFS_0024srEJCPTg_003D(_0023_003DzhqrRQ_0024w_003D._0023_003DzFDJdA7A_003D(num2), _0023_003Dzl3DhHgI_003D);
			}
			if (num3 < _0023_003DzKjjcAoU_003D)
			{
				_0023_003DzKjjcAoU_003D = num3;
				_0023_003DzpGjKR04_003D = num2;
			}
		}
		return _0023_003DzKjjcAoU_003D < num;
	}

	private bool _0023_003DzrP8KSXf4btlx(uint _0023_003DzTSeNR8Q_003D, ref uint _0023_003DzMlCq3wk_003D)
	{
		_0023_003DzMlCq3wk_003D = _0023_003DzNHDUvwc_003D._0023_003DzYlRpapy_b5uM(_0023_003DzTSeNR8Q_003D);
		return _0023_003DzNHDUvwc_003D._0023_003DzYBaDcXE_003D(_0023_003DzMlCq3wk_003D) < (uint)(1 << Convert.ToInt32(_0023_003DzU2_tzJQKCAuC));
	}

	private bool _0023_003DzrP8KSXf4btlx(uint _0023_003DzTSeNR8Q_003D)
	{
		return _0023_003DzNHDUvwc_003D._0023_003Dz7_0024mrUE1_JLUdoHA1gg_003D_003D(0u, _0023_003DzTSeNR8Q_003D) < (uint)(1 << Convert.ToInt32(_0023_003DzU2_tzJQKCAuC));
	}

	private bool _0023_003DzrP8KSXf4btlx(uint _0023_003DzMlCq3wk_003D, _0023_003Dz5C5TPYnyp4Ol5tMpkkk8NyF7uKTui_0024PpCw_003D_003D _0023_003DzNDQ_E88_003D)
	{
		return _0023_003DzNDQ_E88_003D._0023_003DzYBaDcXE_003D(_0023_003DzMlCq3wk_003D) < (uint)(1 << Convert.ToInt32(_0023_003DzU2_tzJQKCAuC));
	}

	private bool _0023_003DzR3rGoOC2YQAzBMjVBQ_003D_003D(uint _0023_003DzTSeNR8Q_003D)
	{
		uint _0023_003Dz437_00244ak_003D = _0023_003DzNHDUvwc_003D._0023_003DzYlRpapy_b5uM(_0023_003DzTSeNR8Q_003D);
		return _0023_003DzNHDUvwc_003D._0023_003DzYBaDcXE_003D(_0023_003Dz437_00244ak_003D) == 0;
	}

	private bool _0023_003DzR3rGoOC2YQAzBMjVBQ_003D_003D(uint _0023_003DzMlCq3wk_003D, _0023_003Dz5C5TPYnyp4Ol5tMpkkk8NyF7uKTui_0024PpCw_003D_003D _0023_003DzNDQ_E88_003D)
	{
		return _0023_003DzNDQ_E88_003D._0023_003DzYBaDcXE_003D(_0023_003DzMlCq3wk_003D) == 0;
	}

	private bool _0023_003DzNPOSZFiDC_eEDhA0og_003D_003D(uint _0023_003DzTSeNR8Q_003D)
	{
		uint num = _0023_003DzNHDUvwc_003D._0023_003DzYlRpapy_b5uM(_0023_003DzTSeNR8Q_003D);
		bool flag = true;
		uint num2 = (uint)(1 << Convert.ToInt32(_0023_003DzU2_tzJQKCAuC));
		if (_0023_003DzNHDUvwc_003D._0023_003DzYBaDcXE_003D(num) >= num2)
		{
			uint num3 = 0u;
			while (num3 < num2 && flag)
			{
				flag = _0023_003DzR3rGoOC2YQAzBMjVBQ_003D_003D(_0023_003DzNHDUvwc_003D._0023_003DzYBaDcXE_003D(num));
				num3++;
				num++;
			}
		}
		else
		{
			flag = _0023_003DzNHDUvwc_003D._0023_003DzYBaDcXE_003D(num) == 0;
		}
		return flag;
	}
}
