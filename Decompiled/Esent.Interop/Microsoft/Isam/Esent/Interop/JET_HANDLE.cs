using System;
using System.Diagnostics;
using System.Globalization;

namespace Microsoft.Isam.Esent.Interop;

public struct JET_HANDLE : IEquatable<JET_HANDLE>, IFormattable
{
	internal IntPtr Value;

	public static JET_HANDLE Nil
	{
		[DebuggerStepThrough]
		get
		{
			return default(JET_HANDLE);
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

	public static bool operator ==(JET_HANDLE lhs, JET_HANDLE rhs)
	{
		return lhs.Value == rhs.Value;
	}

	public static bool operator !=(JET_HANDLE lhs, JET_HANDLE rhs)
	{
		return !(lhs == rhs);
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "JET_HANDLE(0x{0:x})", Value.ToInt64());
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
		return Equals((JET_HANDLE)obj);
	}

	public override int GetHashCode()
	{
		return Value.GetHashCode();
	}

	public bool Equals(JET_HANDLE other)
	{
		return Value.Equals((object?)(nint)other.Value);
	}
}
