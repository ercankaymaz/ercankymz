using System;
using System.Diagnostics;
using System.Security.Cryptography;

internal sealed class _0023_003DqSO1PPb7IiakbhH4RNeeJfckHXTcoC3XAxAoJIPsCgCw_003D : DeriveBytes
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private byte[] _0023_003Dz9jrlnWk_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private byte[] _0023_003DzBxpHhQ0_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dztgqm2r4_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly _0023_003DqIedc4fcxHHa89NcW5pVnlnMci0Cax9lt0nG7_0024uk0CZY_003D _0023_003DzzKDx05I_003D = new _0023_003DqIedc4fcxHHa89NcW5pVnlnMci0Cax9lt0nG7_0024uk0CZY_003D();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly byte[] _0023_003Dz3iPku7s_003D;

	public _0023_003DqSO1PPb7IiakbhH4RNeeJfckHXTcoC3XAxAoJIPsCgCw_003D(byte[] _0023_003Dz9jrlnWk_003D, byte[] _0023_003DzBxpHhQ0_003D, int _0023_003Dztgqm2r4_003D)
	{
		if (_0023_003Dz9jrlnWk_003D == null)
		{
			throw new ArgumentNullException(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564314548));
		}
		if (_0023_003DzBxpHhQ0_003D == null)
		{
			throw new ArgumentNullException(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564314553));
		}
		if (_0023_003Dztgqm2r4_003D < 1)
		{
			throw new ArgumentException(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564314542));
		}
		this._0023_003Dz9jrlnWk_003D = (byte[])_0023_003Dz9jrlnWk_003D.Clone();
		this._0023_003DzBxpHhQ0_003D = (byte[])_0023_003DzBxpHhQ0_003D.Clone();
		this._0023_003Dztgqm2r4_003D = _0023_003Dztgqm2r4_003D;
		_0023_003Dz3iPku7s_003D = new byte[_0023_003DzzKDx05I_003D._0023_003Dz7Gt49k61TpSY3Tpx7mYKrXQzcjAfe4HHCQ_003D_003D()];
	}

	private void _0023_003DzCk5um4ZPdD5laAsW8g_003D_003D(byte[] _0023_003Dz9jrlnWk_003D, int _0023_003DzBxpHhQ0_003D, byte[] _0023_003Dztgqm2r4_003D, byte[] _0023_003DzzKDx05I_003D, int _0023_003Dz3iPku7s_003D)
	{
		if (_0023_003Dz9jrlnWk_003D != null)
		{
			this._0023_003DzzKDx05I_003D._0023_003Dz6MpoC0NSv685r8eseTW2pVY35ie2(_0023_003Dz9jrlnWk_003D, 0, _0023_003Dz9jrlnWk_003D.Length);
		}
		this._0023_003DzzKDx05I_003D._0023_003Dz6MpoC0NSv685r8eseTW2pVY35ie2(_0023_003Dztgqm2r4_003D, 0, _0023_003Dztgqm2r4_003D.Length);
		this._0023_003DzzKDx05I_003D._0023_003DzpAD_HMiJYXa_002409D8cXWIaCLdXHsP950twfhGwVc_003D(this._0023_003Dz3iPku7s_003D, 0);
		Buffer.BlockCopy(this._0023_003Dz3iPku7s_003D, 0, _0023_003DzzKDx05I_003D, _0023_003Dz3iPku7s_003D, this._0023_003Dz3iPku7s_003D.Length);
		for (int i = 1; i < _0023_003DzBxpHhQ0_003D; i++)
		{
			this._0023_003DzzKDx05I_003D._0023_003Dz6MpoC0NSv685r8eseTW2pVY35ie2(this._0023_003Dz3iPku7s_003D, 0, this._0023_003Dz3iPku7s_003D.Length);
			this._0023_003DzzKDx05I_003D._0023_003DzpAD_HMiJYXa_002409D8cXWIaCLdXHsP950twfhGwVc_003D(this._0023_003Dz3iPku7s_003D, 0);
			for (int j = 0; j < this._0023_003Dz3iPku7s_003D.Length; j++)
			{
				_0023_003DzzKDx05I_003D[_0023_003Dz3iPku7s_003D + j] ^= this._0023_003Dz3iPku7s_003D[j];
			}
		}
	}

	public override byte[] GetBytes(int _0023_003Dz9jrlnWk_003D)
	{
		int num = _0023_003DzzKDx05I_003D._0023_003Dz7Gt49k61TpSY3Tpx7mYKrXQzcjAfe4HHCQ_003D_003D();
		int num2 = (_0023_003Dz9jrlnWk_003D + num - 1) / num;
		byte[] array = new byte[4];
		byte[] array2 = new byte[num2 * num];
		int num3 = 0;
		_0023_003DzzKDx05I_003D._0023_003Dz8VHD_txvwM3Rxa9zkP_CgBAO52ZJ(this._0023_003Dz9jrlnWk_003D);
		for (int i = 1; i <= num2; i++)
		{
			int num4 = 3;
			while (++array[num4] == 0)
			{
				num4--;
			}
			_0023_003DzCk5um4ZPdD5laAsW8g_003D_003D(_0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D, array, array2, num3);
			num3 += num;
		}
		if (_0023_003Dz9jrlnWk_003D < array2.Length)
		{
			byte[] array3 = new byte[_0023_003Dz9jrlnWk_003D];
			Buffer.BlockCopy(array2, 0, array3, 0, _0023_003Dz9jrlnWk_003D);
			array2 = array3;
		}
		return array2;
	}

	public override void Reset()
	{
		throw new NotSupportedException();
	}
}
