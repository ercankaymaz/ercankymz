using System;
using System.Diagnostics;
using System.IO;

internal sealed class _0023_003Dqxz2l2ec27m48r7iCFJ2Fx4FB0NtDBy3DfBma7MF_V08_003D : Stream
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dz9jrlnWk_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzBxpHhQ0_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dztgqm2r4_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Stream _0023_003DzzKDx05I_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003Dq0So1GxeA2gcAh9TgG0D5iRLBp4QH4jd23GXkACbQhtA_003D _0023_003Dz3iPku7s_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dz2X8kE24_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzJGsRSpg_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dz9I8ZVlc_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzgqvoyJk_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private byte[] _0023_003DzoEGLyuM_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DziiEv3wQ_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private byte[] _0023_003DzJ6W8874_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzAndD6oU_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzbSmUaeo_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzaTyQZ6E_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzLi0XoCY_003D;

	public override bool CanRead => true;

	public override bool CanSeek => true;

	public override bool CanWrite => false;

	public override long Length
	{
		get
		{
			_0023_003Dz5wv25SJj4k7NNKKwalaf5N4S7pR3O2zRbBnQZw0_003D();
			return _0023_003Dz9jrlnWk_003D;
		}
	}

	public override long Position
	{
		get
		{
			return _0023_003Dz2X8kE24_003D * _0023_003DzaTyQZ6E_003D + _0023_003DzbSmUaeo_003D;
		}
		set
		{
			int num = (int)value / _0023_003DzaTyQZ6E_003D;
			_0023_003DzbSmUaeo_003D = (int)value % _0023_003DzaTyQZ6E_003D;
			if (_0023_003Dz2X8kE24_003D != num)
			{
				_0023_003Dz2X8kE24_003D = num;
				_0023_003DzgqvoyJk_003D = true;
				_0023_003DzJGsRSpg_003D = false;
			}
		}
	}

	public _0023_003Dqxz2l2ec27m48r7iCFJ2Fx4FB0NtDBy3DfBma7MF_V08_003D(Stream _0023_003Dz9jrlnWk_003D, _0023_003Dq0So1GxeA2gcAh9TgG0D5iRLBp4QH4jd23GXkACbQhtA_003D _0023_003DzBxpHhQ0_003D)
	{
		if (_0023_003Dz9jrlnWk_003D == null)
		{
			throw new ArgumentNullException(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564314591));
		}
		if (_0023_003DzBxpHhQ0_003D == null)
		{
			throw new ArgumentNullException(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564311984));
		}
		_0023_003DzzKDx05I_003D = _0023_003Dz9jrlnWk_003D;
		_0023_003Dz3iPku7s_003D = _0023_003DzBxpHhQ0_003D;
		if (_0023_003DzzKDx05I_003D.Length < 4)
		{
			throw new InvalidOperationException();
		}
		_0023_003DzvAoZpnjLiwKIf_0024oaTj7_0024TGDNUujlvJHXFJ7039g_003D();
	}

	private void _0023_003DzvAoZpnjLiwKIf_0024oaTj7_0024TGDNUujlvJHXFJ7039g_003D()
	{
		_0023_003DziiEv3wQ_003D = _0023_003Dz3iPku7s_003D._0023_003Dzl3Rckx5OVe4f3GM0WfBt7ZdV11R_0024nASNDSkqwIZT1MAKB0ukP_00242MtXtNOAkqHH1UoeoQg0tHnRD_x9ZBIg_003D_003D();
		_0023_003DzoEGLyuM_003D = new byte[_0023_003DziiEv3wQ_003D];
		_0023_003DzaTyQZ6E_003D = _0023_003Dz3iPku7s_003D._0023_003DzuStpncDoFB_0024Bn9X5utYOeB3A395GiZ_0024S_00241CSFTjWTpb_Iwp2iPbLvZPZ_q72dNX1SakAOAk_003D();
		_0023_003DzJ6W8874_003D = new byte[_0023_003DzaTyQZ6E_003D];
	}

	public override long Seek(long _0023_003Dz9jrlnWk_003D, SeekOrigin _0023_003DzBxpHhQ0_003D)
	{
		switch (_0023_003DzBxpHhQ0_003D)
		{
		case SeekOrigin.Begin:
			Position = _0023_003Dz9jrlnWk_003D;
			break;
		case SeekOrigin.Current:
			Position += _0023_003Dz9jrlnWk_003D;
			break;
		case SeekOrigin.End:
			Position = Length + _0023_003Dz9jrlnWk_003D;
			break;
		}
		return Position;
	}

	public override void SetLength(long _0023_003Dz9jrlnWk_003D)
	{
		throw new NotSupportedException();
	}

	public override int Read(byte[] _0023_003Dz9jrlnWk_003D, int _0023_003DzBxpHhQ0_003D, int _0023_003Dztgqm2r4_003D)
	{
		if (_0023_003DzBxpHhQ0_003D < 0)
		{
			throw new ArgumentOutOfRangeException(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564311968));
		}
		if (_0023_003Dztgqm2r4_003D < 0)
		{
			throw new ArgumentOutOfRangeException(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564311941));
		}
		if (_0023_003Dz9jrlnWk_003D.Length - _0023_003DzBxpHhQ0_003D < _0023_003Dztgqm2r4_003D)
		{
			throw new ArgumentException();
		}
		if (_0023_003Dztgqm2r4_003D == 0)
		{
			return 0;
		}
		int num = _0023_003Dztgqm2r4_003D;
		int num2 = _0023_003DzBxpHhQ0_003D;
		if (_0023_003DzbSmUaeo_003D < _0023_003DzaTyQZ6E_003D)
		{
			_0023_003DzVQkUDCubygqob84DLOVdeD8nsb_piRJyg_7l_Qc_003D();
			int num3 = _0023_003DzAndD6oU_003D - _0023_003DzbSmUaeo_003D;
			if (num3 > _0023_003Dztgqm2r4_003D)
			{
				Buffer.BlockCopy(_0023_003DzJ6W8874_003D, _0023_003DzbSmUaeo_003D, _0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D);
				_0023_003DzbSmUaeo_003D += _0023_003Dztgqm2r4_003D;
				return _0023_003Dztgqm2r4_003D;
			}
			Buffer.BlockCopy(_0023_003DzJ6W8874_003D, _0023_003DzbSmUaeo_003D, _0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D, num3);
			_0023_003DzbSmUaeo_003D = _0023_003DzAndD6oU_003D;
			if (_0023_003Dz9I8ZVlc_003D)
			{
				return num3;
			}
			num -= num3;
			num2 += num3;
		}
		if (_0023_003Dz9I8ZVlc_003D)
		{
			return _0023_003Dztgqm2r4_003D - num;
		}
		while (num > 0)
		{
			_0023_003DzhgXP1XKtOO8LGWMSnUJTWHSknghvCgTM0NQEENBFqyFJ();
			if (_0023_003Dz9I8ZVlc_003D)
			{
				return _0023_003Dztgqm2r4_003D - num;
			}
			int num4 = _0023_003DzAndD6oU_003D;
			if (num >= num4)
			{
				Buffer.BlockCopy(_0023_003DzJ6W8874_003D, 0, _0023_003Dz9jrlnWk_003D, num2, num4);
				num2 += num4;
				num -= num4;
				_0023_003DzbSmUaeo_003D = num4;
				continue;
			}
			Buffer.BlockCopy(_0023_003DzJ6W8874_003D, 0, _0023_003Dz9jrlnWk_003D, num2, num);
			_0023_003DzbSmUaeo_003D = num;
			return _0023_003Dztgqm2r4_003D;
		}
		return _0023_003Dztgqm2r4_003D;
	}

	private void _0023_003DzVQkUDCubygqob84DLOVdeD8nsb_piRJyg_7l_Qc_003D()
	{
		_0023_003Dz5wv25SJj4k7NNKKwalaf5N4S7pR3O2zRbBnQZw0_003D();
		if (!_0023_003DzJGsRSpg_003D)
		{
			_0023_003DzJGsRSpg_003D = true;
			_0023_003Dz9I8ZVlc_003D = false;
			int num = _0023_003Dz2X8kE24_003D;
			if (_0023_003DzgqvoyJk_003D)
			{
				_0023_003DzzKDx05I_003D.Position = 4 + num * _0023_003DziiEv3wQ_003D;
				_0023_003DzgqvoyJk_003D = false;
			}
			_0023_003DzV9_Mts4qG7NaOcSD7YsjLFdz8LyIYuWrIg_003D_003D(num);
		}
	}

	private void _0023_003DzhgXP1XKtOO8LGWMSnUJTWHSknghvCgTM0NQEENBFqyFJ()
	{
		int num = _0023_003Dz2X8kE24_003D + 1;
		if (_0023_003DzV9_Mts4qG7NaOcSD7YsjLFdz8LyIYuWrIg_003D_003D(num))
		{
			_0023_003Dz2X8kE24_003D = num;
			_0023_003DzbSmUaeo_003D = 0;
		}
		_0023_003DzJGsRSpg_003D = true;
	}

	private bool _0023_003DzV9_Mts4qG7NaOcSD7YsjLFdz8LyIYuWrIg_003D_003D(int _0023_003Dz9jrlnWk_003D)
	{
		int num;
		for (int i = 0; i < _0023_003DziiEv3wQ_003D; i += num)
		{
			num = _0023_003DzzKDx05I_003D.Read(_0023_003DzoEGLyuM_003D, i, _0023_003DziiEv3wQ_003D - i);
			if (num == 0)
			{
				if (i != 0)
				{
					throw new InvalidOperationException();
				}
				_0023_003Dz9I8ZVlc_003D = true;
				return false;
			}
		}
		_0023_003DzAndD6oU_003D = _0023_003Dz3iPku7s_003D._0023_003DzRUaRf1_0024uXCd_0024014IgyPFGQ1WhzdakNCGTidf3nBX4zF3OwW0KT0ZmzkEoZUFoCJ2InG3qf_002466q8cxaPSHFzfr5g_003D(_0023_003DzoEGLyuM_003D, 0, _0023_003DziiEv3wQ_003D, _0023_003DzJ6W8874_003D, 0, null);
		if (_0023_003Dz9jrlnWk_003D == _0023_003DzBxpHhQ0_003D)
		{
			_0023_003DzAndD6oU_003D = _0023_003Dztgqm2r4_003D;
		}
		return true;
	}

	private void _0023_003Dz5wv25SJj4k7NNKKwalaf5N4S7pR3O2zRbBnQZw0_003D()
	{
		if (!_0023_003DzLi0XoCY_003D)
		{
			if (_0023_003DzzKDx05I_003D.Position != 0L)
			{
				_0023_003DzzKDx05I_003D.Position = 0L;
				_0023_003DzgqvoyJk_003D = true;
			}
			_0023_003Dz9jrlnWk_003D = _0023_003DzbTK57IzBRpBVnWKGEVxcoSw_003D(_0023_003DzzKDx05I_003D)._0023_003Dz9jrlnWk_003D;
			_0023_003DzBxpHhQ0_003D = _0023_003Dz9jrlnWk_003D / _0023_003DzaTyQZ6E_003D;
			_0023_003Dztgqm2r4_003D = _0023_003Dz9jrlnWk_003D % _0023_003DzaTyQZ6E_003D;
			_0023_003DzLi0XoCY_003D = true;
		}
	}

	private static _0023_003Dq9tIt1z5U8kopb592jTl1Dv1HrxTJYhPQwg2Zm0vi_Uk_003D _0023_003DzbTK57IzBRpBVnWKGEVxcoSw_003D(Stream _0023_003Dz9jrlnWk_003D)
	{
		_0023_003Dq0d3UOaLcwAHpHXr73AEsTm4JkA88Pbrxf7l8KMLJdjU_003D _0023_003Dq0d3UOaLcwAHpHXr73AEsTm4JkA88Pbrxf7l8KMLJdjU_003D2 = new _0023_003Dq0d3UOaLcwAHpHXr73AEsTm4JkA88Pbrxf7l8KMLJdjU_003D(_0023_003Dz9jrlnWk_003D, 0);
		try
		{
			_0023_003DqSrxlws3SuprWxrjyHO1juxJFrTNvlF8gj_KAkF067yA_003D _0023_003DqSrxlws3SuprWxrjyHO1juxJFrTNvlF8gj_KAkF067yA_003D2 = new _0023_003DqSrxlws3SuprWxrjyHO1juxJFrTNvlF8gj_KAkF067yA_003D(_0023_003Dq0d3UOaLcwAHpHXr73AEsTm4JkA88Pbrxf7l8KMLJdjU_003D2);
			try
			{
				return new _0023_003Dq9tIt1z5U8kopb592jTl1Dv1HrxTJYhPQwg2Zm0vi_Uk_003D(_0023_003DqSrxlws3SuprWxrjyHO1juxJFrTNvlF8gj_KAkF067yA_003D2._0023_003DzzWp83NqubJCg0KBvRVdJ1Clh9XOWlHor0w_003D_003D());
			}
			finally
			{
				((IDisposable)_0023_003DqSrxlws3SuprWxrjyHO1juxJFrTNvlF8gj_KAkF067yA_003D2).Dispose();
			}
		}
		finally
		{
			((IDisposable)_0023_003Dq0d3UOaLcwAHpHXr73AEsTm4JkA88Pbrxf7l8KMLJdjU_003D2).Dispose();
		}
	}

	public override void Flush()
	{
	}

	public override void Write(byte[] _0023_003Dz9jrlnWk_003D, int _0023_003DzBxpHhQ0_003D, int _0023_003Dztgqm2r4_003D)
	{
		throw new NotSupportedException();
	}
}
