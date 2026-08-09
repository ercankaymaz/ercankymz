using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace Opc.Ua;

[DataContract(Name = "StatusCode", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public struct StatusCode : IComparable, IFormattable, IComparable<StatusCode>, IEquatable<StatusCode>
{
	private uint m_code;

	private const uint s_AggregateBits = 31u;

	private const uint s_OverflowBit = 128u;

	private const uint s_LimitBits = 768u;

	private const uint s_DataValueInfoType = 1024u;

	private const uint s_SemanticsChangedBit = 16384u;

	private const uint s_StructureChangedBit = 32768u;

	[DataMember(Name = "Code", Order = 1, IsRequired = false)]
	public uint Code
	{
		get
		{
			return m_code;
		}
		set
		{
			m_code = value;
		}
	}

	public uint CodeBits => m_code & 0xFFFF0000u;

	public uint FlagBits => m_code & 0xFFFF;

	public uint SubCode
	{
		get
		{
			return m_code & 0xFFF0000;
		}
		set
		{
			m_code = 0xFFF0000 & value;
		}
	}

	[XmlIgnore]
	public bool StructureChanged
	{
		get
		{
			return (m_code & 0x8000) != 0;
		}
		set
		{
			if (value)
			{
				m_code |= 32768u;
			}
			else
			{
				m_code &= 4294934527u;
			}
		}
	}

	[XmlIgnore]
	public bool SemanticsChanged
	{
		get
		{
			return (m_code & 0x4000) != 0;
		}
		set
		{
			if (value)
			{
				m_code |= 16384u;
			}
			else
			{
				m_code &= 4294950911u;
			}
		}
	}

	[XmlIgnore]
	public bool HasDataValueInfo
	{
		get
		{
			return (m_code & 0x400) != 0;
		}
		set
		{
			if (value)
			{
				m_code |= 1024u;
				return;
			}
			m_code &= 4294966271u;
			m_code &= 4294966272u;
		}
	}

	[XmlIgnore]
	public LimitBits LimitBits
	{
		get
		{
			return (LimitBits)(m_code & 0x300);
		}
		set
		{
			m_code |= 1024u;
			m_code &= 4294966527u;
			m_code |= (uint)(value & LimitBits.Constant);
		}
	}

	[XmlIgnore]
	public bool Overflow
	{
		get
		{
			if ((m_code & 0x400) != 0)
			{
				return (m_code & 0x80) != 0;
			}
			return false;
		}
		set
		{
			m_code |= 1024u;
			if (value)
			{
				m_code |= 128u;
			}
			else
			{
				m_code &= 4294967167u;
			}
		}
	}

	[XmlIgnore]
	public AggregateBits AggregateBits
	{
		get
		{
			return (AggregateBits)(m_code & 0x1F);
		}
		set
		{
			m_code |= 1024u;
			m_code &= 4294967264u;
			m_code |= (uint)(value & (AggregateBits.DataSourceMask | AggregateBits.Partial | AggregateBits.ExtraData | AggregateBits.MultipleValues));
		}
	}

	public StatusCode(uint code)
	{
		m_code = code;
	}

	public StatusCode(Exception e, uint defaultCode)
	{
		if (e is ServiceResultException ex)
		{
			m_code = ex.StatusCode;
		}
		else
		{
			m_code = defaultCode;
		}
	}

	public StatusCode SetCodeBits(uint bits)
	{
		m_code &= 65535u;
		m_code |= bits & 0xFFFF0000u;
		return this;
	}

	public StatusCode SetFlagBits(uint bits)
	{
		m_code &= 4294901760u;
		m_code |= bits & 0xFFFF;
		return this;
	}

	public StatusCode SetStructureChanged(bool structureChanged)
	{
		StructureChanged = structureChanged;
		return this;
	}

	public StatusCode SetSemanticsChanged(bool semanticsChanged)
	{
		SemanticsChanged = semanticsChanged;
		return this;
	}

	public StatusCode SetLimitBits(LimitBits bits)
	{
		LimitBits = bits;
		return this;
	}

	public StatusCode SetOverflow(bool overflow)
	{
		Overflow = overflow;
		return this;
	}

	public StatusCode SetAggregateBits(AggregateBits bits)
	{
		AggregateBits = bits;
		return this;
	}

	public int CompareTo(object obj)
	{
		if (obj is StatusCode)
		{
			return m_code.CompareTo(((StatusCode)obj).m_code);
		}
		if (obj == null)
		{
			return 1;
		}
		if (obj is uint)
		{
			return m_code.CompareTo((uint)obj);
		}
		return -1;
	}

	public int CompareTo(StatusCode other)
	{
		return m_code.CompareTo(other.Code);
	}

	public string ToString(string format, IFormatProvider formatProvider)
	{
		if (format == null)
		{
			string browseName = StatusCodes.GetBrowseName(m_code & 0xFFFF0000u);
			if (!string.IsNullOrEmpty(browseName))
			{
				return string.Format(formatProvider, "{0}", browseName);
			}
			return string.Format(formatProvider, "0x{0:X8}", m_code);
		}
		throw new FormatException(Utils.Format("Invalid format string: '{0}'.", format));
	}

	public override bool Equals(object obj)
	{
		return CompareTo(obj) == 0;
	}

	public bool Equals(StatusCode other)
	{
		return CompareTo(other) == 0;
	}

	public override int GetHashCode()
	{
		return m_code.GetHashCode();
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(LookupSymbolicId(m_code));
		if ((0xFFFF & Code) != 0)
		{
			stringBuilder.AppendFormat(" [{0:X4}]", 0xFFFF & Code);
		}
		return stringBuilder.ToString();
	}

	public static implicit operator StatusCode(uint code)
	{
		return new StatusCode(code);
	}

	public static explicit operator uint(StatusCode code)
	{
		return code.Code;
	}

	public static string LookupSymbolicId(uint code)
	{
		return StatusCodes.GetBrowseName(code & 0xFFFF0000u);
	}

	public static bool operator ==(StatusCode a, StatusCode b)
	{
		return a.Equals(b);
	}

	public static bool operator !=(StatusCode a, StatusCode b)
	{
		return !(a == b);
	}

	public static bool operator ==(StatusCode a, uint b)
	{
		return a.Equals(b);
	}

	public static bool operator !=(StatusCode a, uint b)
	{
		return !(a == b);
	}

	public static bool operator <(StatusCode a, StatusCode b)
	{
		return a.CompareTo(b) < 0;
	}

	public static bool operator >(StatusCode a, StatusCode b)
	{
		return a.CompareTo(b) > 0;
	}

	public static bool IsGood(StatusCode code)
	{
		return (code.m_code & 0xC0000000u) == 0;
	}

	public static bool IsNotGood(StatusCode code)
	{
		return (code.m_code & 0xC0000000u) != 0;
	}

	public static bool IsUncertain(StatusCode code)
	{
		return (code.m_code & 0x40000000) == 1073741824;
	}

	public static bool IsNotUncertain(StatusCode code)
	{
		return (code.m_code & 0x40000000) != 1073741824;
	}

	public static bool IsBad(StatusCode code)
	{
		return (code.m_code & 0x80000000u) != 0;
	}

	public static bool IsNotBad(StatusCode code)
	{
		return (code.m_code & 0x80000000u) == 0;
	}
}
