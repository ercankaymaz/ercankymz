using System;
using System.Diagnostics;
using System.Security.Cryptography;

internal sealed class _0023_003Dq6tS8rMV1rGswJPasZDHd79p3grccgecsUnZJdkolocw_003D : _0023_003Dq0So1GxeA2gcAh9TgG0D5iRLBp4QH4jd23GXkACbQhtA_003D, IDisposable
{
	private sealed class _0023_003Dz9jrlnWk_003D
	{
		public bool _0023_003Dz9jrlnWk_003D;

		public _0023_003Dq0So1GxeA2gcAh9TgG0D5iRLBp4QH4jd23GXkACbQhtA_003D _0023_003DzBxpHhQ0_003D;
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly _0023_003Dqui43Nmvm7VaVj9UVhsQfgafHFw2npJeQZBP1tnfzCjs_003D m__0023_003Dz9jrlnWk_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly bool _0023_003DzBxpHhQ0_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly bool _0023_003Dztgqm2r4_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly int _0023_003DzzKDx05I_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly int _0023_003Dz3iPku7s_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003Dz9jrlnWk_003D _0023_003Dz2X8kE24_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzJGsRSpg_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly object _0023_003Dz9I8ZVlc_003D = new object();

	public _0023_003Dq6tS8rMV1rGswJPasZDHd79p3grccgecsUnZJdkolocw_003D(bool _0023_003Dz9jrlnWk_003D, _0023_003Dqui43Nmvm7VaVj9UVhsQfgafHFw2npJeQZBP1tnfzCjs_003D _0023_003DzBxpHhQ0_003D, bool _0023_003Dztgqm2r4_003D = false)
	{
		this._0023_003DzBxpHhQ0_003D = _0023_003Dz9jrlnWk_003D;
		this.m__0023_003Dz9jrlnWk_003D = _0023_003DzBxpHhQ0_003D;
		this._0023_003Dztgqm2r4_003D = _0023_003Dztgqm2r4_003D;
		this._0023_003Dztgqm2r4_003D = true;
		int num = _0023_003DzBxpHhQ0_003D._0023_003Dz5Rvu8ZA7TJh9kOvLOX1Cbc_0024LnmiTt7loje_0024farg_003D()._0023_003DzhjsWiuTa0xY3eqkuH8lleW27VAlN();
		_0023_003DzzKDx05I_003D = _0023_003Dzf1YJOhUzBH8mX__WEoMGWqU51xReoJN8a7zQayU_003D(num, _0023_003Dz9jrlnWk_003D);
		_0023_003Dz3iPku7s_003D = _0023_003DzYdMlG7gl_C3LDz_ahvnfLlA_003D(num, _0023_003Dz9jrlnWk_003D);
	}

	public bool _0023_003DzGsIvs9WJkp3mAOjK83j9CB1lRhmt6LIbhcQDXmTKocSs()
	{
		return _0023_003DzBxpHhQ0_003D;
	}

	private static int _0023_003Dzf1YJOhUzBH8mX__WEoMGWqU51xReoJN8a7zQayU_003D(int _0023_003Dz9jrlnWk_003D, bool _0023_003DzBxpHhQ0_003D)
	{
		if (!_0023_003DzBxpHhQ0_003D)
		{
			return (_0023_003Dz9jrlnWk_003D + 7) / 8;
		}
		return (_0023_003Dz9jrlnWk_003D - 1) / 8;
	}

	private static int _0023_003DzYdMlG7gl_C3LDz_ahvnfLlA_003D(int _0023_003Dz9jrlnWk_003D, bool _0023_003DzBxpHhQ0_003D)
	{
		if (!_0023_003DzBxpHhQ0_003D)
		{
			return (_0023_003Dz9jrlnWk_003D - 1) / 8;
		}
		return (_0023_003Dz9jrlnWk_003D + 7) / 8;
	}

