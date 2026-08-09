using System;
using System.Diagnostics;
using System.IO;
using System.Text;

internal sealed class _0023_003Dq92i4vUz2r2p0Q1QJdKoEru9tmNPrV7XoY6GK4JPSqdU_003D : IDisposable
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DqYTk4xL9y3yUl3kt9Zicf_0024AcD_00240AYfMykjylq4w9BbNg_003D _0023_003Dzq80RbjQ_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private byte[] _0023_003DzZzVr6_0024U_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Decoder _0023_003Dz7hRN5Rg_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private byte[] _0023_003DzcbLoSrg_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private char[] _0023_003DzqMLoHoQ_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private char[] _0023_003DzuwE9t4w_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzoyRBT1A_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzLaPeX80_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzKyPCKaY_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private byte[] _0023_003DzoVpU9JU_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private MemoryStream _0023_003Dz5QkdKZk_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private BinaryReader _0023_003DzkJp9o4I_003D;

	public _0023_003Dq92i4vUz2r2p0Q1QJdKoEru9tmNPrV7XoY6GK4JPSqdU_003D(_0023_003DqYTk4xL9y3yUl3kt9Zicf_0024AcD_00240AYfMykjylq4w9BbNg_003D _0023_003Dzq80RbjQ_003D)
		: this(_0023_003Dzq80RbjQ_003D, new UTF8Encoding())
	{
	}

	private _0023_003Dq92i4vUz2r2p0Q1QJdKoEru9tmNPrV7XoY6GK4JPSqdU_003D(_0023_003DqYTk4xL9y3yUl3kt9Zicf_0024AcD_00240AYfMykjylq4w9BbNg_003D _0023_003Dzq80RbjQ_003D, Encoding _0023_003DzZzVr6_0024U_003D)
	{
		if (_0023_003Dzq80RbjQ_003D == null)
		{
			throw new ArgumentNullException();
		}
		if (_0023_003DzZzVr6_0024U_003D == null)
		{
			throw new ArgumentNullException();
		}
		if (!_0023_003Dzq80RbjQ_003D._0023_003DzHFGE36X4nG8G46m87ZI49vnZCuVAnD4cLmEooV24GJj7PQlYvpARIVItXtBx2lFmv0RZ02M_003D())
		{
			throw new ArgumentException();
		}
		this._0023_003Dzq80RbjQ_003D = _0023_003Dzq80RbjQ_003D;
		_0023_003Dz7hRN5Rg_003D = _0023_003DzZzVr6_0024U_003D.GetDecoder();
		_0023_003DzoyRBT1A_003D = _0023_003DzZzVr6_0024U_003D.GetMaxCharCount(128);
		int num = _0023_003DzZzVr6_0024U_003D.GetMaxByteCount(1);
		if (num < 16)
		{
			num = 16;
		}
		this._0023_003DzZzVr6_0024U_003D = new byte[num];
		_0023_003DzuwE9t4w_003D = null;
		_0023_003DzcbLoSrg_003D = null;
		_0023_003DzLaPeX80_003D = _0023_003DzZzVr6_0024U_003D is UnicodeEncoding;
		_0023_003DzKyPCKaY_003D = this._0023_003Dzq80RbjQ_003D is _0023_003DqpOsddWbqwzI4Xv5sOvd5rpoZ6gijBx5aVsJ7lVmnLX0_003D;
	}

	public _0023_003DqYTk4xL9y3yUl3kt9Zicf_0024AcD_00240AYfMykjylq4w9BbNg_003D _0023_003DzK0AegGgD4wsVcOVC6US3uP0INSu2Pf44ng_003D_003D()
	{
		return _0023_003Dzq80RbjQ_003D;
	}

	public void _0023_003Dzrw5JI6WI_TxIbfKkVtZo9VJ2pIMrIEirHQ_003D_003D()
	{
		_0023_003DzXtpsxILfIp_hyCf7pv_f7cSGS21Hecozhw_003D_003D(_0023_003Dzq80RbjQ_003D: true);
	}

	private void _0023_003DzXtpsxILfIp_hyCf7pv_f7cSGS21Hecozhw_003D_003D(bool _0023_003Dzq80RbjQ_003D)
	{
		if (_0023_003Dzq80RbjQ_003D)
		{
			_0023_003DqYTk4xL9y3yUl3kt9Zicf_0024AcD_00240AYfMykjylq4w9BbNg_003D _0023_003DqYTk4xL9y3yUl3kt9Zicf_0024AcD_00240AYfMykjylq4w9BbNg_003D2 = this._0023_003Dzq80RbjQ_003D;
			this._0023_003Dzq80RbjQ_003D = null;
			_0023_003DqYTk4xL9y3yUl3kt9Zicf_0024AcD_00240AYfMykjylq4w9BbNg_003D2?._0023_003DziM47CgM3yWK9aJZiXnvDXJqW8Ue1d_Zg5XB64FUNdTZS39oKk1T8PL4t07IXFIFIVdNRs3qSMjT_00247Yqzh_lcNyo_003D();
		}
		this._0023_003Dzq80RbjQ_003D = null;
		_0023_003DzZzVr6_0024U_003D = null;
		_0023_003Dz7hRN5Rg_003D = null;
		_0023_003DzcbLoSrg_003D = null;
		_0023_003DzqMLoHoQ_003D = null;
		_0023_003DzuwE9t4w_003D = null;
	}

	private void _0023_003DzsIESWrJBgVnkxISj2eRkncq9i9hBEsK37wMrG9F3D_cEQ11RrmMhZkR0hBjRLLUVSamMgFO_0024l05J()
	{
		_0023_003DzXtpsxILfIp_hyCf7pv_f7cSGS21Hecozhw_003D_003D(_0023_003Dzq80RbjQ_003D: true);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zsIESWrJBgVnkxISj2eRkncq9i9hBEsK37wMrG9F3D_cEQ11RrmMhZkR0hBjRLLUVSamMgFO$l05J
		this._0023_003DzsIESWrJBgVnkxISj2eRkncq9i9hBEsK37wMrG9F3D_cEQ11RrmMhZkR0hBjRLLUVSamMgFO_0024l05J();
	}

	public int _0023_003DzLYQcTGCsy1Z5vQkB_RX_0024GfQ_003D()
	{
		_0023_003DzS2DJKw0r0tOHpYjF2k5fYNEfYNo4vEfk_0024kb_N5BOYtOS();
		if (!_0023_003Dzq80RbjQ_003D._0023_003DzvMmIPP0H_S13CBVMIx3BuF_riMzeAsoTCpQsVefjLuYXUAXG6V8zFYCl_FDbqkaoTaOFi4Bjn40q())
		{
			return -1;
		}
		long num = _0023_003Dzq80RbjQ_003D._0023_003DzobG9IxqhwRDSPcfxNOqGyLk4ZhoGqGKIxRc5EwzLMnMXwgfZ90nCXR8JGEQLK55L4VFmzy0_003D();
		int result = _0023_003DzH4oyg12QksZcA3zj9WW27XetjJ_OiS2M0A_003D_003D();
		_0023_003Dzq80RbjQ_003D._0023_003DzeAfqD85UAYY1g8prJCu4S9JwzuyBHOSQrVdSiwf3Lj4Gqu9mD0yaZmrEmeHhlRxoawLGCBo_003D(num);
		return result;
	}

	public int _0023_003DzH4oyg12QksZcA3zj9WW27XetjJ_OiS2M0A_003D_003D()
	{
		_0023_003DzS2DJKw0r0tOHpYjF2k5fYNEfYNo4vEfk_0024kb_N5BOYtOS();
		return _0023_003DzFrItt0MvFPSdH6vBkBq6CD8_003D();
	}

	public bool _0023_003Dzu4XQE7baiUjLN0aaVp8iPQQ_003D()
	{
		_0023_003Dzs3LiRtzOjpZo_rR26_lc9pWTghs8THdnjw_003D_003D(1);
		return _0023_003DzZzVr6_0024U_003D[0] != 0;
	}

	public byte _0023_003Dzgie8dX3wQlY8J8uAg8gyr39CXYW8L0PGHZYb0G4_003D()
	{
		_0023_003DzS2DJKw0r0tOHpYjF2k5fYNEfYNo4vEfk_0024kb_N5BOYtOS();
		int num = _0023_003Dzq80RbjQ_003D._0023_003DzbnO9dtFGogvfxYIC_1KDeXzgmR7PVNfCBCcxW4LqFesA0t0n216lG_SZN7yBQdzks18OA8e3VHO3x_NluSJ375L_RUoc();
		if (num == -1)
		{
			throw new Exception();
		}
		return (byte)num;
	}

	public sbyte _0023_003DzYxwpE779ciLA4_0024V5CIlDrqo_003D()
	{
		_0023_003Dzs3LiRtzOjpZo_rR26_lc9pWTghs8THdnjw_003D_003D(1);
		return (sbyte)_0023_003DzZzVr6_0024U_003D[0];
	}

	public char _0023_003DzeJsjG3d2ZtJFmwTFYg_003D_003D()
	{
		int num = _0023_003DzH4oyg12QksZcA3zj9WW27XetjJ_OiS2M0A_003D_003D();
		if (num == -1)
		{
			throw new Exception();
		}
		return (char)num;
	}

	private static decimal _0023_003DzNJ7zpCzTpY2m6dkvIL58tRmXE58if_nEMg59dY_0024Bx4TZ(int _0023_003Dzq80RbjQ_003D, int _0023_003DzZzVr6_0024U_003D, int _0023_003Dz7hRN5Rg_003D, int _0023_003DzcbLoSrg_003D)
	{
		bool isNegative = (_0023_003DzcbLoSrg_003D & int.MinValue) != 0;
		byte scale = (byte)(_0023_003DzcbLoSrg_003D >> 16);
		return new decimal(_0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D, isNegative, scale);
	}

	internal static decimal _0023_003DzBRlsLJ6V1Z_00247UqXa_cqD8RoesnzJ37MeUA_003D_003D(byte[] _0023_003Dzq80RbjQ_003D)
	{
		int num = _0023_003Dzq80RbjQ_003D[0] | (_0023_003Dzq80RbjQ_003D[1] << 8) | (_0023_003Dzq80RbjQ_003D[2] << 16) | (_0023_003Dzq80RbjQ_003D[3] << 24);
		int num2 = _0023_003Dzq80RbjQ_003D[4] | (_0023_003Dzq80RbjQ_003D[5] << 8) | (_0023_003Dzq80RbjQ_003D[6] << 16) | (_0023_003Dzq80RbjQ_003D[7] << 24);
		int num3 = _0023_003Dzq80RbjQ_003D[8] | (_0023_003Dzq80RbjQ_003D[9] << 8) | (_0023_003Dzq80RbjQ_003D[10] << 16) | (_0023_003Dzq80RbjQ_003D[11] << 24);
		int num4 = _0023_003Dzq80RbjQ_003D[12] | (_0023_003Dzq80RbjQ_003D[13] << 8) | (_0023_003Dzq80RbjQ_003D[14] << 16) | (_0023_003Dzq80RbjQ_003D[15] << 24);
		return _0023_003DzNJ7zpCzTpY2m6dkvIL58tRmXE58if_nEMg59dY_0024Bx4TZ(num, num2, num3, num4);
	}

	public string _0023_003DzXDeO0ZPZHx72cYMmETLMlaj5qFonnk1sTAhKpy0_003D()
	{
		int num = 0;
		_0023_003DzS2DJKw0r0tOHpYjF2k5fYNEfYNo4vEfk_0024kb_N5BOYtOS();
		int num2 = _0023_003Dz2zeqxm_0024BvS1cRa9VitGV0MMzs8pL();
		if (num2 < 0)
		{
			throw new IOException();
		}
		if (num2 == 0)
		{
			return string.Empty;
		}
		if (_0023_003DzcbLoSrg_003D == null)
		{
			_0023_003DzcbLoSrg_003D = new byte[128];
		}
		if (_0023_003DzuwE9t4w_003D == null)
		{
			_0023_003DzuwE9t4w_003D = new char[_0023_003DzoyRBT1A_003D];
		}
		StringBuilder stringBuilder = null;
		do
		{
			int num3 = ((num2 - num > 128) ? 128 : (num2 - num));
			int num4 = _0023_003Dzq80RbjQ_003D._0023_003DzJOoT4gsPGoibAzkPGQ31PpiYn_hZ3qvRCOxibWgYa3KnAQHxK9Wt69jVIDs25kwu05DuT1KcBeXXwLt8kA_003D_003D(_0023_003DzcbLoSrg_003D, 0, num3);
			if (num4 == 0)
			{
				throw new Exception();
			}
			int chars = _0023_003Dz7hRN5Rg_003D.GetChars(_0023_003DzcbLoSrg_003D, 0, num4, _0023_003DzuwE9t4w_003D, 0);
			if (num == 0 && num4 == num2)
			{
				return new string(_0023_003DzuwE9t4w_003D, 0, chars);
			}
			if (stringBuilder == null)
			{
				stringBuilder = new StringBuilder(num2);
			}
			stringBuilder.Append(_0023_003DzuwE9t4w_003D, 0, chars);
			num += num4;
		}
		while (num < num2);
		return stringBuilder.ToString();
	}

	public int _0023_003Dzqx0be5zLfR7lGAatbPAZM1l7Syr_MqLPCg_003D_003D(char[] _0023_003Dzq80RbjQ_003D, int _0023_003DzZzVr6_0024U_003D, int _0023_003Dz7hRN5Rg_003D)
	{
		if (_0023_003Dzq80RbjQ_003D == null)
		{
			throw new ArgumentNullException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355527901), _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355527888));
		}
		if (_0023_003DzZzVr6_0024U_003D < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (_0023_003Dz7hRN5Rg_003D < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (_0023_003Dzq80RbjQ_003D.Length - _0023_003DzZzVr6_0024U_003D < _0023_003Dz7hRN5Rg_003D)
		{
			throw new ArgumentException();
		}
		_0023_003DzS2DJKw0r0tOHpYjF2k5fYNEfYNo4vEfk_0024kb_N5BOYtOS();
		return _0023_003DzEshd_LOdqxTC_0024do4ay7GhtMjx_0024YG(_0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D);
	}

	private int _0023_003DzEshd_LOdqxTC_0024do4ay7GhtMjx_0024YG(char[] _0023_003Dzq80RbjQ_003D, int _0023_003DzZzVr6_0024U_003D, int _0023_003Dz7hRN5Rg_003D)
	{
		int num = 0;
		int num2 = 0;
		int num3 = _0023_003Dz7hRN5Rg_003D;
		if (_0023_003DzcbLoSrg_003D == null)
		{
			_0023_003DzcbLoSrg_003D = new byte[128];
		}
		while (num3 > 0)
		{
			num2 = num3;
			if (_0023_003DzLaPeX80_003D)
			{
				num2 <<= 1;
			}
			if (num2 > 128)
			{
				num2 = 128;
			}
			if (_0023_003DzKyPCKaY_003D)
			{
				_0023_003DqpOsddWbqwzI4Xv5sOvd5rpoZ6gijBx5aVsJ7lVmnLX0_003D _0023_003DqpOsddWbqwzI4Xv5sOvd5rpoZ6gijBx5aVsJ7lVmnLX0_003D2 = (_0023_003DqpOsddWbqwzI4Xv5sOvd5rpoZ6gijBx5aVsJ7lVmnLX0_003D)this._0023_003Dzq80RbjQ_003D;
				int byteIndex = _0023_003DqpOsddWbqwzI4Xv5sOvd5rpoZ6gijBx5aVsJ7lVmnLX0_003D2._0023_003DzQ1lXfjg1bxlJ_I4ngNELCYfdJLOA();
				num2 = _0023_003DqpOsddWbqwzI4Xv5sOvd5rpoZ6gijBx5aVsJ7lVmnLX0_003D2._0023_003DzjRaSYYflF0vxagBuM7ws8Y2BS9t2(num2);
				if (num2 == 0)
				{
					return _0023_003Dz7hRN5Rg_003D - num3;
				}
				num = this._0023_003Dz7hRN5Rg_003D.GetChars(_0023_003DqpOsddWbqwzI4Xv5sOvd5rpoZ6gijBx5aVsJ7lVmnLX0_003D2._0023_003DzLcbIGdcfz9o_QtusyyVjsXg_003D(), byteIndex, num2, _0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D);
			}
			else
			{
				num2 = this._0023_003Dzq80RbjQ_003D._0023_003DzJOoT4gsPGoibAzkPGQ31PpiYn_hZ3qvRCOxibWgYa3KnAQHxK9Wt69jVIDs25kwu05DuT1KcBeXXwLt8kA_003D_003D(_0023_003DzcbLoSrg_003D, 0, num2);
				if (num2 == 0)
				{
					return _0023_003Dz7hRN5Rg_003D - num3;
				}
				num = this._0023_003Dz7hRN5Rg_003D.GetChars(_0023_003DzcbLoSrg_003D, 0, num2, _0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D);
			}
			num3 -= num;
			_0023_003DzZzVr6_0024U_003D += num;
		}
		return _0023_003Dz7hRN5Rg_003D;
	}

	private int _0023_003DzFrItt0MvFPSdH6vBkBq6CD8_003D()
	{
		int num = 0;
		int num2 = 0;
		long num3 = (num3 = 0L);
		if (_0023_003Dzq80RbjQ_003D._0023_003DzvMmIPP0H_S13CBVMIx3BuF_riMzeAsoTCpQsVefjLuYXUAXG6V8zFYCl_FDbqkaoTaOFi4Bjn40q())
		{
			num3 = _0023_003Dzq80RbjQ_003D._0023_003DzobG9IxqhwRDSPcfxNOqGyLk4ZhoGqGKIxRc5EwzLMnMXwgfZ90nCXR8JGEQLK55L4VFmzy0_003D();
		}
		if (_0023_003DzcbLoSrg_003D == null)
		{
			_0023_003DzcbLoSrg_003D = new byte[128];
		}
		if (_0023_003DzqMLoHoQ_003D == null)
		{
			_0023_003DzqMLoHoQ_003D = new char[1];
		}
		while (num == 0)
		{
			num2 = ((!_0023_003DzLaPeX80_003D) ? 1 : 2);
			int num4 = _0023_003Dzq80RbjQ_003D._0023_003DzbnO9dtFGogvfxYIC_1KDeXzgmR7PVNfCBCcxW4LqFesA0t0n216lG_SZN7yBQdzks18OA8e3VHO3x_NluSJ375L_RUoc();
			_0023_003DzcbLoSrg_003D[0] = (byte)num4;
			if (num4 == -1)
			{
				num2 = 0;
			}
			if (num2 == 2)
			{
				num4 = _0023_003Dzq80RbjQ_003D._0023_003DzbnO9dtFGogvfxYIC_1KDeXzgmR7PVNfCBCcxW4LqFesA0t0n216lG_SZN7yBQdzks18OA8e3VHO3x_NluSJ375L_RUoc();
				_0023_003DzcbLoSrg_003D[1] = (byte)num4;
				if (num4 == -1)
				{
					num2 = 1;
				}
			}
			if (num2 == 0)
			{
				return -1;
			}
			try
			{
				num = _0023_003Dz7hRN5Rg_003D.GetChars(_0023_003DzcbLoSrg_003D, 0, num2, _0023_003DzqMLoHoQ_003D, 0);
			}
			catch
			{
				if (_0023_003Dzq80RbjQ_003D._0023_003DzvMmIPP0H_S13CBVMIx3BuF_riMzeAsoTCpQsVefjLuYXUAXG6V8zFYCl_FDbqkaoTaOFi4Bjn40q())
				{
					_0023_003Dzq80RbjQ_003D._0023_003DzI4vE0RkXfN1pne8gbSVDgBlALYg3vbbRkBocu_0024P6sDNdA9J9PRaszMCsJP8vkAvSyWXjY_0024fkw_sdJCJA_0024Q_003D_003D(num3 - _0023_003Dzq80RbjQ_003D._0023_003DzobG9IxqhwRDSPcfxNOqGyLk4ZhoGqGKIxRc5EwzLMnMXwgfZ90nCXR8JGEQLK55L4VFmzy0_003D(), 1);
				}
				throw;
			}
		}
		if (num == 0)
		{
			return -1;
		}
		return _0023_003DzqMLoHoQ_003D[0];
	}

	public char[] _0023_003Dzc72pKPIHtq6jUyfpTWQsud_inHZRS11Xxg_003D_003D(int _0023_003Dzq80RbjQ_003D)
	{
		_0023_003DzS2DJKw0r0tOHpYjF2k5fYNEfYNo4vEfk_0024kb_N5BOYtOS();
		if (_0023_003Dzq80RbjQ_003D < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		char[] array = new char[_0023_003Dzq80RbjQ_003D];
		int num = _0023_003DzEshd_LOdqxTC_0024do4ay7GhtMjx_0024YG(array, 0, _0023_003Dzq80RbjQ_003D);
		if (num != _0023_003Dzq80RbjQ_003D)
		{
			char[] array2 = new char[num];
			Buffer.BlockCopy(array, 0, array2, 0, 2 * num);
			array = array2;
		}
		return array;
	}

	public int _0023_003DzSlkabk59KHIoAbDGK_0024tNGSk_0024dqH_qsBGNg_003D_003D(byte[] _0023_003Dzq80RbjQ_003D, int _0023_003DzZzVr6_0024U_003D, int _0023_003Dz7hRN5Rg_003D)
	{
		if (_0023_003Dzq80RbjQ_003D == null)
		{
			throw new ArgumentNullException();
		}
		if (_0023_003DzZzVr6_0024U_003D < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (_0023_003Dz7hRN5Rg_003D < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (_0023_003Dzq80RbjQ_003D.Length - _0023_003DzZzVr6_0024U_003D < _0023_003Dz7hRN5Rg_003D)
		{
			throw new ArgumentException();
		}
		_0023_003DzS2DJKw0r0tOHpYjF2k5fYNEfYNo4vEfk_0024kb_N5BOYtOS();
		return this._0023_003Dzq80RbjQ_003D._0023_003DzJOoT4gsPGoibAzkPGQ31PpiYn_hZ3qvRCOxibWgYa3KnAQHxK9Wt69jVIDs25kwu05DuT1KcBeXXwLt8kA_003D_003D(_0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D);
	}

	private void _0023_003DzS2DJKw0r0tOHpYjF2k5fYNEfYNo4vEfk_0024kb_N5BOYtOS()
	{
		if (_0023_003Dzq80RbjQ_003D == null)
		{
			throw new Exception();
		}
	}

	public byte[] _0023_003DzTb8hJcDRWwc6ASAjpMe3Qa7gGO9BMd7Glg_003D_003D(int _0023_003Dzq80RbjQ_003D)
	{
		if (_0023_003Dzq80RbjQ_003D < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		_0023_003DzS2DJKw0r0tOHpYjF2k5fYNEfYNo4vEfk_0024kb_N5BOYtOS();
		byte[] array = new byte[_0023_003Dzq80RbjQ_003D];
		int num = 0;
		do
		{
			int num2 = this._0023_003Dzq80RbjQ_003D._0023_003DzJOoT4gsPGoibAzkPGQ31PpiYn_hZ3qvRCOxibWgYa3KnAQHxK9Wt69jVIDs25kwu05DuT1KcBeXXwLt8kA_003D_003D(array, num, _0023_003Dzq80RbjQ_003D);
			if (num2 == 0)
			{
				break;
			}
			num += num2;
			_0023_003Dzq80RbjQ_003D -= num2;
		}
		while (_0023_003Dzq80RbjQ_003D > 0);
		if (num != array.Length)
		{
			byte[] array2 = new byte[num];
			Buffer.BlockCopy(array, 0, array2, 0, num);
			array = array2;
		}
		return array;
	}

	private void _0023_003Dzs3LiRtzOjpZo_rR26_lc9pWTghs8THdnjw_003D_003D(int _0023_003Dzq80RbjQ_003D)
	{
		_0023_003DzS2DJKw0r0tOHpYjF2k5fYNEfYNo4vEfk_0024kb_N5BOYtOS();
		int num = 0;
		int num2 = 0;
		if (_0023_003Dzq80RbjQ_003D == 1)
		{
			num2 = this._0023_003Dzq80RbjQ_003D._0023_003DzbnO9dtFGogvfxYIC_1KDeXzgmR7PVNfCBCcxW4LqFesA0t0n216lG_SZN7yBQdzks18OA8e3VHO3x_NluSJ375L_RUoc();
			if (num2 == -1)
			{
				throw new Exception();
			}
			_0023_003DzZzVr6_0024U_003D[0] = (byte)num2;
			return;
		}
		do
		{
			num2 = this._0023_003Dzq80RbjQ_003D._0023_003DzJOoT4gsPGoibAzkPGQ31PpiYn_hZ3qvRCOxibWgYa3KnAQHxK9Wt69jVIDs25kwu05DuT1KcBeXXwLt8kA_003D_003D(_0023_003DzZzVr6_0024U_003D, num, _0023_003Dzq80RbjQ_003D - num);
			if (num2 == 0)
			{
				throw new Exception();
			}
			num += num2;
		}
		while (num < _0023_003Dzq80RbjQ_003D);
	}

	internal int _0023_003Dz2zeqxm_0024BvS1cRa9VitGV0MMzs8pL()
	{
		int num = 0;
		int num2 = 0;
		byte b;
		do
		{
			if (num2 == 35)
			{
				throw new FormatException();
			}
			b = _0023_003Dzgie8dX3wQlY8J8uAg8gyr39CXYW8L0PGHZYb0G4_003D();
			num |= (b & 0x7F) << num2;
			num2 += 7;
		}
		while ((b & 0x80) != 0);
		return num;
	}

	public int _0023_003Dz54f_9Zwk7KXGsO1HSe28cbSe0t4SIcU23g_003D_003D()
	{
		if (_0023_003DzKyPCKaY_003D)
		{
			return ((_0023_003DqpOsddWbqwzI4Xv5sOvd5rpoZ6gijBx5aVsJ7lVmnLX0_003D)_0023_003Dzq80RbjQ_003D)._0023_003Dzh5DMsiZCgHIXWxCfsbrC7euQjhsXK7JCBi77oK4DXKhB();
		}
		_0023_003Dzs3LiRtzOjpZo_rR26_lc9pWTghs8THdnjw_003D_003D(4);
		return _0023_003DzZzVr6_0024U_003D[0] | (_0023_003DzZzVr6_0024U_003D[3] << 24) | (_0023_003DzZzVr6_0024U_003D[1] << 16) | (_0023_003DzZzVr6_0024U_003D[2] << 8);
	}

	public uint _0023_003Dzxwm21_nmp2f5Ms_0024F4Fcqvf9_0024L1SjCRntwfAJwq4_003D()
	{
		_0023_003Dzs3LiRtzOjpZo_rR26_lc9pWTghs8THdnjw_003D_003D(4);
		return (uint)((_0023_003DzZzVr6_0024U_003D[3] << 16) | _0023_003DzZzVr6_0024U_003D[1] | (_0023_003DzZzVr6_0024U_003D[0] << 8) | (_0023_003DzZzVr6_0024U_003D[2] << 24));
	}

	public long _0023_003Dzp_l1PqLcSGPUHQ75iBvbWgkFJ8MX42NzxbPuGSryMcYN()
	{
		_0023_003Dzs3LiRtzOjpZo_rR26_lc9pWTghs8THdnjw_003D_003D(8);
		byte[] array = _0023_003DzZzVr6_0024U_003D;
		return (uint)((array[7] << 8) | (array[2] << 24) | array[0] | (array[1] << 16)) | ((long)((array[5] << 24) | (array[6] << 16) | array[4] | (array[3] << 8)) << 32);
	}

	public ulong _0023_003Dzg48Lb_0n79k_0024y7bq2E6Xm39RukWnWnHT51AAor0HBbE4()
	{
		_0023_003Dzs3LiRtzOjpZo_rR26_lc9pWTghs8THdnjw_003D_003D(8);
		byte[] array = _0023_003DzZzVr6_0024U_003D;
		return (ulong)((uint)((array[2] << 16) | (array[5] << 24) | (array[4] << 8) | array[6]) | ((long)((array[1] << 16) | array[0] | (array[7] << 24) | (array[3] << 8)) << 32));
	}

	public short _0023_003DzAT5B_0024KrVlUL38D8pF9i1EEk_003D()
	{
		_0023_003Dzs3LiRtzOjpZo_rR26_lc9pWTghs8THdnjw_003D_003D(2);
		byte[] array = _0023_003DzZzVr6_0024U_003D;
		return (short)((array[0] << 8) | array[1]);
	}

	public ushort _0023_003DzZghloTfY5RAcAlQwKAN5HyUxVKvn1iSd9jMNJ_3h2xTY()
	{
		_0023_003Dzs3LiRtzOjpZo_rR26_lc9pWTghs8THdnjw_003D_003D(2);
		byte[] array = _0023_003DzZzVr6_0024U_003D;
		return (ushort)(array[1] | (array[0] << 8));
	}

	private byte[] _0023_003DzngLYW6NNKo_0024LfIyiUsV9Nz5kzZIn()
	{
		byte[] array = _0023_003DzoVpU9JU_003D;
		if (array == null)
		{
			array = (_0023_003DzoVpU9JU_003D = new byte[16]);
		}
		return array;
	}

	public float _0023_003DzIbBE7KhlxKoTwpSpq6mcrXxuMo3nfqpAnbrSQUpbMyP3()
	{
		_0023_003Dzs3LiRtzOjpZo_rR26_lc9pWTghs8THdnjw_003D_003D(4);
		byte[] array = _0023_003DzZzVr6_0024U_003D;
		byte[] array2 = _0023_003DzngLYW6NNKo_0024LfIyiUsV9Nz5kzZIn();
		array2[1] = array[1];
		array2[3] = array[0];
		array2[2] = array[2];
		array2[0] = array[3];
		return _0023_003DzVwJPAQARYNm4_MAr1ktkpZTproL5_00243P9lA_003D_003D(array2).ReadSingle();
	}

	public double _0023_003DzOhiaokG9hmf1w4nBvB5tb_vQVupd()
	{
		_0023_003Dzs3LiRtzOjpZo_rR26_lc9pWTghs8THdnjw_003D_003D(8);
		byte[] array = _0023_003DzZzVr6_0024U_003D;
		byte[] array2 = _0023_003DzngLYW6NNKo_0024LfIyiUsV9Nz5kzZIn();
		array2[5] = array[1];
		array2[2] = array[4];
		array2[0] = array[2];
		array2[3] = array[3];
		array2[7] = array[0];
		array2[4] = array[6];
		array2[1] = array[5];
		array2[6] = array[7];
		return _0023_003DzVwJPAQARYNm4_MAr1ktkpZTproL5_00243P9lA_003D_003D(array2).ReadDouble();
	}

	public decimal _0023_003DzUkPOOPMvw_XxRT_0024kOcgaq7FZnuZPtfGTiV7rGAzk4M87()
	{
		_0023_003Dzs3LiRtzOjpZo_rR26_lc9pWTghs8THdnjw_003D_003D(16);
		byte[] array = _0023_003DzZzVr6_0024U_003D;
		byte[] array2 = _0023_003DzngLYW6NNKo_0024LfIyiUsV9Nz5kzZIn();
		array2[14] = array[11];
		array2[5] = array[12];
		array2[7] = array[9];
		array2[6] = array[1];
		array2[10] = array[8];
		array2[11] = array[10];
		array2[8] = array[3];
		array2[0] = array[14];
		array2[4] = array[15];
		array2[3] = array[13];
		array2[1] = array[2];
		array2[2] = array[6];
		array2[15] = array[7];
		array2[9] = array[4];
		array2[12] = array[0];
		array2[13] = array[5];
		return _0023_003DzBRlsLJ6V1Z_00247UqXa_cqD8RoesnzJ37MeUA_003D_003D(array2);
	}

	private BinaryReader _0023_003DzVwJPAQARYNm4_MAr1ktkpZTproL5_00243P9lA_003D_003D(byte[] _0023_003Dzq80RbjQ_003D)
	{
		MemoryStream memoryStream = _0023_003Dz5QkdKZk_003D;
		BinaryReader binaryReader = _0023_003DzkJp9o4I_003D;
		if (memoryStream == null)
		{
			memoryStream = (_0023_003Dz5QkdKZk_003D = new MemoryStream(8));
			binaryReader = (_0023_003DzkJp9o4I_003D = new BinaryReader(memoryStream));
		}
		else
		{
			binaryReader.BaseStream.Position = 0L;
		}
		memoryStream.Write(_0023_003Dzq80RbjQ_003D, 0, _0023_003Dzq80RbjQ_003D.Length);
		memoryStream.Position = 0L;
		return binaryReader;
	}
}
