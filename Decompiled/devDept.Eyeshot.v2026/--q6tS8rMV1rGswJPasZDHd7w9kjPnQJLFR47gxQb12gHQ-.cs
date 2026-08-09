internal static class _0023_003Dq6tS8rMV1rGswJPasZDHd7w9kjPnQJLFR47gxQb12gHQ_003D
{
	public static void _0023_003DzwQMEccT9MMfg7_BXXdv8JaQQy8_00240xJI5LVTNfh7Rlnn6(byte[] _0023_003DziDLVpbY_003D, int _0023_003Dz5rQzobg_003D, int _0023_003DzAvn2b38_003D)
	{
		for (int i = 0; i < 4; i++)
		{
			_0023_003DziDLVpbY_003D[_0023_003Dz5rQzobg_003D++] ^= (byte)(_0023_003DzAvn2b38_003D >> i * 8);
		}
	}

	public static void _0023_003Dz5ZbR3IfJwJ9P6MKM0xsSqys6u_0024UY(byte[] _0023_003DziDLVpbY_003D, int _0023_003Dz5rQzobg_003D, int _0023_003DzAvn2b38_003D)
	{
		for (int i = 0; i < 4; i++)
		{
			if (_0023_003Dz5rQzobg_003D >= _0023_003DziDLVpbY_003D.Length)
			{
				break;
			}
			_0023_003DziDLVpbY_003D[_0023_003Dz5rQzobg_003D++] ^= (byte)(_0023_003DzAvn2b38_003D >> i * 8);
		}
	}

	public static void _0023_003DzHWI6Jwg3hHHsxks0OnbQvkxbu7AEnr4qq2_Aehg_003D(byte[] _0023_003DziDLVpbY_003D, int _0023_003Dz5rQzobg_003D, long _0023_003DzAvn2b38_003D)
	{
		for (int i = 0; i < 8; i++)
		{
			_0023_003DziDLVpbY_003D[_0023_003Dz5rQzobg_003D++] ^= (byte)(_0023_003DzAvn2b38_003D >> i * 8);
		}
	}
}
