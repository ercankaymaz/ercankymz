using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

internal sealed class _0023_003DqUcu9yDNs_OQWZCK2_0024fdxf4IQhTpJNQBHH_Qq96h8BUo_003D : _0023_003DqVFAcyYKahdwaFZMP0V7msl5MSPdZk96b_0024ExRKQloAVA_003D, IDisposable
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private byte[] _0023_003DzjYYAPCA_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzVC9FBdo_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzwBouG0w_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dzf4Pqh9s_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzTFNDoh0_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzraVZG9g_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzRoqMfFc_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dz1SmHC4c_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzLtLprGE_003D;

	public _0023_003DqUcu9yDNs_OQWZCK2_0024fdxf4IQhTpJNQBHH_Qq96h8BUo_003D()
		: this(0)
	{
	}

	public _0023_003DqUcu9yDNs_OQWZCK2_0024fdxf4IQhTpJNQBHH_Qq96h8BUo_003D(int _0023_003DzjYYAPCA_003D)
	{
		if (_0023_003DzjYYAPCA_003D < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		this._0023_003DzjYYAPCA_003D = new byte[_0023_003DzjYYAPCA_003D];
		_0023_003DzTFNDoh0_003D = _0023_003DzjYYAPCA_003D;
		_0023_003DzraVZG9g_003D = true;
		_0023_003DzRoqMfFc_003D = true;
		_0023_003DzVC9FBdo_003D = 0;
		_0023_003Dz1SmHC4c_003D = true;
	}

	public _0023_003DqUcu9yDNs_OQWZCK2_0024fdxf4IQhTpJNQBHH_Qq96h8BUo_003D(byte[] _0023_003DzjYYAPCA_003D)
		: this(_0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D: true)
	{
	}

	public _0023_003DqUcu9yDNs_OQWZCK2_0024fdxf4IQhTpJNQBHH_Qq96h8BUo_003D(byte[] _0023_003DzjYYAPCA_003D, bool _0023_003DzVC9FBdo_003D)
	{
		if (_0023_003DzjYYAPCA_003D == null)
		{
			throw new ArgumentNullException();
		}
		this._0023_003DzjYYAPCA_003D = _0023_003DzjYYAPCA_003D;
		_0023_003Dzf4Pqh9s_003D = (_0023_003DzTFNDoh0_003D = _0023_003DzjYYAPCA_003D.Length);
		_0023_003DzRoqMfFc_003D = _0023_003DzVC9FBdo_003D;
		this._0023_003DzVC9FBdo_003D = 0;
		_0023_003Dz1SmHC4c_003D = true;
	}

	public _0023_003DqUcu9yDNs_OQWZCK2_0024fdxf4IQhTpJNQBHH_Qq96h8BUo_003D(byte[] _0023_003DzjYYAPCA_003D, int _0023_003DzVC9FBdo_003D, int _0023_003DzwBouG0w_003D)
		: this(_0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D, _0023_003Dzf4Pqh9s_003D: true)
	{
	}

	public _0023_003DqUcu9yDNs_OQWZCK2_0024fdxf4IQhTpJNQBHH_Qq96h8BUo_003D(byte[] _0023_003DzjYYAPCA_003D, int _0023_003DzVC9FBdo_003D, int _0023_003DzwBouG0w_003D, bool _0023_003Dzf4Pqh9s_003D)
	{
		if (_0023_003DzjYYAPCA_003D == null)
		{
			throw new ArgumentNullException();
		}
		if (_0023_003DzVC9FBdo_003D < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (_0023_003DzwBouG0w_003D < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (_0023_003DzjYYAPCA_003D.Length - _0023_003DzVC9FBdo_003D < _0023_003DzwBouG0w_003D)
		{
			throw new ArgumentException();
		}
		this._0023_003DzjYYAPCA_003D = _0023_003DzjYYAPCA_003D;
		this._0023_003DzVC9FBdo_003D = (this._0023_003DzwBouG0w_003D = _0023_003DzVC9FBdo_003D);
		this._0023_003Dzf4Pqh9s_003D = (_0023_003DzTFNDoh0_003D = _0023_003DzVC9FBdo_003D + _0023_003DzwBouG0w_003D);
		_0023_003DzRoqMfFc_003D = _0023_003Dzf4Pqh9s_003D;
		_0023_003DzraVZG9g_003D = false;
		_0023_003Dz1SmHC4c_003D = true;
	}

	[SpecialName]
	public override bool _0023_003Dz6LNiAXLEYQlQLhIkkSFj5ZQYE8rNPD_0024BXH6mpKJP2IT_0024SaA3nI9RmFOW32GicKEjvUQ06R4_003D()
	{
		return _0023_003Dz1SmHC4c_003D;
	}

	[SpecialName]
	public override bool _0023_003DzYdkhPjC_bnFruKiyolthzhcBKRUySfU87viCpZBvxOdbMkrNTBgbISTFYe_0024eUsqOLirln_0024dKhOfc()
	{
		return _0023_003Dz1SmHC4c_003D;
	}

	[SpecialName]
	public override bool _0023_003DzNmGtzU4b3_nlB34INzYAY_0024n12E2he6A52NFrbLE3SlhX__HwyAGTso_0024bP_0024ZVetcOV7ujISxqBFqCxgspra8yPwY_003D()
	{
		return _0023_003DzRoqMfFc_003D;
	}

	protected override void _0023_003DzDQwCJlfrpHuj3j2QSa5UIi03WdVtSwtHK7nJNtUfa3MB3Za8RcJi9_owCQKddppTDxYDVSsGQdu7Kt2YDNYflpk_003D(bool _0023_003DzjYYAPCA_003D)
	{
		if (!_0023_003DzLtLprGE_003D)
		{
			if (_0023_003DzjYYAPCA_003D)
			{
				_0023_003Dz1SmHC4c_003D = false;
				_0023_003DzRoqMfFc_003D = false;
				_0023_003DzraVZG9g_003D = false;
			}
			_0023_003DzLtLprGE_003D = true;
		}
	}

	private bool _0023_003Dz6r9eKiYRHJj5qZOa5E5B4xGMDHvbXLNhmQ_003D_003D(int _0023_003DzjYYAPCA_003D)
	{
		if (_0023_003DzjYYAPCA_003D < 0)
		{
			throw new IOException();
		}
		if (_0023_003DzjYYAPCA_003D > _0023_003DzTFNDoh0_003D)
		{
			int num = _0023_003DzjYYAPCA_003D;
			if (num < 256)
			{
				num = 256;
			}
			if (num < _0023_003DzTFNDoh0_003D * 2)
			{
				num = _0023_003DzTFNDoh0_003D * 2;
			}
			_0023_003DzuPDvyWH1ifWkrcoFl11FeVfrnP34(num);
			return true;
		}
		return false;
	}

	public override void _0023_003DzMMoV2Utk9POZKrnfb5F4vmFD0tN_0024Gis9GPcUXK7SFb7QlEBuELfIiUNi7WU4ykteYlYgjUvI0BLeFAoRnA_003D_003D()
	{
	}

	internal byte[] _0023_003DznVK_002428dVurgAZA6Q6RBdpaE_003D()
	{
		return _0023_003DzjYYAPCA_003D;
	}

	internal void _0023_003DzxoBDaLtgf6M9khmObdMOG1A_003D(out int _0023_003DzjYYAPCA_003D, out int _0023_003DzVC9FBdo_003D)
	{
		if (!_0023_003Dz1SmHC4c_003D)
		{
			throw new Exception();
		}
		_0023_003DzjYYAPCA_003D = this._0023_003DzVC9FBdo_003D;
		_0023_003DzVC9FBdo_003D = _0023_003Dzf4Pqh9s_003D;
	}

	internal int _0023_003Dzrjl2CXYzFMNQfUVms2Qh0iYTrZ_e()
	{
		if (!_0023_003Dz1SmHC4c_003D)
		{
			throw new Exception();
		}
		return _0023_003DzwBouG0w_003D;
	}

	public int _0023_003DzQwfFmp8YhIA05Gevt8CA3W8Caxf_0024(int _0023_003DzjYYAPCA_003D)
	{
		if (!_0023_003Dz1SmHC4c_003D)
		{
			throw new Exception();
		}
		int num = _0023_003Dzf4Pqh9s_003D - _0023_003DzwBouG0w_003D;
		if (num > _0023_003DzjYYAPCA_003D)
		{
			num = _0023_003DzjYYAPCA_003D;
		}
		if (num < 0)
		{
			num = 0;
		}
		_0023_003DzwBouG0w_003D += num;
		return num;
	}

	public int _0023_003DzR5u_8nicz72hq1COBw9ILc5ho8jm()
	{
		if (!_0023_003Dz1SmHC4c_003D)
		{
			throw new Exception();
		}
		return _0023_003DzTFNDoh0_003D - _0023_003DzVC9FBdo_003D;
	}

	public void _0023_003DzuPDvyWH1ifWkrcoFl11FeVfrnP34(int _0023_003DzjYYAPCA_003D)
	{
		if (!_0023_003Dz1SmHC4c_003D)
		{
			throw new Exception();
		}
		if (_0023_003DzjYYAPCA_003D == _0023_003DzTFNDoh0_003D)
		{
			return;
		}
		if (!_0023_003DzraVZG9g_003D)
		{
			throw new Exception();
		}
		if (_0023_003DzjYYAPCA_003D < _0023_003Dzf4Pqh9s_003D)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (_0023_003DzjYYAPCA_003D > 0)
		{
			byte[] dst = new byte[_0023_003DzjYYAPCA_003D];
			if (_0023_003Dzf4Pqh9s_003D > 0)
			{
				Buffer.BlockCopy(this._0023_003DzjYYAPCA_003D, 0, dst, 0, _0023_003Dzf4Pqh9s_003D);
			}
			this._0023_003DzjYYAPCA_003D = dst;
		}
		else
		{
			this._0023_003DzjYYAPCA_003D = null;
		}
		_0023_003DzTFNDoh0_003D = _0023_003DzjYYAPCA_003D;
	}

	[SpecialName]
	public override long _0023_003DzSo_gaJJm3gV22vwn_0024ZQKP2jkH1Wi8Q1d_0024iW8L0sqejJVZPcg9_XQ6lNh50Arlf2kDIcUyU9sztWajFgX9XnbyJg_003D()
	{
		if (!_0023_003Dz1SmHC4c_003D)
		{
			throw new Exception();
		}
		return _0023_003Dzf4Pqh9s_003D - _0023_003DzVC9FBdo_003D;
	}

	[SpecialName]
	public override long _0023_003DzVVh_VOOPvzE8OIDVjtj7IIyotysgSsjRp5iJTq6jEV_00246A2hzlq2gX1_0024tau7otE4P6cvwwsQ_003D()
	{
		if (!_0023_003Dz1SmHC4c_003D)
		{
			throw new Exception();
		}
		return _0023_003DzwBouG0w_003D - _0023_003DzVC9FBdo_003D;
	}

	[SpecialName]
	public override void _0023_003Dzn_t9hyVATRPnUxdqXwaUj9BPcyICJFt_8Z7_002402XyW0bjVPch0w_YOa0C7Qx9nd4TCWcwQcY_003D(long _0023_003DzjYYAPCA_003D)
	{
		if (!_0023_003Dz1SmHC4c_003D)
		{
			throw new Exception();
		}
		if (_0023_003DzjYYAPCA_003D < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (_0023_003DzjYYAPCA_003D > int.MaxValue)
		{
			throw new ArgumentOutOfRangeException();
		}
		_0023_003DzwBouG0w_003D = _0023_003DzVC9FBdo_003D + (int)_0023_003DzjYYAPCA_003D;
	}

	public override int _0023_003DzOVN4VvoLFL2S9tW2hEeVpby89pOXbMnEKyWxF7sXdkjazNQBxn_0024MlbVfdzFAEhNpVwGKfA5miLbFebKbcQ_003D_003D(byte[] _0023_003DzjYYAPCA_003D, int _0023_003DzVC9FBdo_003D, int _0023_003DzwBouG0w_003D)
	{
		if (!_0023_003Dz1SmHC4c_003D)
		{
			throw new Exception();
		}
		if (_0023_003DzjYYAPCA_003D == null)
		{
			throw new ArgumentNullException();
		}
		if (_0023_003DzVC9FBdo_003D < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (_0023_003DzwBouG0w_003D < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (_0023_003DzjYYAPCA_003D.Length - _0023_003DzVC9FBdo_003D < _0023_003DzwBouG0w_003D)
		{
			throw new ArgumentException();
		}
		int num = _0023_003Dzf4Pqh9s_003D - this._0023_003DzwBouG0w_003D;
		if (num > _0023_003DzwBouG0w_003D)
		{
			num = _0023_003DzwBouG0w_003D;
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
				_0023_003DzjYYAPCA_003D[_0023_003DzVC9FBdo_003D + num2] = this._0023_003DzjYYAPCA_003D[this._0023_003DzwBouG0w_003D + num2];
			}
		}
		else
		{
			Buffer.BlockCopy(this._0023_003DzjYYAPCA_003D, this._0023_003DzwBouG0w_003D, _0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D, num);
		}
		this._0023_003DzwBouG0w_003D += num;
		return num;
	}

	public override int _0023_003DznnzKhNjmjuyptKdLZc6mqxHTd2yTc_0024jGQkIgE_0024kkGzZT5azI2ekLCYiTWZBKT94kl5dR5kjcP7cdy_0LOaRYyYNzapzc()
	{
		if (!_0023_003Dz1SmHC4c_003D)
		{
			throw new Exception();
		}
		if (_0023_003DzwBouG0w_003D >= _0023_003Dzf4Pqh9s_003D)
		{
			return -1;
		}
		return _0023_003DzjYYAPCA_003D[_0023_003DzwBouG0w_003D++];
	}

	public override long _0023_003DzF9bNse9wHJLLtepk_gT8nT7RoArbYZ5O7BM_0024pvRSfZZCcif09QuhqkEcicQBZU2Q_1FotqnGeCeOOleA6w_003D_003D(long _0023_003DzjYYAPCA_003D, int _0023_003DzVC9FBdo_003D)
	{
		if (!_0023_003Dz1SmHC4c_003D)
		{
			throw new Exception();
		}
		if (_0023_003DzjYYAPCA_003D > int.MaxValue)
		{
			throw new ArgumentOutOfRangeException();
		}
		switch (_0023_003DzVC9FBdo_003D)
		{
		case 0:
			if (_0023_003DzjYYAPCA_003D < 0)
			{
				throw new IOException();
			}
			_0023_003DzwBouG0w_003D = this._0023_003DzVC9FBdo_003D + (int)_0023_003DzjYYAPCA_003D;
			break;
		case 1:
			if (_0023_003DzjYYAPCA_003D + _0023_003DzwBouG0w_003D < this._0023_003DzVC9FBdo_003D)
			{
				throw new IOException();
			}
			_0023_003DzwBouG0w_003D += (int)_0023_003DzjYYAPCA_003D;
			break;
		case 2:
			if (_0023_003Dzf4Pqh9s_003D + _0023_003DzjYYAPCA_003D < this._0023_003DzVC9FBdo_003D)
			{
				throw new IOException();
			}
			_0023_003DzwBouG0w_003D = _0023_003Dzf4Pqh9s_003D + (int)_0023_003DzjYYAPCA_003D;
			break;
		default:
			throw new ArgumentException();
		}
		return _0023_003DzwBouG0w_003D;
	}

	public override void _0023_003DzRlokVKuxX46IVyoBMh2LGpphiTHC0TFFk0H8Tx1NE1x002pfmkCt9vrGY6uCEUuw7Bncz2NmhNaufaVEn3rtierfB0iU(long _0023_003DzjYYAPCA_003D)
	{
		if (!_0023_003DzRoqMfFc_003D)
		{
			throw new Exception();
		}
		if (_0023_003DzjYYAPCA_003D > int.MaxValue)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (_0023_003DzjYYAPCA_003D < 0 || _0023_003DzjYYAPCA_003D > int.MaxValue - _0023_003DzVC9FBdo_003D)
		{
			throw new ArgumentOutOfRangeException();
		}
		int num = _0023_003DzVC9FBdo_003D + (int)_0023_003DzjYYAPCA_003D;
		if (!_0023_003Dz6r9eKiYRHJj5qZOa5E5B4xGMDHvbXLNhmQ_003D_003D(num) && num > _0023_003Dzf4Pqh9s_003D)
		{
			Array.Clear(this._0023_003DzjYYAPCA_003D, _0023_003Dzf4Pqh9s_003D, num - _0023_003Dzf4Pqh9s_003D);
		}
		_0023_003Dzf4Pqh9s_003D = num;
		if (_0023_003DzwBouG0w_003D > num)
		{
			_0023_003DzwBouG0w_003D = num;
		}
	}

	public byte[] _0023_003DzZP5kWBTOd4njH_0024wsE9f_0024o_0024ppPdCdDKWt4LmgPns_003D()
	{
		byte[] array = new byte[_0023_003Dzf4Pqh9s_003D - _0023_003DzVC9FBdo_003D];
		Buffer.BlockCopy(_0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D, array, 0, _0023_003Dzf4Pqh9s_003D - _0023_003DzVC9FBdo_003D);
		return array;
	}

	public override void _0023_003Dzf2o5xB36wl5j8THLGxH7GtetBjB_Blua0v44kb1Ad3tco7z7uPjB0jSEWmyHLYgvEjs9D4NDPX5ETcf08P3w5yw_003D(byte[] _0023_003DzjYYAPCA_003D, int _0023_003DzVC9FBdo_003D, int _0023_003DzwBouG0w_003D)
	{
		if (!_0023_003Dz1SmHC4c_003D)
		{
			throw new Exception();
		}
		if (!_0023_003DzRoqMfFc_003D)
		{
			throw new Exception();
		}
		if (_0023_003DzjYYAPCA_003D == null)
		{
			throw new ArgumentNullException();
		}
		if (_0023_003DzVC9FBdo_003D < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (_0023_003DzwBouG0w_003D < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (_0023_003DzjYYAPCA_003D.Length - _0023_003DzVC9FBdo_003D < _0023_003DzwBouG0w_003D)
		{
			throw new ArgumentException();
		}
		int num = this._0023_003DzwBouG0w_003D + _0023_003DzwBouG0w_003D;
		if (num < 0)
		{
			throw new IOException();
		}
		if (num > _0023_003Dzf4Pqh9s_003D)
		{
			bool flag = this._0023_003DzwBouG0w_003D > _0023_003Dzf4Pqh9s_003D;
			if (num > _0023_003DzTFNDoh0_003D && _0023_003Dz6r9eKiYRHJj5qZOa5E5B4xGMDHvbXLNhmQ_003D_003D(num))
			{
				flag = false;
			}
			if (flag)
			{
				Array.Clear(this._0023_003DzjYYAPCA_003D, _0023_003Dzf4Pqh9s_003D, num - _0023_003Dzf4Pqh9s_003D);
			}
			_0023_003Dzf4Pqh9s_003D = num;
		}
		if (_0023_003DzwBouG0w_003D <= 8)
		{
			int num2 = _0023_003DzwBouG0w_003D;
			while (--num2 >= 0)
			{
				this._0023_003DzjYYAPCA_003D[this._0023_003DzwBouG0w_003D + num2] = _0023_003DzjYYAPCA_003D[_0023_003DzVC9FBdo_003D + num2];
			}
		}
		else
		{
			Buffer.BlockCopy(_0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D, this._0023_003DzjYYAPCA_003D, this._0023_003DzwBouG0w_003D, _0023_003DzwBouG0w_003D);
		}
		this._0023_003DzwBouG0w_003D = num;
	}

	public override void _0023_003DzJKWgMAjLQyEgo93pZZvIRd01lC9olM606AfMcEkKflmWT7ncLrCSVgW2z6nQi5UT17qfHGk_0024o6DLngnlqf05WJA_003D(byte _0023_003DzjYYAPCA_003D)
	{
		if (!_0023_003Dz1SmHC4c_003D)
		{
			throw new Exception();
		}
		if (!_0023_003DzRoqMfFc_003D)
		{
			throw new Exception();
		}
		if (_0023_003DzwBouG0w_003D >= _0023_003Dzf4Pqh9s_003D)
		{
			int num = _0023_003DzwBouG0w_003D + 1;
			bool flag = _0023_003DzwBouG0w_003D > _0023_003Dzf4Pqh9s_003D;
			if (num >= _0023_003DzTFNDoh0_003D && _0023_003Dz6r9eKiYRHJj5qZOa5E5B4xGMDHvbXLNhmQ_003D_003D(num))
			{
				flag = false;
			}
			if (flag)
			{
				Array.Clear(this._0023_003DzjYYAPCA_003D, _0023_003Dzf4Pqh9s_003D, _0023_003DzwBouG0w_003D - _0023_003Dzf4Pqh9s_003D);
			}
			_0023_003Dzf4Pqh9s_003D = num;
		}
		this._0023_003DzjYYAPCA_003D[_0023_003DzwBouG0w_003D++] = _0023_003DzjYYAPCA_003D;
	}

	public void _0023_003DzPIe8c88CJjCkupCj7XnLvrg_003D(Stream _0023_003DzjYYAPCA_003D)
	{
		if (!_0023_003Dz1SmHC4c_003D)
		{
			throw new Exception();
		}
		if (_0023_003DzjYYAPCA_003D == null)
		{
			throw new ArgumentNullException();
		}
		_0023_003DzjYYAPCA_003D.Write(this._0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D, _0023_003Dzf4Pqh9s_003D - _0023_003DzVC9FBdo_003D);
	}

	internal int _0023_003Dz8TpFK64UhBwmm5P7_00249SkeZ7CCYEbQNHMk3TjD7jXz3nP()
	{
		if (!_0023_003Dz1SmHC4c_003D)
		{
			throw new Exception();
		}
		int num = (_0023_003DzwBouG0w_003D += 4);
		if (num > _0023_003Dzf4Pqh9s_003D)
		{
			_0023_003DzwBouG0w_003D = _0023_003Dzf4Pqh9s_003D;
			throw new Exception();
		}
		return (_0023_003DzjYYAPCA_003D[num - 1] << 24) | (_0023_003DzjYYAPCA_003D[num - 2] << 8) | (_0023_003DzjYYAPCA_003D[num - 3] << 16) | _0023_003DzjYYAPCA_003D[num - 4];
	}
}
