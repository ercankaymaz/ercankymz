using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

internal sealed class _0023_003DqtFN_00241TjdaenuCmn9GBmqpoZ3gp2tHyBL0X9WMKdAUQk_003D : _0023_003Dq6tS8rMV1rGswJPasZDHd76XTcVlfwQMkS5tB1TusLXU_003D, IDisposable
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private byte[] _0023_003Dz9jrlnWk_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzBxpHhQ0_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dztgqm2r4_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzzKDx05I_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dz3iPku7s_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dz2X8kE24_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzJGsRSpg_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dz9I8ZVlc_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzgqvoyJk_003D;

	public _0023_003DqtFN_00241TjdaenuCmn9GBmqpoZ3gp2tHyBL0X9WMKdAUQk_003D()
		: this(0)
	{
	}

	public _0023_003DqtFN_00241TjdaenuCmn9GBmqpoZ3gp2tHyBL0X9WMKdAUQk_003D(int _0023_003Dz9jrlnWk_003D)
	{
		if (_0023_003Dz9jrlnWk_003D < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		this._0023_003Dz9jrlnWk_003D = new byte[_0023_003Dz9jrlnWk_003D];
		_0023_003Dz3iPku7s_003D = _0023_003Dz9jrlnWk_003D;
		_0023_003Dz2X8kE24_003D = true;
		_0023_003DzJGsRSpg_003D = true;
		_0023_003DzBxpHhQ0_003D = 0;
		_0023_003Dz9I8ZVlc_003D = true;
	}

	public _0023_003DqtFN_00241TjdaenuCmn9GBmqpoZ3gp2tHyBL0X9WMKdAUQk_003D(byte[] _0023_003Dz9jrlnWk_003D)
		: this(_0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D: true)
	{
	}

	public _0023_003DqtFN_00241TjdaenuCmn9GBmqpoZ3gp2tHyBL0X9WMKdAUQk_003D(byte[] _0023_003Dz9jrlnWk_003D, bool _0023_003DzBxpHhQ0_003D)
	{
		if (_0023_003Dz9jrlnWk_003D == null)
		{
			throw new ArgumentNullException();
		}
		this._0023_003Dz9jrlnWk_003D = _0023_003Dz9jrlnWk_003D;
		_0023_003DzzKDx05I_003D = (_0023_003Dz3iPku7s_003D = _0023_003Dz9jrlnWk_003D.Length);
		_0023_003DzJGsRSpg_003D = _0023_003DzBxpHhQ0_003D;
		this._0023_003DzBxpHhQ0_003D = 0;
		_0023_003Dz9I8ZVlc_003D = true;
	}

	public _0023_003DqtFN_00241TjdaenuCmn9GBmqpoZ3gp2tHyBL0X9WMKdAUQk_003D(byte[] _0023_003Dz9jrlnWk_003D, int _0023_003DzBxpHhQ0_003D, int _0023_003Dztgqm2r4_003D)
		: this(_0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D, _0023_003DzzKDx05I_003D: true)
	{
	}

	public _0023_003DqtFN_00241TjdaenuCmn9GBmqpoZ3gp2tHyBL0X9WMKdAUQk_003D(byte[] _0023_003Dz9jrlnWk_003D, int _0023_003DzBxpHhQ0_003D, int _0023_003Dztgqm2r4_003D, bool _0023_003DzzKDx05I_003D)
	{
		if (_0023_003Dz9jrlnWk_003D == null)
		{
			throw new ArgumentNullException();
		}
		if (_0023_003DzBxpHhQ0_003D < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (_0023_003Dztgqm2r4_003D < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (_0023_003Dz9jrlnWk_003D.Length - _0023_003DzBxpHhQ0_003D < _0023_003Dztgqm2r4_003D)
		{
			throw new ArgumentException();
		}
		this._0023_003Dz9jrlnWk_003D = _0023_003Dz9jrlnWk_003D;
		this._0023_003DzBxpHhQ0_003D = (this._0023_003Dztgqm2r4_003D = _0023_003DzBxpHhQ0_003D);
		this._0023_003DzzKDx05I_003D = (_0023_003Dz3iPku7s_003D = _0023_003DzBxpHhQ0_003D + _0023_003Dztgqm2r4_003D);
		_0023_003DzJGsRSpg_003D = _0023_003DzzKDx05I_003D;
		_0023_003Dz2X8kE24_003D = false;
		_0023_003Dz9I8ZVlc_003D = true;
	}

	[SpecialName]
	public override bool _0023_003DzjK5kKydld_cz6OMcWYuveIcRsC3DEUwsUJEjet12ggDhghMyDJs1ToxgWcnaztgQsVuh0vo_003D()
	{
		return _0023_003Dz9I8ZVlc_003D;
	}

	[SpecialName]
	public override bool _0023_003DzwX11mF2T9N_0024q2RUO8GOB5Jcl_0024vC87a1tdddqF2Ze7Abi7AAbj2LBGnHuTb_D0bIJMeqAfZyIZO1Q()
	{
		return _0023_003Dz9I8ZVlc_003D;
	}

	[SpecialName]
	public override bool _0023_003DzNmGtzU4b3_nlB34INzYAY_0024n12E2he6A52NFrbLE3SlhX__HwyAGTso_0024bP_0024ZVetcOV7ujISxqBFqCxgspra8yPwY_003D()
	{
		return _0023_003DzJGsRSpg_003D;
	}

	protected override void _0023_003DzmLiGid9bh6wjtMp4tZ6ot1Z4JryUFOVjjPRAX8wWCflc5Y4VTi8gWH43c0WonymTt4CxB3ooVITnRXGoHecdNp4_003D(bool _0023_003Dz9jrlnWk_003D)
	{
		if (!_0023_003DzgqvoyJk_003D)
		{
			if (_0023_003Dz9jrlnWk_003D)
			{
				_0023_003Dz9I8ZVlc_003D = false;
				_0023_003DzJGsRSpg_003D = false;
				_0023_003Dz2X8kE24_003D = false;
			}
			_0023_003DzgqvoyJk_003D = true;
		}
	}

	private bool _0023_003DzP09nWUkyBUouvg7ph2HRYXsYjx7mHuZHxA_003D_003D(int _0023_003Dz9jrlnWk_003D)
	{
		if (_0023_003Dz9jrlnWk_003D < 0)
		{
			throw new IOException();
		}
		if (_0023_003Dz9jrlnWk_003D > _0023_003Dz3iPku7s_003D)
		{
			int num = _0023_003Dz9jrlnWk_003D;
			if (num < 256)
			{
				num = 256;
			}
			if (num < _0023_003Dz3iPku7s_003D * 2)
			{
				num = _0023_003Dz3iPku7s_003D * 2;
			}
			_0023_003DzqKsYk4GjxEbByeQAFbiicZSCaSt9(num);
			return true;
		}
		return false;
	}

	public override void _0023_003DzhSa6k2ftcudYxyG1ZX3NfWbv4mjhSsPIMFkIgKNONjPBwv64ZKoTxJPxpzDSJzFVaqjc_ndc6xxnm4p6Vw_003D_003D()
	{
	}

	internal byte[] _0023_003DzoeXQuH_h3qZO8CsKuXHcm_0024I_003D()
	{
		return _0023_003Dz9jrlnWk_003D;
	}

	internal void _0023_003DznXVH4DgSPPryEoihT6Och_Q_003D(out int _0023_003Dz9jrlnWk_003D, out int _0023_003DzBxpHhQ0_003D)
	{
		if (!_0023_003Dz9I8ZVlc_003D)
		{
			throw new Exception();
		}
		_0023_003Dz9jrlnWk_003D = this._0023_003DzBxpHhQ0_003D;
		_0023_003DzBxpHhQ0_003D = _0023_003DzzKDx05I_003D;
	}

	internal int _0023_003DzrTJ908p3xlAPZKwaeWWbLBISGjT_()
	{
		if (!_0023_003Dz9I8ZVlc_003D)
		{
			throw new Exception();
		}
		return _0023_003Dztgqm2r4_003D;
	}

	public int _0023_003Dzxw06xFa_f0_iOHVyUF0fOWFaQ9Xi(int _0023_003Dz9jrlnWk_003D)
	{
		if (!_0023_003Dz9I8ZVlc_003D)
		{
			throw new Exception();
		}
		int num = _0023_003DzzKDx05I_003D - _0023_003Dztgqm2r4_003D;
		if (num > _0023_003Dz9jrlnWk_003D)
		{
			num = _0023_003Dz9jrlnWk_003D;
		}
		if (num < 0)
		{
			num = 0;
		}
		_0023_003Dztgqm2r4_003D += num;
		return num;
	}

	public int _0023_003DzcAeY98lww9rdhNVSXOyVL_0024NfHxNW()
	{
		if (!_0023_003Dz9I8ZVlc_003D)
		{
			throw new Exception();
		}
		return _0023_003Dz3iPku7s_003D - _0023_003DzBxpHhQ0_003D;
	}

	public void _0023_003DzqKsYk4GjxEbByeQAFbiicZSCaSt9(int _0023_003Dz9jrlnWk_003D)
	{
		if (!_0023_003Dz9I8ZVlc_003D)
		{
			throw new Exception();
		}
		if (_0023_003Dz9jrlnWk_003D == _0023_003Dz3iPku7s_003D)
		{
			return;
		}
		if (!_0023_003Dz2X8kE24_003D)
		{
			throw new Exception();
		}
		if (_0023_003Dz9jrlnWk_003D < _0023_003DzzKDx05I_003D)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (_0023_003Dz9jrlnWk_003D > 0)
		{
			byte[] dst = new byte[_0023_003Dz9jrlnWk_003D];
			if (_0023_003DzzKDx05I_003D > 0)
			{
				Buffer.BlockCopy(this._0023_003Dz9jrlnWk_003D, 0, dst, 0, _0023_003DzzKDx05I_003D);
			}
			this._0023_003Dz9jrlnWk_003D = dst;
		}
		else
		{
			this._0023_003Dz9jrlnWk_003D = null;
		}
		_0023_003Dz3iPku7s_003D = _0023_003Dz9jrlnWk_003D;
	}

	[SpecialName]
	public override long _0023_003Dz0O0V9w8_kQ0BXR7pipw_TeE_0024mwds2QcLM1eCMLEXnNNrcyRNFhfAZq8nMBVy5R5U21yPM54QEfEcLaoIAYOkj80_003D()
	{
		if (!_0023_003Dz9I8ZVlc_003D)
		{
			throw new Exception();
		}
		return _0023_003DzzKDx05I_003D - _0023_003DzBxpHhQ0_003D;
	}

	[SpecialName]
	public override long _0023_003Dz_0024PxYTL_nlzJnpvFXwwRZmMj6PIfqbJZrp54foI9tn5jPksqeRkurekdA04xNnozUhhfo4rA_003D()
	{
		if (!_0023_003Dz9I8ZVlc_003D)
		{
			throw new Exception();
		}
		return _0023_003Dztgqm2r4_003D - _0023_003DzBxpHhQ0_003D;
	}

	[SpecialName]
	public override void _0023_003DzYoGHUZEwKTu13kV8l1r1tB_0024dht2uqAQcK2u4e7dZySI8XM__Dz3SaTmm5Rtni4wKX3rKkto_003D(long _0023_003Dz9jrlnWk_003D)
	{
		if (!_0023_003Dz9I8ZVlc_003D)
		{
			throw new Exception();
		}
		if (_0023_003Dz9jrlnWk_003D < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (_0023_003Dz9jrlnWk_003D > int.MaxValue)
		{
			throw new ArgumentOutOfRangeException();
		}
		_0023_003Dztgqm2r4_003D = _0023_003DzBxpHhQ0_003D + (int)_0023_003Dz9jrlnWk_003D;
	}

	public override int _0023_003DzulSx4Jx4Pj9eE81TPL1Iwudj2y0tGiYiNkUqLldPkK9oqhsQpYmtt9A1zPuRhvzmcjJb1LlRm9dF7M_002427A_003D_003D(byte[] _0023_003Dz9jrlnWk_003D, int _0023_003DzBxpHhQ0_003D, int _0023_003Dztgqm2r4_003D)
	{
		if (!_0023_003Dz9I8ZVlc_003D)
		{
			throw new Exception();
		}
		if (_0023_003Dz9jrlnWk_003D == null)
		{
			throw new ArgumentNullException();
		}
		if (_0023_003DzBxpHhQ0_003D < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (_0023_003Dztgqm2r4_003D < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (_0023_003Dz9jrlnWk_003D.Length - _0023_003DzBxpHhQ0_003D < _0023_003Dztgqm2r4_003D)
		{
			throw new ArgumentException();
		}
		int num = _0023_003DzzKDx05I_003D - this._0023_003Dztgqm2r4_003D;
		if (num > _0023_003Dztgqm2r4_003D)
		{
			num = _0023_003Dztgqm2r4_003D;
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
				_0023_003Dz9jrlnWk_003D[_0023_003DzBxpHhQ0_003D + num2] = this._0023_003Dz9jrlnWk_003D[this._0023_003Dztgqm2r4_003D + num2];
			}
		}
		else
		{
			Buffer.BlockCopy(this._0023_003Dz9jrlnWk_003D, this._0023_003Dztgqm2r4_003D, _0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D, num);
		}
		this._0023_003Dztgqm2r4_003D += num;
		return num;
	}

	public override int _0023_003DzYLzISiGNI5ZPpiirogLzUVXQ5_kEw2di5D17KRbqiAaIvAwk3RipJTy7uljIaVjQyDBIhX_6wjLQ6Rvj42HRfhRTT1Ns()
	{
		if (!_0023_003Dz9I8ZVlc_003D)
		{
			throw new Exception();
		}
		if (_0023_003Dztgqm2r4_003D >= _0023_003DzzKDx05I_003D)
		{
			return -1;
		}
		return _0023_003Dz9jrlnWk_003D[_0023_003Dztgqm2r4_003D++];
	}

	public override long _0023_003Dzz5uSZofwQCQyOcEKwfVQmiivZ_0024bgBfg6QfI4mYf6tHIC42rk18fkszOb_ezLTX5YRgaBPKGRm6aQTYVwBg_003D_003D(long _0023_003Dz9jrlnWk_003D, int _0023_003DzBxpHhQ0_003D)
	{
		if (!_0023_003Dz9I8ZVlc_003D)
		{
			throw new Exception();
		}
		if (_0023_003Dz9jrlnWk_003D > int.MaxValue)
		{
			throw new ArgumentOutOfRangeException();
		}
		switch (_0023_003DzBxpHhQ0_003D)
		{
		case 0:
			if (_0023_003Dz9jrlnWk_003D < 0)
			{
				throw new IOException();
			}
			_0023_003Dztgqm2r4_003D = this._0023_003DzBxpHhQ0_003D + (int)_0023_003Dz9jrlnWk_003D;
			break;
		case 1:
			if (_0023_003Dz9jrlnWk_003D + _0023_003Dztgqm2r4_003D < this._0023_003DzBxpHhQ0_003D)
			{
				throw new IOException();
			}
			_0023_003Dztgqm2r4_003D += (int)_0023_003Dz9jrlnWk_003D;
			break;
		case 2:
			if (_0023_003DzzKDx05I_003D + _0023_003Dz9jrlnWk_003D < this._0023_003DzBxpHhQ0_003D)
			{
				throw new IOException();
			}
			_0023_003Dztgqm2r4_003D = _0023_003DzzKDx05I_003D + (int)_0023_003Dz9jrlnWk_003D;
			break;
		default:
			throw new ArgumentException();
		}
		return _0023_003Dztgqm2r4_003D;
	}

	public override void _0023_003Dz3cEkCr6nJgH8VwhI82JooFSfsJeLHEtFiFLagsYbiZxMDGCmITnozlJPu20z5pu5aYTf9r3lF8GG85Nms1LW66ANhH3b(long _0023_003Dz9jrlnWk_003D)
	{
		if (!_0023_003DzJGsRSpg_003D)
		{
			throw new Exception();
		}
		if (_0023_003Dz9jrlnWk_003D > int.MaxValue)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (_0023_003Dz9jrlnWk_003D < 0 || _0023_003Dz9jrlnWk_003D > int.MaxValue - _0023_003DzBxpHhQ0_003D)
		{
			throw new ArgumentOutOfRangeException();
		}
		int num = _0023_003DzBxpHhQ0_003D + (int)_0023_003Dz9jrlnWk_003D;
		if (!_0023_003DzP09nWUkyBUouvg7ph2HRYXsYjx7mHuZHxA_003D_003D(num) && num > _0023_003DzzKDx05I_003D)
		{
			Array.Clear(this._0023_003Dz9jrlnWk_003D, _0023_003DzzKDx05I_003D, num - _0023_003DzzKDx05I_003D);
		}
		_0023_003DzzKDx05I_003D = num;
		if (_0023_003Dztgqm2r4_003D > num)
		{
			_0023_003Dztgqm2r4_003D = num;
		}
	}

	public byte[] _0023_003Dzk1v2Vj9fK7kpYuN75O020n6W30xvsdVqBD_0024CWfc_003D()
	{
		byte[] array = new byte[_0023_003DzzKDx05I_003D - _0023_003DzBxpHhQ0_003D];
		Buffer.BlockCopy(_0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D, array, 0, _0023_003DzzKDx05I_003D - _0023_003DzBxpHhQ0_003D);
		return array;
	}

	public override void _0023_003DzbSZaYZ8BSCEcshQRwBrSJEHG4NM2gaHw3u5ByyVi_0024wzLdCi0MuXQ3QPzKw1O5qhIQl4qZJ53qFAOx00aVIJmrrk_003D(byte[] _0023_003Dz9jrlnWk_003D, int _0023_003DzBxpHhQ0_003D, int _0023_003Dztgqm2r4_003D)
	{
		if (!_0023_003Dz9I8ZVlc_003D)
		{
			throw new Exception();
		}
		if (!_0023_003DzJGsRSpg_003D)
		{
			throw new Exception();
		}
		if (_0023_003Dz9jrlnWk_003D == null)
		{
			throw new ArgumentNullException();
		}
		if (_0023_003DzBxpHhQ0_003D < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (_0023_003Dztgqm2r4_003D < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (_0023_003Dz9jrlnWk_003D.Length - _0023_003DzBxpHhQ0_003D < _0023_003Dztgqm2r4_003D)
		{
			throw new ArgumentException();
		}
		int num = this._0023_003Dztgqm2r4_003D + _0023_003Dztgqm2r4_003D;
		if (num < 0)
		{
			throw new IOException();
		}
		if (num > _0023_003DzzKDx05I_003D)
		{
			bool flag = this._0023_003Dztgqm2r4_003D > _0023_003DzzKDx05I_003D;
			if (num > _0023_003Dz3iPku7s_003D && _0023_003DzP09nWUkyBUouvg7ph2HRYXsYjx7mHuZHxA_003D_003D(num))
			{
				flag = false;
			}
			if (flag)
			{
				Array.Clear(this._0023_003Dz9jrlnWk_003D, _0023_003DzzKDx05I_003D, num - _0023_003DzzKDx05I_003D);
			}
			_0023_003DzzKDx05I_003D = num;
		}
		if (_0023_003Dztgqm2r4_003D <= 8)
		{
			int num2 = _0023_003Dztgqm2r4_003D;
			while (--num2 >= 0)
			{
				this._0023_003Dz9jrlnWk_003D[this._0023_003Dztgqm2r4_003D + num2] = _0023_003Dz9jrlnWk_003D[_0023_003DzBxpHhQ0_003D + num2];
			}
		}
		else
		{
			Buffer.BlockCopy(_0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D, this._0023_003Dz9jrlnWk_003D, this._0023_003Dztgqm2r4_003D, _0023_003Dztgqm2r4_003D);
		}
		this._0023_003Dztgqm2r4_003D = num;
	}

	public override void _0023_003DzCxaJ_EI5bjxm8pBw__0024_eGqwWtZzJWRCAXgl5dLnyLMOipX1OPMccHgmUQPzbuZvrE6qZ7bWcMroT5AY5noUdyt4_003D(byte _0023_003Dz9jrlnWk_003D)
	{
		if (!_0023_003Dz9I8ZVlc_003D)
		{
			throw new Exception();
		}
		if (!_0023_003DzJGsRSpg_003D)
		{
			throw new Exception();
		}
		if (_0023_003Dztgqm2r4_003D >= _0023_003DzzKDx05I_003D)
		{
			int num = _0023_003Dztgqm2r4_003D + 1;
			bool flag = _0023_003Dztgqm2r4_003D > _0023_003DzzKDx05I_003D;
			if (num >= _0023_003Dz3iPku7s_003D && _0023_003DzP09nWUkyBUouvg7ph2HRYXsYjx7mHuZHxA_003D_003D(num))
			{
				flag = false;
			}
			if (flag)
			{
				Array.Clear(this._0023_003Dz9jrlnWk_003D, _0023_003DzzKDx05I_003D, _0023_003Dztgqm2r4_003D - _0023_003DzzKDx05I_003D);
			}
			_0023_003DzzKDx05I_003D = num;
		}
		this._0023_003Dz9jrlnWk_003D[_0023_003Dztgqm2r4_003D++] = _0023_003Dz9jrlnWk_003D;
	}

	public void _0023_003DzkWAW9dXkHyFJ_0024DRi9WMlJs4_003D(Stream _0023_003Dz9jrlnWk_003D)
	{
		if (!_0023_003Dz9I8ZVlc_003D)
		{
			throw new Exception();
		}
		if (_0023_003Dz9jrlnWk_003D == null)
		{
			throw new ArgumentNullException();
		}
		_0023_003Dz9jrlnWk_003D.Write(this._0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D, _0023_003DzzKDx05I_003D - _0023_003DzBxpHhQ0_003D);
	}

	internal int _0023_003Dzir1SrBz_i6R0mxgejtllxihbZgtGM5MlX4jL_musdJaL()
	{
		if (!_0023_003Dz9I8ZVlc_003D)
		{
			throw new Exception();
		}
		int num = (_0023_003Dztgqm2r4_003D += 4);
		if (num > _0023_003DzzKDx05I_003D)
		{
			_0023_003Dztgqm2r4_003D = _0023_003DzzKDx05I_003D;
			throw new Exception();
		}
		return (_0023_003Dz9jrlnWk_003D[num - 1] << 24) | (_0023_003Dz9jrlnWk_003D[num - 2] << 8) | (_0023_003Dz9jrlnWk_003D[num - 3] << 16) | _0023_003Dz9jrlnWk_003D[num - 4];
	}
}
