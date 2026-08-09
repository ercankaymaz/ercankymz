internal sealed class _0023_003DzW07Cfa3MZmqxJUPw22e476g_003D
{
	public void _0023_003Dzz8DDgng_003D(int _0023_003DzpGjKR04_003D, ref double[] _0023_003Dzkyw2mdM_003D, int _0023_003Dzcg5G72corELm, int _0023_003DzPha_0024VJlONheb, ref double[] _0023_003DzYO5Qaho_003D, int _0023_003DzUTFqlsYh1Z94, int _0023_003DzGWhj1O1jhTmW, double _0023_003DzshZYG54_003D, double _0023_003DzR58imxw_003D)
	{
		double num = 0.0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = -1 + _0023_003Dzcg5G72corELm;
		int num6 = -1 + _0023_003DzUTFqlsYh1Z94;
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
				num = _0023_003DzshZYG54_003D * _0023_003Dzkyw2mdM_003D[num3 + num5] + _0023_003DzR58imxw_003D * _0023_003DzYO5Qaho_003D[num4 + num6];
				_0023_003DzYO5Qaho_003D[num4 + num6] = _0023_003DzshZYG54_003D * _0023_003DzYO5Qaho_003D[num4 + num6] - _0023_003DzR58imxw_003D * _0023_003Dzkyw2mdM_003D[num3 + num5];
				_0023_003Dzkyw2mdM_003D[num3 + num5] = num;
				num3 += _0023_003DzPha_0024VJlONheb;
				num4 += _0023_003DzGWhj1O1jhTmW;
			}
		}
		else
		{
			for (num2 = 1; num2 <= _0023_003DzpGjKR04_003D; num2++)
			{
				num = _0023_003DzshZYG54_003D * _0023_003Dzkyw2mdM_003D[num2 + num5] + _0023_003DzR58imxw_003D * _0023_003DzYO5Qaho_003D[num2 + num6];
				_0023_003DzYO5Qaho_003D[num2 + num6] = _0023_003DzshZYG54_003D * _0023_003DzYO5Qaho_003D[num2 + num6] - _0023_003DzR58imxw_003D * _0023_003Dzkyw2mdM_003D[num2 + num5];
				_0023_003Dzkyw2mdM_003D[num2 + num5] = num;
			}
		}
	}
}
