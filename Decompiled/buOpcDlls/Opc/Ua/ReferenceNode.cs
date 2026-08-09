using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class ReferenceNode : IEncodeable, ICloneable, IJsonEncodeable, IReference, IComparable, IFormattable
{
	private NodeId m_referenceTypeId;

	private bool m_isInverse;

	private ExpandedNodeId m_targetId;

	[DataMember(Name = "ReferenceTypeId", IsRequired = false, Order = 1)]
	public NodeId ReferenceTypeId
	{
		get
		{
			return m_referenceTypeId;
		}
		set
		{
			m_referenceTypeId = value;
		}
	}

	[DataMember(Name = "IsInverse", IsRequired = false, Order = 2)]
	public bool IsInverse
	{
		get
		{
			return m_isInverse;
		}
		set
		{
			m_isInverse = value;
		}
	}

	[DataMember(Name = "TargetId", IsRequired = false, Order = 3)]
	public ExpandedNodeId TargetId
	{
		get
		{
			return m_targetId;
		}
		set
		{
			m_targetId = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.ReferenceNode;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.ReferenceNode_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.ReferenceNode_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.ReferenceNode_Encoding_DefaultJson;

	public ReferenceNode()
	{
		Initialize();
	}

	[OnDeserializing]
	private void Initialize(StreamingContext context)
	{
		Initialize();
	}

	private void Initialize()
	{
		m_referenceTypeId = null;
		m_isInverse = true;
		m_targetId = null;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteNodeId("ReferenceTypeId", ReferenceTypeId);
		encoder.WriteBoolean("IsInverse", IsInverse);
		encoder.WriteExpandedNodeId("TargetId", TargetId);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		ReferenceTypeId = decoder.ReadNodeId("ReferenceTypeId");
		IsInverse = decoder.ReadBoolean("IsInverse");
		TargetId = decoder.ReadExpandedNodeId("TargetId");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if ((object)this == encodeable)
		{
			return true;
		}
		ReferenceNode referenceNode = encodeable as ReferenceNode;
		if (referenceNode == null)
		{
			return false;
		}
		if (!Utils.IsEqual(m_referenceTypeId, referenceNode.m_referenceTypeId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_isInverse, referenceNode.m_isInverse))
		{
			return false;
		}
		if (!Utils.IsEqual(m_targetId, referenceNode.m_targetId))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (ReferenceNode)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ReferenceNode obj = (ReferenceNode)base.MemberwiseClone();
		obj.m_referenceTypeId = (NodeId)Utils.Clone(m_referenceTypeId);
		obj.m_isInverse = (bool)Utils.Clone(m_isInverse);
		obj.m_targetId = (ExpandedNodeId)Utils.Clone(m_targetId);
		return obj;
	}

	public ReferenceNode(NodeId referenceTypeId, bool isInverse, ExpandedNodeId targetId)
	{
		m_referenceTypeId = referenceTypeId;
		m_isInverse = isInverse;
		m_targetId = targetId;
	}

	public override string ToString()
	{
		return ToString(null, null);
	}

	public string ToString(string format, IFormatProvider formatProvider)
	{
		if (format != null)
		{
			throw new FormatException(Utils.Format("Invalid format string: '{0}'.", format));
		}
		string text = null;
		if (m_referenceTypeId != null && m_referenceTypeId.IdType == IdType.Numeric && m_referenceTypeId.NamespaceIndex == 0)
		{
			text = ReferenceTypes.GetBrowseName((uint)m_referenceTypeId.Identifier);
		}
		if (text == null)
		{
			text = Utils.Format("{0}", m_referenceTypeId);
		}
		if (m_isInverse)
		{
			return Utils.Format("<!{0}>{1}", text, m_targetId);
		}
		return Utils.Format("<{0}>{1}", text, m_targetId);
	}

	public override bool Equals(object obj)
	{
		return CompareTo(obj) == 0;
	}

	public override int GetHashCode()
	{
		HashCode hashCode = default(HashCode);
		hashCode.Add(m_referenceTypeId);
		hashCode.Add(m_isInverse);
		hashCode.Add(m_targetId);
		return hashCode.ToHashCode();
	}

	public static bool operator ==(ReferenceNode a, object b)
	{
		if ((object)a == null)
		{
			return b == null;
		}
		return a.CompareTo(b) == 0;
	}

	public static bool operator !=(ReferenceNode a, object b)
	{
		if ((object)a == null)
		{
			return b != null;
		}
		return a.CompareTo(b) != 0;
	}

	public int CompareTo(object obj)
	{
		if (obj == null)
		{
			return 1;
		}
		if (obj == this)
		{
			return 0;
		}
		ReferenceNode referenceNode = obj as ReferenceNode;
		if (referenceNode == null)
		{
			return -1;
		}
		if ((object)m_referenceTypeId == null)
		{
			if ((object)referenceNode.m_referenceTypeId != null)
			{
				return -1;
			}
			return 0;
		}
		int num = m_referenceTypeId.CompareTo(referenceNode.m_referenceTypeId);
		if (num != 0)
		{
			return num;
		}
		if (referenceNode.m_isInverse != m_isInverse)
		{
			if (!m_isInverse)
			{
				return -1;
			}
			return 1;
		}
		if ((object)m_targetId == null)
		{
			if ((object)referenceNode.m_targetId != null)
			{
				return -1;
			}
			return 0;
		}
		return m_targetId.CompareTo(referenceNode.m_targetId);
	}
}
