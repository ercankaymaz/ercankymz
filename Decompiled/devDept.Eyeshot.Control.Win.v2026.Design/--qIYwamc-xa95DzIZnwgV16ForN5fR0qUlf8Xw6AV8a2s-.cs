using System;
using System.Threading;

internal static class _0023_003DqIYwamc_0024xa95DzIZnwgV16ForN5fR0qUlf8Xw6AV8a2s_003D
{
	public static _0023_003Dq6RsKbEvjyFgbikPCxI_0024iydFh6BWi2H2uikFMvo_0024SRa4_003D _0023_003DzjqF0Y1etM6q5D_UUgoSQ0x7asg7mRupD8g_003D_003D()
	{
		return _0023_003Dz3FRlyAwpiAL159KJgVrO_0024wM_003D() ?? new _0023_003Dq_00249gqa_00242OaFZvUQ9SB2xbDPTJa8GSZJZ6QdfYjDgtO2E_003D();
	}

	private static _0023_003Dq6RsKbEvjyFgbikPCxI_0024iydFh6BWi2H2uikFMvo_0024SRa4_003D _0023_003Dz3FRlyAwpiAL159KJgVrO_0024wM_003D()
	{
		try
		{
			_0023_003DqyvT7ICDtp8Yy01kAGSLXnxSR6VzLXRpmmeCWU_J9Xhg_003D _0023_003DqyvT7ICDtp8Yy01kAGSLXnxSR6VzLXRpmmeCWU_J9Xhg_003D2 = new _0023_003DqyvT7ICDtp8Yy01kAGSLXnxSR6VzLXRpmmeCWU_J9Xhg_003D();
			if (!_0023_003DzlmEH05Bcpg3NrwAmaKnimUTTSUSS(_0023_003DqyvT7ICDtp8Yy01kAGSLXnxSR6VzLXRpmmeCWU_J9Xhg_003D2))
			{
				_0023_003DqyvT7ICDtp8Yy01kAGSLXnxSR6VzLXRpmmeCWU_J9Xhg_003D2.Dispose();
				return null;
			}
			return _0023_003DqyvT7ICDtp8Yy01kAGSLXnxSR6VzLXRpmmeCWU_J9Xhg_003D2;
		}
		catch (Exception _0023_003Dz9jrlnWk_003D) when (!_0023_003DzXC_kD51kZTi1hJH4fhpafIOfQ3Ww(_0023_003Dz9jrlnWk_003D))
		{
			return null;
		}
	}

	private static bool _0023_003DzXC_kD51kZTi1hJH4fhpafIOfQ3Ww(Exception _0023_003Dz9jrlnWk_003D)
	{
		if (!(_0023_003Dz9jrlnWk_003D is ThreadAbortException))
		{
			return _0023_003Dz9jrlnWk_003D is ThreadInterruptedException;
		}
		return true;
	}

	private static bool _0023_003DzlmEH05Bcpg3NrwAmaKnimUTTSUSS(_0023_003Dq6RsKbEvjyFgbikPCxI_0024iydFh6BWi2H2uikFMvo_0024SRa4_003D _0023_003Dz9jrlnWk_003D)
	{
		byte[] array = new byte[3] { 0, 130, 255 };
		for (int i = 0; i < array.Length; i++)
		{
			byte _0023_003DzBxpHhQ0_003D = array[i];
			_0023_003Dz9jrlnWk_003D._0023_003DzFWk0iEx7YV5u79_0024y1uaRVY0JW9pUf0t_Uj_0024xqXJgF6bq5RcGLO3dvfOyuREaKTF3n2_L42DrUWnhTba2oGzLSqE_003D(i, ref _0023_003DzBxpHhQ0_003D);
		}
		if (_0023_003Dz9jrlnWk_003D._0023_003Dzj5RqxJS7S0566JxyZ4pprvdCb5qYrV3CmScOC9cXx3UY_0024IBiSjLBPL3J3IYNXmhhQdqPejGDJqR7C7r_0024aE3X6ZgHDq4q() != array.Length)
		{
			return false;
		}
		for (int j = 0; j < array.Length; j++)
		{
			_0023_003Dz9jrlnWk_003D._0023_003DzVtcPnGdX5rANY2JX1ZX5HVk1BJC78UKINE78RM4yFvZtvq8Q5J9tYaT_0024hqyy_rxgLrhYOf9qgqKo(j, out var _0023_003DzBxpHhQ0_003D2);
			if (_0023_003DzBxpHhQ0_003D2 != array[j])
			{
				return false;
			}
		}
		_0023_003Dz9jrlnWk_003D._0023_003DzCx9I9GEAr14NI6PMtKI5TUN5_0024UCT5rpWlmKvRmjUIah6kd7Bv6fxyPMjYRdtKsJ3S56fZiw_003D();
		if (_0023_003Dz9jrlnWk_003D._0023_003Dzj5RqxJS7S0566JxyZ4pprvdCb5qYrV3CmScOC9cXx3UY_0024IBiSjLBPL3J3IYNXmhhQdqPejGDJqR7C7r_0024aE3X6ZgHDq4q() != 0)
		{
			return false;
		}
		return true;
	}
}
