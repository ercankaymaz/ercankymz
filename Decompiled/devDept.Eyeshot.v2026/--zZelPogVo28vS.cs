internal sealed class _0023_003DzZelPogVo28vS
{
	private static readonly uint[] _0023_003DzSY4Mn8Y_003D;

	static _0023_003DzZelPogVo28vS()
	{
		_0023_003DzSY4Mn8Y_003D = new uint[4096];
		_0023_003DztGdcVOA_003D(2197175160u);
	}

	private static void _0023_003DztGdcVOA_003D(uint _0023_003DzYVDIcYzAKAZM)
	{
		for (uint num = 0u; num < 256; num++)
		{
			uint num2 = num;
			for (int i = 0; i < 16; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					num2 = (((num2 & 1) == 1) ? (_0023_003DzYVDIcYzAKAZM ^ (num2 >> 1)) : (num2 >> 1));
				}
				_0023_003DzSY4Mn8Y_003D[i * 256 + num] = num2;
			}
		}
	}

	public uint _0023_003DzL9woobs_003D(uint _0023_003DztuiaUro_003D, byte[] _0023_003Dz0EsKsC8_003D, int _0023_003DzfBEBL_o_003D, int _0023_003Dz736ekIs_003D)
	{
		uint num = 0xFFFFFFFFu ^ _0023_003DztuiaUro_003D;
		uint[] array = _0023_003DzSY4Mn8Y_003D;
		while (_0023_003Dz736ekIs_003D >= 16)
		{
			uint num2 = array[768 + _0023_003Dz0EsKsC8_003D[_0023_003DzfBEBL_o_003D + 12]] ^ array[512 + _0023_003Dz0EsKsC8_003D[_0023_003DzfBEBL_o_003D + 13]] ^ array[256 + _0023_003Dz0EsKsC8_003D[_0023_003DzfBEBL_o_003D + 14]] ^ array[_0023_003Dz0EsKsC8_003D[_0023_003DzfBEBL_o_003D + 15]];
			uint num3 = array[1792 + _0023_003Dz0EsKsC8_003D[_0023_003DzfBEBL_o_003D + 8]] ^ array[1536 + _0023_003Dz0EsKsC8_003D[_0023_003DzfBEBL_o_003D + 9]] ^ array[1280 + _0023_003Dz0EsKsC8_003D[_0023_003DzfBEBL_o_003D + 10]] ^ array[1024 + _0023_003Dz0EsKsC8_003D[_0023_003DzfBEBL_o_003D + 11]];
			uint num4 = array[2816 + _0023_003Dz0EsKsC8_003D[_0023_003DzfBEBL_o_003D + 4]] ^ array[2560 + _0023_003Dz0EsKsC8_003D[_0023_003DzfBEBL_o_003D + 5]] ^ array[2304 + _0023_003Dz0EsKsC8_003D[_0023_003DzfBEBL_o_003D + 6]] ^ array[2048 + _0023_003Dz0EsKsC8_003D[_0023_003DzfBEBL_o_003D + 7]];
			num = array[3840 + ((byte)num ^ _0023_003Dz0EsKsC8_003D[_0023_003DzfBEBL_o_003D])] ^ array[3584 + ((byte)(num >> 8) ^ _0023_003Dz0EsKsC8_003D[_0023_003DzfBEBL_o_003D + 1])] ^ array[3328 + ((byte)(num >> 16) ^ _0023_003Dz0EsKsC8_003D[_0023_003DzfBEBL_o_003D + 2])] ^ array[3072 + ((num >> 24) ^ _0023_003Dz0EsKsC8_003D[_0023_003DzfBEBL_o_003D + 3])] ^ num4 ^ num3 ^ num2;
			_0023_003DzfBEBL_o_003D += 16;
			_0023_003Dz736ekIs_003D -= 16;
		}
		while (--_0023_003Dz736ekIs_003D >= 0)
		{
			num = array[(byte)(num ^ _0023_003Dz0EsKsC8_003D[_0023_003DzfBEBL_o_003D++])] ^ (num >> 8);
		}
		return num ^ 0xFFFFFFFFu;
	}
}
