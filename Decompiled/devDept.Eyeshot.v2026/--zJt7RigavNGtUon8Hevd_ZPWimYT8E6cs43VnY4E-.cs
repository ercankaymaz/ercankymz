internal sealed class _0023_003DzJt7RigavNGtUon8Hevd_ZPWimYT8E6cs43VnY4E_003D
{
	private _0023_003Dz4rzdYKa1XuIx_Imdw_WlPSpzrHlvzPor3A_003D_003D _0023_003DzhqrRQ_0024w_003D;

	private uint _0023_003Dz5IbFCrs_003D;

	private _0023_003Dz5C5TPYnyp4Ol5tMpkkk8NyF7uKTui_0024PpCw_003D_003D _0023_003DzNHDUvwc_003D = new _0023_003Dz5C5TPYnyp4Ol5tMpkkk8NyF7uKTui_0024PpCw_003D_003D(3u);

	public _0023_003DzJt7RigavNGtUon8Hevd_ZPWimYT8E6cs43VnY4E_003D(_0023_003Dz4rzdYKa1XuIx_Imdw_WlPSpzrHlvzPor3A_003D_003D _0023_003Dzl3DhHgI_003D, uint _0023_003Dz14lzA48_003D)
	{
		_0023_003DzhqrRQ_0024w_003D = _0023_003Dzl3DhHgI_003D;
		_0023_003Dz5IbFCrs_003D = _0023_003Dz14lzA48_003D;
	}

	public _0023_003Dz4rzdYKa1XuIx_Imdw_WlPSpzrHlvzPor3A_003D_003D _0023_003DzI_00248m9Go_003D()
	{
		return _0023_003DzhqrRQ_0024w_003D;
	}

	public bool _0023_003Dze6U2VUyBaRq6(uint _0023_003DzoMNiNRw_003D)
	{
		return _0023_003DzNHDUvwc_003D._0023_003Dze6U2VUyBaRq6(3u, _0023_003DzoMNiNRw_003D);
	}

	public uint _0023_003Dz14lzA48_003D()
	{
		return _0023_003DzNHDUvwc_003D._0023_003DzmVsXTy4_003D();
	}

	public bool _0023_003DzqRJnPHc_003D()
	{
		return _0023_003DzNHDUvwc_003D._0023_003DzmVsXTy4_003D() == 0;
	}

	public void _0023_003DzttBXI_0024c_003D()
	{
		_0023_003DzNHDUvwc_003D._0023_003DzttBXI_0024c_003D();
	}

	public bool _0023_003DzSZ0NwQM_003D(uint _0023_003DzGLwmegk_003D)
	{
		if (_0023_003DzhqrRQ_0024w_003D == null || _0023_003DzGLwmegk_003D >= _0023_003DzhqrRQ_0024w_003D._0023_003DzmVsXTy4_003D())
		{
			return false;
		}
		uint num = _0023_003DzhqrRQ_0024w_003D._0023_003DzqeqS8vc_003D();
		uint num2 = _0023_003DzhqrRQ_0024w_003D._0023_003DzELu0Pss_003D();
		uint num3 = num2 + _0023_003DzGLwmegk_003D * num;
		uint num4 = _0023_003DzNHDUvwc_003D._0023_003DzyRujy0UHSSDxp3zrMg_003D_003D(new uint[3] { _0023_003DzGLwmegk_003D, 4294967295u, 4294967295u });
		uint num5 = _0023_003DzNHDUvwc_003D._0023_003DzELu0Pss_003D();
		uint num6 = 0u;
		uint num7 = 0u;
		uint num8 = uint.MaxValue;
		uint num9 = uint.MaxValue;
		bool flag = true;
		while (flag && num7 < num4)
		{
			num8 = num7;
			uint num10 = num5 + 3 * num7;
			uint num11 = _0023_003DzNHDUvwc_003D._0023_003DzYBaDcXE_003D(num10);
			flag = num11 != _0023_003DzGLwmegk_003D;
			uint num12 = num2 + num11 * num;
			num9 = ((_0023_003DzhqrRQ_0024w_003D._0023_003DzYBaDcXE_003D(num3 + num6) < _0023_003DzhqrRQ_0024w_003D._0023_003DzYBaDcXE_003D(num12 + num6)) ? 1u : 2u);
			num7 = _0023_003DzNHDUvwc_003D._0023_003DzYBaDcXE_003D(num10 + num9);
			num6 = (num6 + 1) % _0023_003Dz5IbFCrs_003D;
		}
		if (flag && num8 != uint.MaxValue)
		{
			_0023_003DzNHDUvwc_003D._0023_003DzQmya_mnFMQ1t(num9, num8, num4);
		}
		if (!flag)
		{
			_0023_003DzNHDUvwc_003D._0023_003DzMusAlMc_003D(num4);
		}
		return flag;
	}

	public uint _0023_003DzSZ0NwQM_003D(uint _0023_003DzRVoDPs0_003D, uint _0023_003DzDr1MUxo_003D, _0023_003Dz3GjzoP0yRzXuryLde64bDE8ETLkdYg_0024_8zq_0024JZI_003D _0023_003DzpF1pkP4_003D)
	{
		uint num = 0u;
		while (_0023_003DzRVoDPs0_003D != _0023_003DzDr1MUxo_003D)
		{
			if (_0023_003DzSZ0NwQM_003D(_0023_003DzpF1pkP4_003D._0023_003DzYBaDcXE_003D(_0023_003DzRVoDPs0_003D)))
			{
				num++;
			}
			_0023_003DzRVoDPs0_003D++;
		}
		return num;
	}

	public uint _0023_003DzOdhQ_0024ZnIN0kiqVqwKg_003D_003D<Predicate>(uint _0023_003DzBpUNCVk_003D, double _0023_003DzKjjcAoU_003D, Predicate _0023_003DzV_0024Ui4m7SpXBg)
	{
		double[] _0023_003DzvXOLtKg_003D = new double[_0023_003Dz5IbFCrs_003D];
		if (_0023_003DzhqrRQ_0024w_003D != null && _0023_003DzBpUNCVk_003D < _0023_003DzhqrRQ_0024w_003D._0023_003DzmVsXTy4_003D())
		{
			_0023_003Dz6lGncTjN6Lvoy8Z4ebbI5fd5YT7n3USMLZ8_8WVYRfPlDeGSxIXlVlFDcAOn._0023_003Dzl_0024kBRC0_003D(_0023_003DzhqrRQ_0024w_003D._0023_003DzFDJdA7A_003D(_0023_003DzBpUNCVk_003D), _0023_003DzvXOLtKg_003D);
		}
		return uint.MaxValue;
	}

	public uint _0023_003Dzy1TlDoTFmwGw(uint _0023_003DzBpUNCVk_003D)
	{
		return _0023_003DzOdhQ_0024ZnIN0kiqVqwKg_003D_003D(_0023_003DzBpUNCVk_003D, double.MaxValue, new _0023_003DziKUZqG3nRQL0meMhiy_0024F1oWAZTcHFWcUug_003D_003D());
	}

	public void _0023_003Dz5GTlo5Dge2LL8a0OYQ_003D_003D(double[] _0023_003DzmjvkWumF8WBQ, double[] _0023_003DzHBgZyg85oN4_0024, uint _0023_003DzV_0024Ui4m7SpXBg, _0023_003Dz3GjzoP0yRzXuryLde64bDE8ETLkdYg_0024_8zq_0024JZI_003D _0023_003DzOkHnHgY_003D)
	{
		if (!_0023_003DzqRJnPHc_003D())
		{
			double[] array = new double[2 * _0023_003Dz5IbFCrs_003D];
			_0023_003Dz6lGncTjN6Lvoy8Z4ebbI5fd5YT7n3USMLZ8_8WVYRfPlDeGSxIXlVlFDcAOn._0023_003DzrR7yhtbUeWb_0024(0u, _0023_003DzmjvkWumF8WBQ, 0u, array, _0023_003Dz5IbFCrs_003D);
			_0023_003Dz6lGncTjN6Lvoy8Z4ebbI5fd5YT7n3USMLZ8_8WVYRfPlDeGSxIXlVlFDcAOn._0023_003DzrR7yhtbUeWb_0024(0u, _0023_003DzHBgZyg85oN4_0024, _0023_003Dz5IbFCrs_003D, array, _0023_003Dz5IbFCrs_003D);
			_0023_003DzXKxh05dZ6o7L(array, 0u, 0u, 0u, _0023_003DzV_0024Ui4m7SpXBg, _0023_003DzOkHnHgY_003D);
		}
	}

	private void _0023_003DzXKxh05dZ6o7L(double[] _0023_003DzgnSpxqOwmrgY, uint _0023_003DzoIGIECmz68_Q, uint _0023_003DzTSeNR8Q_003D, uint _0023_003DzxuJqjrs_003D, uint _0023_003DzV_0024Ui4m7SpXBg, _0023_003Dz3GjzoP0yRzXuryLde64bDE8ETLkdYg_0024_8zq_0024JZI_003D _0023_003DzOkHnHgY_003D)
	{
		uint num = _0023_003DzNHDUvwc_003D._0023_003DzYlRpapy_b5uM(_0023_003DzTSeNR8Q_003D);
		uint num2 = _0023_003DzNHDUvwc_003D._0023_003DzYBaDcXE_003D(num);
		uint num3 = _0023_003DzhqrRQ_0024w_003D._0023_003DzYlRpapy_b5uM(num2);
		double num4 = _0023_003DzgnSpxqOwmrgY[_0023_003DzoIGIECmz68_Q + _0023_003DzxuJqjrs_003D];
		double num5 = _0023_003DzgnSpxqOwmrgY[_0023_003DzoIGIECmz68_Q + _0023_003DzxuJqjrs_003D + _0023_003Dz5IbFCrs_003D];
		bool flag = _0023_003DzhqrRQ_0024w_003D._0023_003DzYBaDcXE_003D(num3 + _0023_003DzxuJqjrs_003D) >= num4;
		bool num6 = _0023_003DzhqrRQ_0024w_003D._0023_003DzYBaDcXE_003D(num3 + _0023_003DzxuJqjrs_003D) <= num5;
		bool flag2 = ((_0023_003Dz5IbFCrs_003D != 2) ? _0023_003Dz3QHfi1HfmndQIrq7vm_l38W1Qvv4wd_00243APv5PbvQHGW5MjC7gA_003D_003D._0023_003DzKTrj6v0Ibvku(num3, _0023_003DzhqrRQ_0024w_003D, _0023_003DzgnSpxqOwmrgY) : _0023_003DzasllkMck0_TEyW_0024PzHK1KWoKgEzVXHD9R38O8tOoGwySBe9mYA_003D_003D._0023_003DzKTrj6v0Ibvku(num3, _0023_003DzhqrRQ_0024w_003D, _0023_003DzgnSpxqOwmrgY));
		if (num6 && flag && flag2 && _0023_003DzV_0024Ui4m7SpXBg != num2)
		{
			_0023_003DzOkHnHgY_003D._0023_003DzccHNBKidQXxY(num2);
		}
		if (flag && _0023_003DzNHDUvwc_003D._0023_003DzYBaDcXE_003D(num + 1) != uint.MaxValue)
		{
			_0023_003DzXKxh05dZ6o7L(_0023_003DzgnSpxqOwmrgY, _0023_003DzoIGIECmz68_Q, _0023_003DzNHDUvwc_003D._0023_003DzYBaDcXE_003D(num + 1), (_0023_003DzxuJqjrs_003D + 1) % _0023_003Dz5IbFCrs_003D, _0023_003DzV_0024Ui4m7SpXBg, _0023_003DzOkHnHgY_003D);
		}
		if (num6 && _0023_003DzNHDUvwc_003D._0023_003DzYBaDcXE_003D(num + 2) != uint.MaxValue)
		{
			_0023_003DzXKxh05dZ6o7L(_0023_003DzgnSpxqOwmrgY, _0023_003DzoIGIECmz68_Q, _0023_003DzNHDUvwc_003D._0023_003DzYBaDcXE_003D(num + 2), (_0023_003DzxuJqjrs_003D + 1) % _0023_003Dz5IbFCrs_003D, _0023_003DzV_0024Ui4m7SpXBg, _0023_003DzOkHnHgY_003D);
		}
	}
}
