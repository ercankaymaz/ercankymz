using System;
using System.Globalization;

namespace Microsoft.Isam.Esent.Interop;

public struct JET_DBID : IEquatable<JET_DBID>, IFormattable
{
	internal uint Value;

	public static JET_DBID Nil => new JET_DBID
	{
		Value = uint.MaxValue
	};

	public static bool operator ==(JET_DBID lhs, JET_DBID rhs)
	{
		return lhs.Value == rhs.Value;
	}

	public static bool operator !=(JET_DBID lhs, JET_DBID rhs)
	{
		return !(lhs == rhs);
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "JET_DBID({0})", Value);
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
		return Equals((JET_DBID)obj);
	}

	public override int GetHashCode()
	{
		return Value.GetHashCode();
	}

	public bool Equals(JET_DBID other)
	{
		return Value.Equals(other.Value);
	}
}
