using System;

internal static class _0023_003DqG2j0vYyDwMuB3UfmWnsmaWFxm5_jgeAwi2PjV1Hk_002498_003D
{
	private static uint _0023_003DzUV_VQ_0024ps3vdOfw0fCOHjobs_003D(uint _0023_003DzjYYAPCA_003D, uint _0023_003DzVC9FBdo_003D, uint _0023_003DzwBouG0w_003D, int _0023_003Dzf4Pqh9s_003D, uint _0023_003DzTFNDoh0_003D, uint[] _0023_003DzraVZG9g_003D)
	{
		return (((_0023_003DzwBouG0w_003D >> 5) ^ (_0023_003DzVC9FBdo_003D << 2)) + ((_0023_003DzVC9FBdo_003D >> 3) ^ (_0023_003DzwBouG0w_003D << 4))) ^ ((_0023_003DzjYYAPCA_003D ^ _0023_003DzVC9FBdo_003D) + (_0023_003DzraVZG9g_003D[(_0023_003Dzf4Pqh9s_003D & 3) ^ _0023_003DzTFNDoh0_003D] ^ _0023_003DzwBouG0w_003D));
	}

	public static void _0023_003DzV7AM42Yl2jAbY4wp6gCgLY9P_CS2oHevdw_003D_003D(byte[] _0023_003DzjYYAPCA_003D, int _0023_003DzVC9FBdo_003D, int _0023_003DzwBouG0w_003D, byte[] _0023_003Dzf4Pqh9s_003D)
	{
		if (_0023_003DzjYYAPCA_003D.Length != 0 && _0023_003DzjYYAPCA_003D.Length != 0)
		{
			if (_0023_003DzVC9FBdo_003D + _0023_003DzwBouG0w_003D > _0023_003DzjYYAPCA_003D.Length || _0023_003DzwBouG0w_003D % 4 != 0 || _0023_003DzwBouG0w_003D < 8)
			{
				throw new ArgumentException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348621472));
			}
			if (_0023_003Dzf4Pqh9s_003D == null || _0023_003Dzf4Pqh9s_003D.Length > 16)
			{
				throw new ArgumentNullException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348621493));
			}
			uint[] array = new uint[_0023_003DzwBouG0w_003D / 4];
			_0023_003DzQOjGxFDv7jSZCgJLJEWZBCw_003D(_0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D, array, 0);
			uint[] array2 = new uint[4];
			_0023_003DzQOjGxFDv7jSZCgJLJEWZBCw_003D(_0023_003Dzf4Pqh9s_003D, 0, _0023_003Dzf4Pqh9s_003D.Length, array2, 0);
			_0023_003DzJf90mdRth9BkTgP43Qz9oJgRfjCV(array, array2);
			_0023_003Dz3tNz9_00246ikDMx_0024rp6xwlsls9nuxcTfL9e6YUm_0024tg_003D(array, 0, array.Length, _0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D);
		}
	}

	private static void _0023_003DzJf90mdRth9BkTgP43Qz9oJgRfjCV(uint[] _0023_003DzjYYAPCA_003D, uint[] _0023_003DzVC9FBdo_003D)
	{
		int num = _0023_003DzjYYAPCA_003D.Length - 1;
		if (num < 1)
		{
			return;
		}
		uint _0023_003DzwBouG0w_003D = _0023_003DzjYYAPCA_003D[num];
		uint num2 = 0u;
		int num3 = 6 + 52 / (num + 1);
		while (0 < num3--)
		{
			num2 += 2654435769u;
			uint _0023_003DzTFNDoh0_003D = (num2 >> 2) & 3;
			int i;
			uint _0023_003DzVC9FBdo_003D2;
			for (i = 0; i < num; i++)
			{
				_0023_003DzVC9FBdo_003D2 = _0023_003DzjYYAPCA_003D[i + 1];
				_0023_003DzwBouG0w_003D = (_0023_003DzjYYAPCA_003D[i] += _0023_003DzUV_VQ_0024ps3vdOfw0fCOHjobs_003D(num2, _0023_003DzVC9FBdo_003D2, _0023_003DzwBouG0w_003D, i, _0023_003DzTFNDoh0_003D, _0023_003DzVC9FBdo_003D));
			}
			_0023_003DzVC9FBdo_003D2 = _0023_003DzjYYAPCA_003D[0];
			_0023_003DzwBouG0w_003D = (_0023_003DzjYYAPCA_003D[num] += _0023_003DzUV_VQ_0024ps3vdOfw0fCOHjobs_003D(num2, _0023_003DzVC9FBdo_003D2, _0023_003DzwBouG0w_003D, i, _0023_003DzTFNDoh0_003D, _0023_003DzVC9FBdo_003D));
		}
	}

	private static uint[] _0023_003DzQOjGxFDv7jSZCgJLJEWZBCw_003D(byte[] _0023_003DzjYYAPCA_003D, int _0023_003DzVC9FBdo_003D, int _0023_003DzwBouG0w_003D, uint[] _0023_003Dzf4Pqh9s_003D, int _0023_003DzTFNDoh0_003D)
	{
		if (_0023_003DzVC9FBdo_003D + _0023_003DzwBouG0w_003D > _0023_003DzjYYAPCA_003D.Length)
		{
			throw new ArgumentException();
		}
		int num = _0023_003DzwBouG0w_003D / 4;
		if (_0023_003DzTFNDoh0_003D + num > _0023_003Dzf4Pqh9s_003D.Length)
		{
			throw new ArgumentException();
		}
		int num2 = _0023_003DzVC9FBdo_003D + _0023_003DzwBouG0w_003D;
		for (int i = _0023_003DzVC9FBdo_003D; i < num2; i += 4)
		{
			_0023_003Dzf4Pqh9s_003D[_0023_003DzTFNDoh0_003D + (i - _0023_003DzVC9FBdo_003D) / 4] = (uint)(_0023_003DzjYYAPCA_003D[i] | (_0023_003DzjYYAPCA_003D[i + 1] << 8) | (_0023_003DzjYYAPCA_003D[i + 2] << 16) | (_0023_003DzjYYAPCA_003D[i + 3] << 24));
		}
		return _0023_003Dzf4Pqh9s_003D;
	}

	private static void _0023_003Dz3tNz9_00246ikDMx_0024rp6xwlsls9nuxcTfL9e6YUm_0024tg_003D(uint[] _0023_003DzjYYAPCA_003D, int _0023_003DzVC9FBdo_003D, int _0023_003DzwBouG0w_003D, byte[] _0023_003Dzf4Pqh9s_003D, int _0023_003DzTFNDoh0_003D)
	{
		if (_0023_003DzVC9FBdo_003D + _0023_003DzwBouG0w_003D > _0023_003DzjYYAPCA_003D.Length)
		{
			throw new ArgumentException();
		}
		int num = _0023_003DzwBouG0w_003D * 4;
		if (_0023_003DzTFNDoh0_003D + num > _0023_003Dzf4Pqh9s_003D.Length)
		{
			throw new ArgumentException();
		}
		int num2 = _0023_003DzTFNDoh0_003D + num;
		for (int i = _0023_003DzTFNDoh0_003D; i < num2; i += 4)
		{
			uint num3 = _0023_003DzjYYAPCA_003D[(i - _0023_003DzTFNDoh0_003D) / 4 + _0023_003DzVC9FBdo_003D];
			_0023_003Dzf4Pqh9s_003D[i] = (byte)num3;
			_0023_003Dzf4Pqh9s_003D[i + 1] = (byte)(num3 >> 8);
			_0023_003Dzf4Pqh9s_003D[i + 2] = (byte)(num3 >> 16);
			_0023_003Dzf4Pqh9s_003D[i + 3] = (byte)(num3 >> 24);
		}
	}
}
