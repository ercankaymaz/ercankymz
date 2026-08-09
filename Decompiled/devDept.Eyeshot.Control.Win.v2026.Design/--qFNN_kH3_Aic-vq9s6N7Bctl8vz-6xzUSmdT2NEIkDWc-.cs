using System;
using System.Diagnostics;
using System.IO;

internal sealed class _0023_003DqFNN_kH3_Aic_0024vq9s6N7Bctl8vz_00246xzUSmdT2NEIkDWc_003D : Stream
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dz9jrlnWk_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Stream _0023_003DzBxpHhQ0_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003Dqui43Nmvm7VaVj9UVhsQfgdSoEFWRYz4Kfrzyy9RZqhk_003D[] _0023_003Dztgqm2r4_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003Dqi6yIuMh5RevZxwaFpAFM8mHMbXz6O0vAMU_0024CQC_9iM0_003D _0023_003DzzKDx05I_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DqI9SEM_0024xY3_z7xlRX5ZGWoVE3lfkLN_27nmAmcwyTmZc_003D _0023_003Dz3iPku7s_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DqHG1TmG_0024dSF7XquINMc2Zz0W_0024ylD8AkBMmDuMbnL1GJY_003D _0023_003Dz2X8kE24_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzJGsRSpg_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private byte[] _0023_003Dz9I8ZVlc_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzgqvoyJk_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzoEGLyuM_003D;

	public override bool CanRead => true;

	public override bool CanSeek => true;

	public override bool CanWrite => false;

	public override long Length => _0023_003DzBxpHhQ0_003D.Length;

	public override long Position
	{
		get
		{
			return _0023_003DzBxpHhQ0_003D.Position + (_0023_003DzgqvoyJk_003D - _0023_003DzoEGLyuM_003D);
		}
		set
		{
			Seek(value, SeekOrigin.Begin);
		}
	}

	public _0023_003DqFNN_kH3_Aic_0024vq9s6N7Bctl8vz_00246xzUSmdT2NEIkDWc_003D(Stream _0023_003Dz9jrlnWk_003D, _0023_003Dqi6yIuMh5RevZxwaFpAFM8mHMbXz6O0vAMU_0024CQC_9iM0_003D _0023_003DzBxpHhQ0_003D = null, _0023_003DqI9SEM_0024xY3_z7xlRX5ZGWoVE3lfkLN_27nmAmcwyTmZc_003D _0023_003Dztgqm2r4_003D = null, bool _0023_003DzzKDx05I_003D = false)
	{
		this._0023_003DzBxpHhQ0_003D = _0023_003Dz9jrlnWk_003D;
		this._0023_003Dz9jrlnWk_003D = _0023_003DzzKDx05I_003D;
		_0023_003Dz3iPku7s_003D = _0023_003Dztgqm2r4_003D;
		this._0023_003DzzKDx05I_003D = _0023_003DzBxpHhQ0_003D;
		if (this._0023_003DzzKDx05I_003D == null)
		{
			this._0023_003DzzKDx05I_003D = _0023_003Dqi6yIuMh5RevZxwaFpAFM8mHMbXz6O0vAMU_0024CQC_9iM0_003D._0023_003Dz_0024cGq1hU5lcI__0024huiZef0ltCuuQq_0024jW9MpsfRbug_003D();
		}
		if (this._0023_003DzzKDx05I_003D._0023_003DzFT5X_8fID_LcZnSgvtovoxDo8c_nj05YImQJHrk_003D() == 0)
		{
			throw new ArgumentException(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564314608));
		}
		if (this._0023_003DzzKDx05I_003D._0023_003DzXe0qH53BANWl_0024ywTE5053cXUK5v35C_RQQ_003D_003D() == 0)
		{
			throw new ArgumentException(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564314608));
		}
		if (!this._0023_003DzBxpHhQ0_003D.CanRead)
		{
			throw new ArgumentException(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564314591));
		}
		if (!this._0023_003DzBxpHhQ0_003D.CanSeek)
		{
			throw new ArgumentException(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564314591));
		}
	}

	private void _0023_003DzdXvuGrnMHPhGAnoY6k927DjwP8Qe()
	{
		if (!_0023_003DzJGsRSpg_003D)
		{
			_0023_003Dztgqm2r4_003D = new _0023_003Dqui43Nmvm7VaVj9UVhsQfgdSoEFWRYz4Kfrzyy9RZqhk_003D[_0023_003DzzKDx05I_003D._0023_003DzFT5X_8fID_LcZnSgvtovoxDo8c_nj05YImQJHrk_003D()];
			for (int i = 0; i < _0023_003DzzKDx05I_003D._0023_003DzFT5X_8fID_LcZnSgvtovoxDo8c_nj05YImQJHrk_003D(); i++)
			{
				_0023_003Dztgqm2r4_003D[i] = new _0023_003Dqui43Nmvm7VaVj9UVhsQfgdSoEFWRYz4Kfrzyy9RZqhk_003D();
			}
			if (_0023_003Dz3iPku7s_003D != null)
			{
				_0023_003Dz2X8kE24_003D = _0023_003Dz3iPku7s_003D._0023_003DzpLUAflNG_qPsC6OiXxsEpWxFuZxs0q5RmkDYLvE_003D(_0023_003DzzKDx05I_003D);
			}
			_0023_003DzJGsRSpg_003D = true;
		}
	}

	protected override void Dispose(bool _0023_003Dz9jrlnWk_003D)
	{
		try
		{
			if (_0023_003Dz9jrlnWk_003D && !this._0023_003Dz9jrlnWk_003D)
			{
				_0023_003DzBxpHhQ0_003D.Close();
			}
		}
		finally
		{
			base.Dispose(_0023_003Dz9jrlnWk_003D);
		}
	}

	public override void SetLength(long _0023_003Dz9jrlnWk_003D)
	{
		throw new NotSupportedException();
	}

	public override void Write(byte[] _0023_003Dz9jrlnWk_003D, int _0023_003DzBxpHhQ0_003D, int _0023_003Dztgqm2r4_003D)
	{
		throw new NotSupportedException();
	}

	public override void Flush()
	{
	}

	private int _0023_003Dza0i5Hj_IIM5_0024Z_0024cEiNBd_0024s8_003D(byte[] _0023_003Dz9jrlnWk_003D, int _0023_003DzBxpHhQ0_003D, int _0023_003Dztgqm2r4_003D)
	{
		int num = _0023_003DzoEGLyuM_003D - _0023_003DzgqvoyJk_003D;
		if (num <= 0)
		{
			return 0;
		}
		if (num > _0023_003Dztgqm2r4_003D)
		{
			num = _0023_003Dztgqm2r4_003D;
		}
		Buffer.BlockCopy(_0023_003Dz9I8ZVlc_003D, _0023_003DzgqvoyJk_003D, _0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D, num);
		_0023_003DzgqvoyJk_003D += num;
		return num;
	}

	private void _0023_003DzIAZjJisbEhkPQcxpGImVWdw_003D(int _0023_003Dz9jrlnWk_003D)
	{
		int num = (int)_0023_003DzBxpHhQ0_003D.Position;
		if (num >= _0023_003DzBxpHhQ0_003D.Length)
		{
			return;
		}
		int num2 = num + _0023_003Dz9jrlnWk_003D;
		_0023_003Dqui43Nmvm7VaVj9UVhsQfgdSoEFWRYz4Kfrzyy9RZqhk_003D[] array = _0023_003Dztgqm2r4_003D;
		foreach (_0023_003Dqui43Nmvm7VaVj9UVhsQfgdSoEFWRYz4Kfrzyy9RZqhk_003D _0023_003Dqui43Nmvm7VaVj9UVhsQfgdSoEFWRYz4Kfrzyy9RZqhk_003D2 in array)
		{
			if (_0023_003Dqui43Nmvm7VaVj9UVhsQfgdSoEFWRYz4Kfrzyy9RZqhk_003D2._0023_003DzBxpHhQ0_003D <= num && _0023_003Dqui43Nmvm7VaVj9UVhsQfgdSoEFWRYz4Kfrzyy9RZqhk_003D2._0023_003Dztgqm2r4_003D >= num2)
			{
				_0023_003Dz9I8ZVlc_003D = _0023_003Dqui43Nmvm7VaVj9UVhsQfgdSoEFWRYz4Kfrzyy9RZqhk_003D2._0023_003Dz9jrlnWk_003D;
				_0023_003DzoEGLyuM_003D = _0023_003Dqui43Nmvm7VaVj9UVhsQfgdSoEFWRYz4Kfrzyy9RZqhk_003D2._0023_003Dztgqm2r4_003D - _0023_003Dqui43Nmvm7VaVj9UVhsQfgdSoEFWRYz4Kfrzyy9RZqhk_003D2._0023_003DzBxpHhQ0_003D;
				_0023_003DzgqvoyJk_003D = num - _0023_003Dqui43Nmvm7VaVj9UVhsQfgdSoEFWRYz4Kfrzyy9RZqhk_003D2._0023_003DzBxpHhQ0_003D;
				_0023_003DzBxpHhQ0_003D.Position = _0023_003Dqui43Nmvm7VaVj9UVhsQfgdSoEFWRYz4Kfrzyy9RZqhk_003D2._0023_003Dztgqm2r4_003D;
				_0023_003Dqui43Nmvm7VaVj9UVhsQfgdSoEFWRYz4Kfrzyy9RZqhk_003D2._0023_003DzzKDx05I_003D = DateTime.UtcNow;
				return;
			}
		}
		int num3 = 0;
		DateTime dateTime = _0023_003Dztgqm2r4_003D[0]._0023_003DzzKDx05I_003D;
		for (int j = 1; j < _0023_003Dztgqm2r4_003D.Length; j++)
		{
			if (_0023_003Dztgqm2r4_003D[j]._0023_003DzzKDx05I_003D < dateTime)
			{
				num3 = j;
			}
		}
		_0023_003Dqui43Nmvm7VaVj9UVhsQfgdSoEFWRYz4Kfrzyy9RZqhk_003D _0023_003Dqui43Nmvm7VaVj9UVhsQfgdSoEFWRYz4Kfrzyy9RZqhk_003D3 = _0023_003Dztgqm2r4_003D[num3];
		if (_0023_003Dqui43Nmvm7VaVj9UVhsQfgdSoEFWRYz4Kfrzyy9RZqhk_003D3._0023_003Dz9jrlnWk_003D == null)
		{
			_0023_003Dqui43Nmvm7VaVj9UVhsQfgdSoEFWRYz4Kfrzyy9RZqhk_003D3._0023_003Dz9jrlnWk_003D = new byte[_0023_003DzzKDx05I_003D._0023_003DzCnnTB_Y10OJBh1Ahxp7ilwQYsiEJ4g0GYyNti_0024_0024rC0Pu()];
		}
		int num4 = num;
		num = _0023_003DzVzHsjx23KoFOzVVDjikIIj3Ivb8t(num);
		if (num < 0)
		{
			num = 0;
		}
		num2 = num + _0023_003DzzKDx05I_003D._0023_003DzCnnTB_Y10OJBh1Ahxp7ilwQYsiEJ4g0GYyNti_0024_0024rC0Pu();
		if (_0023_003Dz2X8kE24_003D == null || !_0023_003Dz2X8kE24_003D._0023_003DziU9Os_0024Sm7Z5d60l2jeL3Weg_003D(num, ref _0023_003Dqui43Nmvm7VaVj9UVhsQfgdSoEFWRYz4Kfrzyy9RZqhk_003D3))
		{
			_0023_003Dqui43Nmvm7VaVj9UVhsQfgdSoEFWRYz4Kfrzyy9RZqhk_003D3._0023_003DzBxpHhQ0_003D = num;
			_0023_003Dqui43Nmvm7VaVj9UVhsQfgdSoEFWRYz4Kfrzyy9RZqhk_003D3._0023_003DzzKDx05I_003D = DateTime.UtcNow;
			_0023_003Dz9I8ZVlc_003D = _0023_003Dqui43Nmvm7VaVj9UVhsQfgdSoEFWRYz4Kfrzyy9RZqhk_003D3._0023_003Dz9jrlnWk_003D;
			_0023_003DzBxpHhQ0_003D.Position = num;
			_0023_003DzoEGLyuM_003D = _0023_003DzBxpHhQ0_003D.Read(_0023_003Dz9I8ZVlc_003D, 0, num2 - num);
			_0023_003DzgqvoyJk_003D = num4 - num;
			_0023_003Dqui43Nmvm7VaVj9UVhsQfgdSoEFWRYz4Kfrzyy9RZqhk_003D3._0023_003Dztgqm2r4_003D = num + _0023_003DzoEGLyuM_003D;
			if (_0023_003Dz2X8kE24_003D != null)
			{
				_0023_003Dz2X8kE24_003D._0023_003Dz_0024D1AxkDshZ6_0024e9arVLEUc9k_003D(_0023_003Dqui43Nmvm7VaVj9UVhsQfgdSoEFWRYz4Kfrzyy9RZqhk_003D3);
			}
		}
		else
		{
			_0023_003Dz9I8ZVlc_003D = _0023_003Dqui43Nmvm7VaVj9UVhsQfgdSoEFWRYz4Kfrzyy9RZqhk_003D3._0023_003Dz9jrlnWk_003D;
			_0023_003DzoEGLyuM_003D = _0023_003Dqui43Nmvm7VaVj9UVhsQfgdSoEFWRYz4Kfrzyy9RZqhk_003D3._0023_003Dztgqm2r4_003D - num;
			_0023_003DzBxpHhQ0_003D.Position = _0023_003Dqui43Nmvm7VaVj9UVhsQfgdSoEFWRYz4Kfrzyy9RZqhk_003D3._0023_003Dztgqm2r4_003D;
			_0023_003DzgqvoyJk_003D = num4 - num;
		}
	}

	private int _0023_003DzVzHsjx23KoFOzVVDjikIIj3Ivb8t(int _0023_003Dz9jrlnWk_003D)
	{
		return _0023_003Dz9jrlnWk_003D - _0023_003Dz9jrlnWk_003D % _0023_003DzzKDx05I_003D._0023_003DzCnnTB_Y10OJBh1Ahxp7ilwQYsiEJ4g0GYyNti_0024_0024rC0Pu();
	}

	public override int Read(byte[] _0023_003Dz9jrlnWk_003D, int _0023_003DzBxpHhQ0_003D, int _0023_003Dztgqm2r4_003D)
	{
		if (_0023_003Dz9jrlnWk_003D == null)
		{
			throw new ArgumentNullException(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564314562));
		}
		if (_0023_003DzBxpHhQ0_003D < 0)
		{
			throw new ArgumentOutOfRangeException(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564314423));
		}
		if (_0023_003Dztgqm2r4_003D < 0)
		{
			throw new ArgumentOutOfRangeException(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564314428));
		}
		if (_0023_003Dz9jrlnWk_003D.Length - _0023_003DzBxpHhQ0_003D < _0023_003Dztgqm2r4_003D)
		{
			throw new ArgumentException();
		}
		int num = _0023_003DzBxpHhQ0_003D;
		int num2 = _0023_003Dza0i5Hj_IIM5_0024Z_0024cEiNBd_0024s8_003D(_0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D);
		if (num2 == _0023_003Dztgqm2r4_003D)
		{
			return num2;
		}
		int num3 = num2;
		if (num2 > 0)
		{
			_0023_003Dztgqm2r4_003D -= num2;
			_0023_003DzBxpHhQ0_003D += num2;
		}
		_0023_003DzgqvoyJk_003D = (_0023_003DzoEGLyuM_003D = 0);
		_0023_003DzdXvuGrnMHPhGAnoY6k927DjwP8Qe();
		if (_0023_003Dztgqm2r4_003D >= _0023_003DzzKDx05I_003D._0023_003DzCnnTB_Y10OJBh1Ahxp7ilwQYsiEJ4g0GYyNti_0024_0024rC0Pu())
		{
			if (_0023_003Dz2X8kE24_003D == null)
			{
				return this._0023_003DzBxpHhQ0_003D.Read(_0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D) + num3;
			}
			int num4 = (int)this._0023_003DzBxpHhQ0_003D.Position - num3;
			if (_0023_003Dz2X8kE24_003D._0023_003DzEHMP5140oWDmxpy_00242w_003D_003D(num4, _0023_003Dz9jrlnWk_003D, num, _0023_003Dztgqm2r4_003D + num3, out var num5))
			{
				this._0023_003DzBxpHhQ0_003D.Seek(num5 - num3, SeekOrigin.Current);
				return num5;
			}
			num5 = this._0023_003DzBxpHhQ0_003D.Read(_0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D);
			if (num5 != 0)
			{
				_0023_003Dz2X8kE24_003D._0023_003DzKmBa5euqFvoK4f_8JPMlCh0e86WvQ83wMfGDuoM_003D(num4, _0023_003Dz9jrlnWk_003D, num, num5 + num3, num5 < _0023_003Dztgqm2r4_003D);
			}
			return num5 + num3;
		}
		_0023_003DzIAZjJisbEhkPQcxpGImVWdw_003D(_0023_003Dztgqm2r4_003D);
		num2 = _0023_003Dza0i5Hj_IIM5_0024Z_0024cEiNBd_0024s8_003D(_0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D);
		return num2 + num3;
	}

	public override long Seek(long _0023_003Dz9jrlnWk_003D, SeekOrigin _0023_003DzBxpHhQ0_003D)
	{
		if (_0023_003DzoEGLyuM_003D - _0023_003DzgqvoyJk_003D > 0 && _0023_003DzBxpHhQ0_003D == SeekOrigin.Current)
		{
			_0023_003Dz9jrlnWk_003D -= _0023_003DzoEGLyuM_003D - _0023_003DzgqvoyJk_003D;
		}
		long position = Position;
		long num = this._0023_003DzBxpHhQ0_003D.Seek(_0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D);
		_0023_003DzgqvoyJk_003D = (int)(num - (position - _0023_003DzgqvoyJk_003D));
		if (0 <= _0023_003DzgqvoyJk_003D && _0023_003DzgqvoyJk_003D < _0023_003DzoEGLyuM_003D)
		{
			this._0023_003DzBxpHhQ0_003D.Seek(_0023_003DzoEGLyuM_003D - _0023_003DzgqvoyJk_003D, SeekOrigin.Current);
		}
		else
		{
			_0023_003DzgqvoyJk_003D = (_0023_003DzoEGLyuM_003D = 0);
		}
		return num;
	}
}
