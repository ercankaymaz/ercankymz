internal sealed class _0023_003Dze8oCvvHTMALN41Cf_HvPWKw_003D
{
	public double _0023_003Dzz8DDgng_003D(int _0023_003DzpGjKR04_003D, double[] _0023_003Dzkyw2mdM_003D, int _0023_003Dzcg5G72corELm, int _0023_003DzPha_0024VJlONheb, double[] _0023_003DzYO5Qaho_003D, int _0023_003DzUTFqlsYh1Z94, int _0023_003DzGWhj1O1jhTmW)
	{
		double num = 0.0;
		double num2 = 0.0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		int num7 = -1 + _0023_003Dzcg5G72corELm;
		int num8 = -1 + _0023_003DzUTFqlsYh1Z94;
		num = 0.0;
		num2 = 0.0;
		if (_0023_003DzpGjKR04_003D <= 0)
		{
			return num;
		}
		if (_0023_003DzPha_0024VJlONheb != 1 || _0023_003DzGWhj1O1jhTmW != 1)
		{
			num4 = 1;
			num5 = 1;
			if (_0023_003DzPha_0024VJlONheb < 0)
			{
				num4 = (-_0023_003DzpGjKR04_003D + 1) * _0023_003DzPha_0024VJlONheb + 1;
			}
			if (_0023_003DzGWhj1O1jhTmW < 0)
			{
				num5 = (-_0023_003DzpGjKR04_003D + 1) * _0023_003DzGWhj1O1jhTmW + 1;
			}
			for (num3 = 1; num3 <= _0023_003DzpGjKR04_003D; num3++)
			{
				num2 += _0023_003Dzkyw2mdM_003D[num4 + num7] * _0023_003DzYO5Qaho_003D[num5 + num8];
				num4 += _0023_003DzPha_0024VJlONheb;
				num5 += _0023_003DzGWhj1O1jhTmW;
			}
			return num2;
		}
		num6 = _0023_003Dzt81xN7aa_002489vTvlbYozS6TUjvqyF._0023_003Dz4vcHOP8_003D(_0023_003DzpGjKR04_003D, 5);
		if (num6 != 0)
		{
			for (num3 = 1; num3 <= num6; num3++)
			{
				num2 += _0023_003Dzkyw2mdM_003D[num3 + num7] * _0023_003DzYO5Qaho_003D[num3 + num8];
			}
			if (_0023_003DzpGjKR04_003D < 5)
			{
				goto IL_0135;
			}
		}
		for (num3 = num6 + 1; num3 <= _0023_003DzpGjKR04_003D; num3 += 5)
		{
			num2 += _0023_003Dzkyw2mdM_003D[num3 + num7] * _0023_003DzYO5Qaho_003D[num3 + num8] + _0023_003Dzkyw2mdM_003D[num3 + 1 + num7] * _0023_003DzYO5Qaho_003D[num3 + 1 + num8] + _0023_003Dzkyw2mdM_003D[num3 + 2 + num7] * _0023_003DzYO5Qaho_003D[num3 + 2 + num8] + _0023_003Dzkyw2mdM_003D[num3 + 3 + num7] * _0023_003DzYO5Qaho_003D[num3 + 3 + num8] + _0023_003Dzkyw2mdM_003D[num3 + 4 + num7] * _0023_003DzYO5Qaho_003D[num3 + 4 + num8];
		}
		goto IL_0135;
		IL_0135:
		return num2;
	}
}
