using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;

namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class NodeId : IComparable, IFormattable, IEquatable<NodeId>, ICloneable
{
	private static readonly NodeId s_Null = new NodeId();

	private ushort m_namespaceIndex;

	private IdType m_identifierType;

	private object m_identifier;

	public static NodeId Null => s_Null;

	[DataMember(Name = "Identifier", Order = 1)]
	internal string IdentifierText
	{
		get
		{
			return Format();
		}
		set
		{
			NodeId nodeId = Parse(value);
			m_namespaceIndex = nodeId.NamespaceIndex;
			m_identifierType = nodeId.IdType;
			m_identifier = nodeId.Identifier;
		}
	}

	public ushort NamespaceIndex => m_namespaceIndex;

	public IdType IdType => m_identifierType;

	public object Identifier
	{
		get
		{
			if (m_identifier == null)
			{
				switch (m_identifierType)
				{
				case IdType.Numeric:
					return 0u;
				case IdType.Guid:
					return Guid.Empty;
				}
			}
			return m_identifier;
		}
	}

	public bool IsNullNodeId
	{
		get
		{
			if (m_namespaceIndex != 0)
			{
				return false;
			}
			if (m_identifier != null)
			{
				switch (m_identifierType)
				{
				case IdType.Numeric:
					if (!m_identifier.Equals(0u))
					{
						return false;
					}
					break;
				case IdType.String:
					if (!string.IsNullOrEmpty((string)m_identifier))
					{
						return false;
					}
					break;
				case IdType.Guid:
					if (!m_identifier.Equals(Guid.Empty))
					{
						return false;
					}
					break;
				case IdType.Opaque:
					if (m_identifier != null && ((byte[])m_identifier).Length != 0)
					{
						return false;
					}
					break;
				}
			}
			return true;
		}
	}

	public NodeId()
	{
		Initialize();
	}

	public NodeId(NodeId value)
	{
		if (value == null)
		{
			throw new ArgumentNullException("value");
		}
		m_namespaceIndex = value.m_namespaceIndex;
		m_identifierType = value.m_identifierType;
		m_identifier = Utils.Clone(value.m_identifier);
	}

	public NodeId(uint value)
	{
		m_namespaceIndex = 0;
		m_identifierType = IdType.Numeric;
		m_identifier = value;
	}

	public NodeId(uint value, ushort namespaceIndex)
	{
		m_namespaceIndex = namespaceIndex;
		m_identifierType = IdType.Numeric;
		m_identifier = value;
	}

	public NodeId(string value, ushort namespaceIndex)
	{
		m_namespaceIndex = namespaceIndex;
		m_identifierType = IdType.String;
		m_identifier = value;
	}

	public NodeId(Guid value)
	{
		m_namespaceIndex = 0;
		m_identifierType = IdType.Guid;
		m_identifier = value;
	}

	public NodeId(Guid value, ushort namespaceIndex)
	{
		m_namespaceIndex = namespaceIndex;
		m_identifierType = IdType.Guid;
		m_identifier = value;
	}

	public NodeId(byte[] value)
	{
		m_namespaceIndex = 0;
		m_identifierType = IdType.Opaque;
		m_identifier = null;
		if (value != null)
		{
			byte[] array = new byte[value.Length];
			Array.Copy(value, array, value.Length);
			m_identifier = array;
		}
	}

	public NodeId(byte[] value, ushort namespaceIndex)
	{
		m_namespaceIndex = namespaceIndex;
		m_identifierType = IdType.Opaque;
		m_identifier = null;
		if (value != null)
		{
			byte[] array = new byte[value.Length];
			Array.Copy(value, array, value.Length);
			m_identifier = array;
		}
	}

	public NodeId(string text)
	{
		NodeId nodeId = Parse(text);
		m_namespaceIndex = nodeId.NamespaceIndex;
		m_identifierType = nodeId.IdType;
		m_identifier = nodeId.Identifier;
	}

	public NodeId(object value, ushort namespaceIndex)
	{
		m_namespaceIndex = namespaceIndex;
		if (value is uint)
		{
			SetIdentifier(IdType.Numeric, value);
			return;
		}
		if (value == null || value is string)
		{
			SetIdentifier(IdType.String, value);
			return;
		}
		if (value is Guid)
		{
			SetIdentifier(IdType.Guid, value);
			return;
		}
		if (value is Uuid)
		{
			SetIdentifier(IdType.Guid, value);
			return;
		}
		if (value is byte[])
		{
			SetIdentifier(IdType.Opaque, value);
			return;
		}
		throw new ArgumentException("Identifier type not supported.", "value");
	}

	[OnDeserializing]
	private void Initialize(StreamingContext context)
	{
		Initialize();
	}

	private void Initialize()
	{
		m_namespaceIndex = 0;
		m_identifierType = IdType.Numeric;
		m_identifier = null;
	}

	public static NodeId Create(object identifier, string namespaceUri, NamespaceTable namespaceTable)
	{
		int num = -1;
		if (namespaceTable != null)
		{
			num = namespaceTable.GetIndex(namespaceUri);
		}
		if (num < 0)
		{
			throw ServiceResultException.Create(2150825984u, "NamespaceUri ({0}) is not in the namespace table.", namespaceUri);
		}
		return new NodeId(identifier, (ushort)num);
	}

	public static implicit operator NodeId(uint value)
	{
		return new NodeId(value);
	}

	public static implicit operator NodeId(Guid value)
	{
		return new NodeId(value);
	}

	public static implicit operator NodeId(byte[] value)
	{
		return new NodeId(value);
	}

	public static implicit operator NodeId(string text)
	{
		return Parse(text);
	}

	public static bool IsNull(NodeId nodeId)
	{
		if (nodeId == null)
		{
			return true;
		}
		return nodeId.IsNullNodeId;
	}

	public static bool IsNull(ExpandedNodeId nodeId)
	{
		if (nodeId == null)
		{
			return true;
		}
		return nodeId.IsNull;
	}

	public static NodeId Parse(string text)
	{
		return InternalParse(text, namespaceSet: false);
	}

	internal static NodeId InternalParse(string text, bool namespaceSet)
	{
		ArgumentException ex = null;
		try
		{
			if (string.IsNullOrEmpty(text))
			{
				return Null;
			}
			ushort namespaceIndex = 0;
			if (text.StartsWith("ns=", StringComparison.Ordinal))
			{
				int num = text.IndexOf(';');
				if (num == -1)
				{
					throw new ServiceResultException(2150825984u, "Invalid namespace index.");
				}
				namespaceIndex = Convert.ToUInt16(text.Substring(3, num - 3), CultureInfo.InvariantCulture);
				namespaceSet = true;
				text = text.Substring(num + 1);
			}
			if (text.StartsWith("i=", StringComparison.Ordinal))
			{
				return new NodeId(Convert.ToUInt32(text.Substring(2), CultureInfo.InvariantCulture), namespaceIndex);
			}
			if (text.StartsWith("s=", StringComparison.Ordinal))
			{
				return new NodeId(text.Substring(2), namespaceIndex);
			}
			if (text.StartsWith("g=", StringComparison.Ordinal))
			{
				return new NodeId(new Guid(text.Substring(2)), namespaceIndex);
			}
			if (text.StartsWith("b=", StringComparison.Ordinal))
			{
				return new NodeId(Convert.FromBase64String(text.Substring(2)), namespaceIndex);
			}
			if (text.StartsWith("nsu=", StringComparison.Ordinal))
			{
				ex = new ArgumentException("Invalid namespace Uri ('nsu=') for a NodeId.");
			}
			else
			{
				if (namespaceSet)
				{
					return new NodeId(text, namespaceIndex);
				}
				ex = new ArgumentException("Invalid string NodeId without namespace index ('ns=').");
			}
		}
		catch (Exception e)
		{
			throw new ServiceResultException(2150825984u, Utils.Format("Cannot parse node id text: '{0}'", text), e);
		}
		throw ex;
	}

	public string Format()
	{
		StringBuilder stringBuilder = new StringBuilder();
		Format(stringBuilder);
		return stringBuilder.ToString();
	}

	public void Format(StringBuilder buffer)
	{
		Format(buffer, m_identifier, m_identifierType, m_namespaceIndex);
	}

	public static void Format(StringBuilder buffer, object identifier, IdType identifierType, ushort namespaceIndex)
	{
		if (namespaceIndex != 0)
		{
			buffer.AppendFormat(CultureInfo.InvariantCulture, "ns={0};", namespaceIndex);
		}
		switch (identifierType)
		{
		case IdType.Numeric:
			buffer.Append("i=");
			break;
		case IdType.String:
			buffer.Append("s=");
			break;
		case IdType.Guid:
			buffer.Append("g=");
			break;
		case IdType.Opaque:
			buffer.Append("b=");
			break;
		}
		FormatIdentifier(buffer, identifier, identifierType);
	}

	public override string ToString()
	{
		return ToString(null, null);
	}

	public static ExpandedNodeId ToExpandedNodeId(NodeId nodeId, NamespaceTable namespaceTable)
	{
		if (nodeId == null)
		{
			return null;
		}
		ExpandedNodeId expandedNodeId = new ExpandedNodeId(nodeId);
		if (nodeId.NamespaceIndex > 0)
		{
			string text = namespaceTable.GetString(nodeId.NamespaceIndex);
			if (text != null)
			{
				expandedNodeId.SetNamespaceUri(text);
			}
		}
		return expandedNodeId;
	}

	internal void SetNamespaceIndex(ushort value)
	{
		m_namespaceIndex = value;
	}

	internal void SetIdentifier(IdType idType, object value)
	{
		m_identifierType = idType;
		if (idType == IdType.Opaque)
		{
			m_identifier = Utils.Clone(value);
		}
		else
		{
			m_identifier = value;
		}
	}

	internal void SetIdentifier(string value, IdType idType)
	{
		m_identifierType = idType;
		SetIdentifier(IdType.String, value);
	}

	public int CompareTo(object obj)
	{
		if (obj == null)
		{
			return -1;
		}
		if ((object)this == obj)
		{
			return 0;
		}
		ushort namespaceIndex = m_namespaceIndex;
		IdType idType = m_identifierType;
		object obj2 = null;
		if (obj is NodeId nodeId)
		{
			if (IsNullNodeId && nodeId.IsNullNodeId)
			{
				return 0;
			}
			namespaceIndex = nodeId.NamespaceIndex;
			idType = nodeId.IdType;
			obj2 = nodeId.Identifier;
		}
		else
		{
			uint? num = obj as uint?;
			int? num2 = obj as int?;
			if (num.HasValue || num2.HasValue)
			{
				if (namespaceIndex != 0 || idType != IdType.Numeric)
				{
					return -1;
				}
				uint value;
				if (num2.HasValue && !num.HasValue)
				{
					if (num2.Value < 0)
					{
						return 1;
					}
					value = (uint)num2.Value;
				}
				else
				{
					value = num.Value;
				}
				uint valueOrDefault = (m_identifier as uint?).GetValueOrDefault();
				if (valueOrDefault == value)
				{
					return 0;
				}
				if (valueOrDefault >= value)
				{
					return 1;
				}
				return -1;
			}
			if (obj is ExpandedNodeId expandedNodeId)
			{
				if (expandedNodeId.IsAbsolute)
				{
					return -1;
				}
				if (IsNullNodeId && expandedNodeId.InnerNodeId != null && expandedNodeId.InnerNodeId.IsNullNodeId)
				{
					return 0;
				}
				namespaceIndex = expandedNodeId.NamespaceIndex;
				idType = expandedNodeId.IdType;
				obj2 = expandedNodeId.Identifier;
			}
			else if (obj != null)
			{
				Guid? guid = obj as Guid?;
				Uuid? uuid = obj as Uuid?;
				if (!guid.HasValue && !uuid.HasValue)
				{
					return -1;
				}
				if (namespaceIndex != 0 || idType != IdType.Guid)
				{
					return -1;
				}
				idType = IdType.Guid;
				obj2 = m_identifier;
			}
		}
		if (namespaceIndex != m_namespaceIndex)
		{
			if (m_namespaceIndex >= namespaceIndex)
			{
				return 1;
			}
			return -1;
		}
		if (idType != m_identifierType)
		{
			if (m_identifierType >= idType)
			{
				return 1;
			}
			return -1;
		}
		if (m_identifier == null && obj2 == null)
		{
			return 0;
		}
		if (m_identifier == null && obj2 != null)
		{
			switch (idType)
			{
			case IdType.String:
				if ((obj2 as string).Length == 0)
				{
					return 0;
				}
				break;
			case IdType.Opaque:
				if ((obj2 as byte[]).Length == 0)
				{
					return 0;
				}
				break;
			case IdType.Numeric:
				if ((obj2 as uint?).Value == 0)
				{
					return 0;
				}
				break;
			}
			return -1;
		}
		if (m_identifier != null && obj2 == null)
		{
			switch (idType)
			{
			case IdType.String:
				if ((m_identifier as string).Length == 0)
				{
					return 0;
				}
				break;
			case IdType.Opaque:
				if ((m_identifier as byte[]).Length == 0)
				{
					return 0;
				}
				break;
			case IdType.Numeric:
				if ((m_identifier as uint?).Value == 0)
				{
					return 0;
				}
				break;
			}
			return 1;
		}
		return CompareTo(idType, obj2);
	}

	public static bool operator >(NodeId value1, NodeId value2)
	{
		if ((object)value1 != null)
		{
			return value1.CompareTo(value2) > 0;
		}
		return false;
	}

	public static bool operator <(NodeId value1, NodeId value2)
	{
		if ((object)value1 != null)
		{
			return value1.CompareTo(value2) < 0;
		}
		return true;
	}

	public string ToString(string format, IFormatProvider formatProvider)
	{
		if (format == null)
		{
			return string.Format(formatProvider, "{0}", Format());
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

	public override bool Equals(object obj)
	{
		return CompareTo(obj) == 0;
	}

	public bool Equals(NodeId other)
	{
		if ((object)this == other)
		{
			return true;
		}
		if (IsNullNodeId && (other == null || other.IsNullNodeId))
		{
			return true;
		}
		if (other.NamespaceIndex != m_namespaceIndex)
		{
			return false;
		}
		if (other.IdType != m_identifierType)
		{
			return false;
		}
		return CompareTo(other.IdType, other.Identifier) == 0;
	}

	public override int GetHashCode()
	{
		if (m_identifier == null)
		{
			return 0;
		}
		if (IsNullNodeId)
		{
			return 0;
		}
		HashCode hashCode = default(HashCode);
		hashCode.Add(m_namespaceIndex);
		hashCode.Add(m_identifierType);
		switch (m_identifierType)
		{
		case IdType.Numeric:
			hashCode.Add((uint)m_identifier);
			break;
		case IdType.String:
			hashCode.Add((string)m_identifier);
			break;
		case IdType.Guid:
			hashCode.Add((Guid)m_identifier);
			break;
		case IdType.Opaque:
		{
			byte[] array = (byte[])m_identifier;
			foreach (byte value in array)
			{
				hashCode.Add(value);
			}
			break;
		}
		default:
			hashCode.Add(m_identifier);
			break;
		}
		return hashCode.ToHashCode();
	}

	public static bool operator ==(NodeId value1, object value2)
	{
		if ((object)value1 == null)
		{
			return value2 == null;
		}
		return value1.CompareTo(value2) == 0;
	}

	public static bool operator !=(NodeId value1, object value2)
	{
		if ((object)value1 == null)
		{
			return value2 != null;
		}
		return value1.CompareTo(value2) != 0;
	}

	private static int CompareIdentifiers(IdType idType1, object id1, IdType idType2, object id2)
	{
		if (id1 == null && id2 == null)
		{
			return 0;
		}
		if (idType1 != idType2)
		{
			return idType1.CompareTo(idType2);
		}
		if (id1 == null || id2 == null)
		{
			object obj = id1;
			if (id1 == null)
			{
				obj = id2;
			}
			switch (idType1)
			{
			case IdType.Numeric:
				if (obj is uint && (uint)obj == 0)
				{
					return 0;
				}
				break;
			case IdType.Guid:
				if (obj is Guid && (Guid)obj == Guid.Empty)
				{
					return 0;
				}
				break;
			case IdType.String:
				if (obj is string { Length: 0 })
				{
					return 0;
				}
				break;
			case IdType.Opaque:
				if (obj is byte[] array && array.Length == 0)
				{
					return 0;
				}
				break;
			}
			if (id1 != null)
			{
				return 1;
			}
			return -1;
		}
		if (id1 is byte[] array2)
		{
			if (!(id2 is byte[] array3))
			{
				return 1;
			}
			if (array2.Length != array3.Length)
			{
				return array2.Length.CompareTo(array3.Length);
			}
			for (int i = 0; i < array2.Length; i++)
			{
				int num = array2[i].CompareTo(array3[i]);
				if (num != 0)
				{
					return num;
				}
			}
			return 0;
		}
		if (id1 is IComparable comparable)
		{
			return comparable.CompareTo(id2);
		}
		return string.CompareOrdinal(id1.ToString(), id2.ToString());
	}

	private int CompareTo(IdType idType, object id)
	{
		switch (idType)
		{
		case IdType.Numeric:
		{
			uint num = (uint)m_identifier;
			uint num2 = (uint)id;
			if (num == num2)
			{
				return 0;
			}
			if (num >= num2)
			{
				return 1;
			}
			return -1;
		}
		case IdType.String:
		{
			string strA = (string)m_identifier;
			string strB = (string)id;
			return string.CompareOrdinal(strA, strB);
		}
		case IdType.Guid:
		{
			Guid guid = (Guid)m_identifier;
			if (id is Uuid)
			{
				return guid.CompareTo((Uuid)id);
			}
			return guid.CompareTo((Guid)id);
		}
		case IdType.Opaque:
		{
			byte[] array = (byte[])m_identifier;
			byte[] array2 = (byte[])id;
			if (array.Length == array2.Length)
			{
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i] != array2[i])
					{
						if (array[i] >= array2[i])
						{
							return 1;
						}
						return -1;
					}
				}
				return 0;
			}
			if (array.Length >= array2.Length)
			{
				return 1;
			}
			return -1;
		}
		default:
			return 1;
		}
	}

	private static void FormatIdentifier(StringBuilder buffer, object identifier, IdType identifierType)
	{
		switch (identifierType)
		{
		case IdType.Numeric:
			if (identifier == null)
			{
				buffer.Append('0');
			}
			else
			{
				buffer.AppendFormat(CultureInfo.InvariantCulture, "{0}", identifier);
			}
			break;
		case IdType.String:
			buffer.AppendFormat(CultureInfo.InvariantCulture, "{0}", identifier);
			break;
		case IdType.Guid:
			if (identifier == null)
			{
				buffer.Append(Guid.Empty);
			}
			else
			{
				buffer.AppendFormat(CultureInfo.InvariantCulture, "{0}", identifier);
			}
			break;
		case IdType.Opaque:
			if (identifier != null)
			{
				buffer.AppendFormat(CultureInfo.InvariantCulture, "{0}", Convert.ToBase64String((byte[])identifier));
			}
			break;
		}
	}
}
