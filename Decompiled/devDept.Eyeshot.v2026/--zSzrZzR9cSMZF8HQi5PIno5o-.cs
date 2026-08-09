internal sealed class _0023_003DzSzrZzR9cSMZF8HQi5PIno5o_003D
{
	public void _0023_003Dzz8DDgng_003D(int _0023_003DzpGjKR04_003D, ref double[] _0023_003DzE8QrneA_003D, int _0023_003Dz2aqhBwM2q2_0024U, int _0023_003Dzs0UaYks_003D, int _0023_003DzGKVLTNs_003D, int _0023_003DzLKrjY6Y_003D, int[] _0023_003DzH1fpYbP_5iVB, int _0023_003DzW_0024_0024FC_M8T9W4, int _0023_003DzPha_0024VJlONheb)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		int num7 = 0;
		int num8 = 0;
		int num9 = 0;
		int num10 = 0;
		double num11 = 0.0;
		int num12 = -1 - _0023_003Dzs0UaYks_003D + _0023_003Dz2aqhBwM2q2_0024U;
		int num13 = -1 + _0023_003DzW_0024_0024FC_M8T9W4;
		if (_0023_003DzPha_0024VJlONheb > 0)
		{
			num7 = _0023_003DzGKVLTNs_003D;
			num2 = _0023_003DzGKVLTNs_003D;
			num3 = _0023_003DzLKrjY6Y_003D;
			num4 = 1;
		}
		else
		{
			if (_0023_003DzPha_0024VJlONheb >= 0)
			{
				return;
			}
			num7 = 1 + (1 - _0023_003DzLKrjY6Y_003D) * _0023_003DzPha_0024VJlONheb;
			num2 = _0023_003DzLKrjY6Y_003D;
			num3 = _0023_003DzGKVLTNs_003D;
			num4 = -1;
		}
		num10 = _0023_003DzpGjKR04_003D / 32 * 32;
		if (num10 != 0)
		{
			for (num8 = 1; num8 <= num10; num8 += 32)
			{
				num6 = num7;
				for (num = num2; (num4 >= 0) ? (num <= num3) : (num >= num3); num += num4)
				{
					num5 = _0023_003DzH1fpYbP_5iVB[num6 + num13];
					if (num5 != num)
					{
						for (num9 = num8; num9 <= num8 + 31; num9++)
						{
							num11 = _0023_003DzE8QrneA_003D[num + num9 * _0023_003Dzs0UaYks_003D + num12];
							_0023_003DzE8QrneA_003D[num + num9 * _0023_003Dzs0UaYks_003D + num12] = _0023_003DzE8QrneA_003D[num5 + num9 * _0023_003Dzs0UaYks_003D + num12];
							_0023_003DzE8QrneA_003D[num5 + num9 * _0023_003Dzs0UaYks_003D + num12] = num11;
						}
					}
					num6 += _0023_003DzPha_0024VJlONheb;
				}
			}
		}
		if (num10 == _0023_003DzpGjKR04_003D)
		{
			return;
		}
		num10++;
		num6 = num7;
		for (num = num2; (num4 >= 0) ? (num <= num3) : (num >= num3); num += num4)
		{
			num5 = _0023_003DzH1fpYbP_5iVB[num6 + num13];
			if (num5 != num)
			{
				for (num9 = num10; num9 <= _0023_003DzpGjKR04_003D; num9++)
				{
					num11 = _0023_003DzE8QrneA_003D[num + num9 * _0023_003Dzs0UaYks_003D + num12];
					_0023_003DzE8QrneA_003D[num + num9 * _0023_003Dzs0UaYks_003D + num12] = _0023_003DzE8QrneA_003D[num5 + num9 * _0023_003Dzs0UaYks_003D + num12];
					_0023_003DzE8QrneA_003D[num5 + num9 * _0023_003Dzs0UaYks_003D + num12] = num11;
				}
			}
			num6 += _0023_003DzPha_0024VJlONheb;
		}
	}
}
