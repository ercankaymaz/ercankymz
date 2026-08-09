internal sealed class _0023_003Dzp2nhtkXVnREMr3v3nk6Z5vw_003D
{
	public void _0023_003Dzz8DDgng_003D(int _0023_003DzpGjKR04_003D, double _0023_003Dz90BpdlQ_003D, ref double[] _0023_003Dzkyw2mdM_003D, int _0023_003Dzcg5G72corELm, int _0023_003DzPha_0024VJlONheb)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = -1 + _0023_003Dzcg5G72corELm;
		if (_0023_003DzpGjKR04_003D <= 0 || _0023_003DzPha_0024VJlONheb <= 0)
		{
			return;
		}
		if (_0023_003DzPha_0024VJlONheb != 1)
		{
			num3 = _0023_003DzpGjKR04_003D * _0023_003DzPha_0024VJlONheb;
			for (num = 1; (_0023_003DzPha_0024VJlONheb >= 0) ? (num <= num3) : (num >= num3); num += _0023_003DzPha_0024VJlONheb)
			{
				_0023_003Dzkyw2mdM_003D[num + num4] *= _0023_003Dz90BpdlQ_003D;
			}
			return;
		}
		num2 = _0023_003Dzt81xN7aa_002489vTvlbYozS6TUjvqyF._0023_003Dz4vcHOP8_003D(_0023_003DzpGjKR04_003D, 5);
		if (num2 != 0)
		{
			for (num = 1; num <= num2; num++)
			{
				_0023_003Dzkyw2mdM_003D[num + num4] *= _0023_003Dz90BpdlQ_003D;
			}
			if (_0023_003DzpGjKR04_003D < 5)
			{
				return;
			}
		}
		for (num = num2 + 1; num <= _0023_003DzpGjKR04_003D; num += 5)
		{
			_0023_003Dzkyw2mdM_003D[num + num4] *= _0023_003Dz90BpdlQ_003D;
			_0023_003Dzkyw2mdM_003D[num + 1 + num4] *= _0023_003Dz90BpdlQ_003D;
			_0023_003Dzkyw2mdM_003D[num + 2 + num4] *= _0023_003Dz90BpdlQ_003D;
			_0023_003Dzkyw2mdM_003D[num + 3 + num4] *= _0023_003Dz90BpdlQ_003D;
			_0023_003Dzkyw2mdM_003D[num + 4 + num4] *= _0023_003Dz90BpdlQ_003D;
		}
	}
}
