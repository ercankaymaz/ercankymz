using System;
using System.Diagnostics;
using System.IO;

internal sealed class _0023_003Dq3pUobS7gRU4PocUwxB9HRX2NXFxm2XtrIwnz_0024_k2ZLQ_003D : Stream
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dzq80RbjQ_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzZzVr6_0024U_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dz7hRN5Rg_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Stream _0023_003DzcbLoSrg_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DquMh_RbFIfA6Odscsrwq4H1xZqNu1kphCuT2OFISKuWI_003D _0023_003DzqMLoHoQ_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzuwE9t4w_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzoyRBT1A_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzLaPeX80_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzKyPCKaY_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private byte[] _0023_003DzoVpU9JU_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dz5QkdKZk_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private byte[] _0023_003DzkJp9o4I_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dzkl7CXTo_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzUH03yec_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzAXvW_0024Kw_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzLi0XoCY_003D;

	public override bool CanRead => true;

	public override bool CanSeek => true;

	public override bool CanWrite => false;

	public override long Length
	{
		get
		{
			_0023_003DzbD7p9WUFbuCd_0024j9r7zXc7ODTdihaAoLdn8cSixg_003D();
			return _0023_003Dzq80RbjQ_003D;
		}
	}

	public override long Position
	{
		get
		{
			return _0023_003DzuwE9t4w_003D * _0023_003DzAXvW_0024Kw_003D + _0023_003DzUH03yec_003D;
		}
		set
		{
			int num = (int)value / _0023_003DzAXvW_0024Kw_003D;
			_0023_003DzUH03yec_003D = (int)value % _0023_003DzAXvW_0024Kw_003D;
			if (_0023_003DzuwE9t4w_003D != num)
			{
				_0023_003DzuwE9t4w_003D = num;
				_0023_003DzKyPCKaY_003D = true;
				_0023_003DzoyRBT1A_003D = false;
			}
		}
	}

	public _0023_003Dq3pUobS7gRU4PocUwxB9HRX2NXFxm2XtrIwnz_0024_k2ZLQ_003D(Stream _0023_003Dzq80RbjQ_003D, _0023_003DquMh_RbFIfA6Odscsrwq4H1xZqNu1kphCuT2OFISKuWI_003D _0023_003DzZzVr6_0024U_003D)
	{
		if (_0023_003Dzq80RbjQ_003D == null)
		{
			throw new ArgumentNullException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355525959));
		}
		if (_0023_003DzZzVr6_0024U_003D == null)
		{
			throw new ArgumentNullException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355528502));
		}
		_0023_003DzcbLoSrg_003D = _0023_003Dzq80RbjQ_003D;
		_0023_003DzqMLoHoQ_003D = _0023_003DzZzVr6_0024U_003D;
		if (_0023_003DzcbLoSrg_003D.Length < 4)
		{
			throw new InvalidOperationException();
		}
		_0023_003DztoNbg243mDoFnc4bYKhPxNFmWqqRD08p3sVRq20_003D();
	}

	private void _0023_003DztoNbg243mDoFnc4bYKhPxNFmWqqRD08p3sVRq20_003D()
	{
		_0023_003Dz5QkdKZk_003D = _0023_003DzqMLoHoQ_003D._0023_003DzSEY04nxJtfqOe_NEWeo3eOc0Etbe_0024Jj8XZu70RmqdWkClVfxadDA7Yv3_toO92Ul_00242tmYNYn1vth6Wdsbw_003D_003D();
		_0023_003DzoVpU9JU_003D = new byte[_0023_003Dz5QkdKZk_003D];
		_0023_003DzAXvW_0024Kw_003D = _0023_003DzqMLoHoQ_003D._0023_003DzT9eA_I8w0CDvq_YsYh_iH47uTsD9brXMemU1_QcwtWy1NzoCuxvYwQduSWZOuC3GCh0X92w_003D();
		_0023_003DzkJp9o4I_003D = new byte[_0023_003DzAXvW_0024Kw_003D];
	}

	public override long Seek(long _0023_003Dzq80RbjQ_003D, SeekOrigin _0023_003DzZzVr6_0024U_003D)
	{
		switch (_0023_003DzZzVr6_0024U_003D)
		{
		case SeekOrigin.Begin:
			Position = _0023_003Dzq80RbjQ_003D;
			break;
		case SeekOrigin.Current:
			Position += _0023_003Dzq80RbjQ_003D;
			break;
		case SeekOrigin.End:
			Position = Length + _0023_003Dzq80RbjQ_003D;
			break;
		}
		return Position;
	}

	public override void SetLength(long _0023_003Dzq80RbjQ_003D)
	{
		throw new NotSupportedException();
	}

	public override int Read(byte[] _0023_003Dzq80RbjQ_003D, int _0023_003DzZzVr6_0024U_003D, int _0023_003Dz7hRN5Rg_003D)
	{
		if (_0023_003DzZzVr6_0024U_003D < 0)
		{
			throw new ArgumentOutOfRangeException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355528454));
		}
		if (_0023_003Dz7hRN5Rg_003D < 0)
		{
			throw new ArgumentOutOfRangeException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355528477));
		}
		if (_0023_003Dzq80RbjQ_003D.Length - _0023_003DzZzVr6_0024U_003D < _0023_003Dz7hRN5Rg_003D)
		{
			throw new ArgumentException();
		}
		if (_0023_003Dz7hRN5Rg_003D == 0)
		{
			return 0;
		}
		int num = _0023_003Dz7hRN5Rg_003D;
		int num2 = _0023_003DzZzVr6_0024U_003D;
		if (_0023_003DzUH03yec_003D < _0023_003DzAXvW_0024Kw_003D)
		{
			_0023_003DzsSqyflCAyKCTtyY4luHMAMgOwkGBBbfyf_0024rKZR0_003D();
			int num3 = _0023_003Dzkl7CXTo_003D - _0023_003DzUH03yec_003D;
			if (num3 > _0023_003Dz7hRN5Rg_003D)
			{
				Buffer.BlockCopy(_0023_003DzkJp9o4I_003D, _0023_003DzUH03yec_003D, _0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D);
				_0023_003DzUH03yec_003D += _0023_003Dz7hRN5Rg_003D;
				return _0023_003Dz7hRN5Rg_003D;
			}
			Buffer.BlockCopy(_0023_003DzkJp9o4I_003D, _0023_003DzUH03yec_003D, _0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D, num3);
			_0023_003DzUH03yec_003D = _0023_003Dzkl7CXTo_003D;
			if (_0023_003DzLaPeX80_003D)
			{
				return num3;
			}
			num -= num3;
			num2 += num3;
		}
		if (_0023_003DzLaPeX80_003D)
		{
			return _0023_003Dz7hRN5Rg_003D - num;
		}
		while (num > 0)
		{
			_0023_003DzPFMQxH8jund944mGI7IzCHIMtfZ1jCmmhP8zobu_00244fzk();
			if (_0023_003DzLaPeX80_003D)
			{
				return _0023_003Dz7hRN5Rg_003D - num;
			}
			int num4 = _0023_003Dzkl7CXTo_003D;
			if (num >= num4)
			{
				Buffer.BlockCopy(_0023_003DzkJp9o4I_003D, 0, _0023_003Dzq80RbjQ_003D, num2, num4);
				num2 += num4;
				num -= num4;
				_0023_003DzUH03yec_003D = num4;
				continue;
			}
			Buffer.BlockCopy(_0023_003DzkJp9o4I_003D, 0, _0023_003Dzq80RbjQ_003D, num2, num);
			_0023_003DzUH03yec_003D = num;
			return _0023_003Dz7hRN5Rg_003D;
		}
		return _0023_003Dz7hRN5Rg_003D;
	}

	private void _0023_003DzsSqyflCAyKCTtyY4luHMAMgOwkGBBbfyf_0024rKZR0_003D()
	{
		_0023_003DzbD7p9WUFbuCd_0024j9r7zXc7ODTdihaAoLdn8cSixg_003D();
		if (!_0023_003DzoyRBT1A_003D)
		{
			_0023_003DzoyRBT1A_003D = true;
			_0023_003DzLaPeX80_003D = false;
			int num = _0023_003DzuwE9t4w_003D;
			if (_0023_003DzKyPCKaY_003D)
			{
				_0023_003DzcbLoSrg_003D.Position = 4 + num * _0023_003Dz5QkdKZk_003D;
				_0023_003DzKyPCKaY_003D = false;
			}
			_0023_003DzdRhn2kV1GVM9ukEpsFSZO1crtZMuMX3Z0Q_003D_003D(num);
		}
	}

	private void _0023_003DzPFMQxH8jund944mGI7IzCHIMtfZ1jCmmhP8zobu_00244fzk()
	{
		int num = _0023_003DzuwE9t4w_003D + 1;
		if (_0023_003DzdRhn2kV1GVM9ukEpsFSZO1crtZMuMX3Z0Q_003D_003D(num))
		{
			_0023_003DzuwE9t4w_003D = num;
			_0023_003DzUH03yec_003D = 0;
		}
		_0023_003DzoyRBT1A_003D = true;
	}

	private bool _0023_003DzdRhn2kV1GVM9ukEpsFSZO1crtZMuMX3Z0Q_003D_003D(int _0023_003Dzq80RbjQ_003D)
	{
		int num;
		for (int i = 0; i < _0023_003Dz5QkdKZk_003D; i += num)
		{
			num = _0023_003DzcbLoSrg_003D.Read(_0023_003DzoVpU9JU_003D, i, _0023_003Dz5QkdKZk_003D - i);
			if (num == 0)
			{
				if (i != 0)
				{
					throw new InvalidOperationException();
				}
				_0023_003DzLaPeX80_003D = true;
				return false;
			}
		}
		_0023_003Dzkl7CXTo_003D = _0023_003DzqMLoHoQ_003D._0023_003Dzhdoh5k6m_0024AO52PAYFXGKQO9OGwW5kHwW2wyWQpayqijlwE_0024xck_GBc28La0KktESKmzv8a_0024ZIXdc4iz8z4aF4eo_003D(_0023_003DzoVpU9JU_003D, 0, _0023_003Dz5QkdKZk_003D, _0023_003DzkJp9o4I_003D, 0, null);
		if (_0023_003Dzq80RbjQ_003D == _0023_003DzZzVr6_0024U_003D)
		{
			_0023_003Dzkl7CXTo_003D = _0023_003Dz7hRN5Rg_003D;
		}
		return true;
	}

	private void _0023_003DzbD7p9WUFbuCd_0024j9r7zXc7ODTdihaAoLdn8cSixg_003D()
	{
		if (!_0023_003DzLi0XoCY_003D)
		{
			if (_0023_003DzcbLoSrg_003D.Position != 0L)
			{
				_0023_003DzcbLoSrg_003D.Position = 0L;
				_0023_003DzKyPCKaY_003D = true;
			}
			_0023_003Dzq80RbjQ_003D = _0023_003DzWbLg732pOO2oKqWVnmzH3gU_003D(_0023_003DzcbLoSrg_003D)._0023_003Dzq80RbjQ_003D;
			_0023_003DzZzVr6_0024U_003D = _0023_003Dzq80RbjQ_003D / _0023_003DzAXvW_0024Kw_003D;
			_0023_003Dz7hRN5Rg_003D = _0023_003Dzq80RbjQ_003D % _0023_003DzAXvW_0024Kw_003D;
			_0023_003DzLi0XoCY_003D = true;
		}
	}

	private static _0023_003DqF1uJAXBey_e_bDLwv8Xb1LUBv5mD05TFTQ7_Y_00240Aqyc_003D _0023_003DzWbLg732pOO2oKqWVnmzH3gU_003D(Stream _0023_003Dzq80RbjQ_003D)
	{
		_0023_003Dq6tsYctsQQ5GQ6RFr34KBsxKK9IcURsmJg_wdmbRS8KY_003D _0023_003Dq6tsYctsQQ5GQ6RFr34KBsxKK9IcURsmJg_wdmbRS8KY_003D2 = new _0023_003Dq6tsYctsQQ5GQ6RFr34KBsxKK9IcURsmJg_wdmbRS8KY_003D(_0023_003Dzq80RbjQ_003D, 0);
		try
		{
			_0023_003Dq92i4vUz2r2p0Q1QJdKoEru9tmNPrV7XoY6GK4JPSqdU_003D _0023_003Dq92i4vUz2r2p0Q1QJdKoEru9tmNPrV7XoY6GK4JPSqdU_003D2 = new _0023_003Dq92i4vUz2r2p0Q1QJdKoEru9tmNPrV7XoY6GK4JPSqdU_003D(_0023_003Dq6tsYctsQQ5GQ6RFr34KBsxKK9IcURsmJg_wdmbRS8KY_003D2);
			try
			{
				return new _0023_003DqF1uJAXBey_e_bDLwv8Xb1LUBv5mD05TFTQ7_Y_00240Aqyc_003D(_0023_003Dq92i4vUz2r2p0Q1QJdKoEru9tmNPrV7XoY6GK4JPSqdU_003D2._0023_003Dz54f_9Zwk7KXGsO1HSe28cbSe0t4SIcU23g_003D_003D());
			}
			finally
			{
				((IDisposable)_0023_003Dq92i4vUz2r2p0Q1QJdKoEru9tmNPrV7XoY6GK4JPSqdU_003D2).Dispose();
			}
		}
		finally
		{
			((IDisposable)_0023_003Dq6tsYctsQQ5GQ6RFr34KBsxKK9IcURsmJg_wdmbRS8KY_003D2).Dispose();
		}
	}

	public override void Flush()
	{
	}

	public override void Write(byte[] _0023_003Dzq80RbjQ_003D, int _0023_003DzZzVr6_0024U_003D, int _0023_003Dz7hRN5Rg_003D)
	{
		throw new NotSupportedException();
	}
}
