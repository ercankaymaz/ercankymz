using System;
using System.Diagnostics;
using System.Security.Cryptography;

internal sealed class _0023_003DqNRMsnRsOD6zmKIGS86f_zs3pKwjHMtpCJm7D2Hw7UhY_003D : DeriveBytes
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static volatile bool _0023_003Dzq80RbjQ_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DeriveBytes _0023_003DzZzVr6_0024U_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly byte[] _0023_003Dz7hRN5Rg_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly byte[] _0023_003DzcbLoSrg_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly int _0023_003DzqMLoHoQ_003D;

	public _0023_003DqNRMsnRsOD6zmKIGS86f_zs3pKwjHMtpCJm7D2Hw7UhY_003D(byte[] _0023_003Dzq80RbjQ_003D, byte[] _0023_003DzZzVr6_0024U_003D, int _0023_003Dz7hRN5Rg_003D)
	{
		this._0023_003Dz7hRN5Rg_003D = _0023_003Dzq80RbjQ_003D;
		_0023_003DzcbLoSrg_003D = _0023_003DzZzVr6_0024U_003D;
		_0023_003DzqMLoHoQ_003D = _0023_003Dz7hRN5Rg_003D;
		if (!_0023_003DqNRMsnRsOD6zmKIGS86f_zs3pKwjHMtpCJm7D2Hw7UhY_003D._0023_003Dzq80RbjQ_003D)
		{
			try
			{
				this._0023_003DzZzVr6_0024U_003D = new Rfc2898DeriveBytes(_0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D);
			}
			catch
			{
				_0023_003DqNRMsnRsOD6zmKIGS86f_zs3pKwjHMtpCJm7D2Hw7UhY_003D._0023_003Dzq80RbjQ_003D = true;
			}
		}
		if (this._0023_003DzZzVr6_0024U_003D == null)
		{
			this._0023_003DzZzVr6_0024U_003D = new _0023_003DqIedc4fcxHHa89NcW5pVnlq0qVIp9doyuNA81BfJlVlA_003D(_0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D);
		}
	}

	public override byte[] GetBytes(int _0023_003Dzq80RbjQ_003D)
	{
		byte[] array = null;
		if (!_0023_003DqNRMsnRsOD6zmKIGS86f_zs3pKwjHMtpCJm7D2Hw7UhY_003D._0023_003Dzq80RbjQ_003D)
		{
			try
			{
				array = _0023_003DzZzVr6_0024U_003D.GetBytes(_0023_003Dzq80RbjQ_003D);
			}
			catch
			{
				_0023_003DqNRMsnRsOD6zmKIGS86f_zs3pKwjHMtpCJm7D2Hw7UhY_003D._0023_003Dzq80RbjQ_003D = true;
			}
		}
		if (array == null)
		{
			_0023_003DzZzVr6_0024U_003D = new _0023_003DqIedc4fcxHHa89NcW5pVnlq0qVIp9doyuNA81BfJlVlA_003D(_0023_003Dz7hRN5Rg_003D, _0023_003DzcbLoSrg_003D, _0023_003DzqMLoHoQ_003D);
			array = _0023_003DzZzVr6_0024U_003D.GetBytes(_0023_003Dzq80RbjQ_003D);
		}
		return array;
	}

	public override void Reset()
	{
		throw new NotSupportedException();
	}
}
