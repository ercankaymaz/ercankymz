using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;

namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class ExpandedNodeId : ICloneable, IComparable, IEquatable<ExpandedNodeId>, IFormattable
{
	private const string kHexDigits = "0123456789ABCDEF";

	private static readonly ExpandedNodeId s_Null = new ExpandedNodeId();

	private NodeId m_nodeId;

	private string m_namespaceUri;

	private uint m_serverIndex;

	public virtual ushort NamespaceIndex
	{
		get
		{
			if (m_nodeId != null)
			{
				return m_nodeId.NamespaceIndex;
			}
			return 0;
		}
	}

	public IdType IdType
	{
		get
		{
			if (m_nodeId != null)
			{
				return m_nodeId.IdType;
			}
			return IdType.Numeric;
		}
	}

	public object Identifier
	{
		get
		{
			if (m_nodeId != null)
			{
				return m_nodeId.Identifier;
			}
			return null;
		}
	}

	public string NamespaceUri => m_namespaceUri;

	public uint ServerIndex => m_serverIndex;

	public bool IsNull
	{
		get
		{
			if (!string.IsNullOrEmpty(m_namespaceUri))
			{
				return false;
			}
			if (m_serverIndex != 0)
			{
				return false;
			}
			return NodeId.IsNull(m_nodeId);
		}
	}

	public bool IsAbsolute
	{
		get
		{
			if (!string.IsNullOrEmpty(m_namespaceUri) || m_serverIndex != 0)
			{
				return true;
			}
			return false;
		}
	}

	internal NodeId InnerNodeId
	{
		get
		{
			return m_nodeId;
		}
		set
		{
			m_nodeId = value;
		}
	}

	[DataMember(Name = "Identifier", Order = 1)]
	internal string IdentifierText
	{
		get
		{
			return Format();
		}
		set
		{
			ExpandedNodeId expandedNodeId = Parse(value);
			m_nodeId = expandedNodeId.m_nodeId;
			m_namespaceUri = expandedNodeId.m_namespaceUri;
			m_serverIndex = expandedNodeId.m_serverIndex;
		}
	}

	public static ExpandedNodeId Null => s_Null;

	internal ExpandedNodeId()
	{
		Initialize();
	}

	public ExpandedNodeId(ExpandedNodeId value)
	{
		if (value == null)
		{
			throw new ArgumentNullException("value");
		}
		m_namespaceUri = value.m_namespaceUri;
		if (value.m_nodeId != null)
		{
			m_nodeId = new NodeId(value.m_nodeId);
		}
	}

	public ExpandedNodeId(NodeId nodeId)
	{
		Initialize();
		if (nodeId != null)
		{
			m_nodeId = new NodeId(nodeId);
		}
	}

	public ExpandedNodeId(object identifier, ushort namespaceIndex, string namespaceUri, uint serverIndex)
	{
		m_nodeId = new NodeId(identifier, namespaceIndex);
		m_namespaceUri = namespaceUri;
		m_serverIndex = serverIndex;
	}

	public ExpandedNodeId(NodeId nodeId, string namespaceUri)
	{
		Initialize();
		if (nodeId != null)
		{
			m_nodeId = new NodeId(nodeId);
		}
		if (!string.IsNullOrEmpty(namespaceUri))
		{
			SetNamespaceUri(namespaceUri);
		}
	}

	public ExpandedNodeId(NodeId nodeId, string namespaceUri, uint serverIndex)
	{
		Initialize();
		if (nodeId != null)
		{
			m_nodeId = new NodeId(nodeId);
		}
		if (!string.IsNullOrEmpty(namespaceUri))
		{
			SetNamespaceUri(namespaceUri);
		}
		m_serverIndex = serverIndex;
	}

	public ExpandedNodeId(uint value)
	{
		Initialize();
		m_nodeId = new NodeId(value);
	}

	public ExpandedNodeId(uint value, ushort namespaceIndex)
	{
		Initialize();
		m_nodeId = new NodeId(value, namespaceIndex);
	}

	public ExpandedNodeId(uint value, string namespaceUri)
	{
		Initialize();
		m_nodeId = new NodeId(value);
		SetNamespaceUri(namespaceUri);
	}

	public ExpandedNodeId(string value, ushort namespaceIndex)
	{
		Initialize();
		m_nodeId = new NodeId(value, namespaceIndex);
	}

	public ExpandedNodeId(string value, string namespaceUri)
	{
		Initialize();
		m_nodeId = new NodeId(value, 0);
		SetNamespaceUri(namespaceUri);
	}

	public ExpandedNodeId(Guid value)
	{
		Initialize();
		m_nodeId = new NodeId(value);
	}

	public ExpandedNodeId(Guid value, ushort namespaceIndex)
	{
		Initialize();
		m_nodeId = new NodeId(value, namespaceIndex);
	}

	public ExpandedNodeId(Guid value, string namespaceUri)
	{
		Initialize();
		m_nodeId = new NodeId(value);
		SetNamespaceUri(namespaceUri);
	}

	public ExpandedNodeId(byte[] value)
	{
		Initialize();
		m_nodeId = new NodeId(value);
	}

	public ExpandedNodeId(byte[] value, ushort namespaceIndex)
	{
		Initialize();
		m_nodeId = new NodeId(value, namespaceIndex);
	}

	public ExpandedNodeId(byte[] value, string namespaceUri)
	{
		Initialize();
		m_nodeId = new NodeId(value);
		SetNamespaceUri(namespaceUri);
	}

	public ExpandedNodeId(string text)
	{
		Initialize();
		InternalParse(text);
	}

	private void Initialize()
	{
		m_nodeId = null;
		m_namespaceUri = null;
		m_serverIndex = 0u;
	}

	public string Format()
	{
		StringBuilder stringBuilder = new StringBuilder();
		Format(stringBuilder);
		return stringBuilder.ToString();
	}

	public void Format(StringBuilder buffer)
	{
		if (m_nodeId != null)
		{
			Format(buffer, m_nodeId.Identifier, m_nodeId.IdType, m_nodeId.NamespaceIndex, m_namespaceUri, m_serverIndex);
		}
		else
		{
			Format(buffer, null, IdType.Numeric, 0, m_namespaceUri, m_serverIndex);
		}
	}

	public static void Format(StringBuilder buffer, object identifier, IdType identifierType, ushort namespaceIndex, string namespaceUri, uint serverIndex)
	{
		if (serverIndex != 0)
		{
			buffer.AppendFormat(CultureInfo.InvariantCulture, "svr={0};", serverIndex);
		}
		if (!string.IsNullOrEmpty(namespaceUri))
		{
			buffer.Append("nsu=");
			foreach (char c in namespaceUri)
			{
				if (c == '%' || c == ';')
				{
					buffer.AppendFormat(CultureInfo.InvariantCulture, "%{0:X2}", Convert.ToInt16(c));
				}
				else
				{
					buffer.Append(c);
				}
			}
			buffer.Append(';');
		}
		NodeId.Format(buffer, identifier, identifierType, namespaceIndex);
	}

	public static ExpandedNodeId Parse(string text, NamespaceTable currentNamespaces, NamespaceTable targetNamespaces)
	{
		ExpandedNodeId expandedNodeId = Parse(text);
		string text2 = expandedNodeId.m_namespaceUri;
		if (expandedNodeId.m_nodeId.NamespaceIndex != 0)
		{
			text2 = currentNamespaces.GetString(expandedNodeId.m_nodeId.NamespaceIndex);
		}
		ushort namespaceIndex = 0;
		if (!string.IsNullOrEmpty(text2))
		{
			int index = targetNamespaces.GetIndex(text2);
			if (index == -1)
			{
				throw ServiceResultException.Create(2150825984u, "Cannot map namespace URI onto an index in the target namespace table: {0}", text2);
			}
			namespaceIndex = (ushort)index;
		}
		if (expandedNodeId.ServerIndex != 0)
		{
			expandedNodeId.m_nodeId = new NodeId(expandedNodeId.m_nodeId.Identifier, 0);
			expandedNodeId.m_namespaceUri = text2;
			return expandedNodeId;
		}
		expandedNodeId.m_nodeId = new NodeId(expandedNodeId.m_nodeId.Identifier, namespaceIndex);
		expandedNodeId.m_namespaceUri = null;
		return expandedNodeId;
	}

	public static ExpandedNodeId Parse(string text)
	{
		try
		{
			if (string.IsNullOrEmpty(text))
			{
				return Null;
			}
			return new ExpandedNodeId(text);
		}
		catch (Exception e)
		{
			throw new ServiceResultException(2150825984u, Utils.Format("Cannot parse expanded node id text: '{0}'", text), e);
		}
	}

	internal static void UnescapeUri(string text, int start, int index, StringBuilder buffer)
	{
		for (int i = start; i < index; i++)
		{
			char c = text[i];
			if (c == '%')
			{
				if (i + 2 >= index)
				{
					throw new ServiceResultException(2150825984u, "Invalid escaped character in namespace uri.");
				}
				int num = "0123456789ABCDEF".IndexOf(char.ToUpperInvariant(text[++i]));
				if (num == -1)
				{
					throw new ServiceResultException(2150825984u, "Invalid escaped character in namespace uri.");
				}
				ushort num2 = (ushort)((ushort)(0 + (ushort)num) << 4);
				num = "0123456789ABCDEF".IndexOf(char.ToUpperInvariant(text[++i]));
				if (num == -1)
				{
					throw new ServiceResultException(2150825984u, "Invalid escaped character in namespace uri.");
				}
				char value = Convert.ToChar((ushort)(num2 + (ushort)num));
				buffer.Append(value);
			}
			else
			{
				buffer.Append(c);
			}
		}
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
		if (!IsAbsolute && m_nodeId != null)
		{
			return m_nodeId.CompareTo(obj);
		}
		NodeId nodeId = obj as NodeId;
		ExpandedNodeId expandedNodeId = obj as ExpandedNodeId;
		if (expandedNodeId != null)
		{
			if (IsNull && expandedNodeId.IsNull)
			{
				return 0;
			}
			if (ServerIndex != expandedNodeId.ServerIndex)
			{
				return ServerIndex.CompareTo(expandedNodeId.ServerIndex);
			}
			if (NamespaceUri != expandedNodeId.NamespaceUri)
			{
				if (NamespaceUri != null)
				{
					return string.CompareOrdinal(NamespaceUri, expandedNodeId.NamespaceUri);
				}
				return -1;
			}
			nodeId = expandedNodeId.m_nodeId;
		}
		if (m_nodeId != null)
		{
			return m_nodeId.CompareTo(nodeId);
		}
		if (!(nodeId == null))
		{
			return -1;
		}
		return 0;
	}

	public static bool operator >(ExpandedNodeId value1, object value2)
	{
		if ((object)value1 != null)
		{
			return value1.CompareTo(value2) > 0;
		}
		return false;
	}

	public static bool operator <(ExpandedNodeId value1, object value2)
	{
		if ((object)value1 != null)
		{
			return value1.CompareTo(value2) < 0;
		}
		return true;
	}

	public override bool Equals(object obj)
	{
		return CompareTo(obj) == 0;
	}

	public override int GetHashCode()
	{
		if (m_nodeId == null || m_nodeId.IsNullNodeId)
		{
			return 0;
		}
		if (!IsAbsolute)
		{
			return m_nodeId.GetHashCode();
		}
		HashCode hashCode = default(HashCode);
		if (ServerIndex != 0)
		{
			hashCode.Add(ServerIndex);
		}
		if (NamespaceUri != null)
		{
			hashCode.Add(NamespaceUri);
		}
		hashCode.Add(m_nodeId);
		return hashCode.ToHashCode();
	}

	public static bool operator ==(ExpandedNodeId value1, object value2)
	{
		if ((object)value1 == null)
		{
			return value2 == null;
		}
		return value1.CompareTo(value2) == 0;
	}

	public static bool operator !=(ExpandedNodeId value1, object value2)
	{
		if ((object)value1 == null)
		{
			return value2 != null;
		}
		return value1.CompareTo(value2) != 0;
	}

	public bool Equals(ExpandedNodeId other)
	{
		return CompareTo(other) == 0;
	}

	public string ToString(string format, IFormatProvider formatProvider)
	{
		if (format == null)
		{
			return Format();
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

	public override string ToString()
	{
		return ToString(null, null);
	}

	public static NodeId ToNodeId(ExpandedNodeId nodeId, NamespaceTable namespaceTable)
	{
		if (nodeId == null)
		{
			return null;
		}
		if (string.IsNullOrEmpty(nodeId.m_namespaceUri) && nodeId.m_serverIndex == 0)
		{
			return nodeId.m_nodeId;
		}
		NodeId nodeId2 = new NodeId(nodeId.m_nodeId);
		int num = -1;
		if (namespaceTable != null)
		{
			num = namespaceTable.GetIndex(nodeId.NamespaceUri);
		}
		if (num < 0)
		{
			return null;
		}
		nodeId2.SetNamespaceIndex((ushort)num);
		return nodeId2;
	}

	internal void SetNamespaceIndex(ushort namespaceIndex)
	{
		m_nodeId.SetNamespaceIndex(namespaceIndex);
		m_namespaceUri = null;
	}

	internal void SetNamespaceUri(string uri)
	{
		m_nodeId.SetNamespaceIndex(0);
		m_namespaceUri = uri;
	}

	internal void SetServerIndex(uint serverIndex)
	{
		m_serverIndex = serverIndex;
	}

	public static NodeId Parse(string text, NamespaceTable namespaceUris)
	{
		ExpandedNodeId expandedNodeId = Parse(text);
		if (!expandedNodeId.IsAbsolute)
		{
			return expandedNodeId.InnerNodeId;
		}
		NodeId nodeId = ToNodeId(expandedNodeId, namespaceUris);
		if (nodeId == null)
		{
			throw ServiceResultException.Create(2150825984u, "NamespaceUri ({0}) is not in the namespace table.", expandedNodeId.NamespaceUri);
		}
		return nodeId;
	}

	public static explicit operator NodeId(ExpandedNodeId value)
	{
		if (value == null)
		{
			return null;
		}
		if (value.IsAbsolute)
		{
			throw new InvalidCastException("Cannot cast an absolute ExpandedNodeId to a NodeId. Use ExpandedNodeId.ToNodeId instead.");
		}
		return value.InnerNodeId;
	}

	public static implicit operator ExpandedNodeId(uint value)
	{
		return new ExpandedNodeId(value);
	}

	public static implicit operator ExpandedNodeId(Guid value)
	{
		return new ExpandedNodeId(value);
	}

	public static implicit operator ExpandedNodeId(byte[] value)
	{
		return new ExpandedNodeId(value);
	}

	public static implicit operator ExpandedNodeId(string text)
	{
		return new ExpandedNodeId(text);
	}

	public static implicit operator ExpandedNodeId(NodeId nodeId)
	{
		return new ExpandedNodeId(nodeId);
	}

	private void InternalParse(string text)
	{
		uint num = 0u;
		string text2 = null;
		try
		{
			if (text.StartsWith("svr=", StringComparison.Ordinal))
			{
				int num2 = text.IndexOf(';');
				if (num2 == -1)
				{
					throw new ServiceResultException(2150825984u, "Invalid server index.");
				}
				num = Convert.ToUInt32(text.Substring(4, num2 - 4), CultureInfo.InvariantCulture);
				text = text.Substring(num2 + 1);
			}
			if (text.StartsWith("nsu=", StringComparison.Ordinal))
			{
				int num3 = text.IndexOf(';');
				if (num3 == -1)
				{
					throw new ServiceResultException(2150825984u, "Invalid namespace uri.");
				}
				StringBuilder stringBuilder = new StringBuilder();
				UnescapeUri(text, 4, num3, stringBuilder);
				text2 = stringBuilder.ToString();
				text = text.Substring(num3 + 1);
			}
		}
		catch (Exception e)
		{
			throw new ServiceResultException(2150825984u, Utils.Format("Cannot parse expanded node id text: '{0}'", text), e);
		}
		NodeId nodeId = NodeId.InternalParse(text, num != 0 || !string.IsNullOrEmpty(text2));
		m_nodeId = nodeId;
		m_namespaceUri = text2;
		m_serverIndex = num;
	}
}
