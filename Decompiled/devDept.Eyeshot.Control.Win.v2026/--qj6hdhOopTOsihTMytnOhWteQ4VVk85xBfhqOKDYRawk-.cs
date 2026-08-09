internal static class _0023_003Dqj6hdhOopTOsihTMytnOhWteQ4VVk85xBfhqOKDYRawk_003D
{
	public static void _0023_003Dz00wzQVQ0nNm5Rb5iYAzBp_wif0U3al39mr_aYOro4jsi(byte[] _0023_003DzjYYAPCA_003D, int _0023_003DzVC9FBdo_003D, int _0023_003DzwBouG0w_003D)
	{
		for (int i = 0; i < 4; i++)
		{
			_0023_003DzjYYAPCA_003D[_0023_003DzVC9FBdo_003D++] ^= (byte)(_0023_003DzwBouG0w_003D >> i * 8);
		}
	}

	public static void _0023_003DzlNopltZ3VpWIZXABNcQOvOl0f5Gb(byte[] _0023_003DzjYYAPCA_003D, int _0023_003DzVC9FBdo_003D, int _0023_003DzwBouG0w_003D)
	{
		for (int i = 0; i < 4; i++)
		{
			if (_0023_003DzVC9FBdo_003D >= _0023_003DzjYYAPCA_003D.Length)
			{
				break;
			}
			_0023_003DzjYYAPCA_003D[_0023_003DzVC9FBdo_003D++] ^= (byte)(_0023_003DzwBouG0w_003D >> i * 8);
		}
	}

	public static void _0023_003DzBdIOPMx0gEzpToD6J8KPuHjVF48gyVp7aP3Hfrs_003D(byte[] _0023_003DzjYYAPCA_003D, int _0023_003DzVC9FBdo_003D, long _0023_003DzwBouG0w_003D)
	{
		for (int i = 0; i < 8; i++)
		{
			_0023_003DzjYYAPCA_003D[_0023_003DzVC9FBdo_003D++] ^= (byte)(_0023_003DzwBouG0w_003D >> i * 8);
		}
	}
}
