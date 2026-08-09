internal sealed class _0023_003DzEC2pP8EaQFFBNkU775tFns4_003D
{
	public void _0023_003Dzz8DDgng_003D(int _0023_003DzpGjKR04_003D, ref double[] _0023_003Dzkyw2mdM_003D, int _0023_003Dzcg5G72corELm, int _0023_003DzPha_0024VJlONheb, ref double[] _0023_003DzYO5Qaho_003D, int _0023_003DzUTFqlsYh1Z94, int _0023_003DzGWhj1O1jhTmW)
	{
		double num = 0.0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = -1 + _0023_003Dzcg5G72corELm;
		int num7 = -1 + _0023_003DzUTFqlsYh1Z94;
		if (_0023_003DzpGjKR04_003D <= 0)
		{
			return;
		}
		if (_0023_003DzPha_0024VJlONheb != 1 || _0023_003DzGWhj1O1jhTmW != 1)
		{
			num3 = 1;
			num4 = 1;
			if (_0023_003DzPha_0024VJlONheb < 0)
			{
				num3 = (-_0023_003DzpGjKR04_003D + 1) * _0023_003DzPha_0024VJlONheb + 1;
			}
			if (_0023_003DzGWhj1O1jhTmW < 0)
			{
				num4 = (-_0023_003DzpGjKR04_003D + 1) * _0023_003DzGWhj1O1jhTmW + 1;
			}
			for (num2 = 1; num2 <= _0023_003DzpGjKR04_003D; num2++)
			{
				num = _0023_003Dzkyw2mdM_003D[num3 + num6];
				_0023_003Dzkyw2mdM_003D[num3 + num6] = _0023_003DzYO5Qaho_003D[num4 + num7];
				_0023_003DzYO5Qaho_003D[num4 + num7] = num;
				num3 += _0023_003DzPha_0024VJlONheb;
				num4 += _0023_003DzGWhj1O1jhTmW;
			}
			return;
		}
		num5 = _0023_003Dzt81xN7aa_002489vTvlbYozS6TUjvqyF._0023_003Dz4vcHOP8_003D(_0023_003DzpGjKR04_003D, 3);
		if (num5 != 0)
		{
			for (num2 = 1; num2 <= num5; num2++)
			{
				num = _0023_003Dzkyw2mdM_003D[num2 + num6];
				_0023_003Dzkyw2mdM_003D[num2 + num6] = _0023_003DzYO5Qaho_003D[num2 + num7];
				_0023_003DzYO5Qaho_003D[num2 + num7] = num;
			}
			if (_0023_003DzpGjKR04_003D < 3)
			{
				return;
			}
		}
		for (num2 = num5 + 1; num2 <= _0023_003DzpGjKR04_003D; num2 += 3)
		{
			num = _0023_003Dzkyw2mdM_003D[num2 + num6];
			_0023_003Dzkyw2mdM_003D[num2 + num6] = _0023_003DzYO5Qaho_003D[num2 + num7];
			_0023_003DzYO5Qaho_003D[num2 + num7] = num;
			num = _0023_003Dzkyw2mdM_003D[num2 + 1 + num6];
			_0023_003Dzkyw2mdM_003D[num2 + 1 + num6] = _0023_003DzYO5Qaho_003D[num2 + 1 + num7];
			_0023_003DzYO5Qaho_003D[num2 + 1 + num7] = num;
			num = _0023_003Dzkyw2mdM_003D[num2 + 2 + num6];
			_0023_003Dzkyw2mdM_003D[num2 + 2 + num6] = _0023_003DzYO5Qaho_003D[num2 + 2 + num7];
			_0023_003DzYO5Qaho_003D[num2 + 2 + num7] = num;
		}
	}
}
