using System;
using System.Diagnostics;
using System.IO;

internal sealed class _0023_003Dq0srKRFBAoKYa1j6vwUtjLjQ80X_0024QfLBnIhKJSrNvs8A_003D : Stream
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DziDLVpbY_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dz5rQzobg_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzAvn2b38_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Stream _0023_003DzR58imxw_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DqX0L7PWJ_0024pi7E1lZI88eAO5sAobDJ0hDC4y368rHz_0024nU_003D _0023_003DzmQTFaQA_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzWYPqg2E_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzEWLeis8_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzbfrNXYE_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzkKfJheA_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private byte[] _0023_003DzId5C3LA_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dzt_m8zV0_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private byte[] _0023_003DzshZYG54_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dz8wjMonY_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dz437_00244ak_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzTSeNR8Q_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DziP9fFuA_003D;

	public override bool CanRead => true;

	public override bool CanSeek => true;

	public override bool CanWrite => false;

	public override long Length
	{
		get
		{
			_0023_003Dz75pmtMYvXq5VdhkjDQnybtz38PEGTw6jFrgs9YE_003D();
			return _0023_003DziDLVpbY_003D;
		}
	}

	public override long Position
	{
		get
		{
			return _0023_003DzWYPqg2E_003D * _0023_003DzTSeNR8Q_003D + _0023_003Dz437_00244ak_003D;
		}
		set
		{
			int num = (int)value / _0023_003DzTSeNR8Q_003D;
			_0023_003Dz437_00244ak_003D = (int)value % _0023_003DzTSeNR8Q_003D;
			if (_0023_003DzWYPqg2E_003D != num)
			{
				_0023_003DzWYPqg2E_003D = num;
				_0023_003DzkKfJheA_003D = true;
				_0023_003DzEWLeis8_003D = false;
			}
		}
	}

	public _0023_003Dq0srKRFBAoKYa1j6vwUtjLjQ80X_0024QfLBnIhKJSrNvs8A_003D(Stream _0023_003DziDLVpbY_003D, _0023_003DqX0L7PWJ_0024pi7E1lZI88eAO5sAobDJ0hDC4y368rHz_0024nU_003D _0023_003Dz5rQzobg_003D)
	{
		if (_0023_003DziDLVpbY_003D == null)
		{
			throw new ArgumentNullException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302907814));
		}
		if (_0023_003Dz5rQzobg_003D == null)
		{
			throw new ArgumentNullException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910451));
		}
		_0023_003DzR58imxw_003D = _0023_003DziDLVpbY_003D;
		_0023_003DzmQTFaQA_003D = _0023_003Dz5rQzobg_003D;
		if (_0023_003DzR58imxw_003D.Length < 4)
		{
			throw new InvalidOperationException();
		}
		_0023_003DzP5LlmqtWRA6LSbaynFE5jnDCsQEEgq_nzSdDl5w_003D();
	}

	private void _0023_003DzP5LlmqtWRA6LSbaynFE5jnDCsQEEgq_nzSdDl5w_003D()
	{
		_0023_003Dzt_m8zV0_003D = _0023_003DzmQTFaQA_003D._0023_003Dz0tAR8yUFkU2jUm3AVFRoKtDLjDSmTKVAJNq86eLtMcXspFPCn0S4gvshDBjTY247PBKXdzvFQ6fsojO_0024Ag_003D_003D();
		_0023_003DzId5C3LA_003D = new byte[_0023_003Dzt_m8zV0_003D];
		_0023_003DzTSeNR8Q_003D = _0023_003DzmQTFaQA_003D._0023_003DzcJxPFSkFIEp1XZypJBtY4vG5ohxdNaobWJmZoq6ZkMadWP0_DLYtYqeZaotjUp7DgMiWHac_003D();
		_0023_003DzshZYG54_003D = new byte[_0023_003DzTSeNR8Q_003D];
	}

	public override long Seek(long _0023_003DziDLVpbY_003D, SeekOrigin _0023_003Dz5rQzobg_003D)
	{
		switch (_0023_003Dz5rQzobg_003D)
		{
		case SeekOrigin.Begin:
			Position = _0023_003DziDLVpbY_003D;
			break;
		case SeekOrigin.Current:
			Position += _0023_003DziDLVpbY_003D;
			break;
		case SeekOrigin.End:
			Position = Length + _0023_003DziDLVpbY_003D;
			break;
		}
		return Position;
	}

	public override void SetLength(long _0023_003DziDLVpbY_003D)
	{
		throw new NotSupportedException();
	}

	public override int Read(byte[] _0023_003DziDLVpbY_003D, int _0023_003Dz5rQzobg_003D, int _0023_003DzAvn2b38_003D)
	{
		if (_0023_003Dz5rQzobg_003D < 0)
		{
			throw new ArgumentOutOfRangeException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910435));
		}
		if (_0023_003DzAvn2b38_003D < 0)
		{
			throw new ArgumentOutOfRangeException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910448));
		}
		if (_0023_003DziDLVpbY_003D.Length - _0023_003Dz5rQzobg_003D < _0023_003DzAvn2b38_003D)
		{
			throw new ArgumentException();
		}
		if (_0023_003DzAvn2b38_003D == 0)
		{
			return 0;
		}
		int num = _0023_003DzAvn2b38_003D;
		int num2 = _0023_003Dz5rQzobg_003D;
		if (_0023_003Dz437_00244ak_003D < _0023_003DzTSeNR8Q_003D)
		{
			_0023_003Dz4Qk4RNRLhm8EmhpOuDE8I4vig_8Q46_G0hquiTY_003D();
			int num3 = _0023_003Dz8wjMonY_003D - _0023_003Dz437_00244ak_003D;
			if (num3 > _0023_003DzAvn2b38_003D)
			{
				Buffer.BlockCopy(_0023_003DzshZYG54_003D, _0023_003Dz437_00244ak_003D, _0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D);
				_0023_003Dz437_00244ak_003D += _0023_003DzAvn2b38_003D;
				return _0023_003DzAvn2b38_003D;
			}
			Buffer.BlockCopy(_0023_003DzshZYG54_003D, _0023_003Dz437_00244ak_003D, _0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D, num3);
			_0023_003Dz437_00244ak_003D = _0023_003Dz8wjMonY_003D;
			if (_0023_003DzbfrNXYE_003D)
			{
				return num3;
			}
			num -= num3;
			num2 += num3;
		}
		if (_0023_003DzbfrNXYE_003D)
		{
			return _0023_003DzAvn2b38_003D - num;
		}
		while (num > 0)
		{
			_0023_003DzWS8zesVS9irnz9JfNtNPgR_bO5SfKJdJTs_0024hOB10_0024W8G();
			if (_0023_003DzbfrNXYE_003D)
			{
				return _0023_003DzAvn2b38_003D - num;
			}
			int num4 = _0023_003Dz8wjMonY_003D;
			if (num >= num4)
			{
				Buffer.BlockCopy(_0023_003DzshZYG54_003D, 0, _0023_003DziDLVpbY_003D, num2, num4);
				num2 += num4;
				num -= num4;
				_0023_003Dz437_00244ak_003D = num4;
				continue;
			}
			Buffer.BlockCopy(_0023_003DzshZYG54_003D, 0, _0023_003DziDLVpbY_003D, num2, num);
			_0023_003Dz437_00244ak_003D = num;
			return _0023_003DzAvn2b38_003D;
		}
		return _0023_003DzAvn2b38_003D;
	}

	private void _0023_003Dz4Qk4RNRLhm8EmhpOuDE8I4vig_8Q46_G0hquiTY_003D()
	{
		_0023_003Dz75pmtMYvXq5VdhkjDQnybtz38PEGTw6jFrgs9YE_003D();
		if (!_0023_003DzEWLeis8_003D)
		{
			_0023_003DzEWLeis8_003D = true;
			_0023_003DzbfrNXYE_003D = false;
			int num = _0023_003DzWYPqg2E_003D;
			if (_0023_003DzkKfJheA_003D)
			{
				_0023_003DzR58imxw_003D.Position = 4 + num * _0023_003Dzt_m8zV0_003D;
				_0023_003DzkKfJheA_003D = false;
			}
			_0023_003Dze_XwzG5yTSLY4_nHhlXa3DUeZVayCKX5_0024A_003D_003D(num);
		}
	}

	private void _0023_003DzWS8zesVS9irnz9JfNtNPgR_bO5SfKJdJTs_0024hOB10_0024W8G()
	{
		int num = _0023_003DzWYPqg2E_003D + 1;
		if (_0023_003Dze_XwzG5yTSLY4_nHhlXa3DUeZVayCKX5_0024A_003D_003D(num))
		{
			_0023_003DzWYPqg2E_003D = num;
			_0023_003Dz437_00244ak_003D = 0;
		}
		_0023_003DzEWLeis8_003D = true;
	}

	private bool _0023_003Dze_XwzG5yTSLY4_nHhlXa3DUeZVayCKX5_0024A_003D_003D(int _0023_003DziDLVpbY_003D)
	{
		int num;
		for (int i = 0; i < _0023_003Dzt_m8zV0_003D; i += num)
		{
			num = _0023_003DzR58imxw_003D.Read(_0023_003DzId5C3LA_003D, i, _0023_003Dzt_m8zV0_003D - i);
			if (num == 0)
			{
				if (i != 0)
				{
					throw new InvalidOperationException();
				}
				_0023_003DzbfrNXYE_003D = true;
				return false;
			}
		}
		_0023_003Dz8wjMonY_003D = _0023_003DzmQTFaQA_003D._0023_003DzLwoZv45Pa4_0024jy1VJmhNsdx9TWiqb9GD1vXh6snfFDPWJagI3PaOJZtlcbubGf3aChPH5hztl2z13_hbHC_00243_coA_003D(_0023_003DzId5C3LA_003D, 0, _0023_003Dzt_m8zV0_003D, _0023_003DzshZYG54_003D, 0, null);
		if (_0023_003DziDLVpbY_003D == _0023_003Dz5rQzobg_003D)
		{
			_0023_003Dz8wjMonY_003D = _0023_003DzAvn2b38_003D;
		}
		return true;
	}

	private void _0023_003Dz75pmtMYvXq5VdhkjDQnybtz38PEGTw6jFrgs9YE_003D()
	{
		if (!_0023_003DziP9fFuA_003D)
		{
			if (_0023_003DzR58imxw_003D.Position != 0L)
			{
				_0023_003DzR58imxw_003D.Position = 0L;
				_0023_003DzkKfJheA_003D = true;
			}
			_0023_003DziDLVpbY_003D = _0023_003DzQlN6vVJaRhDCEbH_IAIbm_0024o_003D(_0023_003DzR58imxw_003D)._0023_003DziDLVpbY_003D;
			_0023_003Dz5rQzobg_003D = _0023_003DziDLVpbY_003D / _0023_003DzTSeNR8Q_003D;
			_0023_003DzAvn2b38_003D = _0023_003DziDLVpbY_003D % _0023_003DzTSeNR8Q_003D;
			_0023_003DziP9fFuA_003D = true;
		}
	}

	private static _0023_003Dqu2lukaMdtknH99Y0fKPgR30DWYUJ8EC9HoAueNf8Z_o_003D _0023_003DzQlN6vVJaRhDCEbH_IAIbm_0024o_003D(Stream _0023_003DziDLVpbY_003D)
	{
		_0023_003DqI_0024qdFH6tAfuROz8_nUFyOyuVAGTDfXJAUH71_0024nOZSNg_003D _0023_003DqI_0024qdFH6tAfuROz8_nUFyOyuVAGTDfXJAUH71_0024nOZSNg_003D2 = new _0023_003DqI_0024qdFH6tAfuROz8_nUFyOyuVAGTDfXJAUH71_0024nOZSNg_003D(_0023_003DziDLVpbY_003D, 0);
		try
		{
			_0023_003DqPacQ3FeX7fTjZ97pVfwPYSJjOHh78qwCwQ71GpMvdjw_003D _0023_003DqPacQ3FeX7fTjZ97pVfwPYSJjOHh78qwCwQ71GpMvdjw_003D2 = new _0023_003DqPacQ3FeX7fTjZ97pVfwPYSJjOHh78qwCwQ71GpMvdjw_003D(_0023_003DqI_0024qdFH6tAfuROz8_nUFyOyuVAGTDfXJAUH71_0024nOZSNg_003D2);
			try
			{
				return new _0023_003Dqu2lukaMdtknH99Y0fKPgR30DWYUJ8EC9HoAueNf8Z_o_003D(_0023_003DqPacQ3FeX7fTjZ97pVfwPYSJjOHh78qwCwQ71GpMvdjw_003D2._0023_003DzPPIiwGuDiAMVAWOgOhWlWjqBOxg4yozj0g_003D_003D());
			}
			finally
			{
				((IDisposable)_0023_003DqPacQ3FeX7fTjZ97pVfwPYSJjOHh78qwCwQ71GpMvdjw_003D2).Dispose();
			}
		}
		finally
		{
			((IDisposable)_0023_003DqI_0024qdFH6tAfuROz8_nUFyOyuVAGTDfXJAUH71_0024nOZSNg_003D2).Dispose();
		}
	}

	public override void Flush()
	{
	}

	public override void Write(byte[] _0023_003DziDLVpbY_003D, int _0023_003Dz5rQzobg_003D, int _0023_003DzAvn2b38_003D)
	{
		throw new NotSupportedException();
	}
}
