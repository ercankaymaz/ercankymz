using System;

internal static class _0023_003Dq7DDRIUR2HfeJRmeMtT4tOMe2NRdGzg4TR_S1kTwkG2I_003D
{
	private static uint _0023_003DzqF0kUxJoorWy9tKTUj8Xp_0024Q_003D(uint _0023_003Dz9jrlnWk_003D, uint _0023_003DzBxpHhQ0_003D, uint _0023_003Dztgqm2r4_003D, int _0023_003DzzKDx05I_003D, uint _0023_003Dz3iPku7s_003D, uint[] _0023_003Dz2X8kE24_003D)
	{
		return (((_0023_003Dztgqm2r4_003D >> 5) ^ (_0023_003DzBxpHhQ0_003D << 2)) + ((_0023_003DzBxpHhQ0_003D >> 3) ^ (_0023_003Dztgqm2r4_003D << 4))) ^ ((_0023_003Dz9jrlnWk_003D ^ _0023_003DzBxpHhQ0_003D) + (_0023_003Dz2X8kE24_003D[(_0023_003DzzKDx05I_003D & 3) ^ _0023_003Dz3iPku7s_003D] ^ _0023_003Dztgqm2r4_003D));
	}

	public static void _0023_003Dz6pRZrF8Tjm9s_0024hBAQ5OlLqCNsbQZJH_mzg_003D_003D(byte[] _0023_003Dz9jrlnWk_003D, int _0023_003DzBxpHhQ0_003D, int _0023_003Dztgqm2r4_003D, byte[] _0023_003DzzKDx05I_003D)
	{
		if (_0023_003Dz9jrlnWk_003D.Length != 0 && _0023_003Dz9jrlnWk_003D.Length != 0)
		{
			if (_0023_003DzBxpHhQ0_003D + _0023_003Dztgqm2r4_003D > _0023_003Dz9jrlnWk_003D.Length || _0023_003Dztgqm2r4_003D % 4 != 0 || _0023_003Dztgqm2r4_003D < 8)
			{
				throw new ArgumentException(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564314521));
			}
			if (_0023_003DzzKDx05I_003D == null || _0023_003DzzKDx05I_003D.Length > 16)
			{
				throw new ArgumentNullException(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564314510));
			}
			uint[] array = new uint[_0023_003Dztgqm2r4_003D / 4];
			_0023_003DzDjG1H0Ra2HIhxw3HU85BUps_003D(_0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D, array, 0);
			uint[] array2 = new uint[4];
			_0023_003DzDjG1H0Ra2HIhxw3HU85BUps_003D(_0023_003DzzKDx05I_003D, 0, _0023_003DzzKDx05I_003D.Length, array2, 0);
			_0023_003Dzi_00242IwLJbtLYbtiifeWfBqebgKSU_0024(array, array2);
			_0023_003DzKKxhbf9ghuGiBZDMR1_aFyiKjqonIHtWNihL8p0_003D(array, 0, array.Length, _0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D);
		}
	}

	private static void _0023_003Dzi_00242IwLJbtLYbtiifeWfBqebgKSU_0024(uint[] _0023_003Dz9jrlnWk_003D, uint[] _0023_003DzBxpHhQ0_003D)
	{
		int num = _0023_003Dz9jrlnWk_003D.Length - 1;
		if (num < 1)
		{
			return;
		}
		uint _0023_003Dztgqm2r4_003D = _0023_003Dz9jrlnWk_003D[num];
		uint num2 = 0u;
		int num3 = 6 + 52 / (num + 1);
		while (0 < num3--)
		{
			num2 += 2654435769u;
			uint _0023_003Dz3iPku7s_003D = (num2 >> 2) & 3;
			int i;
			uint _0023_003DzBxpHhQ0_003D2;
			for (i = 0; i < num; i++)
			{
				_0023_003DzBxpHhQ0_003D2 = _0023_003Dz9jrlnWk_003D[i + 1];
				_0023_003Dztgqm2r4_003D = (_0023_003Dz9jrlnWk_003D[i] += _0023_003DzqF0kUxJoorWy9tKTUj8Xp_0024Q_003D(num2, _0023_003DzBxpHhQ0_003D2, _0023_003Dztgqm2r4_003D, i, _0023_003Dz3iPku7s_003D, _0023_003DzBxpHhQ0_003D));
			}
			_0023_003DzBxpHhQ0_003D2 = _0023_003Dz9jrlnWk_003D[0];
			_0023_003Dztgqm2r4_003D = (_0023_003Dz9jrlnWk_003D[num] += _0023_003DzqF0kUxJoorWy9tKTUj8Xp_0024Q_003D(num2, _0023_003DzBxpHhQ0_003D2, _0023_003Dztgqm2r4_003D, i, _0023_003Dz3iPku7s_003D, _0023_003DzBxpHhQ0_003D));
		}
	}

	private static uint[] _0023_003DzDjG1H0Ra2HIhxw3HU85BUps_003D(byte[] _0023_003Dz9jrlnWk_003D, int _0023_003DzBxpHhQ0_003D, int _0023_003Dztgqm2r4_003D, uint[] _0023_003DzzKDx05I_003D, int _0023_003Dz3iPku7s_003D)
	{
		if (_0023_003DzBxpHhQ0_003D + _0023_003Dztgqm2r4_003D > _0023_003Dz9jrlnWk_003D.Length)
		{
			throw new ArgumentException();
		}
		int num = _0023_003Dztgqm2r4_003D / 4;
		if (_0023_003Dz3iPku7s_003D + num > _0023_003DzzKDx05I_003D.Length)
		{
			throw new ArgumentException();
		}
		int num2 = _0023_003DzBxpHhQ0_003D + _0023_003Dztgqm2r4_003D;
		for (int i = _0023_003DzBxpHhQ0_003D; i < num2; i += 4)
		{
			_0023_003DzzKDx05I_003D[_0023_003Dz3iPku7s_003D + (i - _0023_003DzBxpHhQ0_003D) / 4] = (uint)(_0023_003Dz9jrlnWk_003D[i] | (_0023_003Dz9jrlnWk_003D[i + 1] << 8) | (_0023_003Dz9jrlnWk_003D[i + 2] << 16) | (_0023_003Dz9jrlnWk_003D[i + 3] << 24));
		}
		return _0023_003DzzKDx05I_003D;
	}

	private static void _0023_003DzKKxhbf9ghuGiBZDMR1_aFyiKjqonIHtWNihL8p0_003D(uint[] _0023_003Dz9jrlnWk_003D, int _0023_003DzBxpHhQ0_003D, int _0023_003Dztgqm2r4_003D, byte[] _0023_003DzzKDx05I_003D, int _0023_003Dz3iPku7s_003D)
	{
		if (_0023_003DzBxpHhQ0_003D + _0023_003Dztgqm2r4_003D > _0023_003Dz9jrlnWk_003D.Length)
		{
			throw new ArgumentException();
		}
		int num = _0023_003Dztgqm2r4_003D * 4;
		if (_0023_003Dz3iPku7s_003D + num > _0023_003DzzKDx05I_003D.Length)
		{
			throw new ArgumentException();
		}
		int num2 = _0023_003Dz3iPku7s_003D + num;
		for (int i = _0023_003Dz3iPku7s_003D; i < num2; i += 4)
		{
			uint num3 = _0023_003Dz9jrlnWk_003D[(i - _0023_003Dz3iPku7s_003D) / 4 + _0023_003DzBxpHhQ0_003D];
			_0023_003DzzKDx05I_003D[i] = (byte)num3;
			_0023_003DzzKDx05I_003D[i + 1] = (byte)(num3 >> 8);
			_0023_003DzzKDx05I_003D[i + 2] = (byte)(num3 >> 16);
			_0023_003DzzKDx05I_003D[i + 3] = (byte)(num3 >> 24);
		}
	}
}
