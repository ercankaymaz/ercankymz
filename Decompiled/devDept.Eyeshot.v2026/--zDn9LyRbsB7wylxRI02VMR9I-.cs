internal sealed class _0023_003DzDn9LyRbsB7wylxRI02VMR9I_003D
{
	public void _0023_003Dzz8DDgng_003D(int _0023_003DzpGjKR04_003D, double _0023_003Dz90BpdlQ_003D, double[] _0023_003Dzkyw2mdM_003D, int _0023_003Dzcg5G72corELm, int _0023_003DzPha_0024VJlONheb, ref double[] _0023_003DzYO5Qaho_003D, int _0023_003DzUTFqlsYh1Z94, int _0023_003DzGWhj1O1jhTmW)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = -1 + _0023_003Dzcg5G72corELm;
		int num6 = -1 + _0023_003DzUTFqlsYh1Z94;
		if (_0023_003DzpGjKR04_003D <= 0 || _0023_003Dz90BpdlQ_003D == 0.0)
		{
			return;
		}
		if (_0023_003DzPha_0024VJlONheb != 1 || _0023_003DzGWhj1O1jhTmW != 1)
		{
			num2 = 1;
			num3 = 1;
			if (_0023_003DzPha_0024VJlONheb < 0)
			{
				num2 = (-_0023_003DzpGjKR04_003D + 1) * _0023_003DzPha_0024VJlONheb + 1;
			}
			if (_0023_003DzGWhj1O1jhTmW < 0)
			{
				num3 = (-_0023_003DzpGjKR04_003D + 1) * _0023_003DzGWhj1O1jhTmW + 1;
			}
			for (num = 1; num <= _0023_003DzpGjKR04_003D; num++)
			{
				_0023_003DzYO5Qaho_003D[num3 + num6] += _0023_003Dz90BpdlQ_003D * _0023_003Dzkyw2mdM_003D[num2 + num5];
				num2 += _0023_003DzPha_0024VJlONheb;
				num3 += _0023_003DzGWhj1O1jhTmW;
			}
			return;
		}
		num4 = _0023_003Dzt81xN7aa_002489vTvlbYozS6TUjvqyF._0023_003Dz4vcHOP8_003D(_0023_003DzpGjKR04_003D, 4);
		if (num4 != 0)
		{
			for (num = 1; num <= num4; num++)
			{
				_0023_003DzYO5Qaho_003D[num + num6] += _0023_003Dz90BpdlQ_003D * _0023_003Dzkyw2mdM_003D[num + num5];
			}
			if (_0023_003DzpGjKR04_003D < 4)
			{
				return;
			}
		}
		for (num = num4 + 1; num <= _0023_003DzpGjKR04_003D; num += 4)
		{
			_0023_003DzYO5Qaho_003D[num + num6] += _0023_003Dz90BpdlQ_003D * _0023_003Dzkyw2mdM_003D[num + num5];
			_0023_003DzYO5Qaho_003D[num + 1 + num6] += _0023_003Dz90BpdlQ_003D * _0023_003Dzkyw2mdM_003D[num + 1 + num5];
			_0023_003DzYO5Qaho_003D[num + 2 + num6] += _0023_003Dz90BpdlQ_003D * _0023_003Dzkyw2mdM_003D[num + 2 + num5];
			_0023_003DzYO5Qaho_003D[num + 3 + num6] += _0023_003Dz90BpdlQ_003D * _0023_003Dzkyw2mdM_003D[num + 3 + num5];
		}
	}
}
