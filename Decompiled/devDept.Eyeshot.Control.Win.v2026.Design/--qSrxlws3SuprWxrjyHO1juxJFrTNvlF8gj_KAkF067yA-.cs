using System;
using System.Diagnostics;
using System.IO;
using System.Text;

internal sealed class _0023_003DqSrxlws3SuprWxrjyHO1juxJFrTNvlF8gj_KAkF067yA_003D : IDisposable
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003Dq6tS8rMV1rGswJPasZDHd76XTcVlfwQMkS5tB1TusLXU_003D _0023_003Dz9jrlnWk_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private byte[] _0023_003DzBxpHhQ0_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Decoder _0023_003Dztgqm2r4_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private byte[] _0023_003DzzKDx05I_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private char[] _0023_003Dz3iPku7s_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private char[] _0023_003Dz2X8kE24_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzJGsRSpg_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dz9I8ZVlc_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzgqvoyJk_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private byte[] _0023_003DzoEGLyuM_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private MemoryStream _0023_003DziiEv3wQ_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private BinaryReader _0023_003DzJ6W8874_003D;

	public _0023_003DqSrxlws3SuprWxrjyHO1juxJFrTNvlF8gj_KAkF067yA_003D(_0023_003Dq6tS8rMV1rGswJPasZDHd76XTcVlfwQMkS5tB1TusLXU_003D _0023_003Dz9jrlnWk_003D)
		: this(_0023_003Dz9jrlnWk_003D, new UTF8Encoding())
	{
	}

	private _0023_003DqSrxlws3SuprWxrjyHO1juxJFrTNvlF8gj_KAkF067yA_003D(_0023_003Dq6tS8rMV1rGswJPasZDHd76XTcVlfwQMkS5tB1TusLXU_003D _0023_003Dz9jrlnWk_003D, Encoding _0023_003DzBxpHhQ0_003D)
	{
		if (_0023_003Dz9jrlnWk_003D == null)
		{
			throw new ArgumentNullException();
		}
		if (_0023_003DzBxpHhQ0_003D == null)
		{
			throw new ArgumentNullException();
		}
		if (!_0023_003Dz9jrlnWk_003D._0023_003DzjK5kKydld_cz6OMcWYuveIcRsC3DEUwsUJEjet12ggDhghMyDJs1ToxgWcnaztgQsVuh0vo_003D())
		{
			throw new ArgumentException();
		}
		this._0023_003Dz9jrlnWk_003D = _0023_003Dz9jrlnWk_003D;
		_0023_003Dztgqm2r4_003D = _0023_003DzBxpHhQ0_003D.GetDecoder();
		_0023_003DzJGsRSpg_003D = _0023_003DzBxpHhQ0_003D.GetMaxCharCount(128);
		int num = _0023_003DzBxpHhQ0_003D.GetMaxByteCount(1);
		if (num < 16)
		{
			num = 16;
		}
		this._0023_003DzBxpHhQ0_003D = new byte[num];
		_0023_003Dz2X8kE24_003D = null;
		_0023_003DzzKDx05I_003D = null;
		_0023_003Dz9I8ZVlc_003D = _0023_003DzBxpHhQ0_003D is UnicodeEncoding;
		_0023_003DzgqvoyJk_003D = this._0023_003Dz9jrlnWk_003D is _0023_003DqtFN_00241TjdaenuCmn9GBmqpoZ3gp2tHyBL0X9WMKdAUQk_003D;
	}

	public _0023_003Dq6tS8rMV1rGswJPasZDHd76XTcVlfwQMkS5tB1TusLXU_003D _0023_003Dzf_kC_0024hpTUTdHx7uANBVIZvPU6fFbivFk0g_003D_003D()
	{
		return _0023_003Dz9jrlnWk_003D;
	}

	public void _0023_003DzzPja2YwLzyTLE_Ll0gb6lOo4yc4_Hb3bLg_003D_003D()
	{
		_0023_003DzuYfKyY2TKrmdnGzIEVbYxQcihV6r6u2_0024_0024Q_003D_003D(_0023_003Dz9jrlnWk_003D: true);
	}

	private void _0023_003DzuYfKyY2TKrmdnGzIEVbYxQcihV6r6u2_0024_0024Q_003D_003D(bool _0023_003Dz9jrlnWk_003D)
	{
		if (_0023_003Dz9jrlnWk_003D)
		{
			_0023_003Dq6tS8rMV1rGswJPasZDHd76XTcVlfwQMkS5tB1TusLXU_003D _0023_003Dq6tS8rMV1rGswJPasZDHd76XTcVlfwQMkS5tB1TusLXU_003D2 = this._0023_003Dz9jrlnWk_003D;
			this._0023_003Dz9jrlnWk_003D = null;
			_0023_003Dq6tS8rMV1rGswJPasZDHd76XTcVlfwQMkS5tB1TusLXU_003D2?._0023_003Dz3E9FWP2hZmBYhBj1e5l6MJ3E8y_0024_0024LUXcb5_TmNdRsjydDtDjkbsvPUSLeKbpJpMQozMRg2lA74vgax3YOo04TyY_003D();
		}
		this._0023_003Dz9jrlnWk_003D = null;
		_0023_003DzBxpHhQ0_003D = null;
		_0023_003Dztgqm2r4_003D = null;
		_0023_003DzzKDx05I_003D = null;
		_0023_003Dz3iPku7s_003D = null;
		_0023_003Dz2X8kE24_003D = null;
	}

	private void _0023_003Dzo4ttAfamrnXGGcRHMCHT5SwHJRY0VUdjuAplzjCsTSX_0024YsB6ZrIVs6C_kOVKZaUyef_0024hoaRB3Nhq()
	{
		_0023_003DzuYfKyY2TKrmdnGzIEVbYxQcihV6r6u2_0024_0024Q_003D_003D(_0023_003Dz9jrlnWk_003D: true);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zo4ttAfamrnXGGcRHMCHT5SwHJRY0VUdjuAplzjCsTSX$YsB6ZrIVs6C_kOVKZaUyef$hoaRB3Nhq
		this._0023_003Dzo4ttAfamrnXGGcRHMCHT5SwHJRY0VUdjuAplzjCsTSX_0024YsB6ZrIVs6C_kOVKZaUyef_0024hoaRB3Nhq();
	}

	public int _0023_003DzcPatjH73obFoOVZS7jpis_g_003D()
	{
		_0023_003Dz5EbsTzagsJQMlqS2KaMv6arUjQxIaGOaTuZcWdf48cv_0024();
		if (!_0023_003Dz9jrlnWk_003D._0023_003DzwX11mF2T9N_0024q2RUO8GOB5Jcl_0024vC87a1tdddqF2Ze7Abi7AAbj2LBGnHuTb_D0bIJMeqAfZyIZO1Q())
		{
			return -1;
		}
		long num = _0023_003Dz9jrlnWk_003D._0023_003Dz_0024PxYTL_nlzJnpvFXwwRZmMj6PIfqbJZrp54foI9tn5jPksqeRkurekdA04xNnozUhhfo4rA_003D();
		int result = _0023_003Dz3MCT1WV7UIUWwuUxIs4TwapE5a8dgrdxBg_003D_003D();
		_0023_003Dz9jrlnWk_003D._0023_003DzYoGHUZEwKTu13kV8l1r1tB_0024dht2uqAQcK2u4e7dZySI8XM__Dz3SaTmm5Rtni4wKX3rKkto_003D(num);
		return result;
	}

	public int _0023_003Dz3MCT1WV7UIUWwuUxIs4TwapE5a8dgrdxBg_003D_003D()
	{
		_0023_003Dz5EbsTzagsJQMlqS2KaMv6arUjQxIaGOaTuZcWdf48cv_0024();
		return _0023_003DzPqugltJuAE6srNX0xOpFMbg_003D();
	}

	public bool _0023_003DzIP3AkZdn9WJEiLnJXRyNm40_003D()
	{
		_0023_003Dz_0024B6qqUCM_oolwcA0o_0G5baLvo2wbRblew_003D_003D(1);
		return _0023_003DzBxpHhQ0_003D[0] != 0;
	}

	public byte _0023_003Dz2DBTqfW51eVHX_0024PiHey2kryLbqPoOZPrpMXUAwQ_003D()
	{
		_0023_003Dz5EbsTzagsJQMlqS2KaMv6arUjQxIaGOaTuZcWdf48cv_0024();
		int num = _0023_003Dz9jrlnWk_003D._0023_003DzYLzISiGNI5ZPpiirogLzUVXQ5_kEw2di5D17KRbqiAaIvAwk3RipJTy7uljIaVjQyDBIhX_6wjLQ6Rvj42HRfhRTT1Ns();
		if (num == -1)
		{
			throw new Exception();
		}
		return (byte)num;
	}

	public sbyte _0023_003DzAR22HP52FDbZdoGnhOF9tck_003D()
	{
		_0023_003Dz_0024B6qqUCM_oolwcA0o_0G5baLvo2wbRblew_003D_003D(1);
		return (sbyte)_0023_003DzBxpHhQ0_003D[0];
	}

	public char _0023_003DzUQ4Zujf7YyzysbI8gQ_003D_003D()
	{
		int num = _0023_003Dz3MCT1WV7UIUWwuUxIs4TwapE5a8dgrdxBg_003D_003D();
		if (num == -1)
		{
			throw new Exception();
		}
		return (char)num;
	}

	private static decimal _0023_003DzQQSspnrXkbCwq849qUG9MhDuMXS9NsZ8isBMx3vEUh5j(int _0023_003Dz9jrlnWk_003D, int _0023_003DzBxpHhQ0_003D, int _0023_003Dztgqm2r4_003D, int _0023_003DzzKDx05I_003D)
	{
		bool isNegative = (_0023_003DzzKDx05I_003D & int.MinValue) != 0;
		byte scale = (byte)(_0023_003DzzKDx05I_003D >> 16);
		return new decimal(_0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D, isNegative, scale);
	}

	internal static decimal _0023_003DzuBvZDcYhP80ADNoSelyFGe8JHRnG2vAt_g_003D_003D(byte[] _0023_003Dz9jrlnWk_003D)
	{
		int num = _0023_003Dz9jrlnWk_003D[0] | (_0023_003Dz9jrlnWk_003D[1] << 8) | (_0023_003Dz9jrlnWk_003D[2] << 16) | (_0023_003Dz9jrlnWk_003D[3] << 24);
		int num2 = _0023_003Dz9jrlnWk_003D[4] | (_0023_003Dz9jrlnWk_003D[5] << 8) | (_0023_003Dz9jrlnWk_003D[6] << 16) | (_0023_003Dz9jrlnWk_003D[7] << 24);
		int num3 = _0023_003Dz9jrlnWk_003D[8] | (_0023_003Dz9jrlnWk_003D[9] << 8) | (_0023_003Dz9jrlnWk_003D[10] << 16) | (_0023_003Dz9jrlnWk_003D[11] << 24);
		int num4 = _0023_003Dz9jrlnWk_003D[12] | (_0023_003Dz9jrlnWk_003D[13] << 8) | (_0023_003Dz9jrlnWk_003D[14] << 16) | (_0023_003Dz9jrlnWk_003D[15] << 24);
		return _0023_003DzQQSspnrXkbCwq849qUG9MhDuMXS9NsZ8isBMx3vEUh5j(num, num2, num3, num4);
	}

	public string _0023_003DzYwSkP_0024AT_4cNB1WKv1Bn_0024U2fDpNoCLCIgZMBDZU_003D()
	{
		int num = 0;
		_0023_003Dz5EbsTzagsJQMlqS2KaMv6arUjQxIaGOaTuZcWdf48cv_0024();
		int num2 = _0023_003DzenwK8cW1s7NbjzVm6XOeYfWXq5L4();
		if (num2 < 0)
		{
			throw new IOException();
		}
		if (num2 == 0)
		{
			return string.Empty;
		}
		if (_0023_003DzzKDx05I_003D == null)
		{
			_0023_003DzzKDx05I_003D = new byte[128];
		}
		if (_0023_003Dz2X8kE24_003D == null)
		{
			_0023_003Dz2X8kE24_003D = new char[_0023_003DzJGsRSpg_003D];
		}
		StringBuilder stringBuilder = null;
		do
		{
			int num3 = ((num2 - num > 128) ? 128 : (num2 - num));
			int num4 = _0023_003Dz9jrlnWk_003D._0023_003DzulSx4Jx4Pj9eE81TPL1Iwudj2y0tGiYiNkUqLldPkK9oqhsQpYmtt9A1zPuRhvzmcjJb1LlRm9dF7M_002427A_003D_003D(_0023_003DzzKDx05I_003D, 0, num3);
			if (num4 == 0)
			{
				throw new Exception();
			}
			int chars = _0023_003Dztgqm2r4_003D.GetChars(_0023_003DzzKDx05I_003D, 0, num4, _0023_003Dz2X8kE24_003D, 0);
			if (num == 0 && num4 == num2)
			{
				return new string(_0023_003Dz2X8kE24_003D, 0, chars);
			}
			if (stringBuilder == null)
			{
				stringBuilder = new StringBuilder(num2);
			}
			stringBuilder.Append(_0023_003Dz2X8kE24_003D, 0, chars);
			num += num4;
		}
		while (num < num2);
		return stringBuilder.ToString();
	}

	public int _0023_003DziiP2DPZK_cGrWz_0024rAUSSuM2NHKw7sMZmew_003D_003D(char[] _0023_003Dz9jrlnWk_003D, int _0023_003DzBxpHhQ0_003D, int _0023_003Dztgqm2r4_003D)
	{
		if (_0023_003Dz9jrlnWk_003D == null)
		{
			throw new ArgumentNullException(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312133), _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312138));
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
		_0023_003Dz5EbsTzagsJQMlqS2KaMv6arUjQxIaGOaTuZcWdf48cv_0024();
		return _0023_003DzEQrzi_NbfYLCtfOw0XFtI6ChGuYO(_0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D);
	}

	private int _0023_003DzEQrzi_NbfYLCtfOw0XFtI6ChGuYO(char[] _0023_003Dz9jrlnWk_003D, int _0023_003DzBxpHhQ0_003D, int _0023_003Dztgqm2r4_003D)
	{
		int num = 0;
		int num2 = 0;
		int num3 = _0023_003Dztgqm2r4_003D;
		if (_0023_003DzzKDx05I_003D == null)
		{
			_0023_003DzzKDx05I_003D = new byte[128];
		}
		while (num3 > 0)
		{
			num2 = num3;
			if (_0023_003Dz9I8ZVlc_003D)
			{
				num2 <<= 1;
			}
			if (num2 > 128)
			{
				num2 = 128;
			}
			if (_0023_003DzgqvoyJk_003D)
			{
				_0023_003DqtFN_00241TjdaenuCmn9GBmqpoZ3gp2tHyBL0X9WMKdAUQk_003D _0023_003DqtFN_00241TjdaenuCmn9GBmqpoZ3gp2tHyBL0X9WMKdAUQk_003D2 = (_0023_003DqtFN_00241TjdaenuCmn9GBmqpoZ3gp2tHyBL0X9WMKdAUQk_003D)this._0023_003Dz9jrlnWk_003D;
				int byteIndex = _0023_003DqtFN_00241TjdaenuCmn9GBmqpoZ3gp2tHyBL0X9WMKdAUQk_003D2._0023_003DzrTJ908p3xlAPZKwaeWWbLBISGjT_();
				num2 = _0023_003DqtFN_00241TjdaenuCmn9GBmqpoZ3gp2tHyBL0X9WMKdAUQk_003D2._0023_003Dzxw06xFa_f0_iOHVyUF0fOWFaQ9Xi(num2);
				if (num2 == 0)
				{
					return _0023_003Dztgqm2r4_003D - num3;
				}
				num = this._0023_003Dztgqm2r4_003D.GetChars(_0023_003DqtFN_00241TjdaenuCmn9GBmqpoZ3gp2tHyBL0X9WMKdAUQk_003D2._0023_003DzoeXQuH_h3qZO8CsKuXHcm_0024I_003D(), byteIndex, num2, _0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D);
			}
			else
			{
				num2 = this._0023_003Dz9jrlnWk_003D._0023_003DzulSx4Jx4Pj9eE81TPL1Iwudj2y0tGiYiNkUqLldPkK9oqhsQpYmtt9A1zPuRhvzmcjJb1LlRm9dF7M_002427A_003D_003D(_0023_003DzzKDx05I_003D, 0, num2);
				if (num2 == 0)
				{
					return _0023_003Dztgqm2r4_003D - num3;
				}
				num = this._0023_003Dztgqm2r4_003D.GetChars(_0023_003DzzKDx05I_003D, 0, num2, _0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D);
			}
			num3 -= num;
			_0023_003DzBxpHhQ0_003D += num;
		}
		return _0023_003Dztgqm2r4_003D;
	}

	private int _0023_003DzPqugltJuAE6srNX0xOpFMbg_003D()
	{
		int num = 0;
		int num2 = 0;
		long num3 = (num3 = 0L);
		if (_0023_003Dz9jrlnWk_003D._0023_003DzwX11mF2T9N_0024q2RUO8GOB5Jcl_0024vC87a1tdddqF2Ze7Abi7AAbj2LBGnHuTb_D0bIJMeqAfZyIZO1Q())
		{
			num3 = _0023_003Dz9jrlnWk_003D._0023_003Dz_0024PxYTL_nlzJnpvFXwwRZmMj6PIfqbJZrp54foI9tn5jPksqeRkurekdA04xNnozUhhfo4rA_003D();
		}
		if (_0023_003DzzKDx05I_003D == null)
		{
			_0023_003DzzKDx05I_003D = new byte[128];
		}
		if (_0023_003Dz3iPku7s_003D == null)
		{
			_0023_003Dz3iPku7s_003D = new char[1];
		}
		while (num == 0)
		{
			num2 = ((!_0023_003Dz9I8ZVlc_003D) ? 1 : 2);
			int num4 = _0023_003Dz9jrlnWk_003D._0023_003DzYLzISiGNI5ZPpiirogLzUVXQ5_kEw2di5D17KRbqiAaIvAwk3RipJTy7uljIaVjQyDBIhX_6wjLQ6Rvj42HRfhRTT1Ns();
			_0023_003DzzKDx05I_003D[0] = (byte)num4;
			if (num4 == -1)
			{
				num2 = 0;
			}
			if (num2 == 2)
			{
				num4 = _0023_003Dz9jrlnWk_003D._0023_003DzYLzISiGNI5ZPpiirogLzUVXQ5_kEw2di5D17KRbqiAaIvAwk3RipJTy7uljIaVjQyDBIhX_6wjLQ6Rvj42HRfhRTT1Ns();
				_0023_003DzzKDx05I_003D[1] = (byte)num4;
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
				num = _0023_003Dztgqm2r4_003D.GetChars(_0023_003DzzKDx05I_003D, 0, num2, _0023_003Dz3iPku7s_003D, 0);
			}
			catch
			{
				if (_0023_003Dz9jrlnWk_003D._0023_003DzwX11mF2T9N_0024q2RUO8GOB5Jcl_0024vC87a1tdddqF2Ze7Abi7AAbj2LBGnHuTb_D0bIJMeqAfZyIZO1Q())
				{
					_0023_003Dz9jrlnWk_003D._0023_003Dzz5uSZofwQCQyOcEKwfVQmiivZ_0024bgBfg6QfI4mYf6tHIC42rk18fkszOb_ezLTX5YRgaBPKGRm6aQTYVwBg_003D_003D(num3 - _0023_003Dz9jrlnWk_003D._0023_003Dz_0024PxYTL_nlzJnpvFXwwRZmMj6PIfqbJZrp54foI9tn5jPksqeRkurekdA04xNnozUhhfo4rA_003D(), 1);
				}
				throw;
			}
		}
		if (num == 0)
		{
			return -1;
		}
		return _0023_003Dz3iPku7s_003D[0];
	}

	public char[] _0023_003DzWLwc6mV373Q1q0Ytuw5CUKzqfNkoE3Kq2w_003D_003D(int _0023_003Dz9jrlnWk_003D)
	{
		_0023_003Dz5EbsTzagsJQMlqS2KaMv6arUjQxIaGOaTuZcWdf48cv_0024();
		if (_0023_003Dz9jrlnWk_003D < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		char[] array = new char[_0023_003Dz9jrlnWk_003D];
		int num = _0023_003DzEQrzi_NbfYLCtfOw0XFtI6ChGuYO(array, 0, _0023_003Dz9jrlnWk_003D);
		if (num != _0023_003Dz9jrlnWk_003D)
		{
			char[] array2 = new char[num];
			Buffer.BlockCopy(array, 0, array2, 0, 2 * num);
			array = array2;
		}
		return array;
	}

	public int _0023_003Dz63pnmtU9eOqD0MuP96o85H1qyebc1tgnLg_003D_003D(byte[] _0023_003Dz9jrlnWk_003D, int _0023_003DzBxpHhQ0_003D, int _0023_003Dztgqm2r4_003D)
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
		_0023_003Dz5EbsTzagsJQMlqS2KaMv6arUjQxIaGOaTuZcWdf48cv_0024();
		return this._0023_003Dz9jrlnWk_003D._0023_003DzulSx4Jx4Pj9eE81TPL1Iwudj2y0tGiYiNkUqLldPkK9oqhsQpYmtt9A1zPuRhvzmcjJb1LlRm9dF7M_002427A_003D_003D(_0023_003Dz9jrlnWk_003D, _0023_003DzBxpHhQ0_003D, _0023_003Dztgqm2r4_003D);
	}

	private void _0023_003Dz5EbsTzagsJQMlqS2KaMv6arUjQxIaGOaTuZcWdf48cv_0024()
	{
		if (_0023_003Dz9jrlnWk_003D == null)
		{
			throw new Exception();
		}
	}

	public byte[] _0023_003DzWVVbbuhgx6dgF8ckt0wDkTboB_J7n196FA_003D_003D(int _0023_003Dz9jrlnWk_003D)
	{
		if (_0023_003Dz9jrlnWk_003D < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		_0023_003Dz5EbsTzagsJQMlqS2KaMv6arUjQxIaGOaTuZcWdf48cv_0024();
		byte[] array = new byte[_0023_003Dz9jrlnWk_003D];
		int num = 0;
		do
		{
			int num2 = this._0023_003Dz9jrlnWk_003D._0023_003DzulSx4Jx4Pj9eE81TPL1Iwudj2y0tGiYiNkUqLldPkK9oqhsQpYmtt9A1zPuRhvzmcjJb1LlRm9dF7M_002427A_003D_003D(array, num, _0023_003Dz9jrlnWk_003D);
			if (num2 == 0)
			{
				break;
			}
			num += num2;
			_0023_003Dz9jrlnWk_003D -= num2;
		}
		while (_0023_003Dz9jrlnWk_003D > 0);
		if (num != array.Length)
		{
			byte[] array2 = new byte[num];
			Buffer.BlockCopy(array, 0, array2, 0, num);
			array = array2;
		}
		return array;
	}

	private void _0023_003Dz_0024B6qqUCM_oolwcA0o_0G5baLvo2wbRblew_003D_003D(int _0023_003Dz9jrlnWk_003D)
	{
		_0023_003Dz5EbsTzagsJQMlqS2KaMv6arUjQxIaGOaTuZcWdf48cv_0024();
		int num = 0;
		int num2 = 0;
		if (_0023_003Dz9jrlnWk_003D == 1)
		{
			num2 = this._0023_003Dz9jrlnWk_003D._0023_003DzYLzISiGNI5ZPpiirogLzUVXQ5_kEw2di5D17KRbqiAaIvAwk3RipJTy7uljIaVjQyDBIhX_6wjLQ6Rvj42HRfhRTT1Ns();
			if (num2 == -1)
			{
				throw new Exception();
			}
			_0023_003DzBxpHhQ0_003D[0] = (byte)num2;
			return;
		}
		do
		{
			num2 = this._0023_003Dz9jrlnWk_003D._0023_003DzulSx4Jx4Pj9eE81TPL1Iwudj2y0tGiYiNkUqLldPkK9oqhsQpYmtt9A1zPuRhvzmcjJb1LlRm9dF7M_002427A_003D_003D(_0023_003DzBxpHhQ0_003D, num, _0023_003Dz9jrlnWk_003D - num);
			if (num2 == 0)
			{
				throw new Exception();
			}
			num += num2;
		}
		while (num < _0023_003Dz9jrlnWk_003D);
	}

	internal int _0023_003DzenwK8cW1s7NbjzVm6XOeYfWXq5L4()
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
			b = _0023_003Dz2DBTqfW51eVHX_0024PiHey2kryLbqPoOZPrpMXUAwQ_003D();
			num |= (b & 0x7F) << num2;
			num2 += 7;
		}
		while ((b & 0x80) != 0);
		return num;
	}

	public int _0023_003DzzWp83NqubJCg0KBvRVdJ1Clh9XOWlHor0w_003D_003D()
	{
		if (_0023_003DzgqvoyJk_003D)
		{
			return ((_0023_003DqtFN_00241TjdaenuCmn9GBmqpoZ3gp2tHyBL0X9WMKdAUQk_003D)_0023_003Dz9jrlnWk_003D)._0023_003Dzir1SrBz_i6R0mxgejtllxihbZgtGM5MlX4jL_musdJaL();
		}
		_0023_003Dz_0024B6qqUCM_oolwcA0o_0G5baLvo2wbRblew_003D_003D(4);
		return _0023_003DzBxpHhQ0_003D[0] | (_0023_003DzBxpHhQ0_003D[3] << 24) | (_0023_003DzBxpHhQ0_003D[1] << 16) | (_0023_003DzBxpHhQ0_003D[2] << 8);
	}

	public uint _0023_003Dz6ZCFHacYN7DiGCTOLVcLt1ROT7gcyKHf_0024OLcW_0_003D()
	{
		_0023_003Dz_0024B6qqUCM_oolwcA0o_0G5baLvo2wbRblew_003D_003D(4);
		return (uint)((_0023_003DzBxpHhQ0_003D[3] << 16) | _0023_003DzBxpHhQ0_003D[1] | (_0023_003DzBxpHhQ0_003D[0] << 8) | (_0023_003DzBxpHhQ0_003D[2] << 24));
	}

	public long _0023_003Dz1RtBg1_0024Sse5482v8asVTTPvqL0oBixer7Dch_d3qXLja()
	{
		_0023_003Dz_0024B6qqUCM_oolwcA0o_0G5baLvo2wbRblew_003D_003D(8);
		byte[] array = _0023_003DzBxpHhQ0_003D;
		return (uint)((array[7] << 8) | (array[2] << 24) | array[0] | (array[1] << 16)) | ((long)((array[5] << 24) | (array[6] << 16) | array[4] | (array[3] << 8)) << 32);
	}

	public ulong _0023_003Dzfohx3z0hPco_McRQmABz8SvmhxAeH418GnjVldDYQBmi()
	{
		_0023_003Dz_0024B6qqUCM_oolwcA0o_0G5baLvo2wbRblew_003D_003D(8);
		byte[] array = _0023_003DzBxpHhQ0_003D;
		return (ulong)((uint)((array[2] << 16) | (array[5] << 24) | (array[4] << 8) | array[6]) | ((long)((array[1] << 16) | array[0] | (array[7] << 24) | (array[3] << 8)) << 32));
	}

	public short _0023_003DzfyBJnRlgDbP3pAMbTWEdJKI_003D()
	{
		_0023_003Dz_0024B6qqUCM_oolwcA0o_0G5baLvo2wbRblew_003D_003D(2);
		byte[] array = _0023_003DzBxpHhQ0_003D;
		return (short)((array[0] << 8) | array[1]);
	}

	public ushort _0023_003Dz1zMApy2OI0rrWse6_0024UUktlSLP2iUmcLUkpFNZ5lylbxv()
	{
		_0023_003Dz_0024B6qqUCM_oolwcA0o_0G5baLvo2wbRblew_003D_003D(2);
		byte[] array = _0023_003DzBxpHhQ0_003D;
		return (ushort)(array[1] | (array[0] << 8));
	}

	private byte[] _0023_003DzoUhoyjkR_C_L4Ft0_LElyQwwFnWV()
	{
		byte[] array = _0023_003DzoEGLyuM_003D;
		if (array == null)
		{
			array = (_0023_003DzoEGLyuM_003D = new byte[16]);
		}
		return array;
	}

	public float _0023_003DziB0CWaH99iC_0024loCVaOciPifQ5ShPLxAqDHJv5q1KXBjq()
	{
		_0023_003Dz_0024B6qqUCM_oolwcA0o_0G5baLvo2wbRblew_003D_003D(4);
		byte[] array = _0023_003DzBxpHhQ0_003D;
		byte[] array2 = _0023_003DzoUhoyjkR_C_L4Ft0_LElyQwwFnWV();
		array2[1] = array[1];
		array2[3] = array[0];
		array2[2] = array[2];
		array2[0] = array[3];
		return _0023_003Dzx03y6pxtmc_0024NkPcKqn2cA8EtzlOlSLUO_0024w_003D_003D(array2).ReadSingle();
	}

	public double _0023_003DzHvok0YbFZwLvuWkx5ZfQ_0024EkmAXuc()
	{
		_0023_003Dz_0024B6qqUCM_oolwcA0o_0G5baLvo2wbRblew_003D_003D(8);
		byte[] array = _0023_003DzBxpHhQ0_003D;
		byte[] array2 = _0023_003DzoUhoyjkR_C_L4Ft0_LElyQwwFnWV();
		array2[5] = array[1];
		array2[2] = array[4];
		array2[0] = array[2];
		array2[3] = array[3];
		array2[7] = array[0];
		array2[4] = array[6];
		array2[1] = array[5];
		array2[6] = array[7];
		return _0023_003Dzx03y6pxtmc_0024NkPcKqn2cA8EtzlOlSLUO_0024w_003D_003D(array2).ReadDouble();
	}

	public decimal _0023_003DzUkPOOPMvw_XxRT_0024kOcgaq7FZnuZPtfGTiV7rGAzk4M87()
	{
		_0023_003Dz_0024B6qqUCM_oolwcA0o_0G5baLvo2wbRblew_003D_003D(16);
		byte[] array = _0023_003DzBxpHhQ0_003D;
		byte[] array2 = _0023_003DzoUhoyjkR_C_L4Ft0_LElyQwwFnWV();
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
		return _0023_003DzuBvZDcYhP80ADNoSelyFGe8JHRnG2vAt_g_003D_003D(array2);
	}

	private BinaryReader _0023_003Dzx03y6pxtmc_0024NkPcKqn2cA8EtzlOlSLUO_0024w_003D_003D(byte[] _0023_003Dz9jrlnWk_003D)
	{
		MemoryStream memoryStream = _0023_003DziiEv3wQ_003D;
		BinaryReader binaryReader = _0023_003DzJ6W8874_003D;
		if (memoryStream == null)
		{
			memoryStream = (_0023_003DziiEv3wQ_003D = new MemoryStream(8));
			binaryReader = (_0023_003DzJ6W8874_003D = new BinaryReader(memoryStream));
		}
		else
		{
			binaryReader.BaseStream.Position = 0L;
		}
		memoryStream.Write(_0023_003Dz9jrlnWk_003D, 0, _0023_003Dz9jrlnWk_003D.Length);
		memoryStream.Position = 0L;
		return binaryReader;
	}
}
