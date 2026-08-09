using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[DataContract(Name = "Guid", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public struct Uuid : IComparable, IFormattable, IEquatable<Uuid>
{
	public static readonly Uuid Empty;

	private Guid m_guid;

	[DataMember(Name = "String", Order = 1)]
	public string GuidString
	{
		get
		{
			return m_guid.ToString();
		}
		set
		{
			if (string.IsNullOrEmpty(value))
			{
				m_guid = Guid.Empty;
			}
			else
			{
				m_guid = new Guid(value);
			}
		}
	}

	public Uuid(string text)
	{
		m_guid = new Guid(text);
	}

	public Uuid(Guid guid)
	{
		m_guid = guid;
	}

	public static implicit operator Guid(Uuid guid)
	{
		return guid.m_guid;
	}

	public static explicit operator Uuid(Guid guid)
	{
		return new Uuid(guid);
	}

	public static bool operator ==(Uuid a, Uuid b)
	{
		return a.Equals(b);
	}

	public static bool operator !=(Uuid a, Uuid b)
	{
		return !a.Equals(b);
	}

	public static bool operator ==(Uuid a, Guid b)
	{
		return a.Equals(b);
	}

	public static bool operator !=(Uuid a, Guid b)
	{
		return !a.Equals(b);
	}

	public static bool operator <(Uuid a, Uuid b)
	{
		return a.CompareTo(b) < 0;
	}

	public static bool operator >(Uuid a, Uuid b)
	{
		return a.CompareTo(b) > 0;
	}

	public override bool Equals(object obj)
	{
		return CompareTo(obj) == 0;
	}

	public bool Equals(Uuid other)
	{
		return CompareTo(other) == 0;
	}

	public override int GetHashCode()
	{
		return m_guid.GetHashCode();
	}

	public override string ToString()
	{
		return m_guid.ToString();
	}

	public int CompareTo(object obj)
	{
		if (obj is Uuid uuid)
		{
			return uuid.m_guid.CompareTo(m_guid);
		}
		if (obj is Guid)
		{
			return m_guid.CompareTo((Guid)obj);
		}
		return 1;
	}

	public string ToString(string format, IFormatProvider formatProvider)
	{
		return m_guid.ToString(format);
	}

	static Uuid()
	{
	}
}
