using System;
using System.Diagnostics;
using System.Globalization;

namespace Microsoft.Isam.Esent.Interop;

public struct JET_COLUMNID : IEquatable<JET_COLUMNID>, IComparable<JET_COLUMNID>, IFormattable
{
	internal uint Value;

	public static JET_COLUMNID Nil
	{
		[DebuggerStepThrough]
		get
		{
			return default(JET_COLUMNID);
		}
	}

	public bool IsInvalid
	{
		get
		{
			if (Value != 0)
			{
				return Value == uint.MaxValue;
			}
			return true;
		}
	}

	public static bool operator ==(JET_COLUMNID lhs, JET_COLUMNID rhs)
	{
		return lhs.Value == rhs.Value;
	}

	public static bool operator !=(JET_COLUMNID lhs, JET_COLUMNID rhs)
	{
		return !(lhs == rhs);
	}

	public static bool operator <(JET_COLUMNID lhs, JET_COLUMNID rhs)
	{
		return lhs.Value < rhs.Value;
	}

	public static bool operator >(JET_COLUMNID lhs, JET_COLUMNID rhs)
	{
		return lhs.Value > rhs.Value;
	}

	public static bool operator <=(JET_COLUMNID lhs, JET_COLUMNID rhs)
	{
		return lhs.Value <= rhs.Value;
	}

	public static bool operator >=(JET_COLUMNID lhs, JET_COLUMNID rhs)
	{
		return lhs.Value >= rhs.Value;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "JET_COLUMNID(0x{0:x})", Value);
	}

	public string ToString(string format, IFormatProvider formatProvider)
	{
		if (!string.IsNullOrEmpty(format) && !("G" == format))
		{
			return Value.ToString(format, formatProvider);
		}
		return ToString();
	}

	public override bool Equals(object obj)
	{
		if (obj == null || GetType() != obj.GetType())
		{
			return false;
		}
		return Equals((JET_COLUMNID)obj);
	}

	public override int GetHashCode()
	{
		return Value.GetHashCode();
	}

	public bool Equals(JET_COLUMNID other)
	{
		return Value.Equals(other.Value);
	}

	public int CompareTo(JET_COLUMNID other)
	{
		return Value.CompareTo(other.Value);
	}

	internal static JET_COLUMNID CreateColumnidFromNativeValue(int nativeValue)
	{
		return new JET_COLUMNID
		{
			Value = (uint)nativeValue
		};
	}
}
