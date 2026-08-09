using System;
using System.Diagnostics;
using System.Globalization;

namespace Microsoft.Isam.Esent.Interop;

public struct JET_OSSNAPID : IEquatable<JET_OSSNAPID>, IFormattable
{
	internal IntPtr Value;

	public static JET_OSSNAPID Nil
	{
		[DebuggerStepThrough]
		get
		{
			return default(JET_OSSNAPID);
		}
	}

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

	public static bool operator ==(JET_OSSNAPID lhs, JET_OSSNAPID rhs)
	{
		return lhs.Value == rhs.Value;
	}

	public static bool operator !=(JET_OSSNAPID lhs, JET_OSSNAPID rhs)
	{
		return !(lhs == rhs);
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "JET_OSSNAPID(0x{0:x})", Value.ToInt64());
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
		return Equals((JET_OSSNAPID)obj);
	}

	public override int GetHashCode()
	{
		return Value.GetHashCode();
	}

	public bool Equals(JET_OSSNAPID other)
	{
		return Value.Equals((object?)(nint)other.Value);
	}
}
