using System.Diagnostics;

internal struct _0023_003Dz20w_vyIjyyO72B2PaBS0hPw_003D
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private long _0023_003DzpQ9Yq40_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ulong _0023_003DzeOkTzI8_003D;

	public _0023_003Dz20w_vyIjyyO72B2PaBS0hPw_003D(long _0023_003Dz7jHY5oo_003D)
	{
		_0023_003DzeOkTzI8_003D = (ulong)_0023_003Dz7jHY5oo_003D;
		if (_0023_003Dz7jHY5oo_003D < 0)
		{
			_0023_003DzpQ9Yq40_003D = -1L;
		}
		else
		{
			_0023_003DzpQ9Yq40_003D = 0L;
		}
	}

	public _0023_003Dz20w_vyIjyyO72B2PaBS0hPw_003D(long _0023_003DzB1csc6w_003D, ulong _0023_003Dz7jHY5oo_003D)
	{
		_0023_003DzeOkTzI8_003D = _0023_003Dz7jHY5oo_003D;
		_0023_003DzpQ9Yq40_003D = _0023_003DzB1csc6w_003D;
	}

	public _0023_003Dz20w_vyIjyyO72B2PaBS0hPw_003D(_0023_003Dz20w_vyIjyyO72B2PaBS0hPw_003D _0023_003DzXULhp_00248_003D)
	{
		_0023_003DzpQ9Yq40_003D = _0023_003DzXULhp_00248_003D._0023_003DzpQ9Yq40_003D;
		_0023_003DzeOkTzI8_003D = _0023_003DzXULhp_00248_003D._0023_003DzeOkTzI8_003D;
	}

	public bool _0023_003Dzmaumz20_003D()
	{
		return _0023_003DzpQ9Yq40_003D < 0;
	}

	public static bool operator ==(_0023_003Dz20w_vyIjyyO72B2PaBS0hPw_003D _0023_003Dz84KsKCc_003D, _0023_003Dz20w_vyIjyyO72B2PaBS0hPw_003D _0023_003DzQEXDSA0_003D)
	{
		if ((object)_0023_003Dz84KsKCc_003D == (object)_0023_003DzQEXDSA0_003D)
		{
			return true;
		}
		if ((object)_0023_003Dz84KsKCc_003D == null || (object)_0023_003DzQEXDSA0_003D == null)
		{
			return false;
		}
		if (_0023_003Dz84KsKCc_003D._0023_003DzpQ9Yq40_003D == _0023_003DzQEXDSA0_003D._0023_003DzpQ9Yq40_003D)
		{
			return _0023_003Dz84KsKCc_003D._0023_003DzeOkTzI8_003D == _0023_003DzQEXDSA0_003D._0023_003DzeOkTzI8_003D;
		}
		return false;
	}

	public static bool operator !=(_0023_003Dz20w_vyIjyyO72B2PaBS0hPw_003D _0023_003Dz84KsKCc_003D, _0023_003Dz20w_vyIjyyO72B2PaBS0hPw_003D _0023_003DzQEXDSA0_003D)
	{
		return !(_0023_003Dz84KsKCc_003D == _0023_003DzQEXDSA0_003D);
	}

	public override bool Equals(object _0023_003DzCX9Hbao_003D)
	{
		if (_0023_003DzCX9Hbao_003D == null || !(_0023_003DzCX9Hbao_003D is _0023_003Dz20w_vyIjyyO72B2PaBS0hPw_003D _0023_003Dz20w_vyIjyyO72B2PaBS0hPw_003D2))
		{
			return false;
		}
		if (_0023_003Dz20w_vyIjyyO72B2PaBS0hPw_003D2._0023_003DzpQ9Yq40_003D == _0023_003DzpQ9Yq40_003D)
		{
			return _0023_003Dz20w_vyIjyyO72B2PaBS0hPw_003D2._0023_003DzeOkTzI8_003D == _0023_003DzeOkTzI8_003D;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return _0023_003DzpQ9Yq40_003D.GetHashCode() ^ _0023_003DzeOkTzI8_003D.GetHashCode();
	}

	public static bool operator >(_0023_003Dz20w_vyIjyyO72B2PaBS0hPw_003D _0023_003Dz84KsKCc_003D, _0023_003Dz20w_vyIjyyO72B2PaBS0hPw_003D _0023_003DzQEXDSA0_003D)
	{
		if (_0023_003Dz84KsKCc_003D._0023_003DzpQ9Yq40_003D != _0023_003DzQEXDSA0_003D._0023_003DzpQ9Yq40_003D)
		{
			return _0023_003Dz84KsKCc_003D._0023_003DzpQ9Yq40_003D > _0023_003DzQEXDSA0_003D._0023_003DzpQ9Yq40_003D;
		}
		return _0023_003Dz84KsKCc_003D._0023_003DzeOkTzI8_003D > _0023_003DzQEXDSA0_003D._0023_003DzeOkTzI8_003D;
	}

	public static bool operator <(_0023_003Dz20w_vyIjyyO72B2PaBS0hPw_003D _0023_003Dz84KsKCc_003D, _0023_003Dz20w_vyIjyyO72B2PaBS0hPw_003D _0023_003DzQEXDSA0_003D)
	{
		if (_0023_003Dz84KsKCc_003D._0023_003DzpQ9Yq40_003D != _0023_003DzQEXDSA0_003D._0023_003DzpQ9Yq40_003D)
		{
			return _0023_003Dz84KsKCc_003D._0023_003DzpQ9Yq40_003D < _0023_003DzQEXDSA0_003D._0023_003DzpQ9Yq40_003D;
		}
		return _0023_003Dz84KsKCc_003D._0023_003DzeOkTzI8_003D < _0023_003DzQEXDSA0_003D._0023_003DzeOkTzI8_003D;
	}

	public static _0023_003Dz20w_vyIjyyO72B2PaBS0hPw_003D operator +(_0023_003Dz20w_vyIjyyO72B2PaBS0hPw_003D _0023_003DzxwqqPaI_003D, _0023_003Dz20w_vyIjyyO72B2PaBS0hPw_003D _0023_003DzXoZOBv0_003D)
	{
		_0023_003DzxwqqPaI_003D._0023_003DzpQ9Yq40_003D += _0023_003DzXoZOBv0_003D._0023_003DzpQ9Yq40_003D;
		_0023_003DzxwqqPaI_003D._0023_003DzeOkTzI8_003D += _0023_003DzXoZOBv0_003D._0023_003DzeOkTzI8_003D;
		if (_0023_003DzxwqqPaI_003D._0023_003DzeOkTzI8_003D < _0023_003DzXoZOBv0_003D._0023_003DzeOkTzI8_003D)
		{
			_0023_003DzxwqqPaI_003D._0023_003DzpQ9Yq40_003D++;
		}
		return _0023_003DzxwqqPaI_003D;
	}

	public static _0023_003Dz20w_vyIjyyO72B2PaBS0hPw_003D operator -(_0023_003Dz20w_vyIjyyO72B2PaBS0hPw_003D _0023_003DzxwqqPaI_003D, _0023_003Dz20w_vyIjyyO72B2PaBS0hPw_003D _0023_003DzXoZOBv0_003D)
	{
		return _0023_003DzxwqqPaI_003D + -_0023_003DzXoZOBv0_003D;
	}

	public static _0023_003Dz20w_vyIjyyO72B2PaBS0hPw_003D operator -(_0023_003Dz20w_vyIjyyO72B2PaBS0hPw_003D _0023_003DzXULhp_00248_003D)
	{
		if (_0023_003DzXULhp_00248_003D._0023_003DzeOkTzI8_003D == 0L)
		{
			return new _0023_003Dz20w_vyIjyyO72B2PaBS0hPw_003D(-_0023_003DzXULhp_00248_003D._0023_003DzpQ9Yq40_003D, 0uL);
		}
		return new _0023_003Dz20w_vyIjyyO72B2PaBS0hPw_003D(~_0023_003DzXULhp_00248_003D._0023_003DzpQ9Yq40_003D, ~_0023_003DzXULhp_00248_003D._0023_003DzeOkTzI8_003D + 1);
	}

	public static explicit operator double(_0023_003Dz20w_vyIjyyO72B2PaBS0hPw_003D _0023_003DzXULhp_00248_003D)
	{
		if (_0023_003DzXULhp_00248_003D._0023_003DzpQ9Yq40_003D < 0)
		{
			if (_0023_003DzXULhp_00248_003D._0023_003DzeOkTzI8_003D == 0L)
			{
				return (double)_0023_003DzXULhp_00248_003D._0023_003DzpQ9Yq40_003D * 1.8446744073709552E+19;
			}
			return 0.0 - ((double)(~_0023_003DzXULhp_00248_003D._0023_003DzeOkTzI8_003D) + (double)(~_0023_003DzXULhp_00248_003D._0023_003DzpQ9Yq40_003D) * 1.8446744073709552E+19);
		}
		return (double)_0023_003DzXULhp_00248_003D._0023_003DzeOkTzI8_003D + (double)_0023_003DzXULhp_00248_003D._0023_003DzpQ9Yq40_003D * 1.8446744073709552E+19;
	}

	public static _0023_003Dz20w_vyIjyyO72B2PaBS0hPw_003D _0023_003DzSIdtGyi39GaT(long _0023_003DzxwqqPaI_003D, long _0023_003DzXoZOBv0_003D)
	{
		bool num = _0023_003DzxwqqPaI_003D < 0 != _0023_003DzXoZOBv0_003D < 0;
		if (_0023_003DzxwqqPaI_003D < 0)
		{
			_0023_003DzxwqqPaI_003D = -_0023_003DzxwqqPaI_003D;
		}
		if (_0023_003DzXoZOBv0_003D < 0)
		{
			_0023_003DzXoZOBv0_003D = -_0023_003DzXoZOBv0_003D;
		}
		long num2 = _0023_003DzxwqqPaI_003D >>> 32;
		ulong num3 = (ulong)(_0023_003DzxwqqPaI_003D & 0xFFFFFFFFu);
		ulong num4 = (ulong)_0023_003DzXoZOBv0_003D >> 32;
		ulong num5 = (ulong)(_0023_003DzXoZOBv0_003D & 0xFFFFFFFFu);
		ulong num6 = (ulong)num2 * num4;
		ulong num7 = num3 * num5;
		ulong num8 = (ulong)(num2 * (long)num5) + num3 * num4;
		long num9 = (long)(num6 + (num8 >> 32));
		ulong num10 = (num8 << 32) + num7;
		if (num10 < num7)
		{
			num9++;
		}
		_0023_003Dz20w_vyIjyyO72B2PaBS0hPw_003D _0023_003Dz20w_vyIjyyO72B2PaBS0hPw_003D2 = new _0023_003Dz20w_vyIjyyO72B2PaBS0hPw_003D(num9, num10);
		if (!num)
		{
			return _0023_003Dz20w_vyIjyyO72B2PaBS0hPw_003D2;
		}
		return -_0023_003Dz20w_vyIjyyO72B2PaBS0hPw_003D2;
	}
}
