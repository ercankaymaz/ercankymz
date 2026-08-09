using System;

internal static class _0023_003Dq0d3UOaLcwAHpHXr73AEsTkHo9keJqsf1eDwAJmr_UdU_003D
{
	private static uint _0023_003Dz9CzuOO3BHUsv6oIlP29AyLA_003D(uint _0023_003Dzq80RbjQ_003D, uint _0023_003DzZzVr6_0024U_003D, uint _0023_003Dz7hRN5Rg_003D, int _0023_003DzcbLoSrg_003D, uint _0023_003DzqMLoHoQ_003D, uint[] _0023_003DzuwE9t4w_003D)
	{
		return (((_0023_003Dz7hRN5Rg_003D >> 5) ^ (_0023_003DzZzVr6_0024U_003D << 2)) + ((_0023_003DzZzVr6_0024U_003D >> 3) ^ (_0023_003Dz7hRN5Rg_003D << 4))) ^ ((_0023_003Dzq80RbjQ_003D ^ _0023_003DzZzVr6_0024U_003D) + (_0023_003DzuwE9t4w_003D[(_0023_003DzcbLoSrg_003D & 3) ^ _0023_003DzqMLoHoQ_003D] ^ _0023_003Dz7hRN5Rg_003D));
	}

	public static void _0023_003DzG_wKkFN53GnGuWGf136K_0024SM2O6QGzBVrYA_003D_003D(byte[] _0023_003Dzq80RbjQ_003D, int _0023_003DzZzVr6_0024U_003D, int _0023_003Dz7hRN5Rg_003D, byte[] _0023_003DzcbLoSrg_003D)
	{
		if (_0023_003Dzq80RbjQ_003D.Length != 0 && _0023_003Dzq80RbjQ_003D.Length != 0)
		{
			if (_0023_003DzZzVr6_0024U_003D + _0023_003Dz7hRN5Rg_003D > _0023_003Dzq80RbjQ_003D.Length || _0023_003Dz7hRN5Rg_003D % 4 != 0 || _0023_003Dz7hRN5Rg_003D < 8)
			{
				throw new ArgumentException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355525889));
			}
			if (_0023_003DzcbLoSrg_003D == null || _0023_003DzcbLoSrg_003D.Length > 16)
			{
				throw new ArgumentNullException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355525908));
			}
			uint[] array = new uint[_0023_003Dz7hRN5Rg_003D / 4];
			_0023_003Dz5DPS_JZw2_0024Hsx3U0HRGG_0024lA_003D(_0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D, array, 0);
			uint[] array2 = new uint[4];
			_0023_003Dz5DPS_JZw2_0024Hsx3U0HRGG_0024lA_003D(_0023_003DzcbLoSrg_003D, 0, _0023_003DzcbLoSrg_003D.Length, array2, 0);
			_0023_003DzLmbGvKQpiESArOygGIwDObRp8Kg6(array, array2);
			_0023_003DztZkwP2_0024I_00247ZJ1gbsvzbEFTEAKvHIf678PIOpKX8_003D(array, 0, array.Length, _0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D);
		}
	}

	private static void _0023_003DzLmbGvKQpiESArOygGIwDObRp8Kg6(uint[] _0023_003Dzq80RbjQ_003D, uint[] _0023_003DzZzVr6_0024U_003D)
	{
		int num = _0023_003Dzq80RbjQ_003D.Length - 1;
		if (num < 1)
		{
			return;
		}
		uint _0023_003Dz7hRN5Rg_003D = _0023_003Dzq80RbjQ_003D[num];
		uint num2 = 0u;
		int num3 = 6 + 52 / (num + 1);
		while (0 < num3--)
		{
			num2 += 2654435769u;
			uint _0023_003DzqMLoHoQ_003D = (num2 >> 2) & 3;
			int i;
			uint _0023_003DzZzVr6_0024U_003D2;
			for (i = 0; i < num; i++)
			{
				_0023_003DzZzVr6_0024U_003D2 = _0023_003Dzq80RbjQ_003D[i + 1];
				_0023_003Dz7hRN5Rg_003D = (_0023_003Dzq80RbjQ_003D[i] += _0023_003Dz9CzuOO3BHUsv6oIlP29AyLA_003D(num2, _0023_003DzZzVr6_0024U_003D2, _0023_003Dz7hRN5Rg_003D, i, _0023_003DzqMLoHoQ_003D, _0023_003DzZzVr6_0024U_003D));
			}
			_0023_003DzZzVr6_0024U_003D2 = _0023_003Dzq80RbjQ_003D[0];
			_0023_003Dz7hRN5Rg_003D = (_0023_003Dzq80RbjQ_003D[num] += _0023_003Dz9CzuOO3BHUsv6oIlP29AyLA_003D(num2, _0023_003DzZzVr6_0024U_003D2, _0023_003Dz7hRN5Rg_003D, i, _0023_003DzqMLoHoQ_003D, _0023_003DzZzVr6_0024U_003D));
		}
	}

	private static uint[] _0023_003Dz5DPS_JZw2_0024Hsx3U0HRGG_0024lA_003D(byte[] _0023_003Dzq80RbjQ_003D, int _0023_003DzZzVr6_0024U_003D, int _0023_003Dz7hRN5Rg_003D, uint[] _0023_003DzcbLoSrg_003D, int _0023_003DzqMLoHoQ_003D)
	{
		if (_0023_003DzZzVr6_0024U_003D + _0023_003Dz7hRN5Rg_003D > _0023_003Dzq80RbjQ_003D.Length)
		{
			throw new ArgumentException();
		}
		int num = _0023_003Dz7hRN5Rg_003D / 4;
		if (_0023_003DzqMLoHoQ_003D + num > _0023_003DzcbLoSrg_003D.Length)
		{
			throw new ArgumentException();
		}
		int num2 = _0023_003DzZzVr6_0024U_003D + _0023_003Dz7hRN5Rg_003D;
		for (int i = _0023_003DzZzVr6_0024U_003D; i < num2; i += 4)
		{
			_0023_003DzcbLoSrg_003D[_0023_003DzqMLoHoQ_003D + (i - _0023_003DzZzVr6_0024U_003D) / 4] = (uint)(_0023_003Dzq80RbjQ_003D[i] | (_0023_003Dzq80RbjQ_003D[i + 1] << 8) | (_0023_003Dzq80RbjQ_003D[i + 2] << 16) | (_0023_003Dzq80RbjQ_003D[i + 3] << 24));
		}
		return _0023_003DzcbLoSrg_003D;
	}

	private static void _0023_003DztZkwP2_0024I_00247ZJ1gbsvzbEFTEAKvHIf678PIOpKX8_003D(uint[] _0023_003Dzq80RbjQ_003D, int _0023_003DzZzVr6_0024U_003D, int _0023_003Dz7hRN5Rg_003D, byte[] _0023_003DzcbLoSrg_003D, int _0023_003DzqMLoHoQ_003D)
	{
		if (_0023_003DzZzVr6_0024U_003D + _0023_003Dz7hRN5Rg_003D > _0023_003Dzq80RbjQ_003D.Length)
		{
			throw new ArgumentException();
		}
		int num = _0023_003Dz7hRN5Rg_003D * 4;
		if (_0023_003DzqMLoHoQ_003D + num > _0023_003DzcbLoSrg_003D.Length)
		{
			throw new ArgumentException();
		}
		int num2 = _0023_003DzqMLoHoQ_003D + num;
		for (int i = _0023_003DzqMLoHoQ_003D; i < num2; i += 4)
		{
			uint num3 = _0023_003Dzq80RbjQ_003D[(i - _0023_003DzqMLoHoQ_003D) / 4 + _0023_003DzZzVr6_0024U_003D];
			_0023_003DzcbLoSrg_003D[i] = (byte)num3;
			_0023_003DzcbLoSrg_003D[i + 1] = (byte)(num3 >> 8);
			_0023_003DzcbLoSrg_003D[i + 2] = (byte)(num3 >> 16);
			_0023_003DzcbLoSrg_003D[i + 3] = (byte)(num3 >> 24);
		}
	}
}
