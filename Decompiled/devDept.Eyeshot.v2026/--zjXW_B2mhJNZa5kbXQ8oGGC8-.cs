using System;

internal sealed class _0023_003DzjXW_B2mhJNZa5kbXQ8oGGC8_003D
{
	public void _0023_003Dzz8DDgng_003D(int _0023_003DzpGjKR04_003D, ref int _0023_003Dz1gFAmS8_003D, ref int _0023_003DzeYl_1Ac_003D, ref int[] _0023_003DzJP9kYl_0024RxGZl, int _0023_003Dzo4Indf8A52S0Fit7_A_003D_003D, ref int[] _0023_003Dza97KeixZEnKP, int _0023_003Dz5xqjRsRH9ZYTCavHoQ_003D_003D, ref int[] _0023_003DzBGDOHvv_0024mE7y, int _0023_003Dz58_0024lZlqIU0IE2q5zfw_003D_003D, int _0023_003DzB5sB4Vuzokmp)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		double num7 = 0.0;
		int num8 = -1 + _0023_003Dzo4Indf8A52S0Fit7_A_003D_003D;
		int num9 = -1 + _0023_003Dz5xqjRsRH9ZYTCavHoQ_003D_003D;
		int num10 = -1 + _0023_003Dz58_0024lZlqIU0IE2q5zfw_003D_003D;
		num7 = Math.Log(Convert.ToDouble(Math.Max(1, _0023_003DzpGjKR04_003D)) / Convert.ToDouble(_0023_003DzB5sB4Vuzokmp + 1)) / Math.Log(2.0);
		_0023_003Dz1gFAmS8_003D = Convert.ToInt32(Math.Truncate(num7)) + 1;
		num = _0023_003DzpGjKR04_003D / 2;
		_0023_003DzJP9kYl_0024RxGZl[1 + num8] = num + 1;
		_0023_003Dza97KeixZEnKP[1 + num9] = num;
		_0023_003DzBGDOHvv_0024mE7y[1 + num10] = _0023_003DzpGjKR04_003D - num - 1;
		num2 = 0;
		num3 = 1;
		num4 = 1;
		for (num6 = 1; num6 <= _0023_003Dz1gFAmS8_003D - 1; num6++)
		{
			for (num = 0; num <= num4 - 1; num++)
			{
				num2 += 2;
				num3 += 2;
				num5 = num4 + num;
				_0023_003Dza97KeixZEnKP[num2 + num9] = _0023_003Dza97KeixZEnKP[num5 + num9] / 2;
				_0023_003DzBGDOHvv_0024mE7y[num2 + num10] = _0023_003Dza97KeixZEnKP[num5 + num9] - _0023_003Dza97KeixZEnKP[num2 + num9] - 1;
				_0023_003DzJP9kYl_0024RxGZl[num2 + num8] = _0023_003DzJP9kYl_0024RxGZl[num5 + num8] - _0023_003DzBGDOHvv_0024mE7y[num2 + num10] - 1;
				_0023_003Dza97KeixZEnKP[num3 + num9] = _0023_003DzBGDOHvv_0024mE7y[num5 + num10] / 2;
				_0023_003DzBGDOHvv_0024mE7y[num3 + num10] = _0023_003DzBGDOHvv_0024mE7y[num5 + num10] - _0023_003Dza97KeixZEnKP[num3 + num9] - 1;
				_0023_003DzJP9kYl_0024RxGZl[num3 + num8] = _0023_003DzJP9kYl_0024RxGZl[num5 + num8] + _0023_003Dza97KeixZEnKP[num3 + num9] + 1;
			}
			num4 *= 2;
		}
		_0023_003DzeYl_1Ac_003D = num4 * 2 - 1;
	}
}
