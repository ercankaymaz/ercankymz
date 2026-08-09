internal sealed class _0023_003DzWGqdyWGNTlCne4YHvRiublk_003D
{
	public void _0023_003Dzz8DDgng_003D(int _0023_003DzpGjKR04_003D, ref double[] _0023_003Dzyk2fsPo_003D, int _0023_003DzVwzJWWz_0024BCSn, int _0023_003DzPha_0024VJlONheb, ref double[] _0023_003DzvXOLtKg_003D, int _0023_003Dz4chJLWqlzf4p, int _0023_003DzGWhj1O1jhTmW, double[] _0023_003DzshZYG54_003D, int _0023_003DzvjXugQ9hIwn6, double[] _0023_003DzR58imxw_003D, int _0023_003DzSp6AR777HuJl, int _0023_003DzgLQ6sVnWlb_U)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		double num5 = 0.0;
		double num6 = 0.0;
		int num7 = -1 + _0023_003DzVwzJWWz_0024BCSn;
		int num8 = -1 + _0023_003Dz4chJLWqlzf4p;
		int num9 = -1 + _0023_003DzvjXugQ9hIwn6;
		int num10 = -1 + _0023_003DzSp6AR777HuJl;
		num3 = 1;
		num4 = 1;
		num2 = 1;
		for (num = 1; num <= _0023_003DzpGjKR04_003D; num++)
		{
			num5 = _0023_003Dzyk2fsPo_003D[num3 + num7];
			num6 = _0023_003DzvXOLtKg_003D[num4 + num8];
			_0023_003Dzyk2fsPo_003D[num3 + num7] = _0023_003DzshZYG54_003D[num2 + num9] * num5 + _0023_003DzR58imxw_003D[num2 + num10] * num6;
			_0023_003DzvXOLtKg_003D[num4 + num8] = _0023_003DzshZYG54_003D[num2 + num9] * num6 - _0023_003DzR58imxw_003D[num2 + num10] * num5;
			num3 += _0023_003DzPha_0024VJlONheb;
			num4 += _0023_003DzGWhj1O1jhTmW;
			num2 += _0023_003DzgLQ6sVnWlb_U;
		}
	}
}
