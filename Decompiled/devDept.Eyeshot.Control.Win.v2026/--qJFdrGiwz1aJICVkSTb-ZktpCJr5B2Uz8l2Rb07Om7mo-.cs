using System;
using System.Diagnostics;
using System.Security.Cryptography;

internal sealed class _0023_003DqJFdrGiwz1aJICVkSTb_0024ZktpCJr5B2Uz8l2Rb07Om7mo_003D : DeriveBytes
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private byte[] _0023_003DzjYYAPCA_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private byte[] _0023_003DzVC9FBdo_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzwBouG0w_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly _0023_003Dq6BQK4POmdQSdOG1gXvn7D1c7lcSPRiGjLHf1iP0_0024zfs_003D _0023_003Dzf4Pqh9s_003D = new _0023_003Dq6BQK4POmdQSdOG1gXvn7D1c7lcSPRiGjLHf1iP0_0024zfs_003D();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly byte[] _0023_003DzTFNDoh0_003D;

	public _0023_003DqJFdrGiwz1aJICVkSTb_0024ZktpCJr5B2Uz8l2Rb07Om7mo_003D(byte[] _0023_003DzjYYAPCA_003D, byte[] _0023_003DzVC9FBdo_003D, int _0023_003DzwBouG0w_003D)
	{
		if (_0023_003DzjYYAPCA_003D == null)
		{
			throw new ArgumentNullException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348621451));
		}
		if (_0023_003DzVC9FBdo_003D == null)
		{
			throw new ArgumentNullException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348621440));
		}
		if (_0023_003DzwBouG0w_003D < 1)
		{
			throw new ArgumentException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348621461));
		}
		this._0023_003DzjYYAPCA_003D = (byte[])_0023_003DzjYYAPCA_003D.Clone();
		this._0023_003DzVC9FBdo_003D = (byte[])_0023_003DzVC9FBdo_003D.Clone();
		this._0023_003DzwBouG0w_003D = _0023_003DzwBouG0w_003D;
		_0023_003DzTFNDoh0_003D = new byte[_0023_003Dzf4Pqh9s_003D._0023_003DzU79fzYO2wTRg_Z1G3ppStY4R_EYVAB3QjA_003D_003D()];
	}

	private void _0023_003DzfSdynaXSZTGto_0024DQ3A_003D_003D(byte[] _0023_003DzjYYAPCA_003D, int _0023_003DzVC9FBdo_003D, byte[] _0023_003DzwBouG0w_003D, byte[] _0023_003Dzf4Pqh9s_003D, int _0023_003DzTFNDoh0_003D)
	{
		if (_0023_003DzjYYAPCA_003D != null)
		{
			this._0023_003Dzf4Pqh9s_003D._0023_003Dzvxsz596AqRsOm2wzJFMmi_XRIqHx(_0023_003DzjYYAPCA_003D, 0, _0023_003DzjYYAPCA_003D.Length);
		}
		this._0023_003Dzf4Pqh9s_003D._0023_003Dzvxsz596AqRsOm2wzJFMmi_XRIqHx(_0023_003DzwBouG0w_003D, 0, _0023_003DzwBouG0w_003D.Length);
		this._0023_003Dzf4Pqh9s_003D._0023_003DzpHeDaocixpr8f8xgOCIOfJnLVMBmtdPyX5ydLIA_003D(this._0023_003DzTFNDoh0_003D, 0);
		Buffer.BlockCopy(this._0023_003DzTFNDoh0_003D, 0, _0023_003Dzf4Pqh9s_003D, _0023_003DzTFNDoh0_003D, this._0023_003DzTFNDoh0_003D.Length);
		for (int i = 1; i < _0023_003DzVC9FBdo_003D; i++)
		{
			this._0023_003Dzf4Pqh9s_003D._0023_003Dzvxsz596AqRsOm2wzJFMmi_XRIqHx(this._0023_003DzTFNDoh0_003D, 0, this._0023_003DzTFNDoh0_003D.Length);
			this._0023_003Dzf4Pqh9s_003D._0023_003DzpHeDaocixpr8f8xgOCIOfJnLVMBmtdPyX5ydLIA_003D(this._0023_003DzTFNDoh0_003D, 0);
			for (int j = 0; j < this._0023_003DzTFNDoh0_003D.Length; j++)
			{
				_0023_003Dzf4Pqh9s_003D[_0023_003DzTFNDoh0_003D + j] ^= this._0023_003DzTFNDoh0_003D[j];
			}
		}
	}

	public override byte[] GetBytes(int _0023_003DzjYYAPCA_003D)
	{
		int num = _0023_003Dzf4Pqh9s_003D._0023_003DzU79fzYO2wTRg_Z1G3ppStY4R_EYVAB3QjA_003D_003D();
		int num2 = (_0023_003DzjYYAPCA_003D + num - 1) / num;
		byte[] array = new byte[4];
		byte[] array2 = new byte[num2 * num];
		int num3 = 0;
		_0023_003Dzf4Pqh9s_003D._0023_003DzJ6w4_yQxJgEcnaM2ZJ_0024NrNaY3JEt(this._0023_003DzjYYAPCA_003D);
		for (int i = 1; i <= num2; i++)
		{
			int num4 = 3;
			while (++array[num4] == 0)
			{
				num4--;
			}
			_0023_003DzfSdynaXSZTGto_0024DQ3A_003D_003D(_0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D, array, array2, num3);
			num3 += num;
		}
		if (_0023_003DzjYYAPCA_003D < array2.Length)
		{
			byte[] array3 = new byte[_0023_003DzjYYAPCA_003D];
			Buffer.BlockCopy(array2, 0, array3, 0, _0023_003DzjYYAPCA_003D);
			array2 = array3;
		}
		return array2;
	}

	public override void Reset()
	{
		throw new NotSupportedException();
	}
}
