using System;
using System.Diagnostics;
using System.IO;

internal sealed class _0023_003DqrEm2JjIm4VkgfQzkhUQWZbsou98QcykY1FsdyFMbu_8_003D : Stream
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dzq80RbjQ_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Stream _0023_003DzZzVr6_0024U_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DqJ75rpI46d2e8QXpNMN_0024n8dMRYzA7SCPvf_0024hn0hkQhQY_003D[] _0023_003Dz7hRN5Rg_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003Dqf_1TygBFcnFf0K9AFFRX5tWreByfCSY_0024wb98KsAZz08_003D _0023_003DzcbLoSrg_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DqiKG8cMtDhvDx0IwX7MlRZlGvI9dnj4DQ9imxEd_xNkc_003D _0023_003DzqMLoHoQ_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003Dq0aa58W10obKnKDKIHo_WWnIkvyqtS67nfLmpWg3JZ6M_003D _0023_003DzuwE9t4w_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzoyRBT1A_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private byte[] _0023_003DzLaPeX80_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzKyPCKaY_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzoVpU9JU_003D;

	public override bool CanRead => true;

	public override bool CanSeek => true;

	public override bool CanWrite => false;

	public override long Length => _0023_003DzZzVr6_0024U_003D.Length;

	public override long Position
	{
		get
		{
			return _0023_003DzZzVr6_0024U_003D.Position + (_0023_003DzKyPCKaY_003D - _0023_003DzoVpU9JU_003D);
		}
		set
		{
			Seek(value, SeekOrigin.Begin);
		}
	}

	public _0023_003DqrEm2JjIm4VkgfQzkhUQWZbsou98QcykY1FsdyFMbu_8_003D(Stream _0023_003Dzq80RbjQ_003D, _0023_003Dqf_1TygBFcnFf0K9AFFRX5tWreByfCSY_0024wb98KsAZz08_003D _0023_003DzZzVr6_0024U_003D = null, _0023_003DqiKG8cMtDhvDx0IwX7MlRZlGvI9dnj4DQ9imxEd_xNkc_003D _0023_003Dz7hRN5Rg_003D = null, bool _0023_003DzcbLoSrg_003D = false)
	{
		this._0023_003DzZzVr6_0024U_003D = _0023_003Dzq80RbjQ_003D;
		this._0023_003Dzq80RbjQ_003D = _0023_003DzcbLoSrg_003D;
		_0023_003DzqMLoHoQ_003D = _0023_003Dz7hRN5Rg_003D;
		this._0023_003DzcbLoSrg_003D = _0023_003DzZzVr6_0024U_003D;
		if (this._0023_003DzcbLoSrg_003D == null)
		{
			this._0023_003DzcbLoSrg_003D = _0023_003Dqf_1TygBFcnFf0K9AFFRX5tWreByfCSY_0024wb98KsAZz08_003D._0023_003Dz3VI6MzCmPWcaO_HKIe4jatm7pjQOoE2okJKfz_00244_003D();
		}
		if (this._0023_003DzcbLoSrg_003D._0023_003Dz8GMXGrUQQYLJ5_0024hQWpogumuAU_0024ZyK3Z2MSmcNg4_003D() == 0)
		{
			throw new ArgumentException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355526006));
		}
		if (this._0023_003DzcbLoSrg_003D._0023_003DzuOQTWRZp_8XGTgS1ObGjUuGn4SEtiPmrpg_003D_003D() == 0)
		{
			throw new ArgumentException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355526006));
		}
		if (!this._0023_003DzZzVr6_0024U_003D.CanRead)
		{
			throw new ArgumentException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355525959));
		}
		if (!this._0023_003DzZzVr6_0024U_003D.CanSeek)
		{
			throw new ArgumentException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355525959));
		}
	}

	private void _0023_003Dz538jN3nfkg9p_1JEpn6qx8rAjJjy()
	{
		if (!_0023_003DzoyRBT1A_003D)
		{
			_0023_003Dz7hRN5Rg_003D = new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8dMRYzA7SCPvf_0024hn0hkQhQY_003D[_0023_003DzcbLoSrg_003D._0023_003Dz8GMXGrUQQYLJ5_0024hQWpogumuAU_0024ZyK3Z2MSmcNg4_003D()];
			for (int i = 0; i < _0023_003DzcbLoSrg_003D._0023_003Dz8GMXGrUQQYLJ5_0024hQWpogumuAU_0024ZyK3Z2MSmcNg4_003D(); i++)
			{
				_0023_003Dz7hRN5Rg_003D[i] = new _0023_003DqJ75rpI46d2e8QXpNMN_0024n8dMRYzA7SCPvf_0024hn0hkQhQY_003D();
			}
			if (_0023_003DzqMLoHoQ_003D != null)
			{
				_0023_003DzuwE9t4w_003D = _0023_003DzqMLoHoQ_003D._0023_003DzNcip0nEYxS_nf0p_0024sa0iWYk5BNcpK_0024a0No7NbX8_003D(_0023_003DzcbLoSrg_003D);
			}
			_0023_003DzoyRBT1A_003D = true;
		}
	}

	protected override void Dispose(bool _0023_003Dzq80RbjQ_003D)
	{
		try
		{
			if (_0023_003Dzq80RbjQ_003D && !this._0023_003Dzq80RbjQ_003D)
			{
				_0023_003DzZzVr6_0024U_003D.Close();
			}
		}
		finally
		{
			base.Dispose(_0023_003Dzq80RbjQ_003D);
		}
	}

	public override void SetLength(long _0023_003Dzq80RbjQ_003D)
	{
		throw new NotSupportedException();
	}

	public override void Write(byte[] _0023_003Dzq80RbjQ_003D, int _0023_003DzZzVr6_0024U_003D, int _0023_003Dz7hRN5Rg_003D)
	{
		throw new NotSupportedException();
	}

	public override void Flush()
	{
	}

	private int _0023_003DzVo9kPXlXPS8CrrYteUk2b9I_003D(byte[] _0023_003Dzq80RbjQ_003D, int _0023_003DzZzVr6_0024U_003D, int _0023_003Dz7hRN5Rg_003D)
	{
		int num = _0023_003DzoVpU9JU_003D - _0023_003DzKyPCKaY_003D;
		if (num <= 0)
		{
			return 0;
		}
		if (num > _0023_003Dz7hRN5Rg_003D)
		{
			num = _0023_003Dz7hRN5Rg_003D;
		}
		Buffer.BlockCopy(_0023_003DzLaPeX80_003D, _0023_003DzKyPCKaY_003D, _0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D, num);
		_0023_003DzKyPCKaY_003D += num;
		return num;
	}

	private void _0023_003DzJiYGHHZDCbHiQCVlw7cDEmI_003D(int _0023_003Dzq80RbjQ_003D)
	{
		int num = (int)_0023_003DzZzVr6_0024U_003D.Position;
		if (num >= _0023_003DzZzVr6_0024U_003D.Length)
		{
			return;
		}
		int num2 = num + _0023_003Dzq80RbjQ_003D;
		_0023_003DqJ75rpI46d2e8QXpNMN_0024n8dMRYzA7SCPvf_0024hn0hkQhQY_003D[] array = _0023_003Dz7hRN5Rg_003D;
		foreach (_0023_003DqJ75rpI46d2e8QXpNMN_0024n8dMRYzA7SCPvf_0024hn0hkQhQY_003D _0023_003DqJ75rpI46d2e8QXpNMN_0024n8dMRYzA7SCPvf_0024hn0hkQhQY_003D2 in array)
		{
			if (_0023_003DqJ75rpI46d2e8QXpNMN_0024n8dMRYzA7SCPvf_0024hn0hkQhQY_003D2._0023_003DzZzVr6_0024U_003D <= num && _0023_003DqJ75rpI46d2e8QXpNMN_0024n8dMRYzA7SCPvf_0024hn0hkQhQY_003D2._0023_003Dz7hRN5Rg_003D >= num2)
			{
				_0023_003DzLaPeX80_003D = _0023_003DqJ75rpI46d2e8QXpNMN_0024n8dMRYzA7SCPvf_0024hn0hkQhQY_003D2._0023_003Dzq80RbjQ_003D;
				_0023_003DzoVpU9JU_003D = _0023_003DqJ75rpI46d2e8QXpNMN_0024n8dMRYzA7SCPvf_0024hn0hkQhQY_003D2._0023_003Dz7hRN5Rg_003D - _0023_003DqJ75rpI46d2e8QXpNMN_0024n8dMRYzA7SCPvf_0024hn0hkQhQY_003D2._0023_003DzZzVr6_0024U_003D;
				_0023_003DzKyPCKaY_003D = num - _0023_003DqJ75rpI46d2e8QXpNMN_0024n8dMRYzA7SCPvf_0024hn0hkQhQY_003D2._0023_003DzZzVr6_0024U_003D;
				_0023_003DzZzVr6_0024U_003D.Position = _0023_003DqJ75rpI46d2e8QXpNMN_0024n8dMRYzA7SCPvf_0024hn0hkQhQY_003D2._0023_003Dz7hRN5Rg_003D;
				_0023_003DqJ75rpI46d2e8QXpNMN_0024n8dMRYzA7SCPvf_0024hn0hkQhQY_003D2._0023_003DzcbLoSrg_003D = DateTime.UtcNow;
				return;
			}
		}
		int num3 = 0;
		DateTime dateTime = _0023_003Dz7hRN5Rg_003D[0]._0023_003DzcbLoSrg_003D;
		for (int j = 1; j < _0023_003Dz7hRN5Rg_003D.Length; j++)
		{
			if (_0023_003Dz7hRN5Rg_003D[j]._0023_003DzcbLoSrg_003D < dateTime)
			{
				num3 = j;
			}
		}
		_0023_003DqJ75rpI46d2e8QXpNMN_0024n8dMRYzA7SCPvf_0024hn0hkQhQY_003D _0023_003DqJ75rpI46d2e8QXpNMN_0024n8dMRYzA7SCPvf_0024hn0hkQhQY_003D3 = _0023_003Dz7hRN5Rg_003D[num3];
		if (_0023_003DqJ75rpI46d2e8QXpNMN_0024n8dMRYzA7SCPvf_0024hn0hkQhQY_003D3._0023_003Dzq80RbjQ_003D == null)
		{
			_0023_003DqJ75rpI46d2e8QXpNMN_0024n8dMRYzA7SCPvf_0024hn0hkQhQY_003D3._0023_003Dzq80RbjQ_003D = new byte[_0023_003DzcbLoSrg_003D._0023_003DzKD7tWS1ra9PIeIyFrm74c2aSenNaSrE4FltpI34HWkKS()];
		}
		int num4 = num;
		num = _0023_003DzVFFAwICpBGQtwIs38_0024Mj_00245kvMDiJ(num);
		if (num < 0)
		{
			num = 0;
		}
		num2 = num + _0023_003DzcbLoSrg_003D._0023_003DzKD7tWS1ra9PIeIyFrm74c2aSenNaSrE4FltpI34HWkKS();
		if (_0023_003DzuwE9t4w_003D == null || !_0023_003DzuwE9t4w_003D._0023_003DzSAKJWCoMTmaOOlseXTXyI_00240_003D(num, ref _0023_003DqJ75rpI46d2e8QXpNMN_0024n8dMRYzA7SCPvf_0024hn0hkQhQY_003D3))
		{
			_0023_003DqJ75rpI46d2e8QXpNMN_0024n8dMRYzA7SCPvf_0024hn0hkQhQY_003D3._0023_003DzZzVr6_0024U_003D = num;
			_0023_003DqJ75rpI46d2e8QXpNMN_0024n8dMRYzA7SCPvf_0024hn0hkQhQY_003D3._0023_003DzcbLoSrg_003D = DateTime.UtcNow;
			_0023_003DzLaPeX80_003D = _0023_003DqJ75rpI46d2e8QXpNMN_0024n8dMRYzA7SCPvf_0024hn0hkQhQY_003D3._0023_003Dzq80RbjQ_003D;
			_0023_003DzZzVr6_0024U_003D.Position = num;
			_0023_003DzoVpU9JU_003D = _0023_003DzZzVr6_0024U_003D.Read(_0023_003DzLaPeX80_003D, 0, num2 - num);
			_0023_003DzKyPCKaY_003D = num4 - num;
			_0023_003DqJ75rpI46d2e8QXpNMN_0024n8dMRYzA7SCPvf_0024hn0hkQhQY_003D3._0023_003Dz7hRN5Rg_003D = num + _0023_003DzoVpU9JU_003D;
			if (_0023_003DzuwE9t4w_003D != null)
			{
				_0023_003DzuwE9t4w_003D._0023_003Dzqi2U3h0ZctsLy19Rkhhq6CA_003D(_0023_003DqJ75rpI46d2e8QXpNMN_0024n8dMRYzA7SCPvf_0024hn0hkQhQY_003D3);
			}
		}
		else
		{
			_0023_003DzLaPeX80_003D = _0023_003DqJ75rpI46d2e8QXpNMN_0024n8dMRYzA7SCPvf_0024hn0hkQhQY_003D3._0023_003Dzq80RbjQ_003D;
			_0023_003DzoVpU9JU_003D = _0023_003DqJ75rpI46d2e8QXpNMN_0024n8dMRYzA7SCPvf_0024hn0hkQhQY_003D3._0023_003Dz7hRN5Rg_003D - num;
			_0023_003DzZzVr6_0024U_003D.Position = _0023_003DqJ75rpI46d2e8QXpNMN_0024n8dMRYzA7SCPvf_0024hn0hkQhQY_003D3._0023_003Dz7hRN5Rg_003D;
			_0023_003DzKyPCKaY_003D = num4 - num;
		}
	}

	private int _0023_003DzVFFAwICpBGQtwIs38_0024Mj_00245kvMDiJ(int _0023_003Dzq80RbjQ_003D)
	{
		return _0023_003Dzq80RbjQ_003D - _0023_003Dzq80RbjQ_003D % _0023_003DzcbLoSrg_003D._0023_003DzKD7tWS1ra9PIeIyFrm74c2aSenNaSrE4FltpI34HWkKS();
	}

	public override int Read(byte[] _0023_003Dzq80RbjQ_003D, int _0023_003DzZzVr6_0024U_003D, int _0023_003Dz7hRN5Rg_003D)
	{
		if (_0023_003Dzq80RbjQ_003D == null)
		{
			throw new ArgumentNullException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355525976));
		}
		if (_0023_003DzZzVr6_0024U_003D < 0)
		{
			throw new ArgumentOutOfRangeException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355526063));
		}
		if (_0023_003Dz7hRN5Rg_003D < 0)
		{
			throw new ArgumentOutOfRangeException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355526050));
		}
		if (_0023_003Dzq80RbjQ_003D.Length - _0023_003DzZzVr6_0024U_003D < _0023_003Dz7hRN5Rg_003D)
		{
			throw new ArgumentException();
		}
		int num = _0023_003DzZzVr6_0024U_003D;
		int num2 = _0023_003DzVo9kPXlXPS8CrrYteUk2b9I_003D(_0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D);
		if (num2 == _0023_003Dz7hRN5Rg_003D)
		{
			return num2;
		}
		int num3 = num2;
		if (num2 > 0)
		{
			_0023_003Dz7hRN5Rg_003D -= num2;
			_0023_003DzZzVr6_0024U_003D += num2;
		}
		_0023_003DzKyPCKaY_003D = (_0023_003DzoVpU9JU_003D = 0);
		_0023_003Dz538jN3nfkg9p_1JEpn6qx8rAjJjy();
		if (_0023_003Dz7hRN5Rg_003D >= _0023_003DzcbLoSrg_003D._0023_003DzKD7tWS1ra9PIeIyFrm74c2aSenNaSrE4FltpI34HWkKS())
		{
			if (_0023_003DzuwE9t4w_003D == null)
			{
				return this._0023_003DzZzVr6_0024U_003D.Read(_0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D) + num3;
			}
			int num4 = (int)this._0023_003DzZzVr6_0024U_003D.Position - num3;
			if (_0023_003DzuwE9t4w_003D._0023_003Dz1GSWjgaVw6NF6lIsWA_003D_003D(num4, _0023_003Dzq80RbjQ_003D, num, _0023_003Dz7hRN5Rg_003D + num3, out var num5))
			{
				this._0023_003DzZzVr6_0024U_003D.Seek(num5 - num3, SeekOrigin.Current);
				return num5;
			}
			num5 = this._0023_003DzZzVr6_0024U_003D.Read(_0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D);
			if (num5 != 0)
			{
				_0023_003DzuwE9t4w_003D._0023_003DzaNCbk4ZIiTcKuIP1HwFyx5L_00247pr1JNJFIgfRYXE_003D(num4, _0023_003Dzq80RbjQ_003D, num, num5 + num3, num5 < _0023_003Dz7hRN5Rg_003D);
			}
			return num5 + num3;
		}
		_0023_003DzJiYGHHZDCbHiQCVlw7cDEmI_003D(_0023_003Dz7hRN5Rg_003D);
		num2 = _0023_003DzVo9kPXlXPS8CrrYteUk2b9I_003D(_0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D);
		return num2 + num3;
	}

	public override long Seek(long _0023_003Dzq80RbjQ_003D, SeekOrigin _0023_003DzZzVr6_0024U_003D)
	{
		if (_0023_003DzoVpU9JU_003D - _0023_003DzKyPCKaY_003D > 0 && _0023_003DzZzVr6_0024U_003D == SeekOrigin.Current)
		{
			_0023_003Dzq80RbjQ_003D -= _0023_003DzoVpU9JU_003D - _0023_003DzKyPCKaY_003D;
		}
		long position = Position;
		long num = this._0023_003DzZzVr6_0024U_003D.Seek(_0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D);
		_0023_003DzKyPCKaY_003D = (int)(num - (position - _0023_003DzKyPCKaY_003D));
		if (0 <= _0023_003DzKyPCKaY_003D && _0023_003DzKyPCKaY_003D < _0023_003DzoVpU9JU_003D)
		{
			this._0023_003DzZzVr6_0024U_003D.Seek(_0023_003DzoVpU9JU_003D - _0023_003DzKyPCKaY_003D, SeekOrigin.Current);
		}
		else
		{
			_0023_003DzKyPCKaY_003D = (_0023_003DzoVpU9JU_003D = 0);
		}
		return num;
	}
}
