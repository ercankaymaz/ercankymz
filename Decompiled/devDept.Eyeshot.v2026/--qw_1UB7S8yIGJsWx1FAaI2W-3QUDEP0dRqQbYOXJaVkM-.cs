internal static class _0023_003Dqw_1UB7S8yIGJsWx1FAaI2W_00243QUDEP0dRqQbYOXJaVkM_003D
{
	public static bool _0023_003DzwDDkLyByhGgCP8oi8HziVcRz7zD8(int[] _0023_003DziDLVpbY_003D, int[] _0023_003Dz5rQzobg_003D)
	{
		if (_0023_003DziDLVpbY_003D == _0023_003Dz5rQzobg_003D)
		{
			return true;
		}
		if (_0023_003DziDLVpbY_003D == null || _0023_003Dz5rQzobg_003D == null)
		{
			return false;
		}
		if (_0023_003DziDLVpbY_003D.Length != _0023_003Dz5rQzobg_003D.Length)
		{
			return false;
		}
		for (int i = 0; i < _0023_003DziDLVpbY_003D.Length; i++)
		{
			if (_0023_003DziDLVpbY_003D[i] != _0023_003Dz5rQzobg_003D[i])
			{
				return false;
			}
		}
		return true;
	}
}
