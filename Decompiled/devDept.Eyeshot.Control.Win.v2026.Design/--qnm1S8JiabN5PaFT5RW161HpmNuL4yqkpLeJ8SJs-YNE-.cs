internal static class _0023_003Dqnm1S8JiabN5PaFT5RW161HpmNuL4yqkpLeJ8SJs_0024YNE_003D
{
	public static bool _0023_003DzVkC8Il3JOr5u2wgZejlPhSpIgF7_(int[] _0023_003Dz9jrlnWk_003D, int[] _0023_003DzBxpHhQ0_003D)
	{
		if (_0023_003Dz9jrlnWk_003D == _0023_003DzBxpHhQ0_003D)
		{
			return true;
		}
		if (_0023_003Dz9jrlnWk_003D == null || _0023_003DzBxpHhQ0_003D == null)
		{
			return false;
		}
		if (_0023_003Dz9jrlnWk_003D.Length != _0023_003DzBxpHhQ0_003D.Length)
		{
			return false;
		}
		for (int i = 0; i < _0023_003Dz9jrlnWk_003D.Length; i++)
		{
			if (_0023_003Dz9jrlnWk_003D[i] != _0023_003DzBxpHhQ0_003D[i])
			{
				return false;
			}
		}
		return true;
	}
}
