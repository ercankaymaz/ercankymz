internal sealed class _0023_003Dz2SqTcIJNNj9yECic9RLPx7g_003D
{
	public void _0023_003Dzz8DDgng_003D(int _0023_003DzF6aJl54_003D, int _0023_003DzaJXmZ4c_003D, double[] _0023_003DzE8QrneA_003D, int _0023_003Dz2aqhBwM2q2_0024U, int _0023_003DzSK9ef5FvdKJh, int _0023_003DzLMi22WBtz_0024aU, ref int[] _0023_003Dz_0024MGVtQk_003D, int _0023_003DzVWNOkuynnn_0024O)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = -1 + _0023_003Dz2aqhBwM2q2_0024U;
		int num7 = -1 + _0023_003DzVWNOkuynnn_0024O;
		num4 = _0023_003DzF6aJl54_003D;
		num5 = _0023_003DzaJXmZ4c_003D;
		num2 = ((_0023_003DzSK9ef5FvdKJh > 0) ? 1 : _0023_003DzF6aJl54_003D);
		num3 = ((_0023_003DzLMi22WBtz_0024aU <= 0) ? (_0023_003DzF6aJl54_003D + _0023_003DzaJXmZ4c_003D) : (1 + _0023_003DzF6aJl54_003D));
		num = 1;
		while (num4 > 0 && num5 > 0)
		{
			if (_0023_003DzE8QrneA_003D[num2 + num6] <= _0023_003DzE8QrneA_003D[num3 + num6])
			{
				_0023_003Dz_0024MGVtQk_003D[num + num7] = num2;
				num++;
				num2 += _0023_003DzSK9ef5FvdKJh;
				num4--;
			}
			else
			{
				_0023_003Dz_0024MGVtQk_003D[num + num7] = num3;
				num++;
				num3 += _0023_003DzLMi22WBtz_0024aU;
				num5--;
			}
		}
		if (num4 == 0)
		{
			for (num4 = 1; num4 <= num5; num4++)
			{
				_0023_003Dz_0024MGVtQk_003D[num + num7] = num3;
				num++;
				num3 += _0023_003DzLMi22WBtz_0024aU;
			}
		}
		else
		{
			for (num5 = 1; num5 <= num4; num5++)
			{
				_0023_003Dz_0024MGVtQk_003D[num + num7] = num2;
				num++;
				num2 += _0023_003DzSK9ef5FvdKJh;
			}
		}
	}
}
