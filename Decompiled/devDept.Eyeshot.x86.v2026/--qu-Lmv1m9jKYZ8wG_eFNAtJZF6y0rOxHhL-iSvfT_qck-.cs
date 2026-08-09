internal static class _0023_003Dqu_0024Lmv1m9jKYZ8wG_eFNAtJZF6y0rOxHhL_0024iSvfT_qck_003D
{
	public static bool _0023_003Dz3stBIQSfqBegUB4_ZQgb6Ay29BD0(int[] _0023_003Dzq80RbjQ_003D, int[] _0023_003DzZzVr6_0024U_003D)
	{
		if (_0023_003Dzq80RbjQ_003D == _0023_003DzZzVr6_0024U_003D)
		{
			return true;
		}
		if (_0023_003Dzq80RbjQ_003D == null || _0023_003DzZzVr6_0024U_003D == null)
		{
			return false;
		}
		if (_0023_003Dzq80RbjQ_003D.Length != _0023_003DzZzVr6_0024U_003D.Length)
		{
			return false;
		}
		for (int i = 0; i < _0023_003Dzq80RbjQ_003D.Length; i++)
		{
			if (_0023_003Dzq80RbjQ_003D[i] != _0023_003DzZzVr6_0024U_003D[i])
			{
				return false;
			}
		}
		return true;
	}
}
