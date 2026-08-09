using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

internal sealed class _0023_003DqyvT7ICDtp8Yy01kAGSLXnxSR6VzLXRpmmeCWU_J9Xhg_003D : _0023_003Dq6RsKbEvjyFgbikPCxI_0024iydFh6BWi2H2uikFMvo_0024SRa4_003D, IDisposable
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private SecureString _0023_003Dz9jrlnWk_003D = new SecureString();

	[SpecialName]
	public int _0023_003Dzj5RqxJS7S0566JxyZ4pprvdCb5qYrV3CmScOC9cXx3UY_0024IBiSjLBPL3J3IYNXmhhQdqPejGDJqR7C7r_0024aE3X6ZgHDq4q()
	{
		return _0023_003Dz9jrlnWk_003D.Length;
	}

	public _0023_003Dq6RsKbEvjyFgbikPCxI_0024iydFh6BWi2H2uikFMvo_0024SRa4_003D _0023_003DzThNtJrc_84_00243Ae0w81ubGT_0024_0024aiDYzOIAzBzO9xH_6499C4fZLn6estuFUptwooFAHxFY_HjuJi6W_drl4A_003D_003D()
	{
		return new _0023_003DqyvT7ICDtp8Yy01kAGSLXnxSR6VzLXRpmmeCWU_J9Xhg_003D();
	}

	public void _0023_003DzVtcPnGdX5rANY2JX1ZX5HVk1BJC78UKINE78RM4yFvZtvq8Q5J9tYaT_0024hqyy_rxgLrhYOf9qgqKo(int _0023_003Dz9jrlnWk_003D, out byte _0023_003DzBxpHhQ0_003D)
	{
		if (_0023_003Dz9jrlnWk_003D < 0 || _0023_003Dz9jrlnWk_003D >= _0023_003Dzj5RqxJS7S0566JxyZ4pprvdCb5qYrV3CmScOC9cXx3UY_0024IBiSjLBPL3J3IYNXmhhQdqPejGDJqR7C7r_0024aE3X6ZgHDq4q())
		{
			throw new ArgumentOutOfRangeException();
		}
		IntPtr intPtr = IntPtr.Zero;
		char c = '\0';
		try
		{
			intPtr = Marshal.SecureStringToGlobalAllocUnicode(this._0023_003Dz9jrlnWk_003D);
			c = (char)Marshal.ReadInt16(intPtr, _0023_003Dz9jrlnWk_003D * 2);
			_0023_003DzBxpHhQ0_003D = _0023_003DzF1GlPEmV9UBsZeau_0024OF2vBVfMhbXGiKQ_0024A_003D_003D(c, _0023_003Dz9jrlnWk_003D);
		}
		finally
		{
			_0023_003DqpJzGvS9BBRbFYdUqQrKHOB2KEewQfIWN75cSSppENZY_003D._0023_003DzzK5LS9w0895r7pnAdf7i2D2_xq_Gjcvf_5pv22I_003D(ref c);
			if (intPtr != IntPtr.Zero)
			{
				Marshal.ZeroFreeGlobalAllocUnicode(intPtr);
			}
		}
	}

	public void _0023_003DzFWk0iEx7YV5u79_0024y1uaRVY0JW9pUf0t_Uj_0024xqXJgF6bq5RcGLO3dvfOyuREaKTF3n2_L42DrUWnhTba2oGzLSqE_003D(int _0023_003Dz9jrlnWk_003D, ref byte _0023_003DzBxpHhQ0_003D)
	{
		int num = this._0023_003Dz9jrlnWk_003D.Length;
		while (true)
		{
			if (num > _0023_003Dz9jrlnWk_003D)
			{
				this._0023_003Dz9jrlnWk_003D.SetAt(_0023_003Dz9jrlnWk_003D, _0023_003DzMZ9jjfBi0QQsZKBpTVGs5g0Q6yvDfQe5LeHQ1bnOaFHS(_0023_003DzBxpHhQ0_003D, _0023_003Dz9jrlnWk_003D));
				return;
			}
			if (num == _0023_003Dz9jrlnWk_003D)
			{
				break;
			}
			this._0023_003Dz9jrlnWk_003D.AppendChar(_0023_003DzMZ9jjfBi0QQsZKBpTVGs5g0Q6yvDfQe5LeHQ1bnOaFHS(0, num));
			num++;
		}
		this._0023_003Dz9jrlnWk_003D.AppendChar(_0023_003DzMZ9jjfBi0QQsZKBpTVGs5g0Q6yvDfQe5LeHQ1bnOaFHS(_0023_003DzBxpHhQ0_003D, num));
	}

	private static char _0023_003DzMZ9jjfBi0QQsZKBpTVGs5g0Q6yvDfQe5LeHQ1bnOaFHS(byte _0023_003Dz9jrlnWk_003D, int _0023_003DzBxpHhQ0_003D)
	{
		return (char)(_0023_003Dz9jrlnWk_003D + 1);
	}

	private static byte _0023_003DzF1GlPEmV9UBsZeau_0024OF2vBVfMhbXGiKQ_0024A_003D_003D(char _0023_003Dz9jrlnWk_003D, int _0023_003DzBxpHhQ0_003D)
	{
		return (byte)(_0023_003Dz9jrlnWk_003D - 1);
	}

	public void _0023_003DzCx9I9GEAr14NI6PMtKI5TUN5_0024UCT5rpWlmKvRmjUIah6kd7Bv6fxyPMjYRdtKsJ3S56fZiw_003D()
	{
		_0023_003Dz9jrlnWk_003D.Clear();
	}

	public void Dispose()
	{
		_0023_003Dz9jrlnWk_003D.Dispose();
		_0023_003Dz9jrlnWk_003D = null;
	}
}
