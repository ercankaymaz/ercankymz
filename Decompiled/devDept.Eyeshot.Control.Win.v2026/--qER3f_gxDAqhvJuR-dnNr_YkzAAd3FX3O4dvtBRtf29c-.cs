using System;
using System.Diagnostics;
using System.IO;
using System.Text;

internal sealed class _0023_003DqER3f_gxDAqhvJuR_0024dnNr_YkzAAd3FX3O4dvtBRtf29c_003D : IDisposable
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DqVFAcyYKahdwaFZMP0V7msl5MSPdZk96b_0024ExRKQloAVA_003D _0023_003DzjYYAPCA_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private byte[] _0023_003DzVC9FBdo_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Decoder _0023_003DzwBouG0w_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private byte[] _0023_003Dzf4Pqh9s_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private char[] _0023_003DzTFNDoh0_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private char[] _0023_003DzraVZG9g_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzRoqMfFc_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dz1SmHC4c_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzLtLprGE_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private byte[] _0023_003DzmZWYhFQ_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private MemoryStream _0023_003Dzt2pW2yo_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private BinaryReader _0023_003DzJ6W8874_003D;

	public _0023_003DqER3f_gxDAqhvJuR_0024dnNr_YkzAAd3FX3O4dvtBRtf29c_003D(_0023_003DqVFAcyYKahdwaFZMP0V7msl5MSPdZk96b_0024ExRKQloAVA_003D _0023_003DzjYYAPCA_003D)
		: this(_0023_003DzjYYAPCA_003D, new UTF8Encoding())
	{
	}

	private _0023_003DqER3f_gxDAqhvJuR_0024dnNr_YkzAAd3FX3O4dvtBRtf29c_003D(_0023_003DqVFAcyYKahdwaFZMP0V7msl5MSPdZk96b_0024ExRKQloAVA_003D _0023_003DzjYYAPCA_003D, Encoding _0023_003DzVC9FBdo_003D)
	{
		if (_0023_003DzjYYAPCA_003D == null)
		{
			throw new ArgumentNullException();
		}
		if (_0023_003DzVC9FBdo_003D == null)
		{
			throw new ArgumentNullException();
		}
		if (!_0023_003DzjYYAPCA_003D._0023_003Dz6LNiAXLEYQlQLhIkkSFj5ZQYE8rNPD_0024BXH6mpKJP2IT_0024SaA3nI9RmFOW32GicKEjvUQ06R4_003D())
		{
			throw new ArgumentException();
		}
		this._0023_003DzjYYAPCA_003D = _0023_003DzjYYAPCA_003D;
		_0023_003DzwBouG0w_003D = _0023_003DzVC9FBdo_003D.GetDecoder();
		_0023_003DzRoqMfFc_003D = _0023_003DzVC9FBdo_003D.GetMaxCharCount(128);
		int num = _0023_003DzVC9FBdo_003D.GetMaxByteCount(1);
		if (num < 16)
		{
			num = 16;
		}
		this._0023_003DzVC9FBdo_003D = new byte[num];
		_0023_003DzraVZG9g_003D = null;
		_0023_003Dzf4Pqh9s_003D = null;
		_0023_003Dz1SmHC4c_003D = _0023_003DzVC9FBdo_003D is UnicodeEncoding;
		_0023_003DzLtLprGE_003D = this._0023_003DzjYYAPCA_003D is _0023_003DqUcu9yDNs_OQWZCK2_0024fdxf4IQhTpJNQBHH_Qq96h8BUo_003D;
	}

	public _0023_003DqVFAcyYKahdwaFZMP0V7msl5MSPdZk96b_0024ExRKQloAVA_003D _0023_003Dzel5p97GuW6gyA9KS5UElENp6DK_3o0RvIg_003D_003D()
	{
		return _0023_003DzjYYAPCA_003D;
	}

	public void _0023_003DzOwDMuM0cpS3XyuqiEhwUs9RAifBGzG_0024rgQ_003D_003D()
	{
		_0023_003DzAajc9NGQRNFlTYurWL6A1sZuTruqx_FW1A_003D_003D(_0023_003DzjYYAPCA_003D: true);
	}

	private void _0023_003DzAajc9NGQRNFlTYurWL6A1sZuTruqx_FW1A_003D_003D(bool _0023_003DzjYYAPCA_003D)
	{
		if (_0023_003DzjYYAPCA_003D)
		{
			_0023_003DqVFAcyYKahdwaFZMP0V7msl5MSPdZk96b_0024ExRKQloAVA_003D _0023_003DqVFAcyYKahdwaFZMP0V7msl5MSPdZk96b_0024ExRKQloAVA_003D2 = this._0023_003DzjYYAPCA_003D;
			this._0023_003DzjYYAPCA_003D = null;
			_0023_003DqVFAcyYKahdwaFZMP0V7msl5MSPdZk96b_0024ExRKQloAVA_003D2?._0023_003Dz_lOnBjfBkAF7RhQk8KrNpow_hFtjJBb9ahtkrpoSOCRbIWT38BbnDuA8xomVKurBSmWfZ1KjC7gTFJq1OvXOKbg_003D();
		}
		this._0023_003DzjYYAPCA_003D = null;
		_0023_003DzVC9FBdo_003D = null;
		_0023_003DzwBouG0w_003D = null;
		_0023_003Dzf4Pqh9s_003D = null;
		_0023_003DzTFNDoh0_003D = null;
		_0023_003DzraVZG9g_003D = null;
	}

	private void _0023_003Dz_Ez4GKeLRhVG7839m1zAs1m6k3MId6N8l_0024ijKhfKTpEW6mrS__CzKg7pfwCBac_00243SMvWZ12ziCEt()
	{
		_0023_003DzAajc9NGQRNFlTYurWL6A1sZuTruqx_FW1A_003D_003D(_0023_003DzjYYAPCA_003D: true);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=z_Ez4GKeLRhVG7839m1zAs1m6k3MId6N8l$ijKhfKTpEW6mrS__CzKg7pfwCBac$3SMvWZ12ziCEt
		this._0023_003Dz_Ez4GKeLRhVG7839m1zAs1m6k3MId6N8l_0024ijKhfKTpEW6mrS__CzKg7pfwCBac_00243SMvWZ12ziCEt();
	}

	public int _0023_003DzZ_0024604iDC5Ch_jKSPCxyHa4A_003D()
	{
		_0023_003DzSTUjvAI_B8kQ_OoBrcAHoFmFzdO6u9SG6aqo1YbVa2xt();
		if (!_0023_003DzjYYAPCA_003D._0023_003DzYdkhPjC_bnFruKiyolthzhcBKRUySfU87viCpZBvxOdbMkrNTBgbISTFYe_0024eUsqOLirln_0024dKhOfc())
		{
			return -1;
		}
		long num = _0023_003DzjYYAPCA_003D._0023_003DzVVh_VOOPvzE8OIDVjtj7IIyotysgSsjRp5iJTq6jEV_00246A2hzlq2gX1_0024tau7otE4P6cvwwsQ_003D();
		int result = _0023_003DzNa2YIpPFZfZ9i4NMf4xfFyzMoHDjZCuqCg_003D_003D();
		_0023_003DzjYYAPCA_003D._0023_003Dzn_t9hyVATRPnUxdqXwaUj9BPcyICJFt_8Z7_002402XyW0bjVPch0w_YOa0C7Qx9nd4TCWcwQcY_003D(num);
		return result;
	}

	public int _0023_003DzNa2YIpPFZfZ9i4NMf4xfFyzMoHDjZCuqCg_003D_003D()
	{
		_0023_003DzSTUjvAI_B8kQ_OoBrcAHoFmFzdO6u9SG6aqo1YbVa2xt();
		return _0023_003DzSeHqmlu0RpR_0024i415shlqEWM_003D();
	}

	public bool _0023_003DzQQUfegG5ucAhAjgJ3LsQ2gQ_003D()
	{
		_0023_003Dz7AoEY7kf_0024ncXpdkqo8TZSuszHP77gzBpBQ_003D_003D(1);
		return _0023_003DzVC9FBdo_003D[0] != 0;
	}

	public byte _0023_003DzJXRho5bmAzfbdPjIUmcfx8Wcq1uoRPG2yHT5Frg_003D()
	{
		_0023_003DzSTUjvAI_B8kQ_OoBrcAHoFmFzdO6u9SG6aqo1YbVa2xt();
		int num = _0023_003DzjYYAPCA_003D._0023_003DznnzKhNjmjuyptKdLZc6mqxHTd2yTc_0024jGQkIgE_0024kkGzZT5azI2ekLCYiTWZBKT94kl5dR5kjcP7cdy_0LOaRYyYNzapzc();
		if (num == -1)
		{
			throw new Exception();
		}
		return (byte)num;
	}

	public sbyte _0023_003DzQtQvxcFQDR7tquPxydoZ5gk_003D()
	{
		_0023_003Dz7AoEY7kf_0024ncXpdkqo8TZSuszHP77gzBpBQ_003D_003D(1);
		return (sbyte)_0023_003DzVC9FBdo_003D[0];
	}

	public char _0023_003Dz6FYE__gXUISCVmFK1w_003D_003D()
	{
		int num = _0023_003DzNa2YIpPFZfZ9i4NMf4xfFyzMoHDjZCuqCg_003D_003D();
		if (num == -1)
		{
			throw new Exception();
		}
		return (char)num;
	}

	private static decimal _0023_003Dzp6vqFIIPC7BdSED_hw7_u5JxJ45owmbhD3Ad8rgHdimJ(int _0023_003DzjYYAPCA_003D, int _0023_003DzVC9FBdo_003D, int _0023_003DzwBouG0w_003D, int _0023_003Dzf4Pqh9s_003D)
	{
		bool isNegative = (_0023_003Dzf4Pqh9s_003D & int.MinValue) != 0;
		byte scale = (byte)(_0023_003Dzf4Pqh9s_003D >> 16);
		return new decimal(_0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D, isNegative, scale);
	}

	internal static decimal _0023_003DzneLY_xJ2J_0024bkn5lLDJO501dvGWh3VCFtBQ_003D_003D(byte[] _0023_003DzjYYAPCA_003D)
	{
		int num = _0023_003DzjYYAPCA_003D[0] | (_0023_003DzjYYAPCA_003D[1] << 8) | (_0023_003DzjYYAPCA_003D[2] << 16) | (_0023_003DzjYYAPCA_003D[3] << 24);
		int num2 = _0023_003DzjYYAPCA_003D[4] | (_0023_003DzjYYAPCA_003D[5] << 8) | (_0023_003DzjYYAPCA_003D[6] << 16) | (_0023_003DzjYYAPCA_003D[7] << 24);
		int num3 = _0023_003DzjYYAPCA_003D[8] | (_0023_003DzjYYAPCA_003D[9] << 8) | (_0023_003DzjYYAPCA_003D[10] << 16) | (_0023_003DzjYYAPCA_003D[11] << 24);
		int num4 = _0023_003DzjYYAPCA_003D[12] | (_0023_003DzjYYAPCA_003D[13] << 8) | (_0023_003DzjYYAPCA_003D[14] << 16) | (_0023_003DzjYYAPCA_003D[15] << 24);
		return _0023_003Dzp6vqFIIPC7BdSED_hw7_u5JxJ45owmbhD3Ad8rgHdimJ(num, num2, num3, num4);
	}

	public string _0023_003Dz0w9pyVoUGYVaCx6Z9jRjujMZm1HNixgUUFrxFtI_003D()
	{
		int num = 0;
		_0023_003DzSTUjvAI_B8kQ_OoBrcAHoFmFzdO6u9SG6aqo1YbVa2xt();
		int num2 = _0023_003Dz7yE4V0_l28IndeCHhDn7Kuk7Huyw();
		if (num2 < 0)
		{
			throw new IOException();
		}
		if (num2 == 0)
		{
			return string.Empty;
		}
		if (_0023_003Dzf4Pqh9s_003D == null)
		{
			_0023_003Dzf4Pqh9s_003D = new byte[128];
		}
		if (_0023_003DzraVZG9g_003D == null)
		{
			_0023_003DzraVZG9g_003D = new char[_0023_003DzRoqMfFc_003D];
		}
		StringBuilder stringBuilder = null;
		do
		{
			int num3 = ((num2 - num > 128) ? 128 : (num2 - num));
			int num4 = _0023_003DzjYYAPCA_003D._0023_003DzOVN4VvoLFL2S9tW2hEeVpby89pOXbMnEKyWxF7sXdkjazNQBxn_0024MlbVfdzFAEhNpVwGKfA5miLbFebKbcQ_003D_003D(_0023_003Dzf4Pqh9s_003D, 0, num3);
			if (num4 == 0)
			{
				throw new Exception();
			}
			int chars = _0023_003DzwBouG0w_003D.GetChars(_0023_003Dzf4Pqh9s_003D, 0, num4, _0023_003DzraVZG9g_003D, 0);
			if (num == 0 && num4 == num2)
			{
				return new string(_0023_003DzraVZG9g_003D, 0, chars);
			}
			if (stringBuilder == null)
			{
				stringBuilder = new StringBuilder(num2);
			}
			stringBuilder.Append(_0023_003DzraVZG9g_003D, 0, chars);
			num += num4;
		}
		while (num < num2);
		return stringBuilder.ToString();
	}

	public int _0023_003DzloxqsTVTq7Y_0024qPmoJ2nBuGNu1YI_UQJ_00246w_003D_003D(char[] _0023_003DzjYYAPCA_003D, int _0023_003DzVC9FBdo_003D, int _0023_003DzwBouG0w_003D)
	{
		if (_0023_003DzjYYAPCA_003D == null)
		{
			throw new ArgumentNullException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348619644), _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348619633));
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
		_0023_003DzSTUjvAI_B8kQ_OoBrcAHoFmFzdO6u9SG6aqo1YbVa2xt();
		return _0023_003Dzj6Qxrcb2TyGrSCwdS3D5ml3vDwnc(_0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D);
	}

	private int _0023_003Dzj6Qxrcb2TyGrSCwdS3D5ml3vDwnc(char[] _0023_003DzjYYAPCA_003D, int _0023_003DzVC9FBdo_003D, int _0023_003DzwBouG0w_003D)
	{
		int num = 0;
		int num2 = 0;
		int num3 = _0023_003DzwBouG0w_003D;
		if (_0023_003Dzf4Pqh9s_003D == null)
		{
			_0023_003Dzf4Pqh9s_003D = new byte[128];
		}
		while (num3 > 0)
		{
			num2 = num3;
			if (_0023_003Dz1SmHC4c_003D)
			{
				num2 <<= 1;
			}
			if (num2 > 128)
			{
				num2 = 128;
			}
			if (_0023_003DzLtLprGE_003D)
			{
				_0023_003DqUcu9yDNs_OQWZCK2_0024fdxf4IQhTpJNQBHH_Qq96h8BUo_003D _0023_003DqUcu9yDNs_OQWZCK2_0024fdxf4IQhTpJNQBHH_Qq96h8BUo_003D2 = (_0023_003DqUcu9yDNs_OQWZCK2_0024fdxf4IQhTpJNQBHH_Qq96h8BUo_003D)this._0023_003DzjYYAPCA_003D;
				int byteIndex = _0023_003DqUcu9yDNs_OQWZCK2_0024fdxf4IQhTpJNQBHH_Qq96h8BUo_003D2._0023_003Dzrjl2CXYzFMNQfUVms2Qh0iYTrZ_e();
				num2 = _0023_003DqUcu9yDNs_OQWZCK2_0024fdxf4IQhTpJNQBHH_Qq96h8BUo_003D2._0023_003DzQwfFmp8YhIA05Gevt8CA3W8Caxf_0024(num2);
				if (num2 == 0)
				{
					return _0023_003DzwBouG0w_003D - num3;
				}
				num = this._0023_003DzwBouG0w_003D.GetChars(_0023_003DqUcu9yDNs_OQWZCK2_0024fdxf4IQhTpJNQBHH_Qq96h8BUo_003D2._0023_003DznVK_002428dVurgAZA6Q6RBdpaE_003D(), byteIndex, num2, _0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D);
			}
			else
			{
				num2 = this._0023_003DzjYYAPCA_003D._0023_003DzOVN4VvoLFL2S9tW2hEeVpby89pOXbMnEKyWxF7sXdkjazNQBxn_0024MlbVfdzFAEhNpVwGKfA5miLbFebKbcQ_003D_003D(_0023_003Dzf4Pqh9s_003D, 0, num2);
				if (num2 == 0)
				{
					return _0023_003DzwBouG0w_003D - num3;
				}
				num = this._0023_003DzwBouG0w_003D.GetChars(_0023_003Dzf4Pqh9s_003D, 0, num2, _0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D);
			}
			num3 -= num;
			_0023_003DzVC9FBdo_003D += num;
		}
		return _0023_003DzwBouG0w_003D;
	}

	private int _0023_003DzSeHqmlu0RpR_0024i415shlqEWM_003D()
	{
		int num = 0;
		int num2 = 0;
		long num3 = (num3 = 0L);
		if (_0023_003DzjYYAPCA_003D._0023_003DzYdkhPjC_bnFruKiyolthzhcBKRUySfU87viCpZBvxOdbMkrNTBgbISTFYe_0024eUsqOLirln_0024dKhOfc())
		{
			num3 = _0023_003DzjYYAPCA_003D._0023_003DzVVh_VOOPvzE8OIDVjtj7IIyotysgSsjRp5iJTq6jEV_00246A2hzlq2gX1_0024tau7otE4P6cvwwsQ_003D();
		}
		if (_0023_003Dzf4Pqh9s_003D == null)
		{
			_0023_003Dzf4Pqh9s_003D = new byte[128];
		}
		if (_0023_003DzTFNDoh0_003D == null)
		{
			_0023_003DzTFNDoh0_003D = new char[1];
		}
		while (num == 0)
		{
			num2 = ((!_0023_003Dz1SmHC4c_003D) ? 1 : 2);
			int num4 = _0023_003DzjYYAPCA_003D._0023_003DznnzKhNjmjuyptKdLZc6mqxHTd2yTc_0024jGQkIgE_0024kkGzZT5azI2ekLCYiTWZBKT94kl5dR5kjcP7cdy_0LOaRYyYNzapzc();
			_0023_003Dzf4Pqh9s_003D[0] = (byte)num4;
			if (num4 == -1)
			{
				num2 = 0;
			}
			if (num2 == 2)
			{
				num4 = _0023_003DzjYYAPCA_003D._0023_003DznnzKhNjmjuyptKdLZc6mqxHTd2yTc_0024jGQkIgE_0024kkGzZT5azI2ekLCYiTWZBKT94kl5dR5kjcP7cdy_0LOaRYyYNzapzc();
				_0023_003Dzf4Pqh9s_003D[1] = (byte)num4;
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
				num = _0023_003DzwBouG0w_003D.GetChars(_0023_003Dzf4Pqh9s_003D, 0, num2, _0023_003DzTFNDoh0_003D, 0);
			}
			catch
			{
				if (_0023_003DzjYYAPCA_003D._0023_003DzYdkhPjC_bnFruKiyolthzhcBKRUySfU87viCpZBvxOdbMkrNTBgbISTFYe_0024eUsqOLirln_0024dKhOfc())
				{
					_0023_003DzjYYAPCA_003D._0023_003DzF9bNse9wHJLLtepk_gT8nT7RoArbYZ5O7BM_0024pvRSfZZCcif09QuhqkEcicQBZU2Q_1FotqnGeCeOOleA6w_003D_003D(num3 - _0023_003DzjYYAPCA_003D._0023_003DzVVh_VOOPvzE8OIDVjtj7IIyotysgSsjRp5iJTq6jEV_00246A2hzlq2gX1_0024tau7otE4P6cvwwsQ_003D(), 1);
				}
				throw;
			}
		}
		if (num == 0)
		{
			return -1;
		}
		return _0023_003DzTFNDoh0_003D[0];
	}

	public char[] _0023_003Dz_g2eDyeDOcEt040kp27pkrzyOhnPlv32yw_003D_003D(int _0023_003DzjYYAPCA_003D)
	{
		_0023_003DzSTUjvAI_B8kQ_OoBrcAHoFmFzdO6u9SG6aqo1YbVa2xt();
		if (_0023_003DzjYYAPCA_003D < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		char[] array = new char[_0023_003DzjYYAPCA_003D];
		int num = _0023_003Dzj6Qxrcb2TyGrSCwdS3D5ml3vDwnc(array, 0, _0023_003DzjYYAPCA_003D);
		if (num != _0023_003DzjYYAPCA_003D)
		{
			char[] array2 = new char[num];
			Buffer.BlockCopy(array, 0, array2, 0, 2 * num);
			array = array2;
		}
		return array;
	}

	public int _0023_003Dz4_0024_0024Pexl8uo2gvGDQRlS7Fo9UIeiv8gfT0g_003D_003D(byte[] _0023_003DzjYYAPCA_003D, int _0023_003DzVC9FBdo_003D, int _0023_003DzwBouG0w_003D)
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
		_0023_003DzSTUjvAI_B8kQ_OoBrcAHoFmFzdO6u9SG6aqo1YbVa2xt();
		return this._0023_003DzjYYAPCA_003D._0023_003DzOVN4VvoLFL2S9tW2hEeVpby89pOXbMnEKyWxF7sXdkjazNQBxn_0024MlbVfdzFAEhNpVwGKfA5miLbFebKbcQ_003D_003D(_0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D);
	}

	private void _0023_003DzSTUjvAI_B8kQ_OoBrcAHoFmFzdO6u9SG6aqo1YbVa2xt()
	{
		if (_0023_003DzjYYAPCA_003D == null)
		{
			throw new Exception();
		}
	}

	public byte[] _0023_003DzDu76ONenlgLqQ6iaLALulRQhOIsSWS4Oiw_003D_003D(int _0023_003DzjYYAPCA_003D)
	{
		if (_0023_003DzjYYAPCA_003D < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		_0023_003DzSTUjvAI_B8kQ_OoBrcAHoFmFzdO6u9SG6aqo1YbVa2xt();
		byte[] array = new byte[_0023_003DzjYYAPCA_003D];
		int num = 0;
		do
		{
			int num2 = this._0023_003DzjYYAPCA_003D._0023_003DzOVN4VvoLFL2S9tW2hEeVpby89pOXbMnEKyWxF7sXdkjazNQBxn_0024MlbVfdzFAEhNpVwGKfA5miLbFebKbcQ_003D_003D(array, num, _0023_003DzjYYAPCA_003D);
			if (num2 == 0)
			{
				break;
			}
			num += num2;
			_0023_003DzjYYAPCA_003D -= num2;
		}
		while (_0023_003DzjYYAPCA_003D > 0);
		if (num != array.Length)
		{
			byte[] array2 = new byte[num];
			Buffer.BlockCopy(array, 0, array2, 0, num);
			array = array2;
		}
		return array;
	}

	private void _0023_003Dz7AoEY7kf_0024ncXpdkqo8TZSuszHP77gzBpBQ_003D_003D(int _0023_003DzjYYAPCA_003D)
	{
		_0023_003DzSTUjvAI_B8kQ_OoBrcAHoFmFzdO6u9SG6aqo1YbVa2xt();
		int num = 0;
		int num2 = 0;
		if (_0023_003DzjYYAPCA_003D == 1)
		{
			num2 = this._0023_003DzjYYAPCA_003D._0023_003DznnzKhNjmjuyptKdLZc6mqxHTd2yTc_0024jGQkIgE_0024kkGzZT5azI2ekLCYiTWZBKT94kl5dR5kjcP7cdy_0LOaRYyYNzapzc();
			if (num2 == -1)
			{
				throw new Exception();
			}
			_0023_003DzVC9FBdo_003D[0] = (byte)num2;
			return;
		}
		do
		{
			num2 = this._0023_003DzjYYAPCA_003D._0023_003DzOVN4VvoLFL2S9tW2hEeVpby89pOXbMnEKyWxF7sXdkjazNQBxn_0024MlbVfdzFAEhNpVwGKfA5miLbFebKbcQ_003D_003D(_0023_003DzVC9FBdo_003D, num, _0023_003DzjYYAPCA_003D - num);
			if (num2 == 0)
			{
				throw new Exception();
			}
			num += num2;
		}
		while (num < _0023_003DzjYYAPCA_003D);
	}

	internal int _0023_003Dz7yE4V0_l28IndeCHhDn7Kuk7Huyw()
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
			b = _0023_003DzJXRho5bmAzfbdPjIUmcfx8Wcq1uoRPG2yHT5Frg_003D();
			num |= (b & 0x7F) << num2;
			num2 += 7;
		}
		while ((b & 0x80) != 0);
		return num;
	}

	public int _0023_003DzrVNk2UXdi5j_Y1Vz_XKTOeoGKdqelFVp0w_003D_003D()
	{
		if (_0023_003DzLtLprGE_003D)
		{
			return ((_0023_003DqUcu9yDNs_OQWZCK2_0024fdxf4IQhTpJNQBHH_Qq96h8BUo_003D)_0023_003DzjYYAPCA_003D)._0023_003Dz8TpFK64UhBwmm5P7_00249SkeZ7CCYEbQNHMk3TjD7jXz3nP();
		}
		_0023_003Dz7AoEY7kf_0024ncXpdkqo8TZSuszHP77gzBpBQ_003D_003D(4);
		return _0023_003DzVC9FBdo_003D[0] | (_0023_003DzVC9FBdo_003D[3] << 24) | (_0023_003DzVC9FBdo_003D[1] << 16) | (_0023_003DzVC9FBdo_003D[2] << 8);
	}

	public uint _0023_003DzEcvK7dMoa2wIyh0TA77RZrYj8LIDTNRaGGUJ26g_003D()
	{
		_0023_003Dz7AoEY7kf_0024ncXpdkqo8TZSuszHP77gzBpBQ_003D_003D(4);
		return (uint)((_0023_003DzVC9FBdo_003D[3] << 16) | _0023_003DzVC9FBdo_003D[1] | (_0023_003DzVC9FBdo_003D[0] << 8) | (_0023_003DzVC9FBdo_003D[2] << 24));
	}

	public long _0023_003Dztd9RtyYy2lWD_9pt8yLFfBodfHRGj5FmrSmIGROFMirZ()
	{
		_0023_003Dz7AoEY7kf_0024ncXpdkqo8TZSuszHP77gzBpBQ_003D_003D(8);
		byte[] array = _0023_003DzVC9FBdo_003D;
		return (uint)((array[7] << 8) | (array[2] << 24) | array[0] | (array[1] << 16)) | ((long)((array[5] << 24) | (array[6] << 16) | array[4] | (array[3] << 8)) << 32);
	}

	public ulong _0023_003DzuK7d1giOEryeF_fi80Q8zyvS0QTwEBi45g_DiENxdCbo()
	{
		_0023_003Dz7AoEY7kf_0024ncXpdkqo8TZSuszHP77gzBpBQ_003D_003D(8);
		byte[] array = _0023_003DzVC9FBdo_003D;
		return (ulong)((uint)((array[2] << 16) | (array[5] << 24) | (array[4] << 8) | array[6]) | ((long)((array[1] << 16) | array[0] | (array[7] << 24) | (array[3] << 8)) << 32));
	}

	public short _0023_003DzAT5B_0024KrVlUL38D8pF9i1EEk_003D()
	{
		_0023_003Dz7AoEY7kf_0024ncXpdkqo8TZSuszHP77gzBpBQ_003D_003D(2);
		byte[] array = _0023_003DzVC9FBdo_003D;
		return (short)((array[0] << 8) | array[1]);
	}

	public ushort _0023_003DzgG4EIr51RxBvrAjab0dJg4lv_0024_aq36ZKqiDdChHGYrXG()
	{
		_0023_003Dz7AoEY7kf_0024ncXpdkqo8TZSuszHP77gzBpBQ_003D_003D(2);
		byte[] array = _0023_003DzVC9FBdo_003D;
		return (ushort)(array[1] | (array[0] << 8));
	}

	private byte[] _0023_003DzoUhoyjkR_C_L4Ft0_LElyQwwFnWV()
	{
		byte[] array = _0023_003DzmZWYhFQ_003D;
		if (array == null)
		{
			array = (_0023_003DzmZWYhFQ_003D = new byte[16]);
		}
		return array;
	}

	public float _0023_003DzYSSnQ6sIOclVFmYf3CKHWlZxoY9zLmDzrxI29_0024kU_XrE()
	{
		_0023_003Dz7AoEY7kf_0024ncXpdkqo8TZSuszHP77gzBpBQ_003D_003D(4);
		byte[] array = _0023_003DzVC9FBdo_003D;
		byte[] array2 = _0023_003DzoUhoyjkR_C_L4Ft0_LElyQwwFnWV();
		array2[1] = array[1];
		array2[3] = array[0];
		array2[2] = array[2];
		array2[0] = array[3];
		return _0023_003DzryV1NmuwtDHvuj_N8lR_0024Lhr9zhAW9hX9CQ_003D_003D(array2).ReadSingle();
	}

	public double _0023_003DzRvujv4mziPW1_0024weS_J317p5_0024BxFj()
	{
		_0023_003Dz7AoEY7kf_0024ncXpdkqo8TZSuszHP77gzBpBQ_003D_003D(8);
		byte[] array = _0023_003DzVC9FBdo_003D;
		byte[] array2 = _0023_003DzoUhoyjkR_C_L4Ft0_LElyQwwFnWV();
		array2[5] = array[1];
		array2[2] = array[4];
		array2[0] = array[2];
		array2[3] = array[3];
		array2[7] = array[0];
		array2[4] = array[6];
		array2[1] = array[5];
		array2[6] = array[7];
		return _0023_003DzryV1NmuwtDHvuj_N8lR_0024Lhr9zhAW9hX9CQ_003D_003D(array2).ReadDouble();
	}

	public decimal _0023_003Dzh_JwaQo_00244yODaVjMWLWIJd5bIUS9voN8IWt86XZlcq1X()
	{
		_0023_003Dz7AoEY7kf_0024ncXpdkqo8TZSuszHP77gzBpBQ_003D_003D(16);
		byte[] array = _0023_003DzVC9FBdo_003D;
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
		return _0023_003DzneLY_xJ2J_0024bkn5lLDJO501dvGWh3VCFtBQ_003D_003D(array2);
	}

	private BinaryReader _0023_003DzryV1NmuwtDHvuj_N8lR_0024Lhr9zhAW9hX9CQ_003D_003D(byte[] _0023_003DzjYYAPCA_003D)
	{
		MemoryStream memoryStream = _0023_003Dzt2pW2yo_003D;
		BinaryReader binaryReader = _0023_003DzJ6W8874_003D;
		if (memoryStream == null)
		{
			memoryStream = (_0023_003Dzt2pW2yo_003D = new MemoryStream(8));
			binaryReader = (_0023_003DzJ6W8874_003D = new BinaryReader(memoryStream));
		}
		else
		{
			binaryReader.BaseStream.Position = 0L;
		}
		memoryStream.Write(_0023_003DzjYYAPCA_003D, 0, _0023_003DzjYYAPCA_003D.Length);
		memoryStream.Position = 0L;
		return binaryReader;
	}
}
