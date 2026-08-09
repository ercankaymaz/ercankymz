using System;
using System.Diagnostics;
using System.Security.Cryptography;

internal sealed class _0023_003DqIedc4fcxHHa89NcW5pVnlq0qVIp9doyuNA81BfJlVlA_003D : DeriveBytes
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private byte[] _0023_003Dzq80RbjQ_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private byte[] _0023_003DzZzVr6_0024U_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dz7hRN5Rg_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly _0023_003Dq14OGuS53TTgJXN5XHcnlTH7lEFCviV4ypfAj3Btr3U4_003D _0023_003DzcbLoSrg_003D = new _0023_003Dq14OGuS53TTgJXN5XHcnlTH7lEFCviV4ypfAj3Btr3U4_003D();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly byte[] _0023_003DzqMLoHoQ_003D;

	public _0023_003DqIedc4fcxHHa89NcW5pVnlq0qVIp9doyuNA81BfJlVlA_003D(byte[] _0023_003Dzq80RbjQ_003D, byte[] _0023_003DzZzVr6_0024U_003D, int _0023_003Dz7hRN5Rg_003D)
	{
		if (_0023_003Dzq80RbjQ_003D == null)
		{
			throw new ArgumentNullException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355525930));
		}
		if (_0023_003DzZzVr6_0024U_003D == null)
		{
			throw new ArgumentNullException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355525921));
		}
		if (_0023_003Dz7hRN5Rg_003D < 1)
		{
			throw new ArgumentException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355525940));
		}
		this._0023_003Dzq80RbjQ_003D = (byte[])_0023_003Dzq80RbjQ_003D.Clone();
		this._0023_003DzZzVr6_0024U_003D = (byte[])_0023_003DzZzVr6_0024U_003D.Clone();
		this._0023_003Dz7hRN5Rg_003D = _0023_003Dz7hRN5Rg_003D;
		_0023_003DzqMLoHoQ_003D = new byte[_0023_003DzcbLoSrg_003D._0023_003DzKcikuoC5eR1keRj9CKGlb4pEoGd2j1rvuA_003D_003D()];
	}

	private void _0023_003DzjYb_0024U_0024LDVRRgp3y_00241w_003D_003D(byte[] _0023_003Dzq80RbjQ_003D, int _0023_003DzZzVr6_0024U_003D, byte[] _0023_003Dz7hRN5Rg_003D, byte[] _0023_003DzcbLoSrg_003D, int _0023_003DzqMLoHoQ_003D)
	{
		if (_0023_003Dzq80RbjQ_003D != null)
		{
			this._0023_003DzcbLoSrg_003D._0023_003Dzrf6Sibb_0024mJaQk6gpqUQw_sx8wqzt(_0023_003Dzq80RbjQ_003D, 0, _0023_003Dzq80RbjQ_003D.Length);
		}
		this._0023_003DzcbLoSrg_003D._0023_003Dzrf6Sibb_0024mJaQk6gpqUQw_sx8wqzt(_0023_003Dz7hRN5Rg_003D, 0, _0023_003Dz7hRN5Rg_003D.Length);
		this._0023_003DzcbLoSrg_003D._0023_003Dz7PxTZfYfLu2v1xr9TQ_002432h_3FCfV3W_00245QJYWwkw_003D(this._0023_003DzqMLoHoQ_003D, 0);
		Buffer.BlockCopy(this._0023_003DzqMLoHoQ_003D, 0, _0023_003DzcbLoSrg_003D, _0023_003DzqMLoHoQ_003D, this._0023_003DzqMLoHoQ_003D.Length);
		for (int i = 1; i < _0023_003DzZzVr6_0024U_003D; i++)
		{
			this._0023_003DzcbLoSrg_003D._0023_003Dzrf6Sibb_0024mJaQk6gpqUQw_sx8wqzt(this._0023_003DzqMLoHoQ_003D, 0, this._0023_003DzqMLoHoQ_003D.Length);
			this._0023_003DzcbLoSrg_003D._0023_003Dz7PxTZfYfLu2v1xr9TQ_002432h_3FCfV3W_00245QJYWwkw_003D(this._0023_003DzqMLoHoQ_003D, 0);
			for (int j = 0; j < this._0023_003DzqMLoHoQ_003D.Length; j++)
			{
				_0023_003DzcbLoSrg_003D[_0023_003DzqMLoHoQ_003D + j] ^= this._0023_003DzqMLoHoQ_003D[j];
			}
		}
	}

	public override byte[] GetBytes(int _0023_003Dzq80RbjQ_003D)
	{
		int num = _0023_003DzcbLoSrg_003D._0023_003DzKcikuoC5eR1keRj9CKGlb4pEoGd2j1rvuA_003D_003D();
		int num2 = (_0023_003Dzq80RbjQ_003D + num - 1) / num;
		byte[] array = new byte[4];
		byte[] array2 = new byte[num2 * num];
		int num3 = 0;
		_0023_003DzcbLoSrg_003D._0023_003DzuSorB264RUaFBSXxgyEIfVCBJsbY(this._0023_003Dzq80RbjQ_003D);
		for (int i = 1; i <= num2; i++)
		{
			int num4 = 3;
			while (++array[num4] == 0)
			{
				num4--;
			}
			_0023_003DzjYb_0024U_0024LDVRRgp3y_00241w_003D_003D(_0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D, array, array2, num3);
			num3 += num;
		}
		if (_0023_003Dzq80RbjQ_003D < array2.Length)
		{
			byte[] array3 = new byte[_0023_003Dzq80RbjQ_003D];
			Buffer.BlockCopy(array2, 0, array3, 0, _0023_003Dzq80RbjQ_003D);
			array2 = array3;
		}
		return array2;
	}

	public override void Reset()
	{
		throw new NotSupportedException();
	}
}
