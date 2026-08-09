using System;
using System.Diagnostics;
using System.Security.Cryptography;

internal sealed class _0023_003Dqr_0024moDzrF9M_yY31eccEmV1DOGGPE8QpIAk9F3sfGmw8_003D : DeriveBytes
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static volatile bool _0023_003DzjYYAPCA_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DeriveBytes _0023_003DzVC9FBdo_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly byte[] _0023_003DzwBouG0w_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly byte[] _0023_003Dzf4Pqh9s_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly int _0023_003DzTFNDoh0_003D;

	public _0023_003Dqr_0024moDzrF9M_yY31eccEmV1DOGGPE8QpIAk9F3sfGmw8_003D(byte[] _0023_003DzjYYAPCA_003D, byte[] _0023_003DzVC9FBdo_003D, int _0023_003DzwBouG0w_003D)
	{
		this._0023_003DzwBouG0w_003D = _0023_003DzjYYAPCA_003D;
		_0023_003Dzf4Pqh9s_003D = _0023_003DzVC9FBdo_003D;
		_0023_003DzTFNDoh0_003D = _0023_003DzwBouG0w_003D;
		if (!_0023_003Dqr_0024moDzrF9M_yY31eccEmV1DOGGPE8QpIAk9F3sfGmw8_003D._0023_003DzjYYAPCA_003D)
		{
			try
			{
				this._0023_003DzVC9FBdo_003D = new Rfc2898DeriveBytes(_0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D);
			}
			catch
			{
				_0023_003Dqr_0024moDzrF9M_yY31eccEmV1DOGGPE8QpIAk9F3sfGmw8_003D._0023_003DzjYYAPCA_003D = true;
			}
		}
		if (this._0023_003DzVC9FBdo_003D == null)
		{
			this._0023_003DzVC9FBdo_003D = new _0023_003DqJFdrGiwz1aJICVkSTb_0024ZktpCJr5B2Uz8l2Rb07Om7mo_003D(_0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D);
		}
	}

	public override byte[] GetBytes(int _0023_003DzjYYAPCA_003D)
	{
		byte[] array = null;
		if (!_0023_003Dqr_0024moDzrF9M_yY31eccEmV1DOGGPE8QpIAk9F3sfGmw8_003D._0023_003DzjYYAPCA_003D)
		{
			try
			{
				array = _0023_003DzVC9FBdo_003D.GetBytes(_0023_003DzjYYAPCA_003D);
			}
			catch
			{
				_0023_003Dqr_0024moDzrF9M_yY31eccEmV1DOGGPE8QpIAk9F3sfGmw8_003D._0023_003DzjYYAPCA_003D = true;
			}
		}
		if (array == null)
		{
			_0023_003DzVC9FBdo_003D = new _0023_003DqJFdrGiwz1aJICVkSTb_0024ZktpCJr5B2Uz8l2Rb07Om7mo_003D(_0023_003DzwBouG0w_003D, _0023_003Dzf4Pqh9s_003D, _0023_003DzTFNDoh0_003D);
			array = _0023_003DzVC9FBdo_003D.GetBytes(_0023_003DzjYYAPCA_003D);
		}
		return array;
	}

	public override void Reset()
	{
		throw new NotSupportedException();
	}
}
