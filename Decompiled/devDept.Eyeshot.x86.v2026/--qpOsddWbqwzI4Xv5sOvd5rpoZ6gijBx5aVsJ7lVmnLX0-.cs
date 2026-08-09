using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

internal sealed class _0023_003DqpOsddWbqwzI4Xv5sOvd5rpoZ6gijBx5aVsJ7lVmnLX0_003D : _0023_003DqYTk4xL9y3yUl3kt9Zicf_0024AcD_00240AYfMykjylq4w9BbNg_003D, IDisposable
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private byte[] _0023_003Dzq80RbjQ_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzZzVr6_0024U_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dz7hRN5Rg_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzcbLoSrg_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzqMLoHoQ_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzuwE9t4w_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzoyRBT1A_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzLaPeX80_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzKyPCKaY_003D;

	public _0023_003DqpOsddWbqwzI4Xv5sOvd5rpoZ6gijBx5aVsJ7lVmnLX0_003D()
		: this(0)
	{
	}

	public _0023_003DqpOsddWbqwzI4Xv5sOvd5rpoZ6gijBx5aVsJ7lVmnLX0_003D(int _0023_003Dzq80RbjQ_003D)
	{
		if (_0023_003Dzq80RbjQ_003D < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		this._0023_003Dzq80RbjQ_003D = new byte[_0023_003Dzq80RbjQ_003D];
		_0023_003DzqMLoHoQ_003D = _0023_003Dzq80RbjQ_003D;
		_0023_003DzuwE9t4w_003D = true;
		_0023_003DzoyRBT1A_003D = true;
		_0023_003DzZzVr6_0024U_003D = 0;
		_0023_003DzLaPeX80_003D = true;
	}

	public _0023_003DqpOsddWbqwzI4Xv5sOvd5rpoZ6gijBx5aVsJ7lVmnLX0_003D(byte[] _0023_003Dzq80RbjQ_003D)
		: this(_0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D: true)
	{
	}

	public _0023_003DqpOsddWbqwzI4Xv5sOvd5rpoZ6gijBx5aVsJ7lVmnLX0_003D(byte[] _0023_003Dzq80RbjQ_003D, bool _0023_003DzZzVr6_0024U_003D)
	{
		if (_0023_003Dzq80RbjQ_003D == null)
		{
			throw new ArgumentNullException();
		}
		this._0023_003Dzq80RbjQ_003D = _0023_003Dzq80RbjQ_003D;
		_0023_003DzcbLoSrg_003D = (_0023_003DzqMLoHoQ_003D = _0023_003Dzq80RbjQ_003D.Length);
		_0023_003DzoyRBT1A_003D = _0023_003DzZzVr6_0024U_003D;
		this._0023_003DzZzVr6_0024U_003D = 0;
		_0023_003DzLaPeX80_003D = true;
	}

	public _0023_003DqpOsddWbqwzI4Xv5sOvd5rpoZ6gijBx5aVsJ7lVmnLX0_003D(byte[] _0023_003Dzq80RbjQ_003D, int _0023_003DzZzVr6_0024U_003D, int _0023_003Dz7hRN5Rg_003D)
		: this(_0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D, _0023_003DzcbLoSrg_003D: true)
	{
	}

	public _0023_003DqpOsddWbqwzI4Xv5sOvd5rpoZ6gijBx5aVsJ7lVmnLX0_003D(byte[] _0023_003Dzq80RbjQ_003D, int _0023_003DzZzVr6_0024U_003D, int _0023_003Dz7hRN5Rg_003D, bool _0023_003DzcbLoSrg_003D)
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
		this._0023_003Dzq80RbjQ_003D = _0023_003Dzq80RbjQ_003D;
		this._0023_003DzZzVr6_0024U_003D = (this._0023_003Dz7hRN5Rg_003D = _0023_003DzZzVr6_0024U_003D);
		this._0023_003DzcbLoSrg_003D = (_0023_003DzqMLoHoQ_003D = _0023_003DzZzVr6_0024U_003D + _0023_003Dz7hRN5Rg_003D);
		_0023_003DzoyRBT1A_003D = _0023_003DzcbLoSrg_003D;
		_0023_003DzuwE9t4w_003D = false;
		_0023_003DzLaPeX80_003D = true;
	}

	[SpecialName]
	public override bool _0023_003DzHFGE36X4nG8G46m87ZI49vnZCuVAnD4cLmEooV24GJj7PQlYvpARIVItXtBx2lFmv0RZ02M_003D()
	{
		return _0023_003DzLaPeX80_003D;
	}

	[SpecialName]
	public override bool _0023_003DzvMmIPP0H_S13CBVMIx3BuF_riMzeAsoTCpQsVefjLuYXUAXG6V8zFYCl_FDbqkaoTaOFi4Bjn40q()
	{
		return _0023_003DzLaPeX80_003D;
	}

	[SpecialName]
	public override bool _0023_003DzITWEjiGogYkJOd7sGsxfYM4NvdseJGtNKCItLX4wwHqpu7_0024BbAc8iPG7cIU7Ap7sEPTHdaHxn6qM2faN5y_00245ovk_003D()
	{
		return _0023_003DzoyRBT1A_003D;
	}

	protected override void _0023_003DzB_yV8YzNzcugErGFQcVIWRQDQTlh_PY26FeR7DSlzIGv6OR7G1DKuUgiOucmYVlGybcEM4ONSnRko11cfmRy0ZQ_003D(bool _0023_003Dzq80RbjQ_003D)
	{
		if (!_0023_003DzKyPCKaY_003D)
		{
			if (_0023_003Dzq80RbjQ_003D)
			{
				_0023_003DzLaPeX80_003D = false;
				_0023_003DzoyRBT1A_003D = false;
				_0023_003DzuwE9t4w_003D = false;
			}
			_0023_003DzKyPCKaY_003D = true;
		}
	}

	private bool _0023_003DzsEbtgZ2_0024c33SR1qRmohVvzG8xi0smY4YVw_003D_003D(int _0023_003Dzq80RbjQ_003D)
	{
		if (_0023_003Dzq80RbjQ_003D < 0)
		{
			throw new IOException();
		}
		if (_0023_003Dzq80RbjQ_003D > _0023_003DzqMLoHoQ_003D)
		{
			int num = _0023_003Dzq80RbjQ_003D;
			if (num < 256)
			{
				num = 256;
			}
			if (num < _0023_003DzqMLoHoQ_003D * 2)
			{
				num = _0023_003DzqMLoHoQ_003D * 2;
			}
			_0023_003DzX88hHcca4fJvi9WkWYZCCzvfkbUJ(num);
			return true;
		}
		return false;
	}

	public override void _0023_003Dzv3klLckR6GYJ_db3LErj9FAuc7FerFKgy4mDcLFzMliLwIyQoTBvjFSuKoKK84_0024DEx_0024lTjeG4iW4Qw7V0w_003D_003D()
	{
	}

	internal byte[] _0023_003DzLcbIGdcfz9o_QtusyyVjsXg_003D()
	{
		return _0023_003Dzq80RbjQ_003D;
	}

	internal void _0023_003DzJPHJZGRy7VhMRX3J6_0024CImic_003D(out int _0023_003Dzq80RbjQ_003D, out int _0023_003DzZzVr6_0024U_003D)
	{
		if (!_0023_003DzLaPeX80_003D)
		{
			throw new Exception();
		}
		_0023_003Dzq80RbjQ_003D = this._0023_003DzZzVr6_0024U_003D;
		_0023_003DzZzVr6_0024U_003D = _0023_003DzcbLoSrg_003D;
	}

	internal int _0023_003DzQ1lXfjg1bxlJ_I4ngNELCYfdJLOA()
	{
		if (!_0023_003DzLaPeX80_003D)
		{
			throw new Exception();
		}
		return _0023_003Dz7hRN5Rg_003D;
	}

	public int _0023_003DzjRaSYYflF0vxagBuM7ws8Y2BS9t2(int _0023_003Dzq80RbjQ_003D)
	{
		if (!_0023_003DzLaPeX80_003D)
		{
			throw new Exception();
		}
		int num = _0023_003DzcbLoSrg_003D - _0023_003Dz7hRN5Rg_003D;
		if (num > _0023_003Dzq80RbjQ_003D)
		{
			num = _0023_003Dzq80RbjQ_003D;
		}
		if (num < 0)
		{
			num = 0;
		}
		_0023_003Dz7hRN5Rg_003D += num;
		return num;
	}

	public int _0023_003Dzfj6IDcdwIIiHG4Fe9dCniF5gSzTb()
	{
		if (!_0023_003DzLaPeX80_003D)
		{
			throw new Exception();
		}
		return _0023_003DzqMLoHoQ_003D - _0023_003DzZzVr6_0024U_003D;
	}

	public void _0023_003DzX88hHcca4fJvi9WkWYZCCzvfkbUJ(int _0023_003Dzq80RbjQ_003D)
	{
		if (!_0023_003DzLaPeX80_003D)
		{
			throw new Exception();
		}
		if (_0023_003Dzq80RbjQ_003D == _0023_003DzqMLoHoQ_003D)
		{
			return;
		}
		if (!_0023_003DzuwE9t4w_003D)
		{
			throw new Exception();
		}
		if (_0023_003Dzq80RbjQ_003D < _0023_003DzcbLoSrg_003D)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (_0023_003Dzq80RbjQ_003D > 0)
		{
			byte[] dst = new byte[_0023_003Dzq80RbjQ_003D];
			if (_0023_003DzcbLoSrg_003D > 0)
			{
				Buffer.BlockCopy(this._0023_003Dzq80RbjQ_003D, 0, dst, 0, _0023_003DzcbLoSrg_003D);
			}
			this._0023_003Dzq80RbjQ_003D = dst;
		}
		else
		{
			this._0023_003Dzq80RbjQ_003D = null;
		}
		_0023_003DzqMLoHoQ_003D = _0023_003Dzq80RbjQ_003D;
	}

	[SpecialName]
	public override long _0023_003DzCw1_0024ldBjs0aUP3McccU_9Sjt_mWYXegwAz1XgjD5sZO2YJKkSww9WmC4Df0X_LF4W2M9EoA9a9fwM1Q04iTehag_003D()
	{
		if (!_0023_003DzLaPeX80_003D)
		{
			throw new Exception();
		}
		return _0023_003DzcbLoSrg_003D - _0023_003DzZzVr6_0024U_003D;
	}

	[SpecialName]
	public override long _0023_003DzobG9IxqhwRDSPcfxNOqGyLk4ZhoGqGKIxRc5EwzLMnMXwgfZ90nCXR8JGEQLK55L4VFmzy0_003D()
	{
		if (!_0023_003DzLaPeX80_003D)
		{
			throw new Exception();
		}
		return _0023_003Dz7hRN5Rg_003D - _0023_003DzZzVr6_0024U_003D;
	}

	[SpecialName]
	public override void _0023_003DzeAfqD85UAYY1g8prJCu4S9JwzuyBHOSQrVdSiwf3Lj4Gqu9mD0yaZmrEmeHhlRxoawLGCBo_003D(long _0023_003Dzq80RbjQ_003D)
	{
		if (!_0023_003DzLaPeX80_003D)
		{
			throw new Exception();
		}
		if (_0023_003Dzq80RbjQ_003D < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (_0023_003Dzq80RbjQ_003D > int.MaxValue)
		{
			throw new ArgumentOutOfRangeException();
		}
		_0023_003Dz7hRN5Rg_003D = _0023_003DzZzVr6_0024U_003D + (int)_0023_003Dzq80RbjQ_003D;
	}

	public override int _0023_003DzJOoT4gsPGoibAzkPGQ31PpiYn_hZ3qvRCOxibWgYa3KnAQHxK9Wt69jVIDs25kwu05DuT1KcBeXXwLt8kA_003D_003D(byte[] _0023_003Dzq80RbjQ_003D, int _0023_003DzZzVr6_0024U_003D, int _0023_003Dz7hRN5Rg_003D)
	{
		if (!_0023_003DzLaPeX80_003D)
		{
			throw new Exception();
		}
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
		int num = _0023_003DzcbLoSrg_003D - this._0023_003Dz7hRN5Rg_003D;
		if (num > _0023_003Dz7hRN5Rg_003D)
		{
			num = _0023_003Dz7hRN5Rg_003D;
		}
		if (num <= 0)
		{
			return 0;
		}
		if (num <= 8)
		{
			int num2 = num;
			while (--num2 >= 0)
			{
				_0023_003Dzq80RbjQ_003D[_0023_003DzZzVr6_0024U_003D + num2] = this._0023_003Dzq80RbjQ_003D[this._0023_003Dz7hRN5Rg_003D + num2];
			}
		}
		else
		{
			Buffer.BlockCopy(this._0023_003Dzq80RbjQ_003D, this._0023_003Dz7hRN5Rg_003D, _0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D, num);
		}
		this._0023_003Dz7hRN5Rg_003D += num;
		return num;
	}

	public override int _0023_003DzbnO9dtFGogvfxYIC_1KDeXzgmR7PVNfCBCcxW4LqFesA0t0n216lG_SZN7yBQdzks18OA8e3VHO3x_NluSJ375L_RUoc()
	{
		if (!_0023_003DzLaPeX80_003D)
		{
			throw new Exception();
		}
		if (_0023_003Dz7hRN5Rg_003D >= _0023_003DzcbLoSrg_003D)
		{
			return -1;
		}
		return _0023_003Dzq80RbjQ_003D[_0023_003Dz7hRN5Rg_003D++];
	}

	public override long _0023_003DzI4vE0RkXfN1pne8gbSVDgBlALYg3vbbRkBocu_0024P6sDNdA9J9PRaszMCsJP8vkAvSyWXjY_0024fkw_sdJCJA_0024Q_003D_003D(long _0023_003Dzq80RbjQ_003D, int _0023_003DzZzVr6_0024U_003D)
	{
		if (!_0023_003DzLaPeX80_003D)
		{
			throw new Exception();
		}
		if (_0023_003Dzq80RbjQ_003D > int.MaxValue)
		{
			throw new ArgumentOutOfRangeException();
		}
		switch (_0023_003DzZzVr6_0024U_003D)
		{
		case 0:
			if (_0023_003Dzq80RbjQ_003D < 0)
			{
				throw new IOException();
			}
			_0023_003Dz7hRN5Rg_003D = this._0023_003DzZzVr6_0024U_003D + (int)_0023_003Dzq80RbjQ_003D;
			break;
		case 1:
			if (_0023_003Dzq80RbjQ_003D + _0023_003Dz7hRN5Rg_003D < this._0023_003DzZzVr6_0024U_003D)
			{
				throw new IOException();
			}
			_0023_003Dz7hRN5Rg_003D += (int)_0023_003Dzq80RbjQ_003D;
			break;
		case 2:
			if (_0023_003DzcbLoSrg_003D + _0023_003Dzq80RbjQ_003D < this._0023_003DzZzVr6_0024U_003D)
			{
				throw new IOException();
			}
			_0023_003Dz7hRN5Rg_003D = _0023_003DzcbLoSrg_003D + (int)_0023_003Dzq80RbjQ_003D;
			break;
		default:
			throw new ArgumentException();
		}
		return _0023_003Dz7hRN5Rg_003D;
	}

	public override void _0023_003Dzq9sSScLMecynoevHD3htzjHlhzPCWd35ZjYlubS52EE5NgIEEiUcOA7LMbh5g1u1_zQvc0laa9e6SQymmssF0Wb3ZxLL(long _0023_003Dzq80RbjQ_003D)
	{
		if (!_0023_003DzoyRBT1A_003D)
		{
			throw new Exception();
		}
		if (_0023_003Dzq80RbjQ_003D > int.MaxValue)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (_0023_003Dzq80RbjQ_003D < 0 || _0023_003Dzq80RbjQ_003D > int.MaxValue - _0023_003DzZzVr6_0024U_003D)
		{
			throw new ArgumentOutOfRangeException();
		}
		int num = _0023_003DzZzVr6_0024U_003D + (int)_0023_003Dzq80RbjQ_003D;
		if (!_0023_003DzsEbtgZ2_0024c33SR1qRmohVvzG8xi0smY4YVw_003D_003D(num) && num > _0023_003DzcbLoSrg_003D)
		{
			Array.Clear(this._0023_003Dzq80RbjQ_003D, _0023_003DzcbLoSrg_003D, num - _0023_003DzcbLoSrg_003D);
		}
		_0023_003DzcbLoSrg_003D = num;
		if (_0023_003Dz7hRN5Rg_003D > num)
		{
			_0023_003Dz7hRN5Rg_003D = num;
		}
	}

	public byte[] _0023_003DzrTdU3VCCb2C6UQUWzVAcECzR41AvI6dOnNLQ79c_003D()
	{
		byte[] array = new byte[_0023_003DzcbLoSrg_003D - _0023_003DzZzVr6_0024U_003D];
		Buffer.BlockCopy(_0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D, array, 0, _0023_003DzcbLoSrg_003D - _0023_003DzZzVr6_0024U_003D);
		return array;
	}

	public override void _0023_003Dz8RZ33Qgc1tJw0mBVJCrKD61ZYjZ_2JLKozA0bEs8bzZG_0024m1mZPtBgdkXoQxvGRZlx8NlYDRO4jRTKwqrHM_0024Ebqg_003D(byte[] _0023_003Dzq80RbjQ_003D, int _0023_003DzZzVr6_0024U_003D, int _0023_003Dz7hRN5Rg_003D)
	{
		if (!_0023_003DzLaPeX80_003D)
		{
			throw new Exception();
		}
		if (!_0023_003DzoyRBT1A_003D)
		{
			throw new Exception();
		}
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
		int num = this._0023_003Dz7hRN5Rg_003D + _0023_003Dz7hRN5Rg_003D;
		if (num < 0)
		{
			throw new IOException();
		}
		if (num > _0023_003DzcbLoSrg_003D)
		{
			bool flag = this._0023_003Dz7hRN5Rg_003D > _0023_003DzcbLoSrg_003D;
			if (num > _0023_003DzqMLoHoQ_003D && _0023_003DzsEbtgZ2_0024c33SR1qRmohVvzG8xi0smY4YVw_003D_003D(num))
			{
				flag = false;
			}
			if (flag)
			{
				Array.Clear(this._0023_003Dzq80RbjQ_003D, _0023_003DzcbLoSrg_003D, num - _0023_003DzcbLoSrg_003D);
			}
			_0023_003DzcbLoSrg_003D = num;
		}
		if (_0023_003Dz7hRN5Rg_003D <= 8)
		{
			int num2 = _0023_003Dz7hRN5Rg_003D;
			while (--num2 >= 0)
			{
				this._0023_003Dzq80RbjQ_003D[this._0023_003Dz7hRN5Rg_003D + num2] = _0023_003Dzq80RbjQ_003D[_0023_003DzZzVr6_0024U_003D + num2];
			}
		}
		else
		{
			Buffer.BlockCopy(_0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D, this._0023_003Dzq80RbjQ_003D, this._0023_003Dz7hRN5Rg_003D, _0023_003Dz7hRN5Rg_003D);
		}
		this._0023_003Dz7hRN5Rg_003D = num;
	}

	public override void _0023_003Dzhf_0024Z6o51tCgywrmf_0024joJ_mq_0024IPA7gPwligrOBwHXHcacjWkbQBVQ0_0024CwsDfx2RDZTk0RouYA93FYUDgsVBOE35Q_003D(byte _0023_003Dzq80RbjQ_003D)
	{
		if (!_0023_003DzLaPeX80_003D)
		{
			throw new Exception();
		}
		if (!_0023_003DzoyRBT1A_003D)
		{
			throw new Exception();
		}
		if (_0023_003Dz7hRN5Rg_003D >= _0023_003DzcbLoSrg_003D)
		{
			int num = _0023_003Dz7hRN5Rg_003D + 1;
			bool flag = _0023_003Dz7hRN5Rg_003D > _0023_003DzcbLoSrg_003D;
			if (num >= _0023_003DzqMLoHoQ_003D && _0023_003DzsEbtgZ2_0024c33SR1qRmohVvzG8xi0smY4YVw_003D_003D(num))
			{
				flag = false;
			}
			if (flag)
			{
				Array.Clear(this._0023_003Dzq80RbjQ_003D, _0023_003DzcbLoSrg_003D, _0023_003Dz7hRN5Rg_003D - _0023_003DzcbLoSrg_003D);
			}
			_0023_003DzcbLoSrg_003D = num;
		}
		this._0023_003Dzq80RbjQ_003D[_0023_003Dz7hRN5Rg_003D++] = _0023_003Dzq80RbjQ_003D;
	}

	public void _0023_003DzbJNbasdEmEYRux5ZjIw_0024G9E_003D(Stream _0023_003Dzq80RbjQ_003D)
	{
		if (!_0023_003DzLaPeX80_003D)
		{
			throw new Exception();
		}
		if (_0023_003Dzq80RbjQ_003D == null)
		{
			throw new ArgumentNullException();
		}
		_0023_003Dzq80RbjQ_003D.Write(this._0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D, _0023_003DzcbLoSrg_003D - _0023_003DzZzVr6_0024U_003D);
	}

	internal int _0023_003Dzh5DMsiZCgHIXWxCfsbrC7euQjhsXK7JCBi77oK4DXKhB()
	{
		if (!_0023_003DzLaPeX80_003D)
		{
			throw new Exception();
		}
		int num = (_0023_003Dz7hRN5Rg_003D += 4);
		if (num > _0023_003DzcbLoSrg_003D)
		{
			_0023_003Dz7hRN5Rg_003D = _0023_003DzcbLoSrg_003D;
			throw new Exception();
		}
		return (_0023_003Dzq80RbjQ_003D[num - 1] << 24) | (_0023_003Dzq80RbjQ_003D[num - 2] << 8) | (_0023_003Dzq80RbjQ_003D[num - 3] << 16) | _0023_003Dzq80RbjQ_003D[num - 4];
	}
}
