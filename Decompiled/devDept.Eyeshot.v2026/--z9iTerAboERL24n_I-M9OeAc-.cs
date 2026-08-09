internal sealed class _0023_003Dz9iTerAboERL24n_I_0024M9OeAc_003D
{
	public void _0023_003Dzz8DDgng_003D(int _0023_003DzpGjKR04_003D, ref double[] _0023_003Dzyk2fsPo_003D, int _0023_003DzVwzJWWz_0024BCSn, ref double[] _0023_003DzvXOLtKg_003D, int _0023_003Dz4chJLWqlzf4p, ref double[] _0023_003Dz8wjMonY_003D, int _0023_003Dz6_0024ZesPV2zhrz, int _0023_003DzPha_0024VJlONheb, double[] _0023_003DzshZYG54_003D, int _0023_003DzvjXugQ9hIwn6, double[] _0023_003DzR58imxw_003D, int _0023_003DzSp6AR777HuJl, int _0023_003DzgLQ6sVnWlb_U)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		double num4 = 0.0;
		double num5 = 0.0;
		double num6 = 0.0;
		double num7 = 0.0;
		double num8 = 0.0;
		double num9 = 0.0;
		double num10 = 0.0;
		double num11 = 0.0;
		double num12 = 0.0;
		double num13 = 0.0;
		int num14 = -1 + _0023_003DzVwzJWWz_0024BCSn;
		int num15 = -1 + _0023_003Dz4chJLWqlzf4p;
		int num16 = -1 + _0023_003Dz6_0024ZesPV2zhrz;
		int num17 = -1 + _0023_003DzvjXugQ9hIwn6;
		int num18 = -1 + _0023_003DzSp6AR777HuJl;
		num3 = 1;
		num2 = 1;
		for (num = 1; num <= _0023_003DzpGjKR04_003D; num++)
		{
			num11 = _0023_003Dzyk2fsPo_003D[num3 + num14];
			num12 = _0023_003DzvXOLtKg_003D[num3 + num15];
			num13 = _0023_003Dz8wjMonY_003D[num3 + num16];
			num4 = _0023_003DzshZYG54_003D[num2 + num17];
			num5 = _0023_003DzR58imxw_003D[num2 + num18];
			num6 = num5 * num13;
			double num19 = num4 * num13;
			num7 = num19 - num5 * num11;
			num8 = num19 + num5 * num12;
			num9 = num4 * num11 + num6;
			num10 = num4 * num12 - num6;
			_0023_003Dzyk2fsPo_003D[num3 + num14] = num4 * num9 + num5 * num8;
			_0023_003DzvXOLtKg_003D[num3 + num15] = num4 * num10 - num5 * num7;
			_0023_003Dz8wjMonY_003D[num3 + num16] = num4 * num8 - num5 * num9;
			num3 += _0023_003DzPha_0024VJlONheb;
			num2 += _0023_003DzgLQ6sVnWlb_U;
		}
	}
}
