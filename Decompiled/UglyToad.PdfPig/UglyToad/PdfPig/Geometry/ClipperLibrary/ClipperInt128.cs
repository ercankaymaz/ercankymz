namespace UglyToad.PdfPig.Geometry.ClipperLibrary;

internal struct ClipperInt128
{
	private long hi;

	private ulong lo;

	public ClipperInt128(long _lo)
	{
		lo = (ulong)_lo;
		if (_lo < 0)
		{
			hi = -1L;
		}
		else
		{
			hi = 0L;
		}
	}

	public ClipperInt128(long _hi, ulong _lo)
	{
		lo = _lo;
		hi = _hi;
	}

	public ClipperInt128(ClipperInt128 val)
	{
		hi = val.hi;
		lo = val.lo;
	}

	public bool IsNegative()
	{
		return hi < 0;
	}

	public static bool operator ==(ClipperInt128 val1, ClipperInt128 val2)
	{
		if ((object)val1 == (object)val2)
		{
			return true;
		}
		if (val1.hi == val2.hi)
		{
			return val1.lo == val2.lo;
		}
		return false;
	}

	public static bool operator !=(ClipperInt128 val1, ClipperInt128 val2)
	{
		return !(val1 == val2);
	}

	public override bool Equals(object? obj)
	{
		if (!(obj is ClipperInt128 clipperInt))
		{
			return false;
		}
		if (clipperInt.hi == hi)
		{
			return clipperInt.lo == lo;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return hi.GetHashCode() ^ lo.GetHashCode();
	}

	public static bool operator >(ClipperInt128 val1, ClipperInt128 val2)
	{
		if (val1.hi != val2.hi)
		{
			return val1.hi > val2.hi;
		}
		return val1.lo > val2.lo;
	}

	public static bool operator <(ClipperInt128 val1, ClipperInt128 val2)
	{
		if (val1.hi != val2.hi)
		{
			return val1.hi < val2.hi;
		}
		return val1.lo < val2.lo;
	}

	public static ClipperInt128 operator +(ClipperInt128 lhs, ClipperInt128 rhs)
	{
		lhs.hi += rhs.hi;
		lhs.lo += rhs.lo;
		if (lhs.lo < rhs.lo)
		{
			lhs.hi++;
		}
		return lhs;
	}

	public static ClipperInt128 operator -(ClipperInt128 lhs, ClipperInt128 rhs)
	{
		return lhs + -rhs;
	}

	public static ClipperInt128 operator -(ClipperInt128 val)
	{
		if (val.lo == 0L)
		{
			return new ClipperInt128(-val.hi, 0uL);
		}
		return new ClipperInt128(~val.hi, ~val.lo + 1);
	}

	public static explicit operator double(ClipperInt128 val)
	{
		if (val.hi < 0)
		{
			if (val.lo == 0L)
			{
				return (double)val.hi * 1.8446744073709552E+19;
			}
			return 0.0 - ((double)(~val.lo) + (double)(~val.hi) * 1.8446744073709552E+19);
		}
		return (double)val.lo + (double)val.hi * 1.8446744073709552E+19;
	}

	public static ClipperInt128 Int128Mul(long lhs, long rhs)
	{
		bool num = lhs < 0 != rhs < 0;
		if (lhs < 0)
		{
			lhs = -lhs;
		}
		if (rhs < 0)
		{
			rhs = -rhs;
		}
		long num2 = lhs >>> 32;
		ulong num3 = (ulong)(lhs & 0xFFFFFFFFu);
		ulong num4 = (ulong)rhs >> 32;
		ulong num5 = (ulong)(rhs & 0xFFFFFFFFu);
		ulong num6 = (ulong)num2 * num4;
		ulong num7 = num3 * num5;
		ulong num8 = (ulong)(num2 * (long)num5) + num3 * num4;
		long num9 = (long)(num6 + (num8 >> 32));
		ulong num10 = (num8 << 32) + num7;
		if (num10 < num7)
		{
			num9++;
		}
		ClipperInt128 clipperInt = new ClipperInt128(num9, num10);
		if (!num)
		{
			return clipperInt;
		}
		return -clipperInt;
	}
}
