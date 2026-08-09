internal static class _0023_003DqZu9RUwDbCtc4SJBxOJT7L0E0rAk_0024I0fsIsHmcCJBewE_003D
{
	public static bool _0023_003Dz7PefeelIJvedg_0024q69l_M_00241QKtlLF(int[] _0023_003DzjYYAPCA_003D, int[] _0023_003DzVC9FBdo_003D)
	{
		if (_0023_003DzjYYAPCA_003D == _0023_003DzVC9FBdo_003D)
		{
			return true;
		}
		if (_0023_003DzjYYAPCA_003D == null || _0023_003DzVC9FBdo_003D == null)
		{
			return false;
		}
		if (_0023_003DzjYYAPCA_003D.Length != _0023_003DzVC9FBdo_003D.Length)
		{
			return false;
		}
		for (int i = 0; i < _0023_003DzjYYAPCA_003D.Length; i++)
		{
			if (_0023_003DzjYYAPCA_003D[i] != _0023_003DzVC9FBdo_003D[i])
			{
				return false;
			}
		}
		return true;
	}
}
