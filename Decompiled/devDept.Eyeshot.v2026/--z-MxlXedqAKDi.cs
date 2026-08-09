using System;

internal sealed class _0023_003Dz_0024MxlXedqAKDi
{
	private ulong _0023_003DzqMwI0uOHfI5X;

	private ulong _0023_003DzeD8fweVW0GG6;

	private byte[] _0023_003Dzb5cRlCk_003D;

	public _0023_003Dz_0024MxlXedqAKDi(char[] _0023_003Dz0EsKsC8_003D, ulong _0023_003Dz14lzA48_003D)
	{
		_0023_003DzqMwI0uOHfI5X = _0023_003Dz14lzA48_003D;
		Array.Copy(_0023_003Dz0EsKsC8_003D, _0023_003Dzb5cRlCk_003D, (int)_0023_003Dz14lzA48_003D);
	}

	public ulong _0023_003DzpdeSbFA_003D()
	{
		return _0023_003DzeD8fweVW0GG6;
	}

	public bool _0023_003DzT51EUwQ_003D(ulong _0023_003DzfBEBL_o_003D, int _0023_003Dz6grTDAjLWHGq)
	{
		if (_0023_003Dz6grTDAjLWHGq == _0023_003DzxPxUMwOCHjCbWtnqHQ_003D_003D._0023_003Dzvz9AsP5XgcOU)
		{
			_0023_003DzeD8fweVW0GG6 += _0023_003DzfBEBL_o_003D;
		}
		else if (_0023_003Dz6grTDAjLWHGq == _0023_003DzxPxUMwOCHjCbWtnqHQ_003D_003D._0023_003Dz5z31Zx6y55n8)
		{
			_0023_003DzeD8fweVW0GG6 = _0023_003DzfBEBL_o_003D;
		}
		else if (_0023_003Dz6grTDAjLWHGq == _0023_003DzxPxUMwOCHjCbWtnqHQ_003D_003D._0023_003DzGMXG5430qmd3)
		{
			_0023_003DzeD8fweVW0GG6 = _0023_003DzqMwI0uOHfI5X - _0023_003DzfBEBL_o_003D;
		}
		if (_0023_003Dz6grTDAjLWHGq == _0023_003DzxPxUMwOCHjCbWtnqHQ_003D_003D._0023_003Dzvz9AsP5XgcOU)
		{
			_0023_003DzeD8fweVW0GG6 = _0023_003DzqMwI0uOHfI5X;
			return false;
		}
		return true;
	}

	public void _0023_003DzuuY9lIM_003D(byte[] _0023_003DzzLvmjQQ_003D, ulong _0023_003Dzfsn580w_003D)
	{
		int num = (int)_0023_003DzeD8fweVW0GG6;
		for (int i = 0; i < (int)_0023_003Dzfsn580w_003D; i++)
		{
			_0023_003DzzLvmjQQ_003D[i] = _0023_003Dzb5cRlCk_003D[num + i];
			_0023_003DzeD8fweVW0GG6++;
		}
	}
}
