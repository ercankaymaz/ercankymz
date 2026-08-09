using System;

internal sealed class _0023_003Dz9OVMI8guWNn_
{
	public static int _0023_003DzQ9zX7zrpf0iE(char[] _0023_003DzQNumNB4_003D, char[] _0023_003DzKi0jwms_003D, int _0023_003DzNch_0024FQH4wg2a)
	{
		if (_0023_003DzQNumNB4_003D == null || _0023_003DzKi0jwms_003D == null)
		{
			throw new ArgumentNullException();
		}
		int num = Math.Min(_0023_003DzQNumNB4_003D.Length, _0023_003DzNch_0024FQH4wg2a);
		int num2 = Math.Min(_0023_003DzKi0jwms_003D.Length, _0023_003DzNch_0024FQH4wg2a);
		int num3 = Math.Min(num, num2);
		for (int i = 0; i < num3; i++)
		{
			if (_0023_003DzQNumNB4_003D[i] != _0023_003DzKi0jwms_003D[i])
			{
				return _0023_003DzQNumNB4_003D[i] - _0023_003DzKi0jwms_003D[i];
			}
		}
		return num - num2;
	}
}
