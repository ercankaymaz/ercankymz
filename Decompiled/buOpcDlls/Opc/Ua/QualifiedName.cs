using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;

namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class QualifiedName : ICloneable, IFormattable, IComparable
{
	private static readonly QualifiedName s_Null = new QualifiedName();

	private ushort m_namespaceIndex;

	private string m_name;

	public ushort NamespaceIndex => m_namespaceIndex;

	[DataMember(Name = "NamespaceIndex", Order = 1)]
	internal ushort XmlEncodedNamespaceIndex
	{
		get
		{
			return m_namespaceIndex;
		}
		set
		{
			m_namespaceIndex = value;
		}
	}

	public string Name => m_name;

	[DataMember(Name = "Name", Order = 2)]
	internal string XmlEncodedName
	{
		get
		{
			return m_name;
		}
		set
		{
			m_name = value;
		}
	}

	public static QualifiedName Null => s_Null;

	internal QualifiedName()
	{
		m_namespaceIndex = 0;
		m_name = null;
	}

	public QualifiedName(QualifiedName value)
	{
		if (value == null)
		{
			throw new ArgumentNullException("value");
		}
		m_name = value.m_name;
		m_namespaceIndex = value.m_namespaceIndex;
	}

	public QualifiedName(string name)
	{
		m_namespaceIndex = 0;
		m_name = name;
	}

	public QualifiedName(string name, ushort namespaceIndex)
	{
		m_namespaceIndex = namespaceIndex;
		m_name = name;
	}

	public int CompareTo(object obj)
	{
		if (obj == null)
		{
			return -1;
		}
		if (this == obj)
		{
			return 0;
		}
		QualifiedName qualifiedName = obj as QualifiedName;
		if (qualifiedName == null)
		{
			return typeof(QualifiedName).GetTypeInfo().GUID.CompareTo(obj.GetType().GetTypeInfo().GUID);
		}
		if (qualifiedName.m_namespaceIndex != m_namespaceIndex)
		{
			return m_namespaceIndex.CompareTo(qualifiedName.m_namespaceIndex);
		}
		if (m_name != null)
		{
			return string.CompareOrdinal(m_name, qualifiedName.m_name);
		}
		return 0;
	}

	public static bool operator >(QualifiedName value1, QualifiedName value2)
	{
		if ((object)value1 != null)
		{
			return value1.CompareTo(value2) > 0;
		}
		return false;
	}

	public static bool operator <(QualifiedName value1, QualifiedName value2)
	{
		if ((object)value1 != null)
		{
			return value1.CompareTo(value2) < 0;
		}
		return true;
	}

	public override int GetHashCode()
	{
		HashCode hashCode = default(HashCode);
		if (m_name != null)
		{
			hashCode.Add(m_name);
		}
		hashCode.Add(m_namespaceIndex);
		return hashCode.ToHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (this == obj)
		{
			return true;
		}
		QualifiedName qualifiedName = obj as QualifiedName;
		if (qualifiedName == null)
		{
			return false;
		}
		if (qualifiedName.m_namespaceIndex != m_namespaceIndex)
		{
			return false;
		}
		return qualifiedName.m_name == m_name;
	}

	public static bool operator ==(QualifiedName value1, QualifiedName value2)
	{
		return value1?.Equals(value2) ?? ((object)value2 == null);
	}

	public static bool operator !=(QualifiedName value1, QualifiedName value2)
	{
		if ((object)value1 != null)
		{
			return !value1.Equals(value2);
		}
		return (object)value2 != null;
	}

	public override string ToString()
	{
		return ToString(null, null);
	}

	public string ToString(string format, IFormatProvider formatProvider)
	{
		if (format == null)
		{
			StringBuilder stringBuilder = new StringBuilder(((m_name != null) ? m_name.Length : 0) + 10);
			if (m_namespaceIndex == 0)
			{
				if (m_name != null && m_name.IndexOf(':') != -1)
				{
					stringBuilder.Append("0:");
				}
			}
			else
			{
				stringBuilder.Append(m_namespaceIndex);
				stringBuilder.Append(':');
			}
			if (m_name != null)
			{
				stringBuilder.Append(m_name);
			}
			return stringBuilder.ToString();
		}
		throw new FormatException(Utils.Format("Invalid format string: '{0}'.", format));
	}

	public virtual object Clone()
	{
		return MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		return this;
	}

	public static QualifiedName Create(string name, string namespaceUri, NamespaceTable namespaceTable)
	{
		if (string.IsNullOrEmpty(name))
		{
			return Null;
		}
		if (string.IsNullOrEmpty(namespaceUri))
		{
			return new QualifiedName(name);
		}
		int num = -1;
		if (namespaceTable != null)
		{
			num = namespaceTable.GetIndex(namespaceUri);
		}
		if (num < 0)
		{
			throw ServiceResultException.Create(2153775104u, "NamespaceUri ({0}) is not in the NamespaceTable.", namespaceUri);
		}
		return new QualifiedName(name, (ushort)num);
	}

	public static bool IsValid(QualifiedName value, NamespaceTable namespaceUris)
	{
		if (value == null || string.IsNullOrEmpty(value.m_name))
		{
			return false;
		}
		if (namespaceUris != null && namespaceUris.GetString(value.m_namespaceIndex) == null)
		{
			return false;
		}
		return true;
	}

	public static QualifiedName Parse(string text)
	{
		if (string.IsNullOrEmpty(text))
		{
			return Null;
		}
		ushort num = 0;
		int num2 = -1;
		for (int i = 0; i < text.Length; i++)
		{
			char c = text[i];
			if (c == ':')
			{
				num2 = i + 1;
				break;
			}
			if (char.IsDigit(c))
			{
				num *= 10;
				num += (ushort)(c - 48);
			}
		}
		if (num2 == -1)
		{
			return new QualifiedName(text);
		}
		return new QualifiedName(text.Substring(num2), num);
	}

	public static bool IsNull(QualifiedName value)
	{
		if (value != null && (value.m_namespaceIndex != 0 || !string.IsNullOrEmpty(value.m_name)))
		{
			return false;
		}
		return true;
	}

	public static QualifiedName ToQualifiedName(string value)
	{
		return new QualifiedName(value);
	}

	public static implicit operator QualifiedName(string value)
	{
		return new QualifiedName(value);
	}
}
