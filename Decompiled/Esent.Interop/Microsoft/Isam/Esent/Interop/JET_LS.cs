using System;
using System.Globalization;

namespace Microsoft.Isam.Esent.Interop;

public struct JET_LS : IEquatable<JET_LS>, IFormattable
{
	public static readonly JET_LS Nil = new JET_LS
	{
		Value = new IntPtr(-1)
	};

	public bool IsInvalid
	{
		get
		{
			if (!(Value == IntPtr.Zero))
			{
				return Value == new IntPtr(-1);
			}
			return true;
		}
	}

	public IntPtr Value { get; set; }

	public static bool operator ==(JET_LS lhs, JET_LS rhs)
	{
		return lhs.Value == rhs.Value;
	}

	public static bool operator !=(JET_LS lhs, JET_LS rhs)
	{
		return !(lhs == rhs);
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "JET_LS(0x{0:x})", Value.ToInt64());
	}

	public string ToString(string format, IFormatProvider formatProvider)
	{
		if (!string.IsNullOrEmpty(format) && !("G" == format))
		{
			return Value.ToInt64().ToString(format, formatProvider);
		}
		return ToString();
	}

	public override bool Equals(object obj)
	{
		if (obj == null || GetType() != obj.GetType())
		{
			return false;
		}
		return Equals((JET_LS)obj);
	}

	public override int GetHashCode()
	{
		return Value.GetHashCode();
	}

	public bool Equals(JET_LS other)
	{
		return Value.Equals((object?)(nint)other.Value);
	}
}