	public int _0023_003DzRUaRf1_0024uXCd_0024014IgyPFGQ1WhzdakNCGTidf3nBX4zF3OwW0KT0ZmzkEoZUFoCJ2InG3qf_002466q8cxaPSHFzfr5g_003D(byte[] _0023_003Dz9jrlnWk_003D, int _0023_003DzBxpHhQ0_003D, int _0023_003Dztgqm2r4_003D, byte[] _0023_003DzzKDx05I_003D, int _0023_003Dz3iPku7s_003D, RandomNumberGenerator _0023_003Dz2X8kE24_003D)
	{
		_0023_003Dz5_00243kQdiB991Sh5Ax2e0K2AolEU6o();
		_0023_003Dz9jrlnWk_003D _0023_003Dz9jrlnWk_003D2 = this._0023_003Dz2X8kE24_003D;
		try
		{
			return _0023_003Dz9jrlnWk_003D2._0023_003DzBxpHhQ0_003D._0023_003DzRUaRf1_0024uXCd_0024014IgyPFGQ1WhzdakNCGTidf3nBX4zF3OwW0KT0ZmzkEoZUFoCJ2InG3qf_002466q8cxaPSHFzfr5g_003D(_0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D, _0023_003DzzKDx05I_003D, _0023_003Dz3iPku7s_003D, _0023_003Dz2X8kE24_003D);
		}
		catch when (_0023_003Dz9jrlnWk_003D2._0023_003Dz9jrlnWk_003D)
		{
			_0023_003Dz1jDnZTevDTEmxNvHFYx8VEs_003D();
			_0023_003Dz9jrlnWk_003D2 = this._0023_003Dz2X8kE24_003D;
			return _0023_003Dz9jrlnWk_003D2._0023_003DzBxpHhQ0_003D._0023_003DzRUaRf1_0024uXCd_0024014IgyPFGQ1WhzdakNCGTidf3nBX4zF3OwW0KT0ZmzkEoZUFoCJ2InG3qf_002466q8cxaPSHFzfr5g_003D(_0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D, _0023_003DzzKDx05I_003D, _0023_003Dz3iPku7s_003D, _0023_003Dz2X8kE24_003D);
		}
	}

	private void _0023_003Dz1jDnZTevDTEmxNvHFYx8VEs_003D()
	{
		lock (_0023_003Dz9I8ZVlc_003D)
		{
			_0023_003Dz9jrlnWk_003D _0023_003Dz9jrlnWk_003D2 = _0023_003Dz2X8kE24_003D;
			if (!_0023_003Dz9jrlnWk_003D2._0023_003Dz9jrlnWk_003D)
			{
				return;
			}
			try
			{
				if (_0023_003Dz9jrlnWk_003D2._0023_003DzBxpHhQ0_003D is IDisposable disposable)
				{
					disposable.Dispose();
				}
			}
			catch
			{
			}
			_0023_003Dq0So1GxeA2gcAh9TgG0D5iRLBp4QH4jd23GXkACbQhtA_003D _0023_003Dq0So1GxeA2gcAh9TgG0D5iRLBp4QH4jd23GXkACbQhtA_003D2 = _0023_003DzOwUyFmlUGigNZDaPXddq_YHM4OIcn2fYmAy4k2S4Wy4upLJlvFzNpPgBDU0wqymG4VOsBr3LGw7Dkx__kJBJ_Vc_003D(_0023_003DzBxpHhQ0_003D, this.m__0023_003Dz9jrlnWk_003D);
			if (_0023_003Dq0So1GxeA2gcAh9TgG0D5iRLBp4QH4jd23GXkACbQhtA_003D2 == null)
			{
				throw new InvalidOperationException();
			}
			_0023_003Dz2X8kE24_003D = new _0023_003Dz9jrlnWk_003D
			{
				_0023_003Dz9jrlnWk_003D = false,
				_0023_003DzBxpHhQ0_003D = _0023_003Dq0So1GxeA2gcAh9TgG0D5iRLBp4QH4jd23GXkACbQhtA_003D2
			};
		}
	}

	private void _0023_003Dz5_00243kQdiB991Sh5Ax2e0K2AolEU6o()
	{
		if (_0023_003DzJGsRSpg_003D)
		{
			return;
		}
		lock (_0023_003Dz9I8ZVlc_003D)
		{
			if (_0023_003DzJGsRSpg_003D)
			{
				return;
			}
			_0023_003Dq0So1GxeA2gcAh9TgG0D5iRLBp4QH4jd23GXkACbQhtA_003D _0023_003Dq0So1GxeA2gcAh9TgG0D5iRLBp4QH4jd23GXkACbQhtA_003D2;
			if (!_0023_003Dztgqm2r4_003D && (_0023_003Dq0So1GxeA2gcAh9TgG0D5iRLBp4QH4jd23GXkACbQhtA_003D2 = _0023_003DzKZEAkmiLPFWe2hwOqghYi8S8Wim3CbK15S_308IL8bdCImmEZkYdCZOoxB0uprf9aZxx_igixSTVmSMAXI_0024KA1Y_003D(_0023_003DzBxpHhQ0_003D, this.m__0023_003Dz9jrlnWk_003D)) != null)
			{
				_0023_003Dz2X8kE24_003D = new _0023_003Dz9jrlnWk_003D
				{
					_0023_003Dz9jrlnWk_003D = true,
					_0023_003DzBxpHhQ0_003D = _0023_003Dq0So1GxeA2gcAh9TgG0D5iRLBp4QH4jd23GXkACbQhtA_003D2
				};
			}
			else
			{
				_0023_003Dq0So1GxeA2gcAh9TgG0D5iRLBp4QH4jd23GXkACbQhtA_003D2 = _0023_003DzOwUyFmlUGigNZDaPXddq_YHM4OIcn2fYmAy4k2S4Wy4upLJlvFzNpPgBDU0wqymG4VOsBr3LGw7Dkx__kJBJ_Vc_003D(_0023_003DzBxpHhQ0_003D, this.m__0023_003Dz9jrlnWk_003D);
				if (_0023_003Dq0So1GxeA2gcAh9TgG0D5iRLBp4QH4jd23GXkACbQhtA_003D2 == null)
				{
					throw new InvalidOperationException();
				}
				_0023_003Dz2X8kE24_003D = new _0023_003Dz9jrlnWk_003D
				{
					_0023_003Dz9jrlnWk_003D = false,
					_0023_003DzBxpHhQ0_003D = _0023_003Dq0So1GxeA2gcAh9TgG0D5iRLBp4QH4jd23GXkACbQhtA_003D2
				};
			}
			_0023_003DzJGsRSpg_003D = true;
		}
	}

	protected virtual _0023_003Dq0So1GxeA2gcAh9TgG0D5iRLBp4QH4jd23GXkACbQhtA_003D _0023_003DzOwUyFmlUGigNZDaPXddq_YHM4OIcn2fYmAy4k2S4Wy4upLJlvFzNpPgBDU0wqymG4VOsBr3LGw7Dkx__kJBJ_Vc_003D(bool _0023_003Dz9jrlnWk_003D, _0023_003Dqui43Nmvm7VaVj9UVhsQfgafHFw2npJeQZBP1tnfzCjs_003D _0023_003DzBxpHhQ0_003D)
	{
		return new _0023_003DqER3f_gxDAqhvJuR_0024dnNr_fhBRFu_00244Oabifg8Lc7nXeQ_003D(_0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D);
	}

	protected virtual _0023_003Dq0So1GxeA2gcAh9TgG0D5iRLBp4QH4jd23GXkACbQhtA_003D _0023_003DzKZEAkmiLPFWe2hwOqghYi8S8Wim3CbK15S_308IL8bdCImmEZkYdCZOoxB0uprf9aZxx_igixSTVmSMAXI_0024KA1Y_003D(bool _0023_003Dz9jrlnWk_003D, _0023_003Dqui43Nmvm7VaVj9UVhsQfgafHFw2npJeQZBP1tnfzCjs_003D _0023_003DzBxpHhQ0_003D)
	{
		return _0023_003Dqi8YNSAnTImltsLBegHZ98_p96RNMgiTXhVf_5HaCM14_003D._0023_003Dz4RfGhVt41ontKf9PHhjW3_0024a_0024tXCcr2cGgAA4it8_003D(_0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D);
	}

	public void Dispose()
	{
		if (_0023_003Dz2X8kE24_003D?._0023_003DzBxpHhQ0_003D is IDisposable disposable)
		{
			disposable.Dispose();
			_0023_003Dz2X8kE24_003D = null;
		}
	}
}
